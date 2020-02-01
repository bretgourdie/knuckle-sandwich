using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    abstract class FighterState : Component
    {
        private SpriteRenderer _sprite;
        protected abstract SpriteRenderer loadSprite();
        public float TimeSpentInState;

        public FighterState()
        {
            _sprite = loadSprite();
        }

        public override void OnAddedToEntity()
        {
            this.AddComponent(_sprite);
            TimeSpentInState = 0;
        }

        public override void OnRemovedFromEntity()
        {
            this.RemoveComponent(_sprite);
        }

        protected SpriteRenderer loadSprite(string texture2DPath)
        {
            var texture = Core.Content.Load<Texture2D>(texture2DPath);
            return new SpriteRenderer(texture);
        }
    }
}
