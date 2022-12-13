using System;
using System.Collections.Generic;
using System.Linq;

using Enum;
using Objects.Base;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace States.Base
{
    public abstract class BaseGameState
    {
        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();
        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<Events> OnEventNotification;
        private const string FallbackTexture = "Empty";
        private ContentManager _contentManager;

        // State-epecific loading and unload content at runtime
        public abstract void LoadContent(ContentManager contentManager);

        // State-specific input handling
        public abstract void HandleInput();

        // Triggers an event that our MainGame class will respond to
        // by unloading the current state and then loading the new state.
        // At the next game loop iteration, the new state’s Update and Draw
        // methods will start being called.
        protected void NotifyEvent(Events eventType, object argument = null)
        {
            OnEventNotification?.Invoke(this, eventType);

            foreach (var gameObject in _gameObjects)
            {
                gameObject.OnNotify(eventType);
            }
        }
        protected void SwitchState(BaseGameState gameState)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        // Adds objects to a list collection to keep track of whats been
        // drawn on screen. This will be used to add sprites, images etc.
        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        // iterate through all the game objects we want to render on the
        // screen.This method is called from the main Draw method in the
        // MainGame class.
        public void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects.OrderBy(a => a.zIndex))
            {
                gameObject.Render(spriteBatch);
            }
        }

        // Initializes the Content Manager variable
        public void Initialize(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        // To call the ContentManager's Unload method.
        public void UnloadContent()
        {
            _contentManager.Unload();
        }

        // Wrapper around the loading of textures, includes a fallback 
        // incase of a missing texture (this avoids an exception)
        protected Texture2D LoadTexture(string textureName)
        {
            var texture = _contentManager.Load<Texture2D>(textureName);

            return texture ?? _contentManager.Load<Texture2D>(FallbackTexture);
        }
    }
}