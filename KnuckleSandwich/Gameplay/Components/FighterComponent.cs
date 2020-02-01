using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace KnuckleSandwich.Gameplay.Components
{
    class FighterComponent : Component
    {
        public VirtualIntegerAxis XAxisInput { get; private set; }
        public VirtualIntegerAxis YAxisInput { get; private set; }
        public VirtualButton AttackInput { get; private set; }

        private readonly PlayerIndex _playerIndex;
        private readonly Texture2D _breadTexture;

        // TODO: Uncomment after testing with game pads
        public FighterComponent(
            PlayerIndex playerIndex,
            Texture2D breadTexture)
        {
            _playerIndex = playerIndex;
            _breadTexture = breadTexture;
        }

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();

            var idleSprite = new SpriteRenderer(_breadTexture);
            Entity.AddComponent(idleSprite);

            Entity.AddComponent(new BoxCollider(_breadTexture.Bounds));

            Entity.AddComponent(new Mover());

            var xProportion = _playerIndex == PlayerIndex.One ? 1 : 5;
            var y = Constants.Floor - idleSprite.Height / 2;
            Entity.Position = new Vector2(Screen.Width * xProportion / 6, y);

            var negativeXKeyboardKey = _playerIndex == PlayerIndex.One ?
                Keys.A :
                Keys.Left;
            var positiveXKeyboardKey = _playerIndex == PlayerIndex.One ?
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

            var negativeYKeyboardKey = _playerIndex == PlayerIndex.One ?
                Keys.S :
                Keys.Down;
            var positiveYKeyboardKey = _playerIndex == PlayerIndex.One ?
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

            var keyboardAttackButton = _playerIndex == PlayerIndex.One ?
                Keys.LeftShift :
                Keys.RightControl;
            AttackInput = new VirtualButton(
                //new VirtualButton.GamePadButton((int)playerIndex, Buttons.X),
                new VirtualButton.KeyboardKey(keyboardAttackButton)
            );
        }
    }
}
