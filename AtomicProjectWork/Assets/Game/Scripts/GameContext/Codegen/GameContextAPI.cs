/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Contexts;
using Atomic.Entities;
using Atomic.Elements;
using System.Collections.Generic;

namespace SampleGame
{
	public static class GameContextAPI
	{


		///Values
		public const int BulletPool = 1915726678; // IEntityPool
		public const int WorldTransform = -486031409; // Transform
		public const int EntityPool = 1931115573; // GenericSceneEntityPool
		public const int PrefabPool = -98831589; // GenericPrefabPool
		public const int GroundPlane = -1885423927; // Plane
		public const int Character = 294335127; // IEntity
		public const int CameraOffset = -1286660539; // IValue<Vector3>
		public const int Camera = 1018227507; // Camera
		public const int InputMap = 43340267; // InputMap
		public const int AbilitiesPresenter = 274819485; // PlayerAbilitiesPresenter


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntityPool GetBulletPool(this IGameContext obj) => obj.GetValueUnsafe<IEntityPool>(BulletPool);

		public static ref IEntityPool RefBulletPool(this IGameContext obj) => ref obj.GetValueUnsafe<IEntityPool>(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPool(this IGameContext obj, out IEntityPool value) => obj.TryGetValueUnsafe(BulletPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBulletPool(this IGameContext obj, IEntityPool value) => obj.AddValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPool(this IGameContext obj) => obj.HasValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPool(this IGameContext obj) => obj.DelValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPool(this IGameContext obj, IEntityPool value) => obj.SetValue(BulletPool, value);

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
		public static IEntity GetCharacter(this IGameContext obj) => obj.GetValueUnsafe<IEntity>(Character);

		public static ref IEntity RefCharacter(this IGameContext obj) => ref obj.GetValueUnsafe<IEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IGameContext obj, out IEntity value) => obj.TryGetValueUnsafe(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharacter(this IGameContext obj, IEntity value) => obj.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IGameContext obj) => obj.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IGameContext obj) => obj.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IGameContext obj, IEntity value) => obj.SetValue(Character, value);

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PlayerAbilitiesPresenter GetAbilitiesPresenter(this IGameContext obj) => obj.GetValueUnsafe<PlayerAbilitiesPresenter>(AbilitiesPresenter);

		public static ref PlayerAbilitiesPresenter RefAbilitiesPresenter(this IGameContext obj) => ref obj.GetValueUnsafe<PlayerAbilitiesPresenter>(AbilitiesPresenter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAbilitiesPresenter(this IGameContext obj, out PlayerAbilitiesPresenter value) => obj.TryGetValueUnsafe(AbilitiesPresenter, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAbilitiesPresenter(this IGameContext obj, PlayerAbilitiesPresenter value) => obj.AddValue(AbilitiesPresenter, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAbilitiesPresenter(this IGameContext obj) => obj.HasValue(AbilitiesPresenter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAbilitiesPresenter(this IGameContext obj) => obj.DelValue(AbilitiesPresenter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAbilitiesPresenter(this IGameContext obj, PlayerAbilitiesPresenter value) => obj.SetValue(AbilitiesPresenter, value);
    }
}
