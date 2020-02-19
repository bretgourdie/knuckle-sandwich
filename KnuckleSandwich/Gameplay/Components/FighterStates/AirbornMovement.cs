using Nez;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class AirbornMovement : Component
    {
        public float YVelocity = -1200f;
        public float XVelocity;

        public override void OnRemovedFromEntity()
        {
            base.OnRemovedFromEntity();

            if (Entity.GetComponent<Jump>() != null)
            {
                Entity.RemoveComponent<Jump>();
            }
        }
    }
}
