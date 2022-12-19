﻿using Enum;
using States.Base;
using Microsoft.Xna.Framework.Input;
using Objects;
using Microsoft.Xna.Framework;
using Input.Base;
using Input;
using System;

namespace States
{
    public class GameplayState : BaseGameState
    {
        private const string PlayerFighter = "fighter";
        private const string BackgroundTexture = "Barren";
        private PlayerSprite _playerSprite;

        public override void LoadContent()
        {
            _playerSprite = new PlayerSprite(LoadTexture(PlayerFighter));

            AddGameObject(new TerrainBackground(LoadTexture(BackgroundTexture)));
            AddGameObject(_playerSprite);

            // position the player in the middle of the screen, at the bottom, leaving a slight gap at the bottom
            var playerXPos = (_viewportWidth / 2) - (_playerSprite.Width / 2);
            var playerYPos = (_viewportHeight) - (_playerSprite.Height + 50);
            _playerSprite.Position = new Vector2(playerXPos, playerYPos);
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is GameplayInputCommand.GameExit)
                {
                    NotifyEvent(Events.GAME_QUIT);
                }

                if (cmd is GameplayInputCommand.PlayerMoveLeft)
                {
                    _playerSprite.MoveLeft();
                    KeepPlayerInBounds();
                }

                if (cmd is GameplayInputCommand.PlayerMoveRight)
                {
                    _playerSprite.MoveRight();
                    KeepPlayerInBounds();
                }
            });
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new GameplayInputMapper());
        }

        private void KeepPlayerInBounds()
        {
            if (_playerSprite.Position.X < 0)
            {
                _playerSprite.Position = new Vector2(0, _playerSprite.Position.Y);
            }

            if (_playerSprite.Position.X > _viewportWidth - _playerSprite.Width)
            {
                _playerSprite.Position = new Vector2(_viewportWidth - _playerSprite.Width, _playerSprite.Position.Y);
            }

            if (_playerSprite.Position.Y < 0)
            {
                _playerSprite.Position = new Vector2(_playerSprite.Position.X, 0);
            }

            if (_playerSprite.Position.Y > _viewportHeight - _playerSprite.Height)
            {
                _playerSprite.Position = new Vector2(_playerSprite.Position.X, _viewportHeight - _playerSprite.Height);
            }
        }
    }
}

