using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Shared
{
    class Constants
    {
        public const int Height = 600;
        public const int Width = 800;
        public static readonly float Floor = Height - 80;
        public static float FighterOnFloor(SpriteRenderer sprite)
            => Height - 80 - sprite.Height / 2;
    }
}
