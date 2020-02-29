using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;
using Nez.Sprites;
using System;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    abstract class FighterStateProcessingSystem : EntityProcessingSystem
    {
        public FighterStateProcessingSystem(
            params Type[] types) : base(
            new Matcher().All(types).All(
                typeof(FighterComponent)
            ))
        { }

        protected abstract void cleanupForStateChange(Entity entity);

        public override void Process(Entity entity)
        {
            var fs = entity.GetComponent<FighterState>();

            if (fs != null)
            {
                fs.TimeSpentInState += Time.DeltaTime;
            }
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

        protected VirtualButton tauntButton(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();

            return fc.TauntInput;
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
            // Remove crouching
            return false;
            //return yAxis.Value <= -0.25f;
        }

        protected bool isTryingToUp(VirtualAxis yAxis)
        {
            return yAxis >= 0.25f;
        }

        protected bool isTryingToTaunt(VirtualButton tauntButton)
        {
            return tauntButton.IsDown;
        }

        protected void addState<T>(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();
            var spriteAnimator = entity.GetComponent<SpriteAnimator>();

            var states = fc.States;

            var stateType = typeof(T);

            if (states.ContainsKey(stateType))
            {
                var state = states[stateType];
                Debug.Log($"{this.GetType().Name} transitioning to {stateType.Name}");
                entity.AddComponent(states[stateType]);
                spriteAnimator.Play(stateType.Name);
            }

            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
