using System;
using System.Collections.Generic;
using System.Linq;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Objects.Types;
using CatraProto.TL.Generator.Objects.Types.Interfaces;
using CatraProto.TL.Generator.Objects.Types.InternalTypes;
using Object = CatraProto.TL.Generator.Objects.Interfaces.Object;

namespace CatraProto.TL.Generator.CodeGeneration.Optimization
{
    class Optimizer
    {
        private bool _areObjectsBind;
        private bool _areParametersBind;
        private bool _areParametersCommonized;
        private List<Object> _objects;

        public Optimizer(IEnumerable<Object> objects)
        {
            _objects = objects.ToList();
        }

        public List<Object> Objects
        {
            get => _objects.ToList();
        }

        public static List<Object> Optimize(IEnumerable<Object> objects)
        {
            var optimizer = new Optimizer(objects);
            optimizer.BindObjects();
            optimizer.BindParameters();
            optimizer.FindCommonParameters();
            optimizer.FixNamesCollision();
            optimizer.GenAutoResolvingMethods();
            return optimizer.Objects;
        }

        public void BindObjects()
        {
            var newObjectList = new List<Object>(_objects);
            while (newObjectList.Count != 0)
            {
                var obj = newObjectList[0];
                var parsedObjectList = new List<Object>();
                foreach (var passTwo in newObjectList)
                {
                    if (passTwo.Type == obj.Type && passTwo != obj)
                    {
                        obj.Type.ReferencedObjects.Add(passTwo);
                        passTwo.Type = obj.Type;
                        parsedObjectList.Add(passTwo);
                    }
                }

                obj.Type.ReferencedObjects.Add(obj);
                foreach (var parsedObject in parsedObjectList)
                {
                    newObjectList.Remove(parsedObject);
                }

                newObjectList.Remove(obj);
            }

            _areObjectsBind = true;
        }

        public void GenAutoResolvingMethods()
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            foreach (Method method in _objects.Where(x => x is Method).Cast<Method>().ToList())
            {
                var matched = false;
                var optimizedMethod = new Method(method.MethodCompletionType);
                foreach (var methodParameter in method.Parameters)
                {
                    switch (methodParameter.Type.NamingInfo.OriginalName)
                    {
                        case "InputUser":
                        case "InputChannel":
                        {
                            matched = true;
                            var autoCompletingMethod = new InputChannelOrUserAuto(methodParameter.Type.NamingInfo.OriginalName);
                            var parameter = methodParameter.CreateCopy();
                            parameter.Type = autoCompletingMethod;
                            optimizedMethod.Parameters.Add(parameter);
                            break;
                        }
                        case "InputPeer":
                        {
                            matched = true;
                            var autoCompletingMethod = new InputPeerBaseAuto();
                            var parameter = methodParameter.CreateCopy();
                            parameter.Type = autoCompletingMethod;
                            optimizedMethod.Parameters.Add(parameter);
                            break;
                        }
                        case "long" when methodParameter.NamingInfo.OriginalName == "random_id" && !methodParameter.HasFlag:
                        {
                            matched = true;
                            RandomId autoCompletingMethod;
                            if (methodParameter.VectorInfo.IsVector)
                            {
                                var bindTo = method.NamingInfo.OriginalName switch
                                {
                                    "forwardMessages" => "id",
                                    _ => throw new Exception("Random vector long must be bound, constructor: " + method.Id)
                                };
                                autoCompletingMethod = new RandomId(bindTo);
                            }
                            else
                            {
                                autoCompletingMethod = new RandomId();
                            }

                            var parameter = methodParameter.CreateCopy();
                            parameter.Flag = new Flag("internalFakeFlag", 0);
                            parameter.Type = autoCompletingMethod;
                            optimizedMethod.Parameters.Add(parameter);
                            break;
                        }
                        default:
                            optimizedMethod.Parameters.Add(methodParameter);
                            break;
                    }
                }

                if (matched)
                {
                    optimizedMethod.NamingInfo = method.NamingInfo.OriginalName;
                    optimizedMethod.NamingInfo.OriginalNamespacedName = method.NamingInfo.OriginalNamespacedName;
                    optimizedMethod.Type = method.Type;
                    optimizedMethod.ReturnsVector = method.ReturnsVector;
                    optimizedMethod.Id = method.Id;
                    optimizedMethod.Namespace = method.Namespace;
                    optimizedMethod.IsOptimized = true;
                    _objects.Add(optimizedMethod);
                }
            }
        }

        public void BindParameters()
        {
            if (!_areObjectsBind)
            {
                BindObjects();
            }

            foreach (var obj in _objects)
            {
                foreach (var parameter in obj.Parameters)
                {
                    if (parameter.Type.TypeInfo.IsBare || parameter.Type.TypeInfo.IsNaked)
                    {
                        continue;
                    }

                    //It won't pick different objects because they all have already been bound to one unique type
                    TypeBase type = null;
                    foreach (var f in _objects)
                    {
                        if (f.Type == parameter.Type)
                        {
                            type = f.Type;
                            break;
                        }
                    }

                    if (type is null)
                    {
                        throw new Exception("The type " + parameter.Type.NamingInfo.OriginalName + " inside object" + obj.NamingInfo.OriginalName + " has not been found anywhere.");
                    }

                    type.ReferencedParameters.Add(parameter);
                    parameter.Type = type;
                }
            }

            _areParametersBind = true;
        }

        public void FindCommonParameters()
        {
            if (!_areParametersBind)
            {
                BindParameters();
            }

            foreach (var currentObject in _objects.Where(x => x is not Method))
            {
                foreach (var currentObjectParameter in currentObject.Parameters)
                {
                    //We don't want to commonize flags since it may cause confusion
                    if (currentObjectParameter.Type is FlagType)
                    {
                        continue;
                    }

                    //Searches for every object which is as same type as the currentObject and is not a method
                    var sameTypeAsObject = currentObject.Type.ReferencedObjects.Where(x => x is not Method).ToList();

                    //Searches inside the found objects for a parameter that equals the current one.
                    var sameParameterObjects = sameTypeAsObject.Where(x => x.Parameters.Contains(currentObjectParameter)).ToList();

                    //Compares the number of found parameters with the number of object of the same type.
                    //If the count is the same, it means that the parameter is common.
                    if (sameParameterObjects.Count == sameTypeAsObject.Count)
                    {
                        //We can now set the current parameter as common, and proceed to replace the other parameters with this one.
                        currentObjectParameter.IsCommon = true;
                        sameParameterObjects.ForEach(obj =>
                        {
                            //Avoid InvalidOperationException by not modifying the item that is currently being enumerated
                            if (obj == currentObject)
                            {
                                return;
                            }

                            var parameterIndex = obj.Parameters.FindIndex(x => x == currentObjectParameter);
                            obj.Parameters[parameterIndex] = currentObjectParameter;
                        });
                    }
                }
            }

            _areParametersCommonized = true;
        }

        public void FixNamesCollision()
        {
            if (!_areParametersCommonized)
            {
                FindCommonParameters();
            }

            foreach (var obj in _objects)
            {
                var findConflictingNamespace = _objects.Find(x => x.Namespace.PartialNamespace != null && x.Namespace.PartialNamespace == obj.Namespace.FullNamespace);
                if (findConflictingNamespace is not null || obj.Namespace.PartialNamespaceArray[^1] == obj.Namespace.Class)
                {
                    obj.NamingInfo.PascalCaseName = "Api" + obj.NamingInfo.PascalCaseName;
                    obj.NamingInfo.CamelCaseName = "api" + obj.NamingInfo.PascalCaseName;
                    obj.Namespace.Class = obj.NamingInfo.PascalCaseName;
                }

                foreach (var objParameter in obj.Parameters)
                {
                    if (objParameter.NamingInfo.PascalCaseName == obj.NamingInfo.PascalCaseName)
                    {
                        objParameter.NamingInfo.PascalCaseName = objParameter.NamingInfo.PascalCaseName += "Field";
                        objParameter.NamingInfo.CamelCaseName = objParameter.NamingInfo.CamelCaseName += "Field";
                    }
                }
            }
        }
    }
}