/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;

namespace SampleGame
{
	public static class GameContextAPI
	{
		///Tags
		public const int Player = -1615495341;
		public const int Enemy = 979269037;
		public const int Resource = 1172805184;


		///Values
		public const int Health = -915003867; // int
		public const int Speed = -823668238; // float
		public const int Transform = -180157682; // Transform


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerTag(this IGameContext obj) => obj.HasTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerTag(this IGameContext obj) => obj.AddTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerTag(this IGameContext obj) => obj.DelTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEnemyTag(this IGameContext obj) => obj.HasTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddEnemyTag(this IGameContext obj) => obj.AddTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEnemyTag(this IGameContext obj) => obj.DelTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasResourceTag(this IGameContext obj) => obj.HasTag(Resource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddResourceTag(this IGameContext obj) => obj.AddTag(Resource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelResourceTag(this IGameContext obj) => obj.DelTag(Resource);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetHealth(this IGameContext obj) => obj.GetValueUnsafe<int>(Health);

		public static ref int RefHealth(this IGameContext obj) => ref obj.GetValueUnsafe<int>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameContext obj, out int value) => obj.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IGameContext obj, int value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameContext obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameContext obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameContext obj, int value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetSpeed(this IGameContext obj) => obj.GetValueUnsafe<float>(Speed);

		public static ref float RefSpeed(this IGameContext obj) => ref obj.GetValueUnsafe<float>(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpeed(this IGameContext obj, out float value) => obj.TryGetValueUnsafe(Speed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSpeed(this IGameContext obj, float value) => obj.AddValue(Speed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpeed(this IGameContext obj) => obj.HasValue(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpeed(this IGameContext obj) => obj.DelValue(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpeed(this IGameContext obj, float value) => obj.SetValue(Speed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IGameContext obj) => obj.GetValueUnsafe<Transform>(Transform);

		public static ref Transform RefTransform(this IGameContext obj) => ref obj.GetValueUnsafe<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IGameContext obj, out Transform value) => obj.TryGetValueUnsafe(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTransform(this IGameContext obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IGameContext obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IGameContext obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IGameContext obj, Transform value) => obj.SetValue(Transform, value);
    }
}
