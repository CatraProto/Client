using System;

namespace CatraProto.TL.Interfaces
{
	public interface IObjectProvider
	{
		public Type BoolTrue { get; init; }
		public Type BoolFalse { get; init; }
		public int VectorId { get; init; }

		/// <summary>
		///     Provides an instance of the class assigned to its constructorId
		/// </summary>
		/// <param name="constructorId"></param>
		/// <returns>
		///     Returns null if the constructorId is not assigned to any class otherwise, an instance of the class.
		/// </returns>
		public IObject ResolveConstructorId(int constructorId);
	}
}