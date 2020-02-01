using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Gameplay.Components.FighterStates;
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
        public VirtualAxis XAxisInput { get; private set; }
        public VirtualAxis YAxisInput { get; private set; }
        public VirtualButton AttackInput { get; private set; }

        public IDictionary<Type, FighterState> States;

        private readonly PlayerIndex _playerIndex;
        private readonly Texture2D _breadTexture;

        // TODO: Uncomment after testing with game pads
        public FighterComponent(
            PlayerIndex playerIndex,
            Texture2D breadTexture)
        {
            _playerIndex = playerIndex;
            _breadTexture = breadTexture;
            States = new Dictionary<Type, FighterState>();
        }

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();

            Entity.AddComponent(new CircleCollider(_breadTexture.Bounds.Height / 2));

            Entity.AddComponent(new Mover());

            Entity.AddComponent(new JumpComponent());

            _handleStates();

            _handleInput();

            _handlePosition();
        }

        private void _handleStates()
        {
            var idle = new Idle();

            addState<AirbornMovement>(new AirbornMovement());
            addState<Crouch>(new Crouch());
            addState<Dead>(new Dead());
            addState<Hurt>(new Hurt());
            addState<Idle>(idle);
            addState<Jump>(new Jump());
            addState<JumpAttack>(new JumpAttack());
            addState<NeutralAttack>(new NeutralAttack());
            addState<Walk>(new Walk());

            Entity.AddComponent(idle);
        }

        private void addState<T>(FighterState fighterState)
        {
            States[typeof(T)] = fighterState;
        }

        private void _handlePosition()
        {
            var xProportion = _playerIndex == PlayerIndex.One ? 1 : 5;
            var idleState = States[typeof(Idle)];
            var y = Constants.FighterOnFloor(150f);
            Entity.Position = new Vector2(Screen.Width * xProportion / 6, y);
        }

        private void _handleInput()
        {
            var negativeXKeyboardKey = _playerIndex == PlayerIndex.One ?
                Keys.A :
                Keys.Left;
            var positiveXKeyboardKey = _playerIndex == PlayerIndex.One ?
                Keys.D :
                Keys.Right;

            XAxisInput = new VirtualAxis(
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
            YAxisInput = new VirtualAxis(
                new VirtualAxis.KeyboardKeys(
                    VirtualInput.OverlapBehavior.TakeNewer,
                    negativeYKeyboardKey,
                    positiveYKeyboardKey)
            );

            var keyboardAttackButton = _playerIndex == PlayerIndex.One ?
                Keys.LeftShift :
                Keys.RightControl;

            var listOfAttackButtons = new List<VirtualButton.Node>();

            var gamePadAttackButton = _getGamePadXButton(_playerIndex);
            if (gamePadAttackButton != null)
            {
                listOfAttackButtons.Add(gamePadAttackButton);
            }
            listOfAttackButtons.Add(new VirtualButton.KeyboardKey(keyboardAttackButton));

            AttackInput = new VirtualButton(listOfAttackButtons.ToArray());
        }

        private bool _isGamePadConnected(PlayerIndex playerIndex)
        {
            var gamePadState = GamePad.GetState((int)playerIndex);
            return gamePadState.IsConnected;
        }

        private VirtualButton.Node _getGamePadXButton(PlayerIndex playerIndex)
        {
            if (_isGamePadConnected(playerIndex))
            {
                return new VirtualButton.GamePadButton((int)playerIndex, Buttons.X);
            }
            return null;
        }

        private VirtualAxis.Node[] _getGamePadXAxis(PlayerIndex playerIndex)
        {
            if (_isGamePadConnected(playerIndex))
            {
                return new VirtualAxis.Node[]
                {
                    new VirtualAxis.GamePadDpadLeftRight((int)playerIndex),
                    new VirtualAxis.GamePadLeftStickX((int)playerIndex)
                };
            }

            else
            {
                return new VirtualAxis.Node[] { };
            }
        }

        private VirtualAxis.Node[] _getGamePadYAxis(PlayerIndex playerIndex)
        {
            if (_isGamePadConnected(playerIndex))
            {
                return new VirtualAxis.Node[]
                {
                    new VirtualAxis.GamePadDpadUpDown((int)playerIndex),
                    new VirtualAxis.GamePadLeftStickY((int)playerIndex)
                };
            }

            else
            {
                return new VirtualAxis.Node[] { };
            }
        }
    }
}
