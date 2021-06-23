﻿using System;
using System.Collections.Generic;
using System.Linq;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Objects.Types;
using CatraProto.TL.Generator.Objects.Types.Interfaces;
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
			return optimizer.Objects;
		}

		/// <summary>
		///     Binds each object to one unique type and adds them to the type's "ReferencedObjects" List
		/// </summary>
		/// <returns>
		///     Void. The types are updated inside the class' field instead of being recreated.
		/// </returns>
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

		/// <summary>
		/// </summary>
		/// <remarks>
		///     Calling this method will result in calling <see cref="BindObjects" /> if types aren't already bound to their
		///     objects.
		/// </remarks>
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
					if (parameter.Type.IsBare || parameter.Type.IsNaked)
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
						throw new Exception("The type " + parameter.Type.Name + " inside object" + obj.Name + " has not been found anywhere.");
					}

					type.ReferencedParameters.Add(parameter);
					parameter.Type = type;
				}
			}

			_areParametersBind = true;
		}

		/// <summary>
		///     Calling this method will result in calling <see cref="BindParameters" /> if types aren't already bound to their
		///     types.
		/// </summary>
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
					var sameTypeAsObject = currentObject.Type.ReferencedObjects
						.Where(x => x is not Method)
						.ToList();

					//Searches inside the found objects for a parameter that equals the current one.
					var sameParameterObjects = sameTypeAsObject
						.Where(x => x.Parameters.Contains(currentObjectParameter))
						.ToList();

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
				var findConflictingNamespace = _objects.Find(x =>
					x.Namespace.PartialNamespace != null && x.Namespace.PartialNamespace == obj.Namespace.FullNamespace);
				if (findConflictingNamespace is not null || obj.Namespace.PartialNamespaceArray[^1] == obj.Namespace.Class)
				{
					obj.Name = obj.Name[0] + obj.Name;
				}

				foreach (var objParameter in obj.Parameters)
				{
					if (objParameter.Name == obj.Name)
					{
						objParameter.Name += "_";
					}
				}
			}
		}
	}
}