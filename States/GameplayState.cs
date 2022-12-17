using Enum;
using States.Base;
using Microsoft.Xna.Framework.Input;
using Objects;
using Microsoft.Xna.Framework;

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

        public override void HandleInput()
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                NotifyEvent(Events.GAME_QUIT);
            }
        }
    }
}

