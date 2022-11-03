using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Lesson_1_The_Basics
{
    public class Game1 : Game
    {
        Texture2D dinoTexture;
        Texture2D pacTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static Random rand = new Random();
        private int _x = 150;
        private int _y = 0;
        private int _xPac = 0;
        private int _yPac = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "Pac chasing Ghost";
            _graphics.PreferredBackBufferWidth = 800; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 700; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            dinoTexture = Content.Load<Texture2D>("pacGhost");
            pacTexture = Content.Load<Texture2D>("pac");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && _xPac < _graphics.PreferredBackBufferWidth-100)
                _xPac+=5;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && _xPac > 0)
                _xPac-=5;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && _yPac < _graphics.PreferredBackBufferHeight-100)
                _yPac+=5;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && _yPac > 0)
                _yPac-=5;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(dinoTexture, new Vector2(_x, _y), Color.White);
            _spriteBatch.Draw(pacTexture, new Vector2(_xPac, _yPac), Color.White);
            _spriteBatch.End();
            _x+=5;
            if (_x >= _graphics.PreferredBackBufferWidth){
                _x = 0;
                _y += 150;
            }
            if (+_y >= _graphics.PreferredBackBufferHeight){
                _y = 0;
            }


            base.Draw(gameTime);
        }
    }
}