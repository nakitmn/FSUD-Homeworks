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
		public const int GameBoard = -1386833193; // GameBoard
		public const int GameBoardView = 1364106545; // GameBoardView
		public const int Turn = -2146256263; // IReactiveVariable<int>
		public const int SpawnPoints = -616390853; // List<GameBoardPosition>
		public const int SpawnCount = -1002427847; // IValue<int>
		public const int SpawnTurnRate = -547472981; // IValue<int>
		public const int EnemyPrefab = 926451090; // IValue<GameEntity>


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
		public static List<GameBoardPosition> GetSpawnPoints(this IGameContext obj) => obj.GetValueUnsafe<List<GameBoardPosition>>(SpawnPoints);

		public static ref List<GameBoardPosition> RefSpawnPoints(this IGameContext obj) => ref obj.GetValueUnsafe<List<GameBoardPosition>>(SpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpawnPoints(this IGameContext obj, out List<GameBoardPosition> value) => obj.TryGetValueUnsafe(SpawnPoints, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSpawnPoints(this IGameContext obj, List<GameBoardPosition> value) => obj.AddValue(SpawnPoints, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpawnPoints(this IGameContext obj) => obj.HasValue(SpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpawnPoints(this IGameContext obj) => obj.DelValue(SpawnPoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpawnPoints(this IGameContext obj, List<GameBoardPosition> value) => obj.SetValue(SpawnPoints, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetSpawnCount(this IGameContext obj) => obj.GetValueUnsafe<IValue<int>>(SpawnCount);

		public static ref IValue<int> RefSpawnCount(this IGameContext obj) => ref obj.GetValueUnsafe<IValue<int>>(SpawnCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpawnCount(this IGameContext obj, out IValue<int> value) => obj.TryGetValueUnsafe(SpawnCount, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSpawnCount(this IGameContext obj, IValue<int> value) => obj.AddValue(SpawnCount, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpawnCount(this IGameContext obj) => obj.HasValue(SpawnCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpawnCount(this IGameContext obj) => obj.DelValue(SpawnCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpawnCount(this IGameContext obj, IValue<int> value) => obj.SetValue(SpawnCount, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetSpawnTurnRate(this IGameContext obj) => obj.GetValueUnsafe<IValue<int>>(SpawnTurnRate);

		public static ref IValue<int> RefSpawnTurnRate(this IGameContext obj) => ref obj.GetValueUnsafe<IValue<int>>(SpawnTurnRate);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpawnTurnRate(this IGameContext obj, out IValue<int> value) => obj.TryGetValueUnsafe(SpawnTurnRate, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSpawnTurnRate(this IGameContext obj, IValue<int> value) => obj.AddValue(SpawnTurnRate, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpawnTurnRate(this IGameContext obj) => obj.HasValue(SpawnTurnRate);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpawnTurnRate(this IGameContext obj) => obj.DelValue(SpawnTurnRate);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpawnTurnRate(this IGameContext obj, IValue<int> value) => obj.SetValue(SpawnTurnRate, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<GameEntity> GetEnemyPrefab(this IGameContext obj) => obj.GetValueUnsafe<IValue<GameEntity>>(EnemyPrefab);

		public static ref IValue<GameEntity> RefEnemyPrefab(this IGameContext obj) => ref obj.GetValueUnsafe<IValue<GameEntity>>(EnemyPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEnemyPrefab(this IGameContext obj, out IValue<GameEntity> value) => obj.TryGetValueUnsafe(EnemyPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddEnemyPrefab(this IGameContext obj, IValue<GameEntity> value) => obj.AddValue(EnemyPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEnemyPrefab(this IGameContext obj) => obj.HasValue(EnemyPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEnemyPrefab(this IGameContext obj) => obj.DelValue(EnemyPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEnemyPrefab(this IGameContext obj, IValue<GameEntity> value) => obj.SetValue(EnemyPrefab, value);
    }
}
