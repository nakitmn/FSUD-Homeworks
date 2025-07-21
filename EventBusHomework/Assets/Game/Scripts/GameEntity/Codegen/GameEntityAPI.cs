/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;

namespace SampleGame
{
	public static class GameEntityAPI
	{
		///Tags
		public const int Character = 294335127;
		public const int Enemy = 979269037;
		public const int Cell = 1807034588;
		public const int Pushable = -1762021740;


		///Values
		public const int GameObject = 1482111001; // GameObject
		public const int Transform = -180157682; // Transform
		public const int Health = -915003867; // int
		public const int Damage = 375673178; // int
		public const int AttackRange = 2128890732; // IValue<int>
		public const int DefaultMaterial = -1950312091; // IReactiveVariable<Material>
		public const int HighlightedMaterial = 2021817643; // IReactiveVariable<Material>
		public const int CurrentMaterial = -750236251; // IReactiveVariable<Material>
		public const int BoardPosition = 812778532; // IReactiveVariable<GameBoardPosition>
		public const int MoveRange = -2080720063; // IValue<int>
		public const int MaxMovesPerTurn = -348710637; // IValue<int>
		public const int CurrentMovesCount = 254840857; // IReactiveVariable<int>
		public const int MaxAttacksPerTurn = 1469536621; // IValue<int>
		public const int CurrentAttacksCount = 887529444; // IReactiveVariable<int>
		public const int Target = 1103309514; // IReactiveVariable<IGameEntity>


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IGameEntity obj) => obj.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IGameEntity obj) => obj.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IGameEntity obj) => obj.DelTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEnemyTag(this IGameEntity obj) => obj.HasTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddEnemyTag(this IGameEntity obj) => obj.AddTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEnemyTag(this IGameEntity obj) => obj.DelTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCellTag(this IGameEntity obj) => obj.HasTag(Cell);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCellTag(this IGameEntity obj) => obj.AddTag(Cell);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCellTag(this IGameEntity obj) => obj.DelTag(Cell);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPushableTag(this IGameEntity obj) => obj.HasTag(Pushable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPushableTag(this IGameEntity obj) => obj.AddTag(Pushable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPushableTag(this IGameEntity obj) => obj.DelTag(Pushable);


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
		public static int GetHealth(this IGameEntity obj) => obj.GetValueUnsafe<int>(Health);

		public static ref int RefHealth(this IGameEntity obj) => ref obj.GetValueUnsafe<int>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameEntity obj, out int value) => obj.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IGameEntity obj, int value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameEntity obj, int value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDamage(this IGameEntity obj) => obj.GetValueUnsafe<int>(Damage);

		public static ref int RefDamage(this IGameEntity obj) => ref obj.GetValueUnsafe<int>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IGameEntity obj, out int value) => obj.TryGetValueUnsafe(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IGameEntity obj, int value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IGameEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IGameEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IGameEntity obj, int value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetAttackRange(this IGameEntity obj) => obj.GetValueUnsafe<IValue<int>>(AttackRange);

		public static ref IValue<int> RefAttackRange(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackRange(this IGameEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(AttackRange, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackRange(this IGameEntity obj, IValue<int> value) => obj.AddValue(AttackRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackRange(this IGameEntity obj) => obj.HasValue(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackRange(this IGameEntity obj) => obj.DelValue(AttackRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackRange(this IGameEntity obj, IValue<int> value) => obj.SetValue(AttackRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Material> GetDefaultMaterial(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Material>>(DefaultMaterial);

		public static ref IReactiveVariable<Material> RefDefaultMaterial(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Material>>(DefaultMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDefaultMaterial(this IGameEntity obj, out IReactiveVariable<Material> value) => obj.TryGetValueUnsafe(DefaultMaterial, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDefaultMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.AddValue(DefaultMaterial, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDefaultMaterial(this IGameEntity obj) => obj.HasValue(DefaultMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDefaultMaterial(this IGameEntity obj) => obj.DelValue(DefaultMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDefaultMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.SetValue(DefaultMaterial, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Material> GetHighlightedMaterial(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Material>>(HighlightedMaterial);

		public static ref IReactiveVariable<Material> RefHighlightedMaterial(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Material>>(HighlightedMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHighlightedMaterial(this IGameEntity obj, out IReactiveVariable<Material> value) => obj.TryGetValueUnsafe(HighlightedMaterial, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHighlightedMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.AddValue(HighlightedMaterial, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHighlightedMaterial(this IGameEntity obj) => obj.HasValue(HighlightedMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHighlightedMaterial(this IGameEntity obj) => obj.DelValue(HighlightedMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHighlightedMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.SetValue(HighlightedMaterial, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Material> GetCurrentMaterial(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<Material>>(CurrentMaterial);

		public static ref IReactiveVariable<Material> RefCurrentMaterial(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<Material>>(CurrentMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentMaterial(this IGameEntity obj, out IReactiveVariable<Material> value) => obj.TryGetValueUnsafe(CurrentMaterial, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.AddValue(CurrentMaterial, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentMaterial(this IGameEntity obj) => obj.HasValue(CurrentMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentMaterial(this IGameEntity obj) => obj.DelValue(CurrentMaterial);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentMaterial(this IGameEntity obj, IReactiveVariable<Material> value) => obj.SetValue(CurrentMaterial, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<GameBoardPosition> GetBoardPosition(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<GameBoardPosition>>(BoardPosition);

		public static ref IReactiveVariable<GameBoardPosition> RefBoardPosition(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<GameBoardPosition>>(BoardPosition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBoardPosition(this IGameEntity obj, out IReactiveVariable<GameBoardPosition> value) => obj.TryGetValueUnsafe(BoardPosition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBoardPosition(this IGameEntity obj, IReactiveVariable<GameBoardPosition> value) => obj.AddValue(BoardPosition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBoardPosition(this IGameEntity obj) => obj.HasValue(BoardPosition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBoardPosition(this IGameEntity obj) => obj.DelValue(BoardPosition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBoardPosition(this IGameEntity obj, IReactiveVariable<GameBoardPosition> value) => obj.SetValue(BoardPosition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMoveRange(this IGameEntity obj) => obj.GetValueUnsafe<IValue<int>>(MoveRange);

		public static ref IValue<int> RefMoveRange(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(MoveRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRange(this IGameEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(MoveRange, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRange(this IGameEntity obj, IValue<int> value) => obj.AddValue(MoveRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRange(this IGameEntity obj) => obj.HasValue(MoveRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRange(this IGameEntity obj) => obj.DelValue(MoveRange);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRange(this IGameEntity obj, IValue<int> value) => obj.SetValue(MoveRange, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxMovesPerTurn(this IGameEntity obj) => obj.GetValueUnsafe<IValue<int>>(MaxMovesPerTurn);

		public static ref IValue<int> RefMaxMovesPerTurn(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(MaxMovesPerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxMovesPerTurn(this IGameEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(MaxMovesPerTurn, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxMovesPerTurn(this IGameEntity obj, IValue<int> value) => obj.AddValue(MaxMovesPerTurn, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxMovesPerTurn(this IGameEntity obj) => obj.HasValue(MaxMovesPerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxMovesPerTurn(this IGameEntity obj) => obj.DelValue(MaxMovesPerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxMovesPerTurn(this IGameEntity obj, IValue<int> value) => obj.SetValue(MaxMovesPerTurn, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetCurrentMovesCount(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentMovesCount);

		public static ref IReactiveVariable<int> RefCurrentMovesCount(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentMovesCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentMovesCount(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(CurrentMovesCount, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentMovesCount(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(CurrentMovesCount, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentMovesCount(this IGameEntity obj) => obj.HasValue(CurrentMovesCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentMovesCount(this IGameEntity obj) => obj.DelValue(CurrentMovesCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentMovesCount(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(CurrentMovesCount, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxAttacksPerTurn(this IGameEntity obj) => obj.GetValueUnsafe<IValue<int>>(MaxAttacksPerTurn);

		public static ref IValue<int> RefMaxAttacksPerTurn(this IGameEntity obj) => ref obj.GetValueUnsafe<IValue<int>>(MaxAttacksPerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxAttacksPerTurn(this IGameEntity obj, out IValue<int> value) => obj.TryGetValueUnsafe(MaxAttacksPerTurn, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxAttacksPerTurn(this IGameEntity obj, IValue<int> value) => obj.AddValue(MaxAttacksPerTurn, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxAttacksPerTurn(this IGameEntity obj) => obj.HasValue(MaxAttacksPerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxAttacksPerTurn(this IGameEntity obj) => obj.DelValue(MaxAttacksPerTurn);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxAttacksPerTurn(this IGameEntity obj, IValue<int> value) => obj.SetValue(MaxAttacksPerTurn, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetCurrentAttacksCount(this IGameEntity obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentAttacksCount);

		public static ref IReactiveVariable<int> RefCurrentAttacksCount(this IGameEntity obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(CurrentAttacksCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentAttacksCount(this IGameEntity obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(CurrentAttacksCount, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCurrentAttacksCount(this IGameEntity obj, IReactiveVariable<int> value) => obj.AddValue(CurrentAttacksCount, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentAttacksCount(this IGameEntity obj) => obj.HasValue(CurrentAttacksCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentAttacksCount(this IGameEntity obj) => obj.DelValue(CurrentAttacksCount);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentAttacksCount(this IGameEntity obj, IReactiveVariable<int> value) => obj.SetValue(CurrentAttacksCount, value);

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
    }
}
