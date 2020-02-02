using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class Jump : FighterState
    {
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();

            Entity.AddComponent(new AirbornMovement());
        }

        protected override SpriteRenderer loadSprite()
        {
            return loadSprite(Content.Sprites.Bread.Jump);
        }
    }
}
