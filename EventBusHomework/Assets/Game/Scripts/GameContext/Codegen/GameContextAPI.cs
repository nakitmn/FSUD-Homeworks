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
		public const int AnimationQueue = -1133279405; // AnimationQueue
		public const int Camera = 1018227507; // Camera
		public const int SelectedCharacter = 112705328; // IReactiveVariable<IGameEntity>
		public const int Characters = 1970553566; // IGameEntity[]
		public const int CurrentState = -386580614; // IReactiveVariable<GameState>
		public const int InputCondition = 1207100273; // IValue<bool>
		public const int GameBoard = -1386833193; // GameBoard
		public const int GameBoardView = 1364106545; // GameBoardView
		public const int Turn = -2146256263; // IReactiveVariable<int>
		public const int Waves = 1316085542; // List<SpawnWave>
		public const int Enemies = -1212189790; // List<IGameEntity>


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
		public static AnimationQueue GetAnimationQueue(this IGameContext obj) => obj.GetValueUnsafe<AnimationQueue>(AnimationQueue);

		public static ref AnimationQueue RefAnimationQueue(this IGameContext obj) => ref obj.GetValueUnsafe<AnimationQueue>(AnimationQueue);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationQueue(this IGameContext obj, out AnimationQueue value) => obj.TryGetValueUnsafe(AnimationQueue, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimationQueue(this IGameContext obj, AnimationQueue value) => obj.AddValue(AnimationQueue, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationQueue(this IGameContext obj) => obj.HasValue(AnimationQueue);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationQueue(this IGameContext obj) => obj.DelValue(AnimationQueue);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationQueue(this IGameContext obj, AnimationQueue value) => obj.SetValue(AnimationQueue, value);

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
		public static IReactiveVariable<IGameEntity> GetSelectedCharacter(this IGameContext obj) => obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(SelectedCharacter);

		public static ref IReactiveVariable<IGameEntity> RefSelectedCharacter(this IGameContext obj) => ref obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(SelectedCharacter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSelectedCharacter(this IGameContext obj, out IReactiveVariable<IGameEntity> value) => obj.TryGetValueUnsafe(SelectedCharacter, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSelectedCharacter(this IGameContext obj, IReactiveVariable<IGameEntity> value) => obj.AddValue(SelectedCharacter, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSelectedCharacter(this IGameContext obj) => obj.HasValue(SelectedCharacter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSelectedCharacter(this IGameContext obj) => obj.DelValue(SelectedCharacter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSelectedCharacter(this IGameContext obj, IReactiveVariable<IGameEntity> value) => obj.SetValue(SelectedCharacter, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IGameEntity[] GetCharacters(this IGameContext obj) => obj.GetValueUnsafe<IGameEntity[]>(Characters);

		public static ref IGameEntity[] RefCharacters(this IGameContext obj) => ref obj.GetValueUnsafe<IGameEntity[]>(Characters);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacters(this IGameContext obj, out IGameEntity[] value) => obj.TryGetValueUnsafe(Characters, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharacters(this IGameContext obj, IGameEntity[] value) => obj.AddValue(Characters, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacters(this IGameContext obj) => obj.HasValue(Characters);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacters(this IGameContext obj) => obj.DelValue(Characters);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacters(this IGameContext obj, IGameEntity[] value) => obj.SetValue(Characters, value);

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
		public static IValue<bool> GetInputCondition(this IGameContext obj) => obj.GetValueUnsafe<IValue<bool>>(InputCondition);

		public static ref IValue<bool> RefInputCondition(this IGameContext obj) => ref obj.GetValueUnsafe<IValue<bool>>(InputCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInputCondition(this IGameContext obj, out IValue<bool> value) => obj.TryGetValueUnsafe(InputCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInputCondition(this IGameContext obj, IValue<bool> value) => obj.AddValue(InputCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInputCondition(this IGameContext obj) => obj.HasValue(InputCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInputCondition(this IGameContext obj) => obj.DelValue(InputCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInputCondition(this IGameContext obj, IValue<bool> value) => obj.SetValue(InputCondition, value);

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<IGameEntity> GetEnemies(this IGameContext obj) => obj.GetValueUnsafe<List<IGameEntity>>(Enemies);

		public static ref List<IGameEntity> RefEnemies(this IGameContext obj) => ref obj.GetValueUnsafe<List<IGameEntity>>(Enemies);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEnemies(this IGameContext obj, out List<IGameEntity> value) => obj.TryGetValueUnsafe(Enemies, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEnemies(this IGameContext obj, List<IGameEntity> value) => obj.AddValue(Enemies, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEnemies(this IGameContext obj) => obj.HasValue(Enemies);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEnemies(this IGameContext obj) => obj.DelValue(Enemies);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEnemies(this IGameContext obj, List<IGameEntity> value) => obj.SetValue(Enemies, value);
    }
}
