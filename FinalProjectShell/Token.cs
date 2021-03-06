﻿using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class Token : DrawableGameComponent
    {
        private static Texture2D redTexture;
        private static Texture2D yellowTexture;
        public Texture2D Texture { get; set; }
        private bool useRedTexture;

        private bool moveToRestPosition = false;
        private Vector2 restPosition;

        public Vector2 position;
        
        public Token(Game game, bool playerOneActive) : base(game)
        {

            this.useRedTexture = playerOneActive;
        }

        public override void Initialize()
        {
            DrawOrder = int.MaxValue - 2;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            if (redTexture == null)
            {
                redTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Red");
                yellowTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Yellow");
            }

            Texture = useRedTexture ? redTexture : yellowTexture;

            base.LoadContent();
        }

        /// <summary>
        /// Sets the rest position to a specific one depending on where it needs to fall
        /// </summary>
        /// <param name="tokenRestingPositon"></param>
        internal void MoveTokenToRestingPosition(Vector2 tokenRestingPositon)
        {
            moveToRestPosition = true;
            restPosition = tokenRestingPositon;
        }

        public override void Update(GameTime gameTime)
        {
            if (!moveToRestPosition)
            {

                MouseState ms = Mouse.GetState();
                position = new Vector2(ms.X - Texture.Width / 2, 10);

                position.X = MathHelper.Clamp(position.X, 40, Game.GraphicsDevice.Viewport.Width - Texture.Width - 40);
            } else
            {
                if (Math.Round(position.X) != restPosition.X)
                {
                    position = Vector2.Lerp(position, new Vector2(restPosition.X, position.Y), 0.3f);
                    //Console.WriteLine(position.X + ", " + restPosition.X);
                } else
                {

                    position = Vector2.Lerp(position, restPosition, 0.05f);
                }
                if (position == restPosition)
                {
                    this.Enabled = false;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();

            sb.Draw(Texture, position, Microsoft.Xna.Framework.Color.White);

            sb.End();

            base.Draw(gameTime);
        }
    }
}
