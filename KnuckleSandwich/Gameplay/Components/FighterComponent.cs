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
        public readonly VirtualIntegerAxis XAxisInput;
        public readonly VirtualIntegerAxis YAxisInput;
        public readonly VirtualButton AttackInput;

        // TODO: Uncomment after testing with game pads
        public FighterComponent(PlayerIndex playerIndex)
        {
            var negativeXKeyboardKey = playerIndex == PlayerIndex.One ?
                Keys.A :
                Keys.Left;
            var positiveXKeyboardKey = playerIndex == PlayerIndex.One ?
                Keys.D :
                Keys.Right;

            XAxisInput = new VirtualIntegerAxis(
                //new VirtualAxis.GamePadDpadLeftRight((int)playerIndex),
                //new VirtualAxis.GamePadLeftStickX((int)playerIndex),
                new VirtualAxis.KeyboardKeys(
                    VirtualInput.OverlapBehavior.TakeNewer,
                    negativeXKeyboardKey,
                    positiveXKeyboardKey)
            );

            var negativeYKeyboardKey = playerIndex == PlayerIndex.One ?
                Keys.S :
                Keys.Down;
            var positiveYKeyboardKey = playerIndex == PlayerIndex.One ?
                Keys.W :
                Keys.Up;
            YAxisInput = new VirtualIntegerAxis(
                //new VirtualAxis.GamePadDpadUpDown((int)playerIndex),
                //new VirtualAxis.GamePadLeftStickY((int)playerIndex),
                new VirtualAxis.KeyboardKeys(
                    VirtualInput.OverlapBehavior.TakeNewer,
                    negativeYKeyboardKey,
                    positiveYKeyboardKey)
            );

            var keyboardAttackButton = playerIndex == PlayerIndex.One ?
                Keys.LeftShift :
                Keys.RightControl;
            AttackInput = new VirtualButton(
                //new VirtualButton.GamePadButton((int)playerIndex, Buttons.X),
                new VirtualButton.KeyboardKey(keyboardAttackButton)
            );
        }
    }
}
