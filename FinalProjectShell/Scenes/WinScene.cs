﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class WinScene : GameScene
    {
        public WinScene(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            // create and add any components that belong to 
            // this scene to the Scene components list
            AddComponent(new WinnerTextComponent(Game));
            base.Initialize();
            
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            // handle the escape key for this scene
            if (ks.IsKeyDown(Keys.Escape))
            {
                ((ConnectFourGame)Game).HideAllScenes();
                Game.Services.GetService<StartScene>().Show();
            }

            base.Update(gameTime);
        }


    }
}
