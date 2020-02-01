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
        public override void Initialize()
        {
        }

        public override void OnStart()
        {
            var bread = new Entity("bread");
            var texture = Content.Load<Texture2D>(@"Sprites\WhiteBread");
            var sprite = new SpriteRenderer(texture);
            bread.AddComponent(sprite);

            bread.Position = new Vector2(Screen.Width / 2, Screen.Height / 2);

            AddEntity(bread);
        }
    }
}
