using System.Threading.Tasks;
using CatraProto.TL.Generator.CodeGeneration.Optimization;
using CatraProto.TL.Generator.CodeGeneration.Parsing;
using CatraProto.TL.Generator.Objects.Interfaces;
using CatraProto.TL.Generator.Objects.Types.Interfaces;
using Xunit;

namespace CatraProto.TL.Generator.UnitTests.OptimizerTests
{
	public class TypeBindingTest
	{
		private void AreAllReferenced(TypeBase mainType, params Object[] objects)
		{
			foreach (var obj in objects)
			{
				Assert.Contains(mainType.ReferencedObjects, x => x == obj);
			}
		}

		[Fact]
		public async Task ObjectBindingTest()
		{
			string[] schema =
			{
				"message#1 flags:# message:string mammt:int = int;",
				"message_gay#2 flags:# message:string mammt:int = int;",
				"Peer#3 flags:# message:string mammt:int = Peer;",
				"EmptyPeer#4 flags:# message:string mammt:int = Peer;",
				"---functions---",
				"MethodPeer#5 flags:# message:string mammt:int = Peer;"
			};

			//Parser into objects every TL Constructor (and function), in the same order as they were written.
			var parser = await Parser.StartAnalyzing(schema);
			var optimizer = new Optimizer(parser);

			//Binds each object to one unique type and adds them to the Type's "ReferencedObjects" List 
			optimizer.BindObjects();
			var objs = optimizer.Objects;

			var firstIntType = parser[0].Type.GetHashCode(); //message#1
			var firstBoundIntType = objs[0].Type.GetHashCode(); ////message#1, bound
			var secondBoundIntType = objs[1].Type.GetHashCode(); // message_gay#2, bound

			//Checks if the type used in the bound objects is the same as the type created with the first object 
			Assert.Equal(firstIntType, firstBoundIntType);
			Assert.Equal(firstBoundIntType, secondBoundIntType);
			AreAllReferenced(parser[0].Type, objs[0], objs[1]);

			var firstPeerType = parser[2].Type.GetHashCode(); //Peer#3
			var firstBoundPeerType = objs[2].Type.GetHashCode(); ////Peer#3, bound
			var secondBoundPeerType = objs[3].Type.GetHashCode(); // EmptyPeer#4, bound
			var thirdBoundPeerType = objs[4].Type.GetHashCode(); // MethodPeer#5, bound

			//Checks if the type used in the bound objects is the same as the type created with the first object 
			Assert.Equal(firstPeerType, firstBoundPeerType);
			Assert.Equal(firstPeerType, secondBoundPeerType);
			Assert.Equal(firstPeerType, thirdBoundPeerType);
			AreAllReferenced(parser[2].Type, objs[2], objs[3], objs[4]);
		}
	}
}