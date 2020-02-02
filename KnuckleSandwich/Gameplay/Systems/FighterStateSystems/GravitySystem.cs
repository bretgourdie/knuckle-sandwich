using KnuckleSandwich.Gameplay.Components.FighterStates;
using KnuckleSandwich.Shared;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class GravitySystem : FighterStateProcessingSystem
    {
        const float gravity = 50f;

        public GravitySystem() : base(typeof(AirbornMovement))
        { }

        public override void Process(Entity entity)
        {
            var airbornMovement = entity.GetComponent<AirbornMovement>();
            var mover = entity.GetComponent<Mover>();

            var inputMovement = new Vector2(
                airbornMovement.XVelocity,
                airbornMovement.YVelocity);

            var movement = inputMovement * Time.DeltaTime;
            mover.CalculateMovement(ref movement, out var res);
            mover.ApplyMovement(movement);

            airbornMovement.YVelocity += gravity;

            var sprite = entity.GetComponent<SpriteRenderer>();

            var fighterOnFloorYCoord = Constants.FighterOnFloor(sprite);

            if (entity.Position.Y >= fighterOnFloorYCoord)
            {
                entity.Position = new Vector2(
                    entity.Position.X,
                    fighterOnFloorYCoord);

                cleanupForStateChange(entity);
                addState<Idle>(entity);
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<AirbornMovement>();
        }
    }
}
