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
		public const int Hello = -137262718;
		public const int Attack = 1080829965;
		public const int PostAttack = 303188910;


		///Event Extensions


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeHello(this IEventBus bus) => bus.Dispose(Hello);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription SubscribeHello(this IEventBus bus, Action action) => bus.Subscribe(Hello, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeHello(this IEventBus bus, Action action) => bus.Unsubscribe(Hello, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeHello(this IEventBus bus) => bus.Invoke(Hello);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedHello(this IEventBus bus) => bus.IsSubscribed(Hello);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposeAttack(this IEventBus bus) => bus.Dispose(Attack);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IEntity, IEntity> SubscribeAttack(this IEventBus bus, Action<IEntity, IEntity> action) => bus.Subscribe(Attack, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeAttack(this IEventBus bus, Action<IEntity, IEntity> action) => bus.Unsubscribe(Attack, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokeAttack(this IEventBus bus, IEntity source, IEntity target) => bus.Invoke(Attack, source, target);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedAttack(this IEventBus bus) => bus.IsSubscribed(Attack);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DisposePostAttack(this IEventBus bus) => bus.Dispose(PostAttack);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Subscription<IEntity, IEntity> SubscribePostAttack(this IEventBus bus, Action<IEntity, IEntity> action) => bus.Subscribe(PostAttack, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribePostAttack(this IEventBus bus, Action<IEntity, IEntity> action) => bus.Unsubscribe(PostAttack, action);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvokePostAttack(this IEventBus bus, IEntity source, IEntity target) => bus.Invoke(PostAttack, source, target);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSubscribedPostAttack(this IEventBus bus) => bus.IsSubscribed(PostAttack);
    }
}
