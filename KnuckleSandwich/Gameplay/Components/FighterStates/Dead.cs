using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class Dead : FighterState
    {
        protected override SpriteRenderer loadSprite()
        {
            return loadSprite(Content.Sprites.Bread.Dead);
        }
    }
}
