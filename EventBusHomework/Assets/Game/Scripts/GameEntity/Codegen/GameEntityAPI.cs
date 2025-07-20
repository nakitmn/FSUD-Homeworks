/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;

namespace SampleGame
{
	public static class GameEntityAPI
	{
		///Tags
		public const int Character = 294335127;
		public const int Cell = 1807034588;
		public const int Pushable = -1762021740;


		///Values
		public const int GameObject = 1482111001; // GameObject
		public const int Transform = -180157682; // Transform
		public const int Health = -915003867; // int
		public const int Damage = 375673178; // int
		public const int AttackRange = 2128890732; // IValue<int>
		public const int X = -1213057461; // IReactiveVariable<int>
		public const int Y = -1061878051; // IReactiveVariable<int>
		public const int Material = -2050484285; // IReactiveVariable<Material>
		public const int MoveRange = -2080720063; // IValue<int>


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IGameEntity obj) => obj.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IGameEntity obj) => obj.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IGameEntity obj) => obj.DelTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCellTag(this IGameEntity obj) => obj.HasTag(Cell);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCellTag(this IGameEntity obj) => obj.AddTag(Cell);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCellTag(this IGameEntity obj) => obj.DelTag(Cell);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPushableTag(this IGameEntity obj) => obj.HasTag(Pushable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPushableTag(this IGameEntity obj) => obj.AddTag(Pushable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPushableTag(this IGameEntity obj) => obj.DelTag(Pushable);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject GetGameObject(this IGameEntity obj) => obj.GetValueUnsafe<GameObject>(GameObject);

		public static ref GameObject RefGameObject(this IGameEntity obj) => ref obj.GetValueUnsafe<GameObject>(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameObject(this IGameEntity obj, out GameObject value) => obj.TryGetValueUnsafe(GameObject, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameObject(this IGameEntity obj, GameObject value) => obj.AddValue(GameObject, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameObject(this IGameEntity obj) => obj.HasValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameObject(this IGameEntity obj) => obj.DelValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameObject(this IGameEntity obj, GameObject value) => obj.SetValue(GameObject, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IGameEntity obj) => obj.GetValueUnsafe<Transform>(Transform);

		public static ref Transform RefTransform(this IGameEntity obj) => ref obj.GetValueUnsafe<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IGameEntity obj, out Transform value) => obj.TryGetValueUnsafe(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTransform(this IGameEntity obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IGameEntity obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IGameEntity obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IGameEntity obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetHealth(this IGameEntity obj) => obj.GetValueUnsafe<int>(Health);

		public static ref int RefHealth(this IGameEntity obj) => ref obj.GetValueUnsafe<int>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameEntity obj, out int value) => obj.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IGameEntity obj, int value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameEntity obj, int value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDamage(this IGameEntity obj) => obj.GetValueUnsafe<int>(Damage);

		public static ref int RefDamage(this IGameEntity obj) => ref obj.GetValueUnsafe<int>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IGameEntity obj, out int value) => obj.TryGetValueUnsafe(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IGameEntity obj, int value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IGameEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IGameEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IGameEntity obj, int value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetAttackRange(this IGameEntity obj) => obj.GetValueUnsafe<IValue<int>>(AttackRange);

		public static ref IValue<int> RefAttackRange(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackRange(this IGameEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(AttackRange, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackRange(this IGameEntity obj, IValue<int> value) => obj.AddValue(AttackRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackRange(this IGameEntity obj) => obj.HasValue(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackRange(this IGameEntity obj) => obj.DelValue(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackRange(this IGameEntity obj, IValue<int> value) => obj.SetValue(AttackRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetX(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(X);

		public static ref IReactiveVariable<int> RefX(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(X);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetX(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(X, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddX(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(X, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasX(this IGameEntity obj) => obj.HasValue(X);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelX(this IGameEntity obj) => obj.DelValue(X);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetX(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(X, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetY(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(Y);

		public static ref IReactiveVariable<int> RefY(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetY(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(Y, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddY(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(Y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasY(this IGameEntity obj) => obj.HasValue(Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelY(this IGameEntity obj) => obj.DelValue(Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetY(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(Y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Material> GetMaterial(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Material>>(Material);

		public static ref IReactiveVariable<Material> RefMaterial(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Material>>(Material);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaterial(this IGameEntity obj, out IReactiveVariable<Material> value) => obj.TryGetValueUnsafe(Material, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.AddValue(Material, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaterial(this IGameEntity obj) => obj.HasValue(Material);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaterial(this IGameEntity obj) => obj.DelValue(Material);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.SetValue(Material, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMoveRange(this IGameEntity obj) => obj.GetValueUnsafe<IValue<int>>(MoveRange);

		public static ref IValue<int> RefMoveRange(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(MoveRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRange(this IGameEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(MoveRange, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRange(this IGameEntity obj, IValue<int> value) => obj.AddValue(MoveRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRange(this IGameEntity obj) => obj.HasValue(MoveRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRange(this IGameEntity obj) => obj.DelValue(MoveRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRange(this IGameEntity obj, IValue<int> value) => obj.SetValue(MoveRange, value);
    }
}
