/**
* Code generation. Don't modify! 
**/

using Atomic.Events;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Events;
using System;
using Atomic.Entities;

namespace SampleGame
{
	public static class EventAPI
	{
		///Events
		public const int StartTurn = 1138966150;
		public const int EndTurn = 1950703458;
		public const int Damaged = 326473335;
		public const int Attack = 1080829965;
		public const int Moved = 120431345;
		public const int PushedOut = -759371857;
		public const int PushedInTarget = -1011670209;
		public const int Pushed = -513447518;
		public const int Died = 543283834;


		///Event Extensions


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeStartTurn(this IEventBus bus) => bus.Dispose(StartTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription SubscribeStartTurn(this IEventBus bus, Action action) => bus.Subscribe(StartTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeStartTurn(this IEventBus bus, Action action) => bus.Unsubscribe(StartTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeStartTurn(this IEventBus bus) => bus.Invoke(StartTurn);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedStartTurn(this IEventBus bus) => bus.IsSubscribed(StartTurn);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeEndTurn(this IEventBus bus) => bus.Dispose(EndTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription SubscribeEndTurn(this IEventBus bus, Action action) => bus.Subscribe(EndTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeEndTurn(this IEventBus bus, Action action) => bus.Unsubscribe(EndTurn, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeEndTurn(this IEventBus bus) => bus.Invoke(EndTurn);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedEndTurn(this IEventBus bus) => bus.IsSubscribed(EndTurn);


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
		public static bool DisposeAttack(this IEventBus bus) => bus.Dispose(Attack);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IGameEntity, IGameEntity> SubscribeAttack(this IEventBus bus, Action<IGameEntity, IGameEntity> action) => bus.Subscribe(Attack, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeAttack(this IEventBus bus, Action<IGameEntity, IGameEntity> action) => bus.Unsubscribe(Attack, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeAttack(this IEventBus bus, IGameEntity target, IGameEntity source) => bus.Invoke(Attack, target, source);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedAttack(this IEventBus bus) => bus.IsSubscribed(Attack);


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
		public static Subscription<IGameEntity, IGameEntity> SubscribePushedInTarget(this IEventBus bus, Action<IGameEntity, IGameEntity> action) => bus.Subscribe(PushedInTarget, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribePushedInTarget(this IEventBus bus, Action<IGameEntity, IGameEntity> action) => bus.Unsubscribe(PushedInTarget, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokePushedInTarget(this IEventBus bus, IGameEntity pushedEntity, IGameEntity targetEntity) => bus.Invoke(PushedInTarget, pushedEntity, targetEntity);
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
