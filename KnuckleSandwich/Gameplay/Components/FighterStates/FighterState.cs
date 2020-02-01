using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    abstract class FighterState : Component
    {
        public SpriteRenderer Sprite;
        protected abstract SpriteRenderer loadSprite();
        public float TimeSpentInState;

        public FighterState()
        {
            Sprite = loadSprite();
        }

        public override void OnAddedToEntity()
        {
            this.AddComponent(Sprite);
            TimeSpentInState = 0;
        }

        public override void OnRemovedFromEntity()
        {
            this.RemoveComponent(Sprite);
        }

        protected SpriteRenderer loadSprite(string texture2DPath)
        {
            var texture = Core.Content.Load<Texture2D>(texture2DPath);
            return new SpriteRenderer(texture);
        }
    }
}
