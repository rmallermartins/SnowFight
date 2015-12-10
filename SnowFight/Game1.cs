using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SnowFight
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IBackground _background;
        private IPlayer _player1;
        private IPlayer _player2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720
            };
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _background = new Background("background");
            _player1 = new Player();
            _player2 = new Player();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var viewport = GraphicsDevice.Viewport;

            _background.LoadContent(Content);

            _player1.Animation.Origin = new Vector2(64, 64);
            _player1.Animation.Position = new Vector2(200, viewport.Height / 2);
            _player1.Animation.LoadContent(Content);

            _player2.Animation.Flip = true;
            _player2.Animation.Origin = new Vector2(64, 64);
            _player2.Animation.DrawColor = Color.Red;
            _player2.Animation.Position = new Vector2(1080, viewport.Height / 2);
            _player2.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _background.Draw(_spriteBatch);
            _player1.Draw(_spriteBatch);
            _player2.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
