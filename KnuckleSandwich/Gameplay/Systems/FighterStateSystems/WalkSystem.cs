using KnuckleSandwich.Gameplay.Components.FighterStates;
using Microsoft.Xna.Framework;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class WalkSystem : FighterStateProcessingSystem
    {
        const float _moveSpeed = 350f;

        public WalkSystem() : base(typeof(Walk), typeof(Mover))
        { }

        public override void Process(Entity entity)
        {
            var xInput = xAxis(entity);
            var yInput = yAxis(entity);

            if (isTryingToAttack(attackButton(entity)))
            {
                cleanupForStateChange(entity);
                addState<NeutralAttack>(entity);
            }

            else if (isTryingToUp(yInput))
            {
                cleanupForStateChange(entity);
                addState<Jump>(entity);
            }

            else if (isTryingToDown(yInput))
            {
                cleanupForStateChange(entity);
                addState<Crouch>(entity);
            }

            else if (!isTryingToLeft(xInput) && !isTryingToRight(xInput))
            {
                cleanupForStateChange(entity);
                addState<Idle>(entity);
            }

            else if (isTryingToLeft(xInput) || isTryingToRight(xInput))
            {
                var mover = entity.GetComponent<Mover>();

                var leftRightMovement = new Vector2(
                    xInput.Value,
                    0);

                var movement = leftRightMovement * _moveSpeed * Time.DeltaTime;

                mover.CalculateMovement(ref movement, out var res);
                mover.ApplyMovement(movement);
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<Walk>();
        }
    }
}
