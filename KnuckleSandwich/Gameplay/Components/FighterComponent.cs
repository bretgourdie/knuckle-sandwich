using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace KnuckleSandwich.Gameplay.Components
{
    class FighterComponent : Component
    {
        public FighterComponent(PlayerIndex playerIndex)
        {
            var xAxisInput = new VirtualIntegerAxis(
                new VirtualAxis.GamePadDpadLeftRight((int)playerIndex),
                new VirtualAxis.GamePadLeftStickX((int)playerIndex),
                new VirtualAxis.KeyboardKeys(
                    VirtualInput.OverlapBehavior.TakeNewer,
                    Keys.A,
                    Keys.D)
            );
        }
    }
}
