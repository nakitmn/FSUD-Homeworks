/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Elements;

namespace SampleGame
{
	public static class AbilityAPI
	{
		///Tags
		public const int Base = 1619415391;
		public const int Point = 1986321440;
		public const int Target = 1103309514;


		///Values
		public const int BaseAction = 942602042; // IAction
		public const int BaseCondition = -395139187; // IFunction<bool>
		public const int BaseEvent = -1277683221; // IEvent
		public const int TargetPoint = 1623536989; // IReactiveVariable<Vector3>
		public const int PointAction = -269391236; // IAction<Vector3>
		public const int PointCondition = 1323724090; // IFunction<Vector3, bool>
		public const int PointEvent = 1637331210; // IEvent<Vector3>
		public const int TargetAction = 1858217420; // IAction<IEntity>
		public const int TargetCondition = 1133093239; // IFunction<IEntity, bool>
		public const int TargetEvent = -321991458; // IEvent<IEntity>
		public const int Charges = -179148410; // IReactiveVariable<int>
		public const int ManaCost = -175662323; // IValue<int>
		public const int Radius = 1020291948; // IValue<float>
		public const int Cooldown = 655707791; // Cooldown
		public const int Delay = 1935388575; // Cooldown
		public const int IsRunning = -887662580; // IReactiveVariable<bool>
		public const int Icon = -978942235; // Sprite


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBaseTag(this Ability obj) => obj.HasTag(Base);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBaseTag(this Ability obj) => obj.AddTag(Base);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBaseTag(this Ability obj) => obj.DelTag(Base);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPointTag(this Ability obj) => obj.HasTag(Point);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPointTag(this Ability obj) => obj.AddTag(Point);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPointTag(this Ability obj) => obj.DelTag(Point);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetTag(this Ability obj) => obj.HasTag(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTargetTag(this Ability obj) => obj.AddTag(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetTag(this Ability obj) => obj.DelTag(Target);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetBaseAction(this Ability obj) => obj.GetValueUnsafe<IAction>(BaseAction);

		public static ref IAction RefBaseAction(this Ability obj) => ref obj.GetValueUnsafe<IAction>(BaseAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBaseAction(this Ability obj, out IAction value) => obj.TryGetValueUnsafe(BaseAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBaseAction(this Ability obj, IAction value) => obj.AddValue(BaseAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBaseAction(this Ability obj) => obj.HasValue(BaseAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBaseAction(this Ability obj) => obj.DelValue(BaseAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBaseAction(this Ability obj, IAction value) => obj.SetValue(BaseAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IFunction<bool> GetBaseCondition(this Ability obj) => obj.GetValueUnsafe<IFunction<bool>>(BaseCondition);

		public static ref IFunction<bool> RefBaseCondition(this Ability obj) => ref obj.GetValueUnsafe<IFunction<bool>>(BaseCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBaseCondition(this Ability obj, out IFunction<bool> value) => obj.TryGetValueUnsafe(BaseCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBaseCondition(this Ability obj, IFunction<bool> value) => obj.AddValue(BaseCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBaseCondition(this Ability obj) => obj.HasValue(BaseCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBaseCondition(this Ability obj) => obj.DelValue(BaseCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBaseCondition(this Ability obj, IFunction<bool> value) => obj.SetValue(BaseCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetBaseEvent(this Ability obj) => obj.GetValueUnsafe<IEvent>(BaseEvent);

		public static ref IEvent RefBaseEvent(this Ability obj) => ref obj.GetValueUnsafe<IEvent>(BaseEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBaseEvent(this Ability obj, out IEvent value) => obj.TryGetValueUnsafe(BaseEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBaseEvent(this Ability obj, IEvent value) => obj.AddValue(BaseEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBaseEvent(this Ability obj) => obj.HasValue(BaseEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBaseEvent(this Ability obj) => obj.DelValue(BaseEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBaseEvent(this Ability obj, IEvent value) => obj.SetValue(BaseEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetTargetPoint(this Ability obj) => obj.GetValueUnsafe<IReactiveVariable<Vector3>>(TargetPoint);

		public static ref IReactiveVariable<Vector3> RefTargetPoint(this Ability obj) => ref obj.GetValueUnsafe<IReactiveVariable<Vector3>>(TargetPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetPoint(this Ability obj, out IReactiveVariable<Vector3> value) => obj.TryGetValueUnsafe(TargetPoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetPoint(this Ability obj, IReactiveVariable<Vector3> value) => obj.AddValue(TargetPoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetPoint(this Ability obj) => obj.HasValue(TargetPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetPoint(this Ability obj) => obj.DelValue(TargetPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetPoint(this Ability obj, IReactiveVariable<Vector3> value) => obj.SetValue(TargetPoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3> GetPointAction(this Ability obj) => obj.GetValueUnsafe<IAction<Vector3>>(PointAction);

		public static ref IAction<Vector3> RefPointAction(this Ability obj) => ref obj.GetValueUnsafe<IAction<Vector3>>(PointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPointAction(this Ability obj, out IAction<Vector3> value) => obj.TryGetValueUnsafe(PointAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPointAction(this Ability obj, IAction<Vector3> value) => obj.AddValue(PointAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPointAction(this Ability obj) => obj.HasValue(PointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPointAction(this Ability obj) => obj.DelValue(PointAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPointAction(this Ability obj, IAction<Vector3> value) => obj.SetValue(PointAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IFunction<Vector3, bool> GetPointCondition(this Ability obj) => obj.GetValueUnsafe<IFunction<Vector3, bool>>(PointCondition);

		public static ref IFunction<Vector3, bool> RefPointCondition(this Ability obj) => ref obj.GetValueUnsafe<IFunction<Vector3, bool>>(PointCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPointCondition(this Ability obj, out IFunction<Vector3, bool> value) => obj.TryGetValueUnsafe(PointCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPointCondition(this Ability obj, IFunction<Vector3, bool> value) => obj.AddValue(PointCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPointCondition(this Ability obj) => obj.HasValue(PointCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPointCondition(this Ability obj) => obj.DelValue(PointCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPointCondition(this Ability obj, IFunction<Vector3, bool> value) => obj.SetValue(PointCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetPointEvent(this Ability obj) => obj.GetValueUnsafe<IEvent<Vector3>>(PointEvent);

		public static ref IEvent<Vector3> RefPointEvent(this Ability obj) => ref obj.GetValueUnsafe<IEvent<Vector3>>(PointEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPointEvent(this Ability obj, out IEvent<Vector3> value) => obj.TryGetValueUnsafe(PointEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPointEvent(this Ability obj, IEvent<Vector3> value) => obj.AddValue(PointEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPointEvent(this Ability obj) => obj.HasValue(PointEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPointEvent(this Ability obj) => obj.DelValue(PointEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPointEvent(this Ability obj, IEvent<Vector3> value) => obj.SetValue(PointEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<IEntity> GetTargetAction(this Ability obj) => obj.GetValueUnsafe<IAction<IEntity>>(TargetAction);

		public static ref IAction<IEntity> RefTargetAction(this Ability obj) => ref obj.GetValueUnsafe<IAction<IEntity>>(TargetAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetAction(this Ability obj, out IAction<IEntity> value) => obj.TryGetValueUnsafe(TargetAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetAction(this Ability obj, IAction<IEntity> value) => obj.AddValue(TargetAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetAction(this Ability obj) => obj.HasValue(TargetAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetAction(this Ability obj) => obj.DelValue(TargetAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetAction(this Ability obj, IAction<IEntity> value) => obj.SetValue(TargetAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IFunction<IEntity, bool> GetTargetCondition(this Ability obj) => obj.GetValueUnsafe<IFunction<IEntity, bool>>(TargetCondition);

		public static ref IFunction<IEntity, bool> RefTargetCondition(this Ability obj) => ref obj.GetValueUnsafe<IFunction<IEntity, bool>>(TargetCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetCondition(this Ability obj, out IFunction<IEntity, bool> value) => obj.TryGetValueUnsafe(TargetCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetCondition(this Ability obj, IFunction<IEntity, bool> value) => obj.AddValue(TargetCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetCondition(this Ability obj) => obj.HasValue(TargetCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetCondition(this Ability obj) => obj.DelValue(TargetCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetCondition(this Ability obj, IFunction<IEntity, bool> value) => obj.SetValue(TargetCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<IEntity> GetTargetEvent(this Ability obj) => obj.GetValueUnsafe<IEvent<IEntity>>(TargetEvent);

		public static ref IEvent<IEntity> RefTargetEvent(this Ability obj) => ref obj.GetValueUnsafe<IEvent<IEntity>>(TargetEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetEvent(this Ability obj, out IEvent<IEntity> value) => obj.TryGetValueUnsafe(TargetEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTargetEvent(this Ability obj, IEvent<IEntity> value) => obj.AddValue(TargetEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetEvent(this Ability obj) => obj.HasValue(TargetEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetEvent(this Ability obj) => obj.DelValue(TargetEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetEvent(this Ability obj, IEvent<IEntity> value) => obj.SetValue(TargetEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetCharges(this Ability obj) => obj.GetValueUnsafe<IReactiveVariable<int>>(Charges);

		public static ref IReactiveVariable<int> RefCharges(this Ability obj) => ref obj.GetValueUnsafe<IReactiveVariable<int>>(Charges);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharges(this Ability obj, out IReactiveVariable<int> value) => obj.TryGetValueUnsafe(Charges, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharges(this Ability obj, IReactiveVariable<int> value) => obj.AddValue(Charges, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharges(this Ability obj) => obj.HasValue(Charges);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharges(this Ability obj) => obj.DelValue(Charges);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharges(this Ability obj, IReactiveVariable<int> value) => obj.SetValue(Charges, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetManaCost(this Ability obj) => obj.GetValueUnsafe<IValue<int>>(ManaCost);

		public static ref IValue<int> RefManaCost(this Ability obj) => ref obj.GetValueUnsafe<IValue<int>>(ManaCost);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetManaCost(this Ability obj, out IValue<int> value) => obj.TryGetValueUnsafe(ManaCost, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddManaCost(this Ability obj, IValue<int> value) => obj.AddValue(ManaCost, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasManaCost(this Ability obj) => obj.HasValue(ManaCost);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelManaCost(this Ability obj) => obj.DelValue(ManaCost);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetManaCost(this Ability obj, IValue<int> value) => obj.SetValue(ManaCost, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRadius(this Ability obj) => obj.GetValueUnsafe<IValue<float>>(Radius);

		public static ref IValue<float> RefRadius(this Ability obj) => ref obj.GetValueUnsafe<IValue<float>>(Radius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRadius(this Ability obj, out IValue<float> value) => obj.TryGetValueUnsafe(Radius, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRadius(this Ability obj, IValue<float> value) => obj.AddValue(Radius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRadius(this Ability obj) => obj.HasValue(Radius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRadius(this Ability obj) => obj.DelValue(Radius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRadius(this Ability obj, IValue<float> value) => obj.SetValue(Radius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetCooldown(this Ability obj) => obj.GetValueUnsafe<Cooldown>(Cooldown);

		public static ref Cooldown RefCooldown(this Ability obj) => ref obj.GetValueUnsafe<Cooldown>(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCooldown(this Ability obj, out Cooldown value) => obj.TryGetValueUnsafe(Cooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCooldown(this Ability obj, Cooldown value) => obj.AddValue(Cooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCooldown(this Ability obj) => obj.HasValue(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCooldown(this Ability obj) => obj.DelValue(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCooldown(this Ability obj, Cooldown value) => obj.SetValue(Cooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetDelay(this Ability obj) => obj.GetValueUnsafe<Cooldown>(Delay);

		public static ref Cooldown RefDelay(this Ability obj) => ref obj.GetValueUnsafe<Cooldown>(Delay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDelay(this Ability obj, out Cooldown value) => obj.TryGetValueUnsafe(Delay, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDelay(this Ability obj, Cooldown value) => obj.AddValue(Delay, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDelay(this Ability obj) => obj.HasValue(Delay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDelay(this Ability obj) => obj.DelValue(Delay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDelay(this Ability obj, Cooldown value) => obj.SetValue(Delay, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<bool> GetIsRunning(this Ability obj) => obj.GetValueUnsafe<IReactiveVariable<bool>>(IsRunning);

		public static ref IReactiveVariable<bool> RefIsRunning(this Ability obj) => ref obj.GetValueUnsafe<IReactiveVariable<bool>>(IsRunning);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsRunning(this Ability obj, out IReactiveVariable<bool> value) => obj.TryGetValueUnsafe(IsRunning, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddIsRunning(this Ability obj, IReactiveVariable<bool> value) => obj.AddValue(IsRunning, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsRunning(this Ability obj) => obj.HasValue(IsRunning);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsRunning(this Ability obj) => obj.DelValue(IsRunning);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsRunning(this Ability obj, IReactiveVariable<bool> value) => obj.SetValue(IsRunning, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Sprite GetIcon(this Ability obj) => obj.GetValueUnsafe<Sprite>(Icon);

		public static ref Sprite RefIcon(this Ability obj) => ref obj.GetValueUnsafe<Sprite>(Icon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIcon(this Ability obj, out Sprite value) => obj.TryGetValueUnsafe(Icon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddIcon(this Ability obj, Sprite value) => obj.AddValue(Icon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIcon(this Ability obj) => obj.HasValue(Icon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIcon(this Ability obj) => obj.DelValue(Icon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIcon(this Ability obj, Sprite value) => obj.SetValue(Icon, value);
    }
}
