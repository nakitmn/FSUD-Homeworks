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
    }
}
