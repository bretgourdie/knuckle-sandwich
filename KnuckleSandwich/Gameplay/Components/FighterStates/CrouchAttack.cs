using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class CrouchAttack : FighterState
    {
        protected override SpriteRenderer loadSprite()
        {
            return loadSprite(Content.Sprites.Bread.CrouchAttack);
        }
    }
}
