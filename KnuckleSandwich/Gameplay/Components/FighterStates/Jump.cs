using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class Jump : FighterState
    {
        protected override SpriteRenderer loadSprite()
        {
            return loadSprite(Content.Sprites.Bread.Jump);
        }
    }
}
