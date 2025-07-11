/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Elements;
using System.Collections.Generic;

namespace SampleGame
{
	public static class GameContextAPI
	{


		///Values
		public const int WorldTransform = -486031409; // Transform
		public const int EntityPool = 1931115573; // GenericSceneEntityPool
		public const int PrefabPool = -98831589; // GenericPrefabPool
		public const int GroundPlane = -1885423927; // Plane
		public const int Character = 294335127; // IGameEntity
		public const int PlayClickAction = -954041664; // IAction<Vector3>
		public const int CameraOffset = -1286660539; // IValue<Vector3>
		public const int Camera = 1018227507; // Camera
		public const int InputMap = 43340267; // InputMap


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetWorldTransform(this IGameContext obj) => obj.GetValueUnsafe<Transform>(WorldTransform);

		public static ref Transform RefWorldTransform(this IGameContext obj) => ref obj.GetValueUnsafe<Transform>(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWorldTransform(this IGameContext obj, out Transform value) => obj.TryGetValueUnsafe(WorldTransform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWorldTransform(this IGameContext obj, Transform value) => obj.AddValue(WorldTransform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWorldTransform(this IGameContext obj) => obj.HasValue(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWorldTransform(this IGameContext obj) => obj.DelValue(WorldTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWorldTransform(this IGameContext obj, Transform value) => obj.SetValue(WorldTransform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GenericSceneEntityPool GetEntityPool(this IGameContext obj) => obj.GetValueUnsafe<GenericSceneEntityPool>(EntityPool);

		public static ref GenericSceneEntityPool RefEntityPool(this IGameContext obj) => ref obj.GetValueUnsafe<GenericSceneEntityPool>(EntityPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEntityPool(this IGameContext obj, out GenericSceneEntityPool value) => obj.TryGetValueUnsafe(EntityPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEntityPool(this IGameContext obj, GenericSceneEntityPool value) => obj.AddValue(EntityPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEntityPool(this IGameContext obj) => obj.HasValue(EntityPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEntityPool(this IGameContext obj) => obj.DelValue(EntityPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEntityPool(this IGameContext obj, GenericSceneEntityPool value) => obj.SetValue(EntityPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GenericPrefabPool GetPrefabPool(this IGameContext obj) => obj.GetValueUnsafe<GenericPrefabPool>(PrefabPool);

		public static ref GenericPrefabPool RefPrefabPool(this IGameContext obj) => ref obj.GetValueUnsafe<GenericPrefabPool>(PrefabPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPrefabPool(this IGameContext obj, out GenericPrefabPool value) => obj.TryGetValueUnsafe(PrefabPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPrefabPool(this IGameContext obj, GenericPrefabPool value) => obj.AddValue(PrefabPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPrefabPool(this IGameContext obj) => obj.HasValue(PrefabPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPrefabPool(this IGameContext obj) => obj.DelValue(PrefabPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPrefabPool(this IGameContext obj, GenericPrefabPool value) => obj.SetValue(PrefabPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Plane GetGroundPlane(this IGameContext obj) => obj.GetValueUnsafe<Plane>(GroundPlane);

		public static ref Plane RefGroundPlane(this IGameContext obj) => ref obj.GetValueUnsafe<Plane>(GroundPlane);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGroundPlane(this IGameContext obj, out Plane value) => obj.TryGetValueUnsafe(GroundPlane, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGroundPlane(this IGameContext obj, Plane value) => obj.AddValue(GroundPlane, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGroundPlane(this IGameContext obj) => obj.HasValue(GroundPlane);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGroundPlane(this IGameContext obj) => obj.DelValue(GroundPlane);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGroundPlane(this IGameContext obj, Plane value) => obj.SetValue(GroundPlane, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IGameEntity GetCharacter(this IGameContext obj) => obj.GetValueUnsafe<IGameEntity>(Character);

		public static ref IGameEntity RefCharacter(this IGameContext obj) => ref obj.GetValueUnsafe<IGameEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IGameContext obj, out IGameEntity value) => obj.TryGetValueUnsafe(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharacter(this IGameContext obj, IGameEntity value) => obj.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IGameContext obj) => obj.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IGameContext obj) => obj.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IGameContext obj, IGameEntity value) => obj.SetValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3> GetPlayClickAction(this IGameContext obj) => obj.GetValueUnsafe<IAction<Vector3>>(PlayClickAction);

		public static ref IAction<Vector3> RefPlayClickAction(this IGameContext obj) => ref obj.GetValueUnsafe<IAction<Vector3>>(PlayClickAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayClickAction(this IGameContext obj, out IAction<Vector3> value) => obj.TryGetValueUnsafe(PlayClickAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPlayClickAction(this IGameContext obj, IAction<Vector3> value) => obj.AddValue(PlayClickAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayClickAction(this IGameContext obj) => obj.HasValue(PlayClickAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayClickAction(this IGameContext obj) => obj.DelValue(PlayClickAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayClickAction(this IGameContext obj, IAction<Vector3> value) => obj.SetValue(PlayClickAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<Vector3> GetCameraOffset(this IGameContext obj) => obj.GetValueUnsafe<IValue<Vector3>>(CameraOffset);

		public static ref IValue<Vector3> RefCameraOffset(this IGameContext obj) => ref obj.GetValueUnsafe<IValue<Vector3>>(CameraOffset);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCameraOffset(this IGameContext obj, out IValue<Vector3> value) => obj.TryGetValueUnsafe(CameraOffset, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCameraOffset(this IGameContext obj, IValue<Vector3> value) => obj.AddValue(CameraOffset, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCameraOffset(this IGameContext obj) => obj.HasValue(CameraOffset);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCameraOffset(this IGameContext obj) => obj.DelValue(CameraOffset);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCameraOffset(this IGameContext obj, IValue<Vector3> value) => obj.SetValue(CameraOffset, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Camera GetCamera(this IGameContext obj) => obj.GetValueUnsafe<Camera>(Camera);

		public static ref Camera RefCamera(this IGameContext obj) => ref obj.GetValueUnsafe<Camera>(Camera);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCamera(this IGameContext obj, out Camera value) => obj.TryGetValueUnsafe(Camera, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCamera(this IGameContext obj, Camera value) => obj.AddValue(Camera, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCamera(this IGameContext obj) => obj.HasValue(Camera);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCamera(this IGameContext obj) => obj.DelValue(Camera);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCamera(this IGameContext obj, Camera value) => obj.SetValue(Camera, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static InputMap GetInputMap(this IGameContext obj) => obj.GetValueUnsafe<InputMap>(InputMap);

		public static ref InputMap RefInputMap(this IGameContext obj) => ref obj.GetValueUnsafe<InputMap>(InputMap);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInputMap(this IGameContext obj, out InputMap value) => obj.TryGetValueUnsafe(InputMap, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInputMap(this IGameContext obj, InputMap value) => obj.AddValue(InputMap, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInputMap(this IGameContext obj) => obj.HasValue(InputMap);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInputMap(this IGameContext obj) => obj.DelValue(InputMap);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInputMap(this IGameContext obj, InputMap value) => obj.SetValue(InputMap, value);
    }
}
