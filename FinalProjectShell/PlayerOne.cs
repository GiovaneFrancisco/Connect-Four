﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FinalProject
{
    class PlayerOne : Player
    {        
        public PlayerOne(Game game, GameScene parent) : base(game, parent)
        {
        }

        /// <summary>
        /// Creates a new token with the property "useRedTexture" true, so that the token will use the red texture
        /// </summary>
        public override void CreateNewToken()
        {
           if(PlayerEnabled)
            {
                lastCreated = new Token(Game, true);
                this.parent.AddComponent(lastCreated);
            }
        }
    }
}
