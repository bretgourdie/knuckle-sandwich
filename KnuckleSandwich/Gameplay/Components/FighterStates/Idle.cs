using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Components.FighterStates
{
    class Idle : FighterState
    {

        protected override SpriteRenderer loadSprite()
        {
            return loadSprite(Content.Sprites.Bread.Idle);
        }
    }
}
