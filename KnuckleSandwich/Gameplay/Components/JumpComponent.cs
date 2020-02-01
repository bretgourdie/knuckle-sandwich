using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Components
{
    class JumpComponent : Component
    {
        public const float InitialJump = -1200f;
        public const float Decay = 50f;

        public float CurrentYVelocity { get; set; }
    }
}
