/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;
using SampleGame;

namespace Game.View
{
	public static class ViewContextAPI
	{


		///Values
		public const int Camera = 1018227507; // Camera
		public const int AnimationQueue = -1133279405; // AnimationQueue
		public const int WorldView = -301363708; // EntityWorldView
		public const int GameBoardPresenter = 2061873695; // GameBoardPresenter
		public const int SelectedCharacter = 112705328; // IReactiveVariable<IGameEntity>
		public const int InputCondition = 1207100273; // IValue<bool>


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Camera GetCamera(this IViewContext obj) => obj.GetValueUnsafe<Camera>(Camera);

		public static ref Camera RefCamera(this IViewContext obj) => ref obj.GetValueUnsafe<Camera>(Camera);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCamera(this IViewContext obj, out Camera value) => obj.TryGetValueUnsafe(Camera, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCamera(this IViewContext obj, Camera value) => obj.AddValue(Camera, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCamera(this IViewContext obj) => obj.HasValue(Camera);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCamera(this IViewContext obj) => obj.DelValue(Camera);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCamera(this IViewContext obj, Camera value) => obj.SetValue(Camera, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AnimationQueue GetAnimationQueue(this IViewContext obj) => obj.GetValueUnsafe<AnimationQueue>(AnimationQueue);

		public static ref AnimationQueue RefAnimationQueue(this IViewContext obj) => ref obj.GetValueUnsafe<AnimationQueue>(AnimationQueue);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationQueue(this IViewContext obj, out AnimationQueue value) => obj.TryGetValueUnsafe(AnimationQueue, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimationQueue(this IViewContext obj, AnimationQueue value) => obj.AddValue(AnimationQueue, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationQueue(this IViewContext obj) => obj.HasValue(AnimationQueue);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationQueue(this IViewContext obj) => obj.DelValue(AnimationQueue);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationQueue(this IViewContext obj, AnimationQueue value) => obj.SetValue(AnimationQueue, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EntityWorldView GetWorldView(this IViewContext obj) => obj.GetValueUnsafe<EntityWorldView>(WorldView);

		public static ref EntityWorldView RefWorldView(this IViewContext obj) => ref obj.GetValueUnsafe<EntityWorldView>(WorldView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWorldView(this IViewContext obj, out EntityWorldView value) => obj.TryGetValueUnsafe(WorldView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWorldView(this IViewContext obj, EntityWorldView value) => obj.AddValue(WorldView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWorldView(this IViewContext obj) => obj.HasValue(WorldView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWorldView(this IViewContext obj) => obj.DelValue(WorldView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWorldView(this IViewContext obj, EntityWorldView value) => obj.SetValue(WorldView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameBoardPresenter GetGameBoardPresenter(this IViewContext obj) => obj.GetValueUnsafe<GameBoardPresenter>(GameBoardPresenter);

		public static ref GameBoardPresenter RefGameBoardPresenter(this IViewContext obj) => ref obj.GetValueUnsafe<GameBoardPresenter>(GameBoardPresenter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameBoardPresenter(this IViewContext obj, out GameBoardPresenter value) => obj.TryGetValueUnsafe(GameBoardPresenter, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGameBoardPresenter(this IViewContext obj, GameBoardPresenter value) => obj.AddValue(GameBoardPresenter, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameBoardPresenter(this IViewContext obj) => obj.HasValue(GameBoardPresenter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameBoardPresenter(this IViewContext obj) => obj.DelValue(GameBoardPresenter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameBoardPresenter(this IViewContext obj, GameBoardPresenter value) => obj.SetValue(GameBoardPresenter, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IGameEntity> GetSelectedCharacter(this IViewContext obj) => obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(SelectedCharacter);

		public static ref IReactiveVariable<IGameEntity> RefSelectedCharacter(this IViewContext obj) => ref obj.GetValueUnsafe<IReactiveVariable<IGameEntity>>(SelectedCharacter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSelectedCharacter(this IViewContext obj, out IReactiveVariable<IGameEntity> value) => obj.TryGetValueUnsafe(SelectedCharacter, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddSelectedCharacter(this IViewContext obj, IReactiveVariable<IGameEntity> value) => obj.AddValue(SelectedCharacter, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSelectedCharacter(this IViewContext obj) => obj.HasValue(SelectedCharacter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSelectedCharacter(this IViewContext obj) => obj.DelValue(SelectedCharacter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSelectedCharacter(this IViewContext obj, IReactiveVariable<IGameEntity> value) => obj.SetValue(SelectedCharacter, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<bool> GetInputCondition(this IViewContext obj) => obj.GetValueUnsafe<IValue<bool>>(InputCondition);

		public static ref IValue<bool> RefInputCondition(this IViewContext obj) => ref obj.GetValueUnsafe<IValue<bool>>(InputCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInputCondition(this IViewContext obj, out IValue<bool> value) => obj.TryGetValueUnsafe(InputCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInputCondition(this IViewContext obj, IValue<bool> value) => obj.AddValue(InputCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInputCondition(this IViewContext obj) => obj.HasValue(InputCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInputCondition(this IViewContext obj) => obj.DelValue(InputCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInputCondition(this IViewContext obj, IValue<bool> value) => obj.SetValue(InputCondition, value);
    }
}
