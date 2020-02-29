using KnuckleSandwich.Gameplay.Components;
using Nez;

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

            var otherColliders = Physics.BoxcastBroadphaseExcludingSelf(selfCollider);

            foreach (var otherCollider in otherColliders)
            {
                if (otherCollider is BoxCollider)
                {
                    var otherBoxCollider = (BoxCollider)otherCollider;
                    if (isBeingStompedOn(selfCollider, otherBoxCollider))
                    {
                        entity.Destroy();
                    }
                }
            }
        }

        private bool isBeingStompedOn(
            BoxCollider self,
            BoxCollider other)
        {
            var isColliding = self.CollidesWith(other, out CollisionResult collisionResult);

            return collisionResult.MinimumTranslationVector.Y < 0;
        }
    }
}
