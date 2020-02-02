using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class CrouchSystem : FighterStateProcessingSystem
    {
        public CrouchSystem() : base(typeof(Crouch)) { }

        public override void Process(Entity entity)
        {
            var yInput = yAxis(entity);

            if (attackButton(entity).IsPressed)
            {
                entity.RemoveComponent<Crouch>();
                addState<CrouchAttack>(entity);
            }

            else if (isTryingToUp(yInput))
            {
                entity.RemoveComponent<Crouch>();
                addState<Jump>(entity);
            }

            else if (inIdleXDeadZone(yInput))
            {
                entity.RemoveComponent<Crouch>();
                addState<Idle>(entity);
            }
        }
    }
}
