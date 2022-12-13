using Objects.Base;

using Microsoft.Xna.Framework.Graphics;

namespace Objects
{
    public class PlayerSprite : BaseGameObject
    {
        public PlayerSprite(Texture2D texture)
        {
            _texture = texture;
        }
    }
}