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
	public static class GameEntityAPI
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
		public const int StopAction = 149392863; // IAction
		public const int ForwardDirection = -597461024; // IReactiveVariable<float>
		public const int AngularSpeed = -1089183267; // IValue<float>
		public const int AngularDirection = -1725439556; // IValue<Vector3>
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
		public const int SelectAbilityCondition = 1530526709; // IValue<bool>
		public const int SelectAbilityAction = 905490121; // IAction<Ability>
		public const int Damage = 375673178; // IReactiveVariable<int>
		public const int ExtraDamage = -530877775; // IExpression<int>
		public const int Target = 1103309514; // IReactiveVariable<IGameEntity>
		public const int DamageRadius = 945363216; // IValue<float>
		public const int FireAction = 1186461126; // IAction
		public const int FirePoint = 397255013; // Transform
		public const int InteractAction = -1026843572; // IAction<IGameEntity>
		public const int TargetInteractible = 21081601; // IReactiveVariable<IGameEntity>
		public const int Owner = 245483896; // IReactiveVariable<IGameEntity>
		public const int Effects = -2018114250; // IReactiveDictionary<string, Effect>
		public const int ProjectileEffects = -2063755301; // EffectConfig[]
		public const int Loot = 100693705; // SceneEntity[]
		public const int Trigger = -707381567; // TriggerEventReceiver


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IGameEntity obj) => obj.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IGameEntity obj) => obj.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IGameEntity obj) => obj.DelTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveableTag(this IGameEntity obj) => obj.HasTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveableTag(this IGameEntity obj) => obj.AddTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveableTag(this IGameEntity obj) => obj.DelTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractibleTag(this IGameEntity obj) => obj.HasTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractibleTag(this IGameEntity obj) => obj.AddTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractibleTag(this IGameEntity obj) => obj.DelTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLootableTag(this IGameEntity obj) => obj.HasTag(Lootable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddLootableTag(this IGameEntity obj) => obj.AddTag(Lootable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLootableTag(this IGameEntity obj) => obj.DelTag(Lootable);


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
		public static Rigidbody GetRigidbody(this IGameEntity obj) => obj.GetValueUnsafe<Rigidbody>(Rigidbody);

		public static ref Rigidbody RefRigidbody(this IGameEntity obj) => ref obj.GetValueUnsafe<Rigidbody>(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRigidbody(this IGameEntity obj, out Rigidbody value) => obj.TryGetValueUnsafe(Rigidbody, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRigidbody(this IGameEntity obj, Rigidbody value) => obj.AddValue(Rigidbody, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRigidbody(this IGameEntity obj) => obj.HasValue(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRigidbody(this IGameEntity obj) => obj.DelValue(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRigidbody(this IGameEntity obj, Rigidbody value) => obj.SetValue(Rigidbody, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static NavMeshAgent GetNavAgent(this IGameEntity obj) => obj.GetValueUnsafe<NavMeshAgent>(NavAgent);

		public static ref NavMeshAgent RefNavAgent(this IGameEntity obj) => ref obj.GetValueUnsafe<NavMeshAgent>(NavAgent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetNavAgent(this IGameEntity obj, out NavMeshAgent value) => obj.TryGetValueUnsafe(NavAgent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddNavAgent(this IGameEntity obj, NavMeshAgent value) => obj.AddValue(NavAgent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasNavAgent(this IGameEntity obj) => obj.HasValue(NavAgent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelNavAgent(this IGameEntity obj) => obj.DelValue(NavAgent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetNavAgent(this IGameEntity obj, NavMeshAgent value) => obj.SetValue(NavAgent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IGameEntity obj) => obj.GetValueUnsafe<Animator>(Animator);

		public static ref Animator RefAnimator(this IGameEntity obj) => ref obj.GetValueUnsafe<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IGameEntity obj, out Animator value) => obj.TryGetValueUnsafe(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimator(this IGameEntity obj, Animator value) => obj.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IGameEntity obj) => obj.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IGameEntity obj) => obj.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IGameEntity obj, Animator value) => obj.SetValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetMoveSpeed(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<float>>(MoveSpeed);

		public static ref IReactiveVariable<float> RefMoveSpeed(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IGameEntity obj, out IReactiveVariable<float> value) => obj.TryGetValueUnsafe(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IGameEntity obj, IReactiveVariable<float> value) => obj.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IGameEntity obj) => obj.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IGameEntity obj) => obj.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IGameEntity obj, IReactiveVariable<float> value) => obj.SetValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetNormalizedCurrentSpeed(this IGameEntity obj) => obj.GetValueUnsafe<IValue<float>>(NormalizedCurrentSpeed);

		public static ref IValue<float> RefNormalizedCurrentSpeed(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<float>>(NormalizedCurrentSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetNormalizedCurrentSpeed(this IGameEntity obj, out IValue<float> value) => obj.TryGetValueUnsafe(NormalizedCurrentSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddNormalizedCurrentSpeed(this IGameEntity obj, IValue<float> value) => obj.AddValue(NormalizedCurrentSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasNormalizedCurrentSpeed(this IGameEntity obj) => obj.HasValue(NormalizedCurrentSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelNormalizedCurrentSpeed(this IGameEntity obj) => obj.DelValue(NormalizedCurrentSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetNormalizedCurrentSpeed(this IGameEntity obj, IValue<float> value) => obj.SetValue(NormalizedCurrentSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetMoveCondition(this IGameEntity obj) => obj.GetValueUnsafe<IExpression<bool>>(MoveCondition);

		public static ref IExpression<bool> RefMoveCondition(this IGameEntity obj) => ref obj.GetValueUnsafe<IExpression<bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IGameEntity obj, out IExpression<bool> value) => obj.TryGetValueUnsafe(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCondition(this IGameEntity obj, IExpression<bool> value) => obj.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IGameEntity obj) => obj.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IGameEntity obj) => obj.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IGameEntity obj, IExpression<bool> value) => obj.SetValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<bool> GetIsMoving(this IGameEntity obj) => obj.GetValueUnsafe<IValue<bool>>(IsMoving);

		public static ref IValue<bool> RefIsMoving(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<bool>>(IsMoving);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsMoving(this IGameEntity obj, out IValue<bool> value) => obj.TryGetValueUnsafe(IsMoving, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddIsMoving(this IGameEntity obj, IValue<bool> value) => obj.AddValue(IsMoving, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsMoving(this IGameEntity obj) => obj.HasValue(IsMoving);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsMoving(this IGameEntity obj) => obj.DelValue(IsMoving);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsMoving(this IGameEntity obj, IValue<bool> value) => obj.SetValue(IsMoving, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetMoveDirection(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Vector3>>(MoveDirection);

		public static ref IReactiveVariable<Vector3> RefMoveDirection(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Vector3>>(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDirection(this IGameEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValueUnsafe(MoveDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveDirection(this IGameEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDirection(this IGameEntity obj) => obj.HasValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDirection(this IGameEntity obj) => obj.DelValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDirection(this IGameEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3> GetMovePointAction(this IGameEntity obj) => obj.GetValueUnsafe<IAction<Vector3>>(MovePointAction);

		public static ref IAction<Vector3> RefMovePointAction(this IGameEntity obj) => ref obj.GetValueUnsafe<IAction<Vector3>>(MovePointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMovePointAction(this IGameEntity obj, out IAction<Vector3> value) => obj.TryGetValueUnsafe(MovePointAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMovePointAction(this IGameEntity obj, IAction<Vector3> value) => obj.AddValue(MovePointAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMovePointAction(this IGameEntity obj) => obj.HasValue(MovePointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMovePointAction(this IGameEntity obj) => obj.DelValue(MovePointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMovePointAction(this IGameEntity obj, IAction<Vector3> value) => obj.SetValue(MovePointAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3> GetTeleportAction(this IGameEntity obj) => obj.GetValueUnsafe<IAction<Vector3>>(TeleportAction);

		public static ref IAction<Vector3> RefTeleportAction(this IGameEntity obj) => ref obj.GetValueUnsafe<IAction<Vector3>>(TeleportAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTeleportAction(this IGameEntity obj, out IAction<Vector3> value) => obj.TryGetValueUnsafe(TeleportAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTeleportAction(this IGameEntity obj, IAction<Vector3> value) => obj.AddValue(TeleportAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTeleportAction(this IGameEntity obj) => obj.HasValue(TeleportAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTeleportAction(this IGameEntity obj) => obj.DelValue(TeleportAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTeleportAction(this IGameEntity obj, IAction<Vector3> value) => obj.SetValue(TeleportAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetStopAction(this IGameEntity obj) => obj.GetValueUnsafe<IAction>(StopAction);

		public static ref IAction RefStopAction(this IGameEntity obj) => ref obj.GetValueUnsafe<IAction>(StopAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetStopAction(this IGameEntity obj, out IAction value) => obj.TryGetValueUnsafe(StopAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddStopAction(this IGameEntity obj, IAction value) => obj.AddValue(StopAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasStopAction(this IGameEntity obj) => obj.HasValue(StopAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelStopAction(this IGameEntity obj) => obj.DelValue(StopAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetStopAction(this IGameEntity obj, IAction value) => obj.SetValue(StopAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetForwardDirection(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<float>>(ForwardDirection);

		public static ref IReactiveVariable<float> RefForwardDirection(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<float>>(ForwardDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetForwardDirection(this IGameEntity obj, out IReactiveVariable<float> value) => obj.TryGetValueUnsafe(ForwardDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddForwardDirection(this IGameEntity obj, IReactiveVariable<float> value) => obj.AddValue(ForwardDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasForwardDirection(this IGameEntity obj) => obj.HasValue(ForwardDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelForwardDirection(this IGameEntity obj) => obj.DelValue(ForwardDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetForwardDirection(this IGameEntity obj, IReactiveVariable<float> value) => obj.SetValue(ForwardDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetAngularSpeed(this IGameEntity obj) => obj.GetValueUnsafe<IValue<float>>(AngularSpeed);

		public static ref IValue<float> RefAngularSpeed(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<float>>(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAngularSpeed(this IGameEntity obj, out IValue<float> value) => obj.TryGetValueUnsafe(AngularSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAngularSpeed(this IGameEntity obj, IValue<float> value) => obj.AddValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAngularSpeed(this IGameEntity obj) => obj.HasValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAngularSpeed(this IGameEntity obj) => obj.DelValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAngularSpeed(this IGameEntity obj, IValue<float> value) => obj.SetValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<Vector3> GetAngularDirection(this IGameEntity obj) => obj.GetValueUnsafe<IValue<Vector3>>(AngularDirection);

		public static ref IValue<Vector3> RefAngularDirection(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<Vector3>>(AngularDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAngularDirection(this IGameEntity obj, out IValue<Vector3> value) => obj.TryGetValueUnsafe(AngularDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAngularDirection(this IGameEntity obj, IValue<Vector3> value) => obj.AddValue(AngularDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAngularDirection(this IGameEntity obj) => obj.HasValue(AngularDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAngularDirection(this IGameEntity obj) => obj.DelValue(AngularDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAngularDirection(this IGameEntity obj, IValue<Vector3> value) => obj.SetValue(AngularDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetTurnDirection(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<float>>(TurnDirection);

		public static ref IReactiveVariable<float> RefTurnDirection(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<float>>(TurnDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTurnDirection(this IGameEntity obj, out IReactiveVariable<float> value) => obj.TryGetValueUnsafe(TurnDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTurnDirection(this IGameEntity obj, IReactiveVariable<float> value) => obj.AddValue(TurnDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTurnDirection(this IGameEntity obj) => obj.HasValue(TurnDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTurnDirection(this IGameEntity obj) => obj.DelValue(TurnDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTurnDirection(this IGameEntity obj, IReactiveVariable<float> value) => obj.SetValue(TurnDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetMaxHealth(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(MaxHealth);

		public static ref IReactiveVariable<int> RefMaxHealth(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxHealth(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(MaxHealth, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxHealth(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(MaxHealth, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxHealth(this IGameEntity obj) => obj.HasValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxHealth(this IGameEntity obj) => obj.DelValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxHealth(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(MaxHealth, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(Health);

		public static ref IReactiveVariable<int> RefHealth(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetLifetime(this IGameEntity obj) => obj.GetValueUnsafe<Cooldown>(Lifetime);

		public static ref Cooldown RefLifetime(this IGameEntity obj) => ref obj.GetValueUnsafe<Cooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IGameEntity obj, out Cooldown value) => obj.TryGetValueUnsafe(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLifetime(this IGameEntity obj, Cooldown value) => obj.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IGameEntity obj) => obj.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IGameEntity obj) => obj.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IGameEntity obj, Cooldown value) => obj.SetValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IGameEntity obj) => obj.GetValueUnsafe<IAction>(DestroyAction);

		public static ref IAction RefDestroyAction(this IGameEntity obj) => ref obj.GetValueUnsafe<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IGameEntity obj, out IAction value) => obj.TryGetValueUnsafe(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDestroyAction(this IGameEntity obj, IAction value) => obj.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IGameEntity obj) => obj.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IGameEntity obj) => obj.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IGameEntity obj, IAction value) => obj.SetValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetDamagedEvent(this IGameEntity obj) => obj.GetValueUnsafe<IEvent>(DamagedEvent);

		public static ref IEvent RefDamagedEvent(this IGameEntity obj) => ref obj.GetValueUnsafe<IEvent>(DamagedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamagedEvent(this IGameEntity obj, out IEvent value) => obj.TryGetValueUnsafe(DamagedEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamagedEvent(this IGameEntity obj, IEvent value) => obj.AddValue(DamagedEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamagedEvent(this IGameEntity obj) => obj.HasValue(DamagedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamagedEvent(this IGameEntity obj) => obj.DelValue(DamagedEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamagedEvent(this IGameEntity obj, IEvent value) => obj.SetValue(DamagedEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetDeathEvent(this IGameEntity obj) => obj.GetValueUnsafe<IEvent>(DeathEvent);

		public static ref IEvent RefDeathEvent(this IGameEntity obj) => ref obj.GetValueUnsafe<IEvent>(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathEvent(this IGameEntity obj, out IEvent value) => obj.TryGetValueUnsafe(DeathEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeathEvent(this IGameEntity obj, IEvent value) => obj.AddValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathEvent(this IGameEntity obj) => obj.HasValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathEvent(this IGameEntity obj) => obj.DelValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathEvent(this IGameEntity obj, IEvent value) => obj.SetValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxMana(this IGameEntity obj) => obj.GetValueUnsafe<IValue<int>>(MaxMana);

		public static ref IValue<int> RefMaxMana(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(MaxMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxMana(this IGameEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(MaxMana, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxMana(this IGameEntity obj, IValue<int> value) => obj.AddValue(MaxMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxMana(this IGameEntity obj) => obj.HasValue(MaxMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxMana(this IGameEntity obj) => obj.DelValue(MaxMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxMana(this IGameEntity obj, IValue<int> value) => obj.SetValue(MaxMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetCurrentMana(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentMana);

		public static ref IReactiveVariable<int> RefCurrentMana(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentMana(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(CurrentMana, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentMana(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(CurrentMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentMana(this IGameEntity obj) => obj.HasValue(CurrentMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentMana(this IGameEntity obj) => obj.DelValue(CurrentMana);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentMana(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(CurrentMana, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveDictionary<string, Ability> GetAbilities(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveDictionary<string, Ability>>(Abilities);

		public static ref IReactiveDictionary<string, Ability> RefAbilities(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveDictionary<string, Ability>>(Abilities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAbilities(this IGameEntity obj, out IReactiveDictionary<string, Ability> value) => obj.TryGetValueUnsafe(Abilities, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAbilities(this IGameEntity obj, IReactiveDictionary<string, Ability> value) => obj.AddValue(Abilities, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAbilities(this IGameEntity obj) => obj.HasValue(Abilities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAbilities(this IGameEntity obj) => obj.DelValue(Abilities);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAbilities(this IGameEntity obj, IReactiveDictionary<string, Ability> value) => obj.SetValue(Abilities, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Ability> GetSelectedAbility(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Ability>>(SelectedAbility);

		public static ref IReactiveVariable<Ability> RefSelectedAbility(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Ability>>(SelectedAbility);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSelectedAbility(this IGameEntity obj, out IReactiveVariable<Ability> value) => obj.TryGetValueUnsafe(SelectedAbility, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSelectedAbility(this IGameEntity obj, IReactiveVariable<Ability> value) => obj.AddValue(SelectedAbility, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSelectedAbility(this IGameEntity obj) => obj.HasValue(SelectedAbility);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSelectedAbility(this IGameEntity obj) => obj.DelValue(SelectedAbility);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSelectedAbility(this IGameEntity obj, IReactiveVariable<Ability> value) => obj.SetValue(SelectedAbility, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<bool> GetSelectAbilityCondition(this IGameEntity obj) => obj.GetValueUnsafe<IValue<bool>>(SelectAbilityCondition);

		public static ref IValue<bool> RefSelectAbilityCondition(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<bool>>(SelectAbilityCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSelectAbilityCondition(this IGameEntity obj, out IValue<bool> value) => obj.TryGetValueUnsafe(SelectAbilityCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSelectAbilityCondition(this IGameEntity obj, IValue<bool> value) => obj.AddValue(SelectAbilityCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSelectAbilityCondition(this IGameEntity obj) => obj.HasValue(SelectAbilityCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSelectAbilityCondition(this IGameEntity obj) => obj.DelValue(SelectAbilityCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSelectAbilityCondition(this IGameEntity obj, IValue<bool> value) => obj.SetValue(SelectAbilityCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Ability> GetSelectAbilityAction(this IGameEntity obj) => obj.GetValueUnsafe<IAction<Ability>>(SelectAbilityAction);

		public static ref IAction<Ability> RefSelectAbilityAction(this IGameEntity obj) => ref obj.GetValueUnsafe<IAction<Ability>>(SelectAbilityAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSelectAbilityAction(this IGameEntity obj, out IAction<Ability> value) => obj.TryGetValueUnsafe(SelectAbilityAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSelectAbilityAction(this IGameEntity obj, IAction<Ability> value) => obj.AddValue(SelectAbilityAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSelectAbilityAction(this IGameEntity obj) => obj.HasValue(SelectAbilityAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSelectAbilityAction(this IGameEntity obj) => obj.DelValue(SelectAbilityAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSelectAbilityAction(this IGameEntity obj, IAction<Ability> value) => obj.SetValue(SelectAbilityAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetDamage(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(Damage);

		public static ref IReactiveVariable<int> RefDamage(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IGameEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IGameEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<int> GetExtraDamage(this IGameEntity obj) => obj.GetValueUnsafe<IExpression<int>>(ExtraDamage);

		public static ref IExpression<int> RefExtraDamage(this IGameEntity obj) => ref obj.GetValueUnsafe<IExpression<int>>(ExtraDamage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetExtraDamage(this IGameEntity obj, out IExpression<int> value) => obj.TryGetValueUnsafe(ExtraDamage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddExtraDamage(this IGameEntity obj, IExpression<int> value) => obj.AddValue(ExtraDamage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasExtraDamage(this IGameEntity obj) => obj.HasValue(ExtraDamage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelExtraDamage(this IGameEntity obj) => obj.DelValue(ExtraDamage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetExtraDamage(this IGameEntity obj, IExpression<int> value) => obj.SetValue(ExtraDamage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IGameEntity> GetTarget(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(Target);

		public static ref IReactiveVariable<IGameEntity> RefTarget(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IGameEntity obj, out IReactiveVariable<IGameEntity> value) => obj.TryGetValueUnsafe(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTarget(this IGameEntity obj, IReactiveVariable<IGameEntity> value) => obj.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IGameEntity obj) => obj.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IGameEntity obj) => obj.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IGameEntity obj, IReactiveVariable<IGameEntity> value) => obj.SetValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetDamageRadius(this IGameEntity obj) => obj.GetValueUnsafe<IValue<float>>(DamageRadius);

		public static ref IValue<float> RefDamageRadius(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<float>>(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamageRadius(this IGameEntity obj, out IValue<float> value) => obj.TryGetValueUnsafe(DamageRadius, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamageRadius(this IGameEntity obj, IValue<float> value) => obj.AddValue(DamageRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageRadius(this IGameEntity obj) => obj.HasValue(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageRadius(this IGameEntity obj) => obj.DelValue(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamageRadius(this IGameEntity obj, IValue<float> value) => obj.SetValue(DamageRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetFireAction(this IGameEntity obj) => obj.GetValueUnsafe<IAction>(FireAction);

		public static ref IAction RefFireAction(this IGameEntity obj) => ref obj.GetValueUnsafe<IAction>(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAction(this IGameEntity obj, out IAction value) => obj.TryGetValueUnsafe(FireAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAction(this IGameEntity obj, IAction value) => obj.AddValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAction(this IGameEntity obj) => obj.HasValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAction(this IGameEntity obj) => obj.DelValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAction(this IGameEntity obj, IAction value) => obj.SetValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetFirePoint(this IGameEntity obj) => obj.GetValueUnsafe<Transform>(FirePoint);

		public static ref Transform RefFirePoint(this IGameEntity obj) => ref obj.GetValueUnsafe<Transform>(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirePoint(this IGameEntity obj, out Transform value) => obj.TryGetValueUnsafe(FirePoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFirePoint(this IGameEntity obj, Transform value) => obj.AddValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirePoint(this IGameEntity obj) => obj.HasValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirePoint(this IGameEntity obj) => obj.DelValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirePoint(this IGameEntity obj, Transform value) => obj.SetValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<IGameEntity> GetInteractAction(this IGameEntity obj) => obj.GetValueUnsafe<IAction<IGameEntity>>(InteractAction);

		public static ref IAction<IGameEntity> RefInteractAction(this IGameEntity obj) => ref obj.GetValueUnsafe<IAction<IGameEntity>>(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractAction(this IGameEntity obj, out IAction<IGameEntity> value) => obj.TryGetValueUnsafe(InteractAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractAction(this IGameEntity obj, IAction<IGameEntity> value) => obj.AddValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractAction(this IGameEntity obj) => obj.HasValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractAction(this IGameEntity obj) => obj.DelValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractAction(this IGameEntity obj, IAction<IGameEntity> value) => obj.SetValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IGameEntity> GetTargetInteractible(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(TargetInteractible);

		public static ref IReactiveVariable<IGameEntity> RefTargetInteractible(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetInteractible(this IGameEntity obj, out IReactiveVariable<IGameEntity> value) => obj.TryGetValueUnsafe(TargetInteractible, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetInteractible(this IGameEntity obj, IReactiveVariable<IGameEntity> value) => obj.AddValue(TargetInteractible, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetInteractible(this IGameEntity obj) => obj.HasValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetInteractible(this IGameEntity obj) => obj.DelValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetInteractible(this IGameEntity obj, IReactiveVariable<IGameEntity> value) => obj.SetValue(TargetInteractible, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IGameEntity> GetOwner(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(Owner);

		public static ref IReactiveVariable<IGameEntity> RefOwner(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetOwner(this IGameEntity obj, out IReactiveVariable<IGameEntity> value) => obj.TryGetValueUnsafe(Owner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddOwner(this IGameEntity obj, IReactiveVariable<IGameEntity> value) => obj.AddValue(Owner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasOwner(this IGameEntity obj) => obj.HasValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelOwner(this IGameEntity obj) => obj.DelValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetOwner(this IGameEntity obj, IReactiveVariable<IGameEntity> value) => obj.SetValue(Owner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveDictionary<string, Effect> GetEffects(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveDictionary<string, Effect>>(Effects);

		public static ref IReactiveDictionary<string, Effect> RefEffects(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveDictionary<string, Effect>>(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEffects(this IGameEntity obj, out IReactiveDictionary<string, Effect> value) => obj.TryGetValueUnsafe(Effects, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEffects(this IGameEntity obj, IReactiveDictionary<string, Effect> value) => obj.AddValue(Effects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEffects(this IGameEntity obj) => obj.HasValue(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEffects(this IGameEntity obj) => obj.DelValue(Effects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEffects(this IGameEntity obj, IReactiveDictionary<string, Effect> value) => obj.SetValue(Effects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EffectConfig[] GetProjectileEffects(this IGameEntity obj) => obj.GetValueUnsafe<EffectConfig[]>(ProjectileEffects);

		public static ref EffectConfig[] RefProjectileEffects(this IGameEntity obj) => ref obj.GetValueUnsafe<EffectConfig[]>(ProjectileEffects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetProjectileEffects(this IGameEntity obj, out EffectConfig[] value) => obj.TryGetValueUnsafe(ProjectileEffects, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddProjectileEffects(this IGameEntity obj, EffectConfig[] value) => obj.AddValue(ProjectileEffects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectileEffects(this IGameEntity obj) => obj.HasValue(ProjectileEffects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectileEffects(this IGameEntity obj) => obj.DelValue(ProjectileEffects);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetProjectileEffects(this IGameEntity obj, EffectConfig[] value) => obj.SetValue(ProjectileEffects, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity[] GetLoot(this IGameEntity obj) => obj.GetValueUnsafe<SceneEntity[]>(Loot);

		public static ref SceneEntity[] RefLoot(this IGameEntity obj) => ref obj.GetValueUnsafe<SceneEntity[]>(Loot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLoot(this IGameEntity obj, out SceneEntity[] value) => obj.TryGetValueUnsafe(Loot, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLoot(this IGameEntity obj, SceneEntity[] value) => obj.AddValue(Loot, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLoot(this IGameEntity obj) => obj.HasValue(Loot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLoot(this IGameEntity obj) => obj.DelValue(Loot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLoot(this IGameEntity obj, SceneEntity[] value) => obj.SetValue(Loot, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEventReceiver GetTrigger(this IGameEntity obj) => obj.GetValueUnsafe<TriggerEventReceiver>(Trigger);

		public static ref TriggerEventReceiver RefTrigger(this IGameEntity obj) => ref obj.GetValueUnsafe<TriggerEventReceiver>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IGameEntity obj, out TriggerEventReceiver value) => obj.TryGetValueUnsafe(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrigger(this IGameEntity obj, TriggerEventReceiver value) => obj.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IGameEntity obj) => obj.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IGameEntity obj) => obj.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IGameEntity obj, TriggerEventReceiver value) => obj.SetValue(Trigger, value);
    }
}
