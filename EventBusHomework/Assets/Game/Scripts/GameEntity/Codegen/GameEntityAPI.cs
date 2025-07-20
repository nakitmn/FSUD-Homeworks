/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;

namespace SampleGame
{
	public static class GameEntityAPI
	{
		///Tags
		public const int Pushable = -1762021740;


		///Values
		public const int Transform = -180157682; // Transform
		public const int Health = -915003867; // int
		public const int Damage = 375673178; // int


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPushableTag(this IGameEntity obj) => obj.HasTag(Pushable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPushableTag(this IGameEntity obj) => obj.AddTag(Pushable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPushableTag(this IGameEntity obj) => obj.DelTag(Pushable);


		///Value Extensions

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
    }
}
