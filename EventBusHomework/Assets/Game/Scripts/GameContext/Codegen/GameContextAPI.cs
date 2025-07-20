/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Atomic.Events;

namespace SampleGame
{
	public static class GameContextAPI
	{


		///Values
		public const int EventBus = -103062940; // IEventBus
		public const int GameBoard = -1386833193; // GameBoard
		public const int GameBoardView = 1364106545; // GameBoardView


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
		public static GameBoardView GetGameBoardView(this IGameContext obj) => obj.GetValueUnsafe<GameBoardView>(GameBoardView);

		public static ref GameBoardView RefGameBoardView(this IGameContext obj) => ref obj.GetValueUnsafe<GameBoardView>(GameBoardView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameBoardView(this IGameContext obj, out GameBoardView value) => obj.TryGetValueUnsafe(GameBoardView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameBoardView(this IGameContext obj, GameBoardView value) => obj.AddValue(GameBoardView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameBoardView(this IGameContext obj) => obj.HasValue(GameBoardView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameBoardView(this IGameContext obj) => obj.DelValue(GameBoardView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameBoardView(this IGameContext obj, GameBoardView value) => obj.SetValue(GameBoardView, value);
    }
}
