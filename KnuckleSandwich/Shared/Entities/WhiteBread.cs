using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Gameplay.Components;
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
            AddComponent(new FighterComponent(playerIndex, breadTexture));
        }
    }
}
