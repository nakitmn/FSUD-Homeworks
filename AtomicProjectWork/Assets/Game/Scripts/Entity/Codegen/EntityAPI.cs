/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Elements;
using UnityEngine.AI;

namespace SampleGame
{
	public static class EntityAPI
	{
		///Tags
		public const int Damageable = 563499515;
		public const int Moveable = 448011500;
		public const int Interactible = -2055148603;
		public const int Lootable = -1354239725;


		///Values
		public const int GameObject = 1482111001; // GameObject
		public const int Transform = -180157682; // Transform
		public const int Rigidbody = -2101481708; // Rigidbody
		public const int NavAgent = -1998069057; // NavMeshAgent
		public const int Animator = -1714818978; // Animator
		public const int MoveSpeed = 526065662; // IReactiveVariable<float>
		public const int NormalizedCurrentSpeed = 1307496334; // IValue<float>
		public const int MoveCondition = 1466174948; // IExpression<bool>
		public const int IsMoving = 120489994; // IValue<bool>
		public const int MoveDirection = -721923052; // IReactiveVariable<Vector3>
		public const int MovePointAction = 368661144; // IAction<Vector3>
		public const int TeleportAction = -2106011968; // IAction<Vector3>
		public const int ForwardDirection = -597461024; // IReactiveVariable<float>
		public const int AngularSpeed = -1089183267; // IValue<float>
		public const int AngularDirection = -1725439556; // IReactiveVariable<Vector3>
		public const int TurnDirection = 1232893390; // IReactiveVariable<float>
		public const int MaxHealth = 1923500305; // IReactiveVariable<int>
		public const int Health = -915003867; // IReactiveVariable<int>
		public const int Lifetime = -997109026; // Cooldown
		public const int DestroyAction = 85938956; // IAction
		public const int DamagedEvent = 442715181; // IEvent
		public const int DeathEvent = -1096613677; // IEvent
		public const int MaxMana = 1394248230; // IValue<int>
		public const int CurrentMana = 49250327; // IReactiveVariable<int>
		public const int Abilities = 986255111; // IReactiveDictionary<string, Ability>
		public const int SelectedAbility = 1999545338; // IReactiveVariable<Ability>
		public const int CurrentWeapon = -205032771; // IReactiveVariable<IEntity>
		public const int Damage = 375673178; // IReactiveVariable<int>
		public const int ExtraDamage = -530877775; // IExpression<int>
		public const int Target = 1103309514; // IReactiveVariable<IEntity>
		public const int DamageRadius = 945363216; // IValue<float>
		public const int FireAction = 1186461126; // IAction
		public const int FirePoint = 397255013; // Transform
		public const int InteractAction = -1026843572; // IAction<IEntity>
		public const int TargetInteractible = 21081601; // IReactiveVariable<IEntity>
		public const int Owner = 245483896; // IReactiveVariable<IEntity>
		public const int Effects = -2018114250; // IReactiveDictionary<string, EffectInstance>
		public const int ProjectileEffects = -2063755301; // EffectConfig[]
		public const int Loot = 100693705; // SceneEntity[]
		public const int Trigger = -707381567; // TriggerEventReceiver


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IEntity obj) => obj.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IEntity obj) => obj.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IEntity obj) => obj.DelTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveableTag(this IEntity obj) => obj.HasTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveableTag(this IEntity obj) => obj.AddTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveableTag(this IEntity obj) => obj.DelTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractibleTag(this IEntity obj) => obj.HasTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractibleTag(this IEntity obj) => obj.AddTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractibleTag(this IEntity obj) => obj.DelTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLootableTag(this IEntity obj) => obj.HasTag(Lootable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddLootableTag(this IEntity obj) => obj.AddTag(Lootable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLootableTag(this IEntity obj) => obj.DelTag(Lootable);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject GetGameObject(this IEntity obj) => obj.GetValueUnsafe<GameObject>(GameObject);

		public static ref GameObject RefGameObject(this IEntity obj) => ref obj.GetValueUnsafe<GameObject>(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameObject(this IEntity obj, out GameObject value) => obj.TryGetValueUnsafe(GameObject, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameObject(this IEntity obj, GameObject value) => obj.AddValue(GameObject, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameObject(this IEntity obj) => obj.HasValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameObject(this IEntity obj) => obj.DelValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameObject(this IEntity obj, GameObject value) => obj.SetValue(GameObject, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IEntity obj) => obj.GetValueUnsafe<Transform>(Transform);

		public static ref Transform RefTransform(this IEntity obj) => ref obj.GetValueUnsafe<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValueUnsafe(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rigidbody GetRigidbody(this IEntity obj) => obj.GetValueUnsafe<Rigidbody>(Rigidbody);

		public static ref Rigidbody RefRigidbody(this IEntity obj) => ref obj.GetValueUnsafe<Rigidbody>(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRigidbody(this IEntity obj, out Rigidbody value) => obj.TryGetValueUnsafe(Rigidbody, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRigidbody(this IEntity obj, Rigidbody value) => obj.AddValue(Rigidbody, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRigidbody(this IEntity obj) => obj.HasValue(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRigidbody(this IEntity obj) => obj.DelValue(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRigidbody(this IEntity obj, Rigidbody value) => obj.SetValue(Rigidbody, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static NavMeshAgent GetNavAgent(this IEntity obj) => obj.GetValueUnsafe<NavMeshAgent>(NavAgent);

		public static ref NavMeshAgent RefNavAgent(this IEntity obj) => ref obj.GetValueUnsafe<NavMeshAgent>(NavAgent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetNavAgent(this IEntity obj, out NavMeshAgent value) => obj.TryGetValueUnsafe(NavAgent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddNavAgent(this IEntity obj, NavMeshAgent value) => obj.AddValue(NavAgent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasNavAgent(this IEntity obj) => obj.HasValue(NavAgent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelNavAgent(this IEntity obj) => obj.DelValue(NavAgent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetNavAgent(this IEntity obj, NavMeshAgent value) => obj.SetValue(NavAgent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IEntity obj) => obj.GetValueUnsafe<Animator>(Animator);

		public static ref Animator RefAnimator(this IEntity obj) => ref obj.GetValueUnsafe<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValueUnsafe(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetMoveSpeed(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<float>>(MoveSpeed);

		public static ref IReactiveVariable<float> RefMoveSpeed(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValueUnsafe(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetNormalizedCurrentSpeed(this IEntity obj) => obj.GetValueUnsafe<IValue<float>>(NormalizedCurrentSpeed);

		public static ref IValue<float> RefNormalizedCurrentSpeed(this IEntity obj) => ref obj.GetValueUnsafe<IValue<float>>(NormalizedCurrentSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetNormalizedCurrentSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValueUnsafe(NormalizedCurrentSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddNormalizedCurrentSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(NormalizedCurrentSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasNormalizedCurrentSpeed(this IEntity obj) => obj.HasValue(NormalizedCurrentSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelNormalizedCurrentSpeed(this IEntity obj) => obj.DelValue(NormalizedCurrentSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetNormalizedCurrentSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(NormalizedCurrentSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetMoveCondition(this IEntity obj) => obj.GetValueUnsafe<IExpression<bool>>(MoveCondition);

		public static ref IExpression<bool> RefMoveCondition(this IEntity obj) => ref obj.GetValueUnsafe<IExpression<bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValueUnsafe(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IEntity obj) => obj.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IEntity obj) => obj.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<bool> GetIsMoving(this IEntity obj) => obj.GetValueUnsafe<IValue<bool>>(IsMoving);

		public static ref IValue<bool> RefIsMoving(this IEntity obj) => ref obj.GetValueUnsafe<IValue<bool>>(IsMoving);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsMoving(this IEntity obj, out IValue<bool> value) => obj.TryGetValueUnsafe(IsMoving, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddIsMoving(this IEntity obj, IValue<bool> value) => obj.AddValue(IsMoving, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsMoving(this IEntity obj) => obj.HasValue(IsMoving);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsMoving(this IEntity obj) => obj.DelValue(IsMoving);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsMoving(this IEntity obj, IValue<bool> value) => obj.SetValue(IsMoving, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Vector3>>(MoveDirection);

		public static ref IReactiveVariable<Vector3> RefMoveDirection(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Vector3>>(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValueUnsafe(MoveDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3> GetMovePointAction(this IEntity obj) => obj.GetValueUnsafe<IAction<Vector3>>(MovePointAction);

		public static ref IAction<Vector3> RefMovePointAction(this IEntity obj) => ref obj.GetValueUnsafe<IAction<Vector3>>(MovePointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMovePointAction(this IEntity obj, out IAction<Vector3> value) => obj.TryGetValueUnsafe(MovePointAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMovePointAction(this IEntity obj, IAction<Vector3> value) => obj.AddValue(MovePointAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMovePointAction(this IEntity obj) => obj.HasValue(MovePointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMovePointAction(this IEntity obj) => obj.DelValue(MovePointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMovePointAction(this IEntity obj, IAction<Vector3> value) => obj.SetValue(MovePointAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3> GetTeleportAction(this IEntity obj) => obj.GetValueUnsafe<IAction<Vector3>>(TeleportAction);

		public static ref IAction<Vector3> RefTeleportAction(this IEntity obj) => ref obj.GetValueUnsafe<IAction<Vector3>>(TeleportAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTeleportAction(this IEntity obj, out IAction<Vector3> value) => obj.TryGetValueUnsafe(TeleportAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTeleportAction(this IEntity obj, IAction<Vector3> value) => obj.AddValue(TeleportAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTeleportAction(this IEntity obj) => obj.HasValue(TeleportAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTeleportAction(this IEntity obj) => obj.DelValue(TeleportAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTeleportAction(this IEntity obj, IAction<Vector3> value) => obj.SetValue(TeleportAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetForwardDirection(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<float>>(ForwardDirection);

		public static ref IReactiveVariable<float> RefForwardDirection(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<float>>(ForwardDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetForwardDirection(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValueUnsafe(ForwardDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddForwardDirection(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(ForwardDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasForwardDirection(this IEntity obj) => obj.HasValue(ForwardDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelForwardDirection(this IEntity obj) => obj.DelValue(ForwardDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetForwardDirection(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(ForwardDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetAngularSpeed(this IEntity obj) => obj.GetValueUnsafe<IValue<float>>(AngularSpeed);

		public static ref IValue<float> RefAngularSpeed(this IEntity obj) => ref obj.GetValueUnsafe<IValue<float>>(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAngularSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValueUnsafe(AngularSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAngularSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAngularSpeed(this IEntity obj) => obj.HasValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAngularSpeed(this IEntity obj) => obj.DelValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAngularSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetAngularDirection(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Vector3>>(AngularDirection);

		public static ref IReactiveVariable<Vector3> RefAngularDirection(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Vector3>>(AngularDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAngularDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValueUnsafe(AngularDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAngularDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(AngularDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAngularDirection(this IEntity obj) => obj.HasValue(AngularDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAngularDirection(this IEntity obj) => obj.DelValue(AngularDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAngularDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(AngularDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetTurnDirection(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<float>>(TurnDirection);

		public static ref IReactiveVariable<float> RefTurnDirection(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<float>>(TurnDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTurnDirection(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValueUnsafe(TurnDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTurnDirection(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(TurnDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTurnDirection(this IEntity obj) => obj.HasValue(TurnDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTurnDirection(this IEntity obj) => obj.DelValue(TurnDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTurnDirection(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(TurnDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetMaxHealth(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(MaxHealth);

		public static ref IReactiveVariable<int> RefMaxHealth(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxHealth(this IEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(MaxHealth, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxHealth(this IEntity obj, IReactiveVariable<int> value) => obj.AddValue(MaxHealth, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxHealth(this IEntity obj) => obj.HasValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxHealth(this IEntity obj) => obj.DelValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxHealth(this IEntity obj, IReactiveVariable<int> value) => obj.SetValue(MaxHealth, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(Health);

		public static ref IReactiveVariable<int> RefHealth(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IEntity obj, IReactiveVariable<int> value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity obj, IReactiveVariable<int> value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetLifetime(this IEntity obj) => obj.GetValueUnsafe<Cooldown>(Lifetime);

		public static ref Cooldown RefLifetime(this IEntity obj) => ref obj.GetValueUnsafe<Cooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IEntity obj, out Cooldown value) => obj.TryGetValueUnsafe(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLifetime(this IEntity obj, Cooldown value) => obj.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IEntity obj) => obj.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IEntity obj) => obj.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IEntity obj, Cooldown value) => obj.SetValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IEntity obj) => obj.GetValueUnsafe<IAction>(DestroyAction);

		public static ref IAction RefDestroyAction(this IEntity obj) => ref obj.GetValueUnsafe<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IEntity obj, out IAction value) => obj.TryGetValueUnsafe(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDestroyAction(this IEntity obj, IAction value) => obj.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IEntity obj) => obj.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IEntity obj) => obj.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IEntity obj, IAction value) => obj.SetValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetDamagedEvent(this IEntity obj) => obj.GetValueUnsafe<IEvent>(DamagedEvent);

		public static ref IEvent RefDamagedEvent(this IEntity obj) => ref obj.GetValueUnsafe<IEvent>(DamagedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamagedEvent(this IEntity obj, out IEvent value) => obj.TryGetValueUnsafe(DamagedEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamagedEvent(this IEntity obj, IEvent value) => obj.AddValue(DamagedEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamagedEvent(this IEntity obj) => obj.HasValue(DamagedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamagedEvent(this IEntity obj) => obj.DelValue(DamagedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamagedEvent(this IEntity obj, IEvent value) => obj.SetValue(DamagedEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetDeathEvent(this IEntity obj) => obj.GetValueUnsafe<IEvent>(DeathEvent);

		public static ref IEvent RefDeathEvent(this IEntity obj) => ref obj.GetValueUnsafe<IEvent>(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathEvent(this IEntity obj, out IEvent value) => obj.TryGetValueUnsafe(DeathEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeathEvent(this IEntity obj, IEvent value) => obj.AddValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathEvent(this IEntity obj) => obj.HasValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathEvent(this IEntity obj) => obj.DelValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathEvent(this IEntity obj, IEvent value) => obj.SetValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxMana(this IEntity obj) => obj.GetValueUnsafe<IValue<int>>(MaxMana);

		public static ref IValue<int> RefMaxMana(this IEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(MaxMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxMana(this IEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(MaxMana, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxMana(this IEntity obj, IValue<int> value) => obj.AddValue(MaxMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxMana(this IEntity obj) => obj.HasValue(MaxMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxMana(this IEntity obj) => obj.DelValue(MaxMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxMana(this IEntity obj, IValue<int> value) => obj.SetValue(MaxMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetCurrentMana(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentMana);

		public static ref IReactiveVariable<int> RefCurrentMana(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentMana(this IEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(CurrentMana, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentMana(this IEntity obj, IReactiveVariable<int> value) => obj.AddValue(CurrentMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentMana(this IEntity obj) => obj.HasValue(CurrentMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentMana(this IEntity obj) => obj.DelValue(CurrentMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentMana(this IEntity obj, IReactiveVariable<int> value) => obj.SetValue(CurrentMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveDictionary<string, Ability> GetAbilities(this IEntity obj) => obj.GetValueUnsafe<IReactiveDictionary<string, Ability>>(Abilities);

		public static ref IReactiveDictionary<string, Ability> RefAbilities(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveDictionary<string, Ability>>(Abilities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAbilities(this IEntity obj, out IReactiveDictionary<string, Ability> value) => obj.TryGetValueUnsafe(Abilities, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAbilities(this IEntity obj, IReactiveDictionary<string, Ability> value) => obj.AddValue(Abilities, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAbilities(this IEntity obj) => obj.HasValue(Abilities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAbilities(this IEntity obj) => obj.DelValue(Abilities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAbilities(this IEntity obj, IReactiveDictionary<string, Ability> value) => obj.SetValue(Abilities, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Ability> GetSelectedAbility(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Ability>>(SelectedAbility);

		public static ref IReactiveVariable<Ability> RefSelectedAbility(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Ability>>(SelectedAbility);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSelectedAbility(this IEntity obj, out IReactiveVariable<Ability> value) => obj.TryGetValueUnsafe(SelectedAbility, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSelectedAbility(this IEntity obj, IReactiveVariable<Ability> value) => obj.AddValue(SelectedAbility, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSelectedAbility(this IEntity obj) => obj.HasValue(SelectedAbility);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSelectedAbility(this IEntity obj) => obj.DelValue(SelectedAbility);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSelectedAbility(this IEntity obj, IReactiveVariable<Ability> value) => obj.SetValue(SelectedAbility, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetCurrentWeapon(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<IEntity>>(CurrentWeapon);

		public static ref IReactiveVariable<IEntity> RefCurrentWeapon(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<IEntity>>(CurrentWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentWeapon(this IEntity obj, out IReactiveVariable<IEntity> value) => obj.TryGetValueUnsafe(CurrentWeapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentWeapon(this IEntity obj, IReactiveVariable<IEntity> value) => obj.AddValue(CurrentWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentWeapon(this IEntity obj) => obj.HasValue(CurrentWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentWeapon(this IEntity obj) => obj.DelValue(CurrentWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentWeapon(this IEntity obj, IReactiveVariable<IEntity> value) => obj.SetValue(CurrentWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetDamage(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(Damage);

		public static ref IReactiveVariable<int> RefDamage(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IEntity obj, IReactiveVariable<int> value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IEntity obj, IReactiveVariable<int> value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<int> GetExtraDamage(this IEntity obj) => obj.GetValueUnsafe<IExpression<int>>(ExtraDamage);

		public static ref IExpression<int> RefExtraDamage(this IEntity obj) => ref obj.GetValueUnsafe<IExpression<int>>(ExtraDamage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetExtraDamage(this IEntity obj, out IExpression<int> value) => obj.TryGetValueUnsafe(ExtraDamage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddExtraDamage(this IEntity obj, IExpression<int> value) => obj.AddValue(ExtraDamage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasExtraDamage(this IEntity obj) => obj.HasValue(ExtraDamage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelExtraDamage(this IEntity obj) => obj.DelValue(ExtraDamage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetExtraDamage(this IEntity obj, IExpression<int> value) => obj.SetValue(ExtraDamage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetTarget(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<IEntity>>(Target);

		public static ref IReactiveVariable<IEntity> RefTarget(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<IEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IEntity obj, out IReactiveVariable<IEntity> value) => obj.TryGetValueUnsafe(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTarget(this IEntity obj, IReactiveVariable<IEntity> value) => obj.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IEntity obj) => obj.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IEntity obj) => obj.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IEntity obj, IReactiveVariable<IEntity> value) => obj.SetValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetDamageRadius(this IEntity obj) => obj.GetValueUnsafe<IValue<float>>(DamageRadius);

		public static ref IValue<float> RefDamageRadius(this IEntity obj) => ref obj.GetValueUnsafe<IValue<float>>(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamageRadius(this IEntity obj, out IValue<float> value) => obj.TryGetValueUnsafe(DamageRadius, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamageRadius(this IEntity obj, IValue<float> value) => obj.AddValue(DamageRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageRadius(this IEntity obj) => obj.HasValue(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageRadius(this IEntity obj) => obj.DelValue(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamageRadius(this IEntity obj, IValue<float> value) => obj.SetValue(DamageRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetFireAction(this IEntity obj) => obj.GetValueUnsafe<IAction>(FireAction);

		public static ref IAction RefFireAction(this IEntity obj) => ref obj.GetValueUnsafe<IAction>(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAction(this IEntity obj, out IAction value) => obj.TryGetValueUnsafe(FireAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAction(this IEntity obj, IAction value) => obj.AddValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAction(this IEntity obj) => obj.HasValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAction(this IEntity obj) => obj.DelValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAction(this IEntity obj, IAction value) => obj.SetValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetFirePoint(this IEntity obj) => obj.GetValueUnsafe<Transform>(FirePoint);

		public static ref Transform RefFirePoint(this IEntity obj) => ref obj.GetValueUnsafe<Transform>(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirePoint(this IEntity obj, out Transform value) => obj.TryGetValueUnsafe(FirePoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFirePoint(this IEntity obj, Transform value) => obj.AddValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirePoint(this IEntity obj) => obj.HasValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirePoint(this IEntity obj) => obj.DelValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirePoint(this IEntity obj, Transform value) => obj.SetValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<IEntity> GetInteractAction(this IEntity obj) => obj.GetValueUnsafe<IAction<IEntity>>(InteractAction);

		public static ref IAction<IEntity> RefInteractAction(this IEntity obj) => ref obj.GetValueUnsafe<IAction<IEntity>>(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractAction(this IEntity obj, out IAction<IEntity> value) => obj.TryGetValueUnsafe(InteractAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractAction(this IEntity obj, IAction<IEntity> value) => obj.AddValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractAction(this IEntity obj) => obj.HasValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractAction(this IEntity obj) => obj.DelValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractAction(this IEntity obj, IAction<IEntity> value) => obj.SetValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetTargetInteractible(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<IEntity>>(TargetInteractible);

		public static ref IReactiveVariable<IEntity> RefTargetInteractible(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<IEntity>>(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetInteractible(this IEntity obj, out IReactiveVariable<IEntity> value) => obj.TryGetValueUnsafe(TargetInteractible, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetInteractible(this IEntity obj, IReactiveVariable<IEntity> value) => obj.AddValue(TargetInteractible, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetInteractible(this IEntity obj) => obj.HasValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetInteractible(this IEntity obj) => obj.DelValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetInteractible(this IEntity obj, IReactiveVariable<IEntity> value) => obj.SetValue(TargetInteractible, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetOwner(this IEntity obj) => obj.GetValueUnsafe<IReactiveVariable<IEntity>>(Owner);

		public static ref IReactiveVariable<IEntity> RefOwner(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<IEntity>>(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetOwner(this IEntity obj, out IReactiveVariable<IEntity> value) => obj.TryGetValueUnsafe(Owner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddOwner(this IEntity obj, IReactiveVariable<IEntity> value) => obj.AddValue(Owner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasOwner(this IEntity obj) => obj.HasValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelOwner(this IEntity obj) => obj.DelValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetOwner(this IEntity obj, IReactiveVariable<IEntity> value) => obj.SetValue(Owner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveDictionary<string, EffectInstance> GetEffects(this IEntity obj) => obj.GetValueUnsafe<IReactiveDictionary<string, EffectInstance>>(Effects);

		public static ref IReactiveDictionary<string, EffectInstance> RefEffects(this IEntity obj) => ref obj.GetValueUnsafe<IReactiveDictionary<string, EffectInstance>>(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEffects(this IEntity obj, out IReactiveDictionary<string, EffectInstance> value) => obj.TryGetValueUnsafe(Effects, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEffects(this IEntity obj, IReactiveDictionary<string, EffectInstance> value) => obj.AddValue(Effects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEffects(this IEntity obj) => obj.HasValue(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEffects(this IEntity obj) => obj.DelValue(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEffects(this IEntity obj, IReactiveDictionary<string, EffectInstance> value) => obj.SetValue(Effects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EffectConfig[] GetProjectileEffects(this IEntity obj) => obj.GetValueUnsafe<EffectConfig[]>(ProjectileEffects);

		public static ref EffectConfig[] RefProjectileEffects(this IEntity obj) => ref obj.GetValueUnsafe<EffectConfig[]>(ProjectileEffects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetProjectileEffects(this IEntity obj, out EffectConfig[] value) => obj.TryGetValueUnsafe(ProjectileEffects, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddProjectileEffects(this IEntity obj, EffectConfig[] value) => obj.AddValue(ProjectileEffects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectileEffects(this IEntity obj) => obj.HasValue(ProjectileEffects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectileEffects(this IEntity obj) => obj.DelValue(ProjectileEffects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetProjectileEffects(this IEntity obj, EffectConfig[] value) => obj.SetValue(ProjectileEffects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity[] GetLoot(this IEntity obj) => obj.GetValueUnsafe<SceneEntity[]>(Loot);

		public static ref SceneEntity[] RefLoot(this IEntity obj) => ref obj.GetValueUnsafe<SceneEntity[]>(Loot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLoot(this IEntity obj, out SceneEntity[] value) => obj.TryGetValueUnsafe(Loot, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLoot(this IEntity obj, SceneEntity[] value) => obj.AddValue(Loot, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLoot(this IEntity obj) => obj.HasValue(Loot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLoot(this IEntity obj) => obj.DelValue(Loot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLoot(this IEntity obj, SceneEntity[] value) => obj.SetValue(Loot, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEventReceiver GetTrigger(this IEntity obj) => obj.GetValueUnsafe<TriggerEventReceiver>(Trigger);

		public static ref TriggerEventReceiver RefTrigger(this IEntity obj) => ref obj.GetValueUnsafe<TriggerEventReceiver>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IEntity obj, out TriggerEventReceiver value) => obj.TryGetValueUnsafe(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrigger(this IEntity obj, TriggerEventReceiver value) => obj.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IEntity obj) => obj.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IEntity obj) => obj.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IEntity obj, TriggerEventReceiver value) => obj.SetValue(Trigger, value);
    }
}
