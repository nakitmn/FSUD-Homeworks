/**
* Code generation. Don't modify! 
**/

using Atomic.Events;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Events;
using System;
using Atomic.Entities;

namespace Game.Core
{
	public static class EventAPI
	{
		///Events
		public const int StartPlayerTurn = -225180363;
		public const int EndPlayerTurn = -1841842288;
		public const int StartEnemyTurn = 1939014648;
		public const int EndEnemyTurn = 1622111079;
		public const int Spawned = -959104060;
		public const int Damaged = 326473335;
		public const int AttackStarted = 919964588;
		public const int AttackEnded = -1126054038;
		public const int Moved = 120431345;
		public const int PushedOut = -759371857;
		public const int PushedInTarget = -1011670209;
		public const int Pushed = -513447518;
		public const int Died = 543283834;


		///Event Extensions


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeStartPlayerTurn(this IEventBus bus) => bus.Dispose(StartPlayerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription SubscribeStartPlayerTurn(this IEventBus bus, Action action) => bus.Subscribe(StartPlayerTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeStartPlayerTurn(this IEventBus bus, Action action) => bus.Unsubscribe(StartPlayerTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeStartPlayerTurn(this IEventBus bus) => bus.Invoke(StartPlayerTurn);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedStartPlayerTurn(this IEventBus bus) => bus.IsSubscribed(StartPlayerTurn);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeEndPlayerTurn(this IEventBus bus) => bus.Dispose(EndPlayerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription SubscribeEndPlayerTurn(this IEventBus bus, Action action) => bus.Subscribe(EndPlayerTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeEndPlayerTurn(this IEventBus bus, Action action) => bus.Unsubscribe(EndPlayerTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeEndPlayerTurn(this IEventBus bus) => bus.Invoke(EndPlayerTurn);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedEndPlayerTurn(this IEventBus bus) => bus.IsSubscribed(EndPlayerTurn);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeStartEnemyTurn(this IEventBus bus) => bus.Dispose(StartEnemyTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription SubscribeStartEnemyTurn(this IEventBus bus, Action action) => bus.Subscribe(StartEnemyTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeStartEnemyTurn(this IEventBus bus, Action action) => bus.Unsubscribe(StartEnemyTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeStartEnemyTurn(this IEventBus bus) => bus.Invoke(StartEnemyTurn);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedStartEnemyTurn(this IEventBus bus) => bus.IsSubscribed(StartEnemyTurn);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeEndEnemyTurn(this IEventBus bus) => bus.Dispose(EndEnemyTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription SubscribeEndEnemyTurn(this IEventBus bus, Action action) => bus.Subscribe(EndEnemyTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeEndEnemyTurn(this IEventBus bus, Action action) => bus.Unsubscribe(EndEnemyTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeEndEnemyTurn(this IEventBus bus) => bus.Invoke(EndEnemyTurn);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedEndEnemyTurn(this IEventBus bus) => bus.IsSubscribed(EndEnemyTurn);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeSpawned(this IEventBus bus) => bus.Dispose(Spawned);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IGameEntity, GameBoardPosition> SubscribeSpawned(this IEventBus bus, Action<IGameEntity, GameBoardPosition> action) => bus.Subscribe(Spawned, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeSpawned(this IEventBus bus, Action<IGameEntity, GameBoardPosition> action) => bus.Unsubscribe(Spawned, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeSpawned(this IEventBus bus, IGameEntity entity, GameBoardPosition position) => bus.Invoke(Spawned, entity, position);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedSpawned(this IEventBus bus) => bus.IsSubscribed(Spawned);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeDamaged(this IEventBus bus) => bus.Dispose(Damaged);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IGameEntity, int> SubscribeDamaged(this IEventBus bus, Action<IGameEntity, int> action) => bus.Subscribe(Damaged, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeDamaged(this IEventBus bus, Action<IGameEntity, int> action) => bus.Unsubscribe(Damaged, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeDamaged(this IEventBus bus, IGameEntity target, int damage) => bus.Invoke(Damaged, target, damage);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedDamaged(this IEventBus bus) => bus.IsSubscribed(Damaged);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeAttackStarted(this IEventBus bus) => bus.Dispose(AttackStarted);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<AttackEventData> SubscribeAttackStarted(this IEventBus bus, Action<AttackEventData> action) => bus.Subscribe(AttackStarted, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeAttackStarted(this IEventBus bus, Action<AttackEventData> action) => bus.Unsubscribe(AttackStarted, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeAttackStarted(this IEventBus bus, AttackEventData eventData) => bus.Invoke(AttackStarted, eventData);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedAttackStarted(this IEventBus bus) => bus.IsSubscribed(AttackStarted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeAttackEnded(this IEventBus bus) => bus.Dispose(AttackEnded);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<AttackEventData> SubscribeAttackEnded(this IEventBus bus, Action<AttackEventData> action) => bus.Subscribe(AttackEnded, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeAttackEnded(this IEventBus bus, Action<AttackEventData> action) => bus.Unsubscribe(AttackEnded, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeAttackEnded(this IEventBus bus, AttackEventData eventData) => bus.Invoke(AttackEnded, eventData);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedAttackEnded(this IEventBus bus) => bus.IsSubscribed(AttackEnded);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeMoved(this IEventBus bus) => bus.Dispose(Moved);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IGameEntity, GameBoardPosition> SubscribeMoved(this IEventBus bus, Action<IGameEntity, GameBoardPosition> action) => bus.Subscribe(Moved, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeMoved(this IEventBus bus, Action<IGameEntity, GameBoardPosition> action) => bus.Unsubscribe(Moved, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeMoved(this IEventBus bus, IGameEntity target, GameBoardPosition position) => bus.Invoke(Moved, target, position);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedMoved(this IEventBus bus) => bus.IsSubscribed(Moved);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposePushedOut(this IEventBus bus) => bus.Dispose(PushedOut);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IGameEntity, GameBoardPosition, Vector2Int> SubscribePushedOut(this IEventBus bus, Action<IGameEntity, GameBoardPosition, Vector2Int> action) => bus.Subscribe(PushedOut, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribePushedOut(this IEventBus bus, Action<IGameEntity, GameBoardPosition, Vector2Int> action) => bus.Unsubscribe(PushedOut, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokePushedOut(this IEventBus bus, IGameEntity target, GameBoardPosition startPosition, Vector2Int pushDirection) => bus.Invoke(PushedOut, target, startPosition, pushDirection);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedPushedOut(this IEventBus bus) => bus.IsSubscribed(PushedOut);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposePushedInTarget(this IEventBus bus) => bus.Dispose(PushedInTarget);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<PushInTargetEventData> SubscribePushedInTarget(this IEventBus bus, Action<PushInTargetEventData> action) => bus.Subscribe(PushedInTarget, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribePushedInTarget(this IEventBus bus, Action<PushInTargetEventData> action) => bus.Unsubscribe(PushedInTarget, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokePushedInTarget(this IEventBus bus, PushInTargetEventData pushData) => bus.Invoke(PushedInTarget, pushData);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedPushedInTarget(this IEventBus bus) => bus.IsSubscribed(PushedInTarget);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposePushed(this IEventBus bus) => bus.Dispose(Pushed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IGameEntity, GameBoardPosition, Vector2Int> SubscribePushed(this IEventBus bus, Action<IGameEntity, GameBoardPosition, Vector2Int> action) => bus.Subscribe(Pushed, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribePushed(this IEventBus bus, Action<IGameEntity, GameBoardPosition, Vector2Int> action) => bus.Unsubscribe(Pushed, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokePushed(this IEventBus bus, IGameEntity target, GameBoardPosition startPosition, Vector2Int pushDirection) => bus.Invoke(Pushed, target, startPosition, pushDirection);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedPushed(this IEventBus bus) => bus.IsSubscribed(Pushed);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeDied(this IEventBus bus) => bus.Dispose(Died);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IGameEntity> SubscribeDied(this IEventBus bus, Action<IGameEntity> action) => bus.Subscribe(Died, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeDied(this IEventBus bus, Action<IGameEntity> action) => bus.Unsubscribe(Died, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeDied(this IEventBus bus, IGameEntity target) => bus.Invoke(Died, target);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedDied(this IEventBus bus) => bus.IsSubscribed(Died);
    }
}
