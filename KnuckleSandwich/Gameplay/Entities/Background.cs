using KnuckleSandwich.Shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Entities
{
    class Background : Entity
    {
        public Background(Texture2D backgroundTexture)
        {
            var spriteRenderer = new SpriteRenderer(backgroundTexture);
            this.AddComponent(spriteRenderer);

            this.SetLocalPosition(
                new Vector2(
                    Constants.Width / 2,
                    Constants.Height / 2
                )
            );
        }
    }
}
