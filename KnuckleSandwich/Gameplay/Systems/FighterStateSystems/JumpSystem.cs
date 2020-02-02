using KnuckleSandwich.Gameplay.Components.FighterStates;
using KnuckleSandwich.Shared;
using Microsoft.Xna.Framework;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class JumpSystem : FighterStateProcessingSystem
    {
        const float decay = 50f;

        public JumpSystem() : base(typeof(Jump))
        { }

        public override void Process(Entity entity)
        {
            base.Process(entity);

            var airbornMovement = entity.GetComponent<AirbornMovement>();
            var xInput = xAxis(entity);
            var yInput = yAxis(entity);

            // Cut off short jump
            if (yInput.Value < 0.25f)
            {
                airbornMovement.YVelocity =
                    MathHelper.Max(0f, airbornMovement.YVelocity);
            }

            if (isTryingToAttack(attackButton(entity)))
            {
                cleanupForStateChange(entity);
                addState<JumpAttack>(entity);
            }

            else
            {
                var xMovement = xInput.Value * Constants.MoveSpeed;
                airbornMovement.XVelocity = xMovement;
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<Jump>();
        }
    }
}
