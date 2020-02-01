using KnuckleSandwich.Gameplay.Entities;
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
            _breadTexture = Content.Load<Texture2D>(@"Sprites\Bread\Idle");
            _backgroundTexture = Content.Load<Texture2D>(@"Sprites\Gameplay\Background");
        }

        public override void OnStart()
        {
            var entities = new Entity[]
            {
                new WhiteBread(_breadTexture, PlayerIndex.One),
                new WhiteBread(_breadTexture, PlayerIndex.Two),
                new Background(_backgroundTexture)
            };

            entities.ToList().ForEach(x => AddEntity(x));

        }
    }
}
