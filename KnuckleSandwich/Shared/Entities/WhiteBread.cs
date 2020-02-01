using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Shared.Entities
{
    class WhiteBread : Entity
    {
        public WhiteBread(
            Texture2D breadTexture,
            PlayerIndex playerIndex)
        {
            var sprite = new SpriteRenderer(breadTexture);
            AddComponent(sprite);

            var xProportion = playerIndex == PlayerIndex.One ? 1 : 5;
            var y = Constants.Floor - sprite.Height / 2;
            this.Position = new Vector2(Screen.Width * xProportion / 6, y);
        }
    }
}
