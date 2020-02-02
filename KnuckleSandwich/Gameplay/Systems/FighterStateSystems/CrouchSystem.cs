using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class CrouchSystem : FighterStateProcessingSystem
    {
        public CrouchSystem() : base(typeof(Crouch)) { }

        public override void Process(Entity entity)
        {
            base.Process(entity);

            var yInput = yAxis(entity);

            if (attackButton(entity).IsPressed)
            {
                cleanupForStateChange(entity);
                addState<CrouchAttack>(entity);
            }

            else if (isTryingToUp(yInput))
            {
                cleanupForStateChange(entity);
                addState<Jump>(entity);
            }

            else if (inIdleXDeadZone(yInput))
            {
                cleanupForStateChange(entity);
                addState<Idle>(entity);
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<Crouch>();
        }
    }
}
