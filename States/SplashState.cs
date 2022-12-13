using Objects;
using States.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace States
{
    public class SplashState : BaseGameState
    {
        public override void LoadContent()
        {

            AddGameObject(new SplashImage(LoadTexture("splash")));
        }

        public override void HandleInput()
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Enter))
            {
                SwitchState(new GameplayState());
            }
        }
    }
}