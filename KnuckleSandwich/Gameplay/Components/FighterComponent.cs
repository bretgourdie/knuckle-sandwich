﻿using System;
using System.Collections.Generic;
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
        public VirtualButton TauntInput { get; private set; }
        public VirtualButton ResetInput { get; private set; }

        public SpriteAnimator Animator { get; private set; }

        public IDictionary<Type, FighterState> States;

        public float KnockbackVelocity;

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

            Entity.AddComponent(new BoxCollider() { IsTrigger = true });

            Entity.AddComponent(new Mover());

            Animator = Entity.AddComponent(new SpriteAnimator());

            Entity.Tag = (int)_playerIndex;

            _handleStates();

            _handleInput();

            _handlePosition();
        }

        private void _handleStates()
        {
            var idle = Entity.AddComponent(new Idle());

            addState<Crouch>(new Crouch());
            addState<CrouchAttack>(new CrouchAttack());
            addState<Dead>(new Dead());
            addState<Hurt>(new Hurt());
            addState<Idle>(idle);
            addState<Jump>(new Jump());
            addState<NeutralAttack>(new NeutralAttack());
            addState<Walk>(new Walk());

            Animator.Play(idle.GetType().Name);
        }

        private void addState<T>(FighterState fighterState)
        {
            States[typeof(T)] = fighterState;
            Animator.AddAnimation(
                fighterState.GetType().Name,
                new []
                {
                    fighterState.Sprite.Sprite
                });
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

            var keyboardTantButton = _playerIndex == PlayerIndex.One ?
                Keys.LeftShift :
                Keys.RightControl;

            var listOfTauntButtons = new List<VirtualButton.Node>();

            var gamePadTauntButton = _getGamePadXButton(_playerIndex);
            if (gamePadTauntButton != null)
            {
                listOfTauntButtons.Add(gamePadTauntButton);
            }
            listOfTauntButtons.Add(new VirtualButton.KeyboardKey(keyboardTantButton));

            TauntInput = new VirtualButton(listOfTauntButtons.ToArray());

            var listOfResetButtons = new List<VirtualButton.Node>();
            var gamePadResetButton = _getGamePadBackButton(_playerIndex);
            if (gamePadResetButton != null)
            {
                listOfResetButtons.Add(gamePadResetButton);
            }
            listOfResetButtons.Add(new VirtualButton.KeyboardKey(Keys.F5));

            ResetInput = new VirtualButton(listOfResetButtons.ToArray());
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

        private VirtualButton.Node _getGamePadBackButton(PlayerIndex playerIndex)
        {
            if (_isGamePadConnected(playerIndex))
            {
                return new VirtualButton.GamePadButton((int)playerIndex, Buttons.Back);
            }
            return null;
        }
    }
}
