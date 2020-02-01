using KnuckleSandwich.Gameplay.Components;
using Nez;
using System;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    abstract class FighterStateProcessingSystem : EntityProcessingSystem
    {
        public FighterStateProcessingSystem(
            params Type[] types) : base(
            new Matcher().All(types).All(typeof(FighterComponent)))
        { }

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

        protected void addState<T>(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();

            var states = fc.States;

            if (states.ContainsKey(typeof(T)))
            {
                entity.AddComponent(states[typeof(T)]);
            }

            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
