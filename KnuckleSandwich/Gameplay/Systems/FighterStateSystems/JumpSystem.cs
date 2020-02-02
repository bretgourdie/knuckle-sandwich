using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using KnuckleSandwich.Shared;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

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
            var mover = entity.GetComponent<Mover>();

            // Cut off short jump
            if (yInput.Value < 0.25f)
            {
                airbornMovement.YVelocity =
                    MathHelper.Max(0f, airbornMovement.YVelocity);
            }

            if (isTryingToAttack(attackButton(entity)))
            {
                cleanupForStateChange(entity, removeAirbornMovement: false);
                entity.AddComponent<JumpAttack>();
            }

            else
            {
                var inputMovement = new Vector2(
                    xInput.Value * Constants.MoveSpeed,
                    airbornMovement.YVelocity);

                var movement = inputMovement * Time.DeltaTime;
                mover.CalculateMovement(ref movement, out var res);
                mover.ApplyMovement(movement);

                airbornMovement.YVelocity += decay;

                var sprite = entity.GetComponent<SpriteRenderer>();

                var fighterOnFloorYCoord = Constants.FighterOnFloor(sprite);

                if (entity.Position.Y >= fighterOnFloorYCoord)
                {
                    entity.Position = new Vector2(
                        entity.Position.X,
                        fighterOnFloorYCoord);

                    cleanupForStateChange(entity, removeAirbornMovement: true);

                    addState<Idle>(entity);
                }
            }
        }

        private void cleanupForStateChange(
            Entity entity,
            bool removeAirbornMovement)
        {
            cleanupForStateChange(entity);

            if (removeAirbornMovement)
            {
                entity.RemoveComponent<AirbornMovement>();
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<Jump>();
        }
    }
}
