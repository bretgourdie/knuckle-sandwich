using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    abstract class FighterState : Component
    {
        public abstract Type HandleInput(VirtualAxis xAxis, VirtualAxis yAxis, VirtualButton attackButton, VirtualButton specialButton);
        private SpriteRenderer _sprite;
        protected abstract SpriteRenderer loadSprite();

        public FighterState()
        {
            _sprite = loadSprite();
        }

        public override void OnAddedToEntity()
        {
            this.AddComponent(_sprite);
        }

        public override void OnRemovedFromEntity()
        {
            this.RemoveComponent(_sprite);
        }
    }
}
