using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Gameplay.Entities;
using KnuckleSandwich.Shared.Entities;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Systems
{
    class FacingSystem : EntityProcessingSystem
    {
        readonly Entity _spritePointer;
        readonly Entity[] _breads;

        public FacingSystem(
            Entity spritePointer,
            params Entity[] players) : base(
            new Matcher().One(
                typeof(FighterComponent),
                typeof(SpritePointing)
            ))
        {
            _spritePointer = spritePointer;
            _breads = players;
        }

        public override void Process(Entity entity)
        {
            var fighterComponent = entity.GetComponent<FighterComponent>();
            if (fighterComponent != null)
            {
                var sprite = entity.GetComponent<SpriteRenderer>();
                sprite.FlipX = _spritePointer.Position.X < entity.Position.X;
            }

            if (entity.GetComponent<SpritePointing>() != null)
            {
                var middle = _breads.Sum(x => x.Position.X) / 2;
                entity.Position = new Vector2(middle, entity.Position.Y);
            }
        }
    }
}
