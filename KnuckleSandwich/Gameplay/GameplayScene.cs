﻿using KnuckleSandwich.Gameplay.Entities;
using KnuckleSandwich.Gameplay.Systems;
using KnuckleSandwich.Shared.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay
{
    public class GameplayScene : Scene
    {
        Texture2D _breadTexture;
        Texture2D _backgroundTexture;

        public override void Initialize()
        {
            _breadTexture = Content.Load<Texture2D>(Nez.Content.Sprites.Bread.Idle);
            _backgroundTexture = Content.Load<Texture2D>(Nez.Content.Sprites.Gameplay.Background);
        }

        public override void OnStart()
        {
            var player1 = new WhiteBread(_breadTexture, PlayerIndex.One);
            var player2 = new WhiteBread(_breadTexture, PlayerIndex.Two);
            var spritePointer = new SpritePointer();

            var entities = new Entity[]
            {
                player1,
                player2,
                spritePointer,
                new Background(_backgroundTexture)
            };

            entities.ToList().ForEach(x => AddEntity(x));

            var systems = new EntitySystem[]
            {
                new MovementSystem(),
                new JumpSystem(),
                new FacingSystem(spritePointer, player1, player2)
            };

            systems.ToList().ForEach(x => AddEntityProcessor(x));

        }
    }
}
