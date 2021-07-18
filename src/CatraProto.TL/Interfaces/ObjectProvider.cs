using System;

namespace CatraProto.TL.Interfaces
{
	public abstract class ObjectProvider
	{
		public abstract Type BoolTrue { get; init; }
		public abstract Type BoolFalse { get; init; }
		public abstract int VectorId { get; init; }

		/// <summary>
		///     Provides an instance of the class assigned to its constructorId
		/// </summary>
		/// <param name="constructorId"></param>
		/// <returns>
		///     Returns null if the constructorId is not assigned to any class otherwise, an instance of the class.
		/// </returns>
		public abstract IObject ResolveConstructorId(int constructorId);

		protected virtual bool InternalResolveConstructorId(int constructorId, out IObject obj)
		{
			obj = null;
			return false;
		}
	}
}