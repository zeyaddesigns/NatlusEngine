using System;
using System.Collections.Generic;
using System.Linq;
using NatlusEngine.Engine.Input;
using NatlusEngine.Engine.Objects;
//using NatlusEngine.Engine.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace NatlusEngine.Engine.States
{
    public abstract class BaseGameState
    {
        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();
        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<BaseGameStateEvent> OnEventNotification;
        private const string FallbackTexture = "Empty";
        private ContentManager _contentManager;
        protected int _viewportHeight;
        protected int _viewportWidth;
        protected InputManager InputManager { get; set; }

        // State-epecific loading and unload content at runtime
        public abstract void LoadContent();

        // State-specific input handling
        public abstract void HandleInput(GameTime gameTime);

        public virtual void Update(GameTime gameTime) { }

        // Triggers an event that our MainGame class will respond to
        // by unloading the current state and then loading the new state.
        // At the next game loop iteration, the new state’s Update and Draw
        // methods will start being called.
        protected void NotifyEvent(BaseGameStateEvent gameEvent)
        {
            OnEventNotification?.Invoke(this, gameEvent);

            foreach (var gameObject in _gameObjects)
            {
                gameObject.OnNotify(gameEvent);
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

        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
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
        public void Initialize(ContentManager contentManager, int viewportWidth, int viewportHeight)
        {
            _contentManager = contentManager;
            _viewportHeight = viewportHeight;
            _viewportWidth = viewportWidth;

            SetInputManager();
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

        protected abstract void SetInputManager();
    }
}