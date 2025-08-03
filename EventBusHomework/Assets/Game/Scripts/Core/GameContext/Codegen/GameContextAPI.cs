/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Atomic.Events;
using Atomic.Elements;
using System.Collections.Generic;

namespace SampleGame
{
	public static class GameContextAPI
	{


		///Values
		public const int EventBus = -103062940; // IEventBus
		public const int EntityWorld = 1757640864; // IEntityWorld
		public const int GameBoard = -1386833193; // GameBoard
		public const int CurrentState = -386580614; // IReactiveVariable<GameState>
		public const int Turn = -2146256263; // IReactiveVariable<int>
		public const int Waves = 1316085542; // List<SpawnWave>


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEventBus GetEventBus(this IGameContext obj) => obj.GetValueUnsafe<IEventBus>(EventBus);

		public static ref IEventBus RefEventBus(this IGameContext obj) => ref obj.GetValueUnsafe<IEventBus>(EventBus);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEventBus(this IGameContext obj, out IEventBus value) => obj.TryGetValueUnsafe(EventBus, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEventBus(this IGameContext obj, IEventBus value) => obj.AddValue(EventBus, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEventBus(this IGameContext obj) => obj.HasValue(EventBus);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEventBus(this IGameContext obj) => obj.DelValue(EventBus);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEventBus(this IGameContext obj, IEventBus value) => obj.SetValue(EventBus, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntityWorld GetEntityWorld(this IGameContext obj) => obj.GetValueUnsafe<IEntityWorld>(EntityWorld);

		public static ref IEntityWorld RefEntityWorld(this IGameContext obj) => ref obj.GetValueUnsafe<IEntityWorld>(EntityWorld);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEntityWorld(this IGameContext obj, out IEntityWorld value) => obj.TryGetValueUnsafe(EntityWorld, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEntityWorld(this IGameContext obj, IEntityWorld value) => obj.AddValue(EntityWorld, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEntityWorld(this IGameContext obj) => obj.HasValue(EntityWorld);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEntityWorld(this IGameContext obj) => obj.DelValue(EntityWorld);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEntityWorld(this IGameContext obj, IEntityWorld value) => obj.SetValue(EntityWorld, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameBoard GetGameBoard(this IGameContext obj) => obj.GetValueUnsafe<GameBoard>(GameBoard);

		public static ref GameBoard RefGameBoard(this IGameContext obj) => ref obj.GetValueUnsafe<GameBoard>(GameBoard);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameBoard(this IGameContext obj, out GameBoard value) => obj.TryGetValueUnsafe(GameBoard, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameBoard(this IGameContext obj, GameBoard value) => obj.AddValue(GameBoard, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameBoard(this IGameContext obj) => obj.HasValue(GameBoard);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameBoard(this IGameContext obj) => obj.DelValue(GameBoard);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameBoard(this IGameContext obj, GameBoard value) => obj.SetValue(GameBoard, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<GameState> GetCurrentState(this IGameContext obj) => obj.GetValueUnsafe<IReactiveVariable<GameState>>(CurrentState);

		public static ref IReactiveVariable<GameState> RefCurrentState(this IGameContext obj) => ref obj.GetValueUnsafe<IReactiveVariable<GameState>>(CurrentState);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentState(this IGameContext obj, out IReactiveVariable<GameState> value) => obj.TryGetValueUnsafe(CurrentState, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentState(this IGameContext obj, IReactiveVariable<GameState> value) => obj.AddValue(CurrentState, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentState(this IGameContext obj) => obj.HasValue(CurrentState);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentState(this IGameContext obj) => obj.DelValue(CurrentState);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentState(this IGameContext obj, IReactiveVariable<GameState> value) => obj.SetValue(CurrentState, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetTurn(this IGameContext obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(Turn);

		public static ref IReactiveVariable<int> RefTurn(this IGameContext obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(Turn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTurn(this IGameContext obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(Turn, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTurn(this IGameContext obj, IReactiveVariable<int> value) => obj.AddValue(Turn, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTurn(this IGameContext obj) => obj.HasValue(Turn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTurn(this IGameContext obj) => obj.DelValue(Turn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTurn(this IGameContext obj, IReactiveVariable<int> value) => obj.SetValue(Turn, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<SpawnWave> GetWaves(this IGameContext obj) => obj.GetValueUnsafe<List<SpawnWave>>(Waves);

		public static ref List<SpawnWave> RefWaves(this IGameContext obj) => ref obj.GetValueUnsafe<List<SpawnWave>>(Waves);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWaves(this IGameContext obj, out List<SpawnWave> value) => obj.TryGetValueUnsafe(Waves, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWaves(this IGameContext obj, List<SpawnWave> value) => obj.AddValue(Waves, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWaves(this IGameContext obj) => obj.HasValue(Waves);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWaves(this IGameContext obj) => obj.DelValue(Waves);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWaves(this IGameContext obj, List<SpawnWave> value) => obj.SetValue(Waves, value);
    }
}
