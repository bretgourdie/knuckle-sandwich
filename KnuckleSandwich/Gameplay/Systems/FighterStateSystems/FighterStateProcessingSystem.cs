using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;
using System;
using System.Collections.Generic;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    abstract class FighterStateProcessingSystem : EntityProcessingSystem
    {
        private readonly IDictionary<Type, FighterState> _states;

        public FighterStateProcessingSystem(
            IDictionary<Type, FighterState> states,
            params Type[] types) : base(
            new Matcher().All(types).All(typeof(FighterComponent)))
        {
            _states = states;
        }

        protected FighterState getState<T>() where T : FighterState
        {
            var type = typeof(T);
            if (_states.ContainsKey(type))
            {
                return _states[type];
            }

            throw new NotImplementedException();
        }

        protected VirtualAxis xAxis(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();

            return fc.XAxisInput;
        }

        protected VirtualAxis yAxis(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();

            return fc.YAxisInput;
        }

        protected VirtualButton attackButton(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();

            return fc.AttackInput;
        }

        protected bool inIdleYDeadZone(VirtualAxis yAxis)
        {
            return !isTryingToUp(yAxis) && !isTryingToDown(yAxis);
        }

        protected bool inIdleXDeadZone(VirtualAxis xAxis)
        {
            return !isTryingToLeft(xAxis) && !isTryingToRight(xAxis);
        }

        protected bool isTryingToLeft(VirtualAxis xAxis)
        {
            return xAxis.Value <= -0.25f;
        }

        protected bool isTryingToRight(VirtualAxis xAxis)
        {
            return xAxis.Value >= 0.25f;
        }

        protected bool isTryingToDown(VirtualAxis yAxis)
        {
            return yAxis.Value <= -0.25f;
        }

        protected bool isTryingToUp(VirtualAxis yAxis)
        {
            return yAxis >= 0.25f;
        }

        protected bool isTryingToAttack(VirtualButton attackButton)
        {
            return attackButton.IsPressed;
        }
    }
}
