using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Shared;
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
    class BoundarySystem : EntityProcessingSystem
    {
        public BoundarySystem() : base(
            new Matcher().All(
                typeof(FighterComponent)
                ))
        { }

        public override void Process(Entity entity)
        {
            var rawXPos = entity.Position.X;
            var spriteRenderer = entity.GetComponent<SpriteRenderer>();
            var halfOfSprite = spriteRenderer.Width / 2;

            var clampedXPos = Mathf.Clamp(rawXPos,
                0 + halfOfSprite,
                Constants.Width - halfOfSprite);

            entity.SetPosition(
                new Vector2(
                    clampedXPos,
                    entity.Position.Y));
        }
    }
}
