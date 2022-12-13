using Enum;
using States.Base;
using Microsoft.Xna.Framework.Input;
using Objects;

namespace States
{
    public class GameplayState : BaseGameState
    {
        private const string PlayerFighter = "fighter";
        private const string BackgroundTexture = "Barren";

        public override void LoadContent()
        {
            AddGameObject(new SplashImage(LoadTexture(BackgroundTexture)));
            AddGameObject(new PlayerSprite(LoadTexture(PlayerFighter)));
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
