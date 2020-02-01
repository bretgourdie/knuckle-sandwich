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

        public override Type HandleInput(VirtualAxis xAxis, VirtualAxis yAxis, VirtualButton attackButton, VirtualButton specialButton)
        {
            if (attackButton.IsPressed)
            {
                return typeof(NeutralAttack);
            }

            else if (yAxis.Value > 0f)
            {
                return typeof(Jump);
            }

            else if (yAxis.Value < 0f)
            {
                return typeof(Crouch);
            }

            else if (xAxis.Value != 0f)
            {
                return typeof(Walk);
            }

            return typeof(Idle);
        }

        protected override SpriteRenderer loadSprite()
        {
            var texture = Core.Content.Load<Texture2D>(
                Nez.Content.Sprites.Bread.Idle);

            return new SpriteRenderer(texture);
        }
    }
}
