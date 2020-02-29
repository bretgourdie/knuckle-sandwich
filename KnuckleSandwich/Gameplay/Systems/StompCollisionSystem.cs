using KnuckleSandwich.Gameplay.Components;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using System.Linq;

namespace KnuckleSandwich.Gameplay.Systems
{
    class StompCollisionSystem : EntityProcessingSystem
    {
        public StompCollisionSystem() : base(
            new Matcher().All(
                typeof(FighterComponent)
                ))
        { }

        public override void Process(Entity entity)
        {
            var selfCollider = entity.GetComponent<BoxCollider>();

            var otherColliders = Physics.BoxcastBroadphaseExcludingSelf(selfCollider).ToList();

            for (int ii = 0; ii < otherColliders.Count; ii++)
            {
                var otherCollider = otherColliders[ii];
                if (otherCollider is BoxCollider)
                {
                    var otherBoxCollider = otherCollider as BoxCollider;
                    if (isBeingStompedOn(selfCollider, otherBoxCollider))
                    {
                        entity.Destroy();
                    }

                    else if (isOtherCollision(selfCollider, otherBoxCollider))
                    {
                        // bump backwards
                        var spriteRenderer = entity.GetComponent<SpriteRenderer>();

                        var xVelocity = -120f;

                        if (spriteRenderer.FlipX)
                        {
                            xVelocity *= -1;
                        }

                        bumpBack(entity, xVelocity);

                        bumpBack(otherCollider.Entity, -xVelocity);
                    }
                }
            }
        }

        private void bumpBack(Entity entity, float xVelocity)
        {
            var mover = entity.GetComponent<Mover>();

            mover.ApplyMovement(
                new Vector2(
                    xVelocity,
                    0));
        }

        private bool isBeingStompedOn(
            BoxCollider self,
            BoxCollider other)
        {
            var isColliding = self.CollidesWith(other, out CollisionResult collisionResult);

            return isColliding
                && collisionResult.MinimumTranslationVector.Y < 0
                && collisionResult.MinimumTranslationVector.X == 0;
        }

        private bool isOtherCollision(
            BoxCollider self,
            BoxCollider other)
        {
            var isColliding = self.CollidesWith(other, out CollisionResult collisionResult);
            return isColliding;
        }
    }
}
