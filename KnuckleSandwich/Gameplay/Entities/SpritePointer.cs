using KnuckleSandwich.Gameplay.Components;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Entities
{
    class SpritePointer : Entity
    {
        public SpritePointer()
        {
            AddComponent(new SpritePointing());
        }
    }
}
