using Microsoft.Xna.Framework;
using Nez;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    abstract class FighterAttackState : FighterState
    {
        private Entity _butter;

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();

            _butter = ButterFactory.GetButter(Entity.Tag);

            _butter.SetParent(Entity);

            _butter.LocalPosition = new Vector2(-100f, 0f);
        }
    }
}
