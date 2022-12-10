using Enum;
using States.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace States
{
    public class GameplayState : BaseGameState
    {
        public override void LoadContent(ContentManager contentManager)
        {
            
        }

        public override void UnloadContent(ContentManager contentManager)
        {
            contentManager.Unload();
        }

        // checks if a gamepad’s back button is pressed or if the
        // keyboard’s Enter key is pressed.
        public override void HandleInput()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                NotifyEvent(Events.GAME_QUIT);
            }
        }
    }
}
