using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class CrouchAttack : FighterAttackState
    {
        protected override SpriteRenderer loadSprite()
        {
            return loadSprite(Content.Sprites.Bread.CrouchAttack);
        }
    }
}
