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
        private IBackground _snowballPileLeft;
        private IBackground _snowballPileRight;
        private IBackground _sledge;
        private IBackground _snowman;

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
            _snowballPileLeft = new Background("snowball_pile");
            _snowballPileRight = new Background("snowball_pile");
            _sledge = new Background("sledge");
            _snowman = new Background("snowman");

            _player1 = new Player();
            _player2 = new Player();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var viewport = GraphicsDevice.Viewport;

            _background.LoadContent(Content);

            initSnowPileLeft();
            initSnowPileRight();
            initSledge();
            initSnowman();
            initPlayer1();
            initPlayer2();
        }

        private void initSnowPileLeft()
        {
            _snowballPileLeft.LoadContent(Content);
            _snowballPileLeft.Sprite.Origin = new Vector2(_snowballPileLeft.Texture.Width / 2,
                _snowballPileLeft.Texture.Height / 2);
            _snowballPileLeft.Sprite.Position = new Vector2(200, 495);
        }

        private void initSnowPileRight()
        {
            _snowballPileRight.LoadContent(Content);
            _snowballPileRight.Sprite.Origin = new Vector2(_snowballPileRight.Texture.Width / 2,
                _snowballPileRight.Texture.Height / 2);
            _snowballPileRight.Sprite.Position = new Vector2(1080, 495);
        }

        private void initSledge()
        {
            _sledge.LoadContent(Content);
            _sledge.Sprite.Origin = new Vector2(_sledge.Texture.Width / 2, _sledge.Texture.Height / 2);
            _sledge.Sprite.Position = new Vector2(500, 350);
            _sledge.Sprite.Scale = 0.85f;
        }

        private void initSnowman()
        {
            _snowman.LoadContent(Content);
            _snowman.Sprite.Origin = new Vector2(_snowman.Texture.Width / 2,
                _snowman.Texture.Height / 2);
            _snowman.Sprite.Position = new Vector2(800, 400);
            _snowman.Sprite.Scale = 0.9f;
        }

        private void initPlayer1()
        {
            _player1.LoadContent(Content);
            _player1.Sprite.Origin = new Vector2(64, 64);
            _player1.Sprite.Position = new Vector2(200, 500);
            _player1.MovSpeed = 100;
            _player1.LeftMovKey = Keys.A;
            _player1.RightMovKey = Keys.D;
        }

        private void initPlayer2()
        {
            _player2.LoadContent(Content);
            _player2.Sprite.Flip = true;
            _player2.Sprite.Origin = new Vector2(64, 64);
            _player2.Sprite.DrawColor = Color.Red;
            _player2.Sprite.Position = new Vector2(1080, 500);
            _player2.MovSpeed = 100;
            _player2.LeftMovKey = Keys.J;
            _player2.RightMovKey = Keys.L;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player1.Update(gameTime);
            _player2.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _background.Draw(_spriteBatch);
            _snowballPileLeft.Draw(_spriteBatch);
            _snowballPileRight.Draw(_spriteBatch);
            _sledge.Draw(_spriteBatch);
            _snowman.Draw(_spriteBatch);

            _player1.Draw(_spriteBatch);
            _player2.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
