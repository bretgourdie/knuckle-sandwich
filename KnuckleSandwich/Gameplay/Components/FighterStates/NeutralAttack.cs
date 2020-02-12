using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class NeutralAttack : FighterAttackState
    {
        protected override SpriteRenderer loadSprite()
        {
            return loadSprite(Content.Sprites.Bread.Attack);
        }
    }
}
