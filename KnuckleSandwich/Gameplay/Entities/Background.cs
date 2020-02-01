using Microsoft.Xna.Framework;
using Nez;
using KnuckleSandwich.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;

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
