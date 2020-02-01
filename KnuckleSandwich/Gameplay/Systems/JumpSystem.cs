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
    class JumpSystem : EntityProcessingSystem
    {
        public JumpSystem() : base(
            new Matcher().All(
                typeof(FighterComponent),
                typeof(Mover),
                typeof(JumpComponent),
                typeof(SpriteRenderer)
            ))
        { }

        public override void Process(Entity entity)
        {
            var fighterComponent = entity.GetComponent<FighterComponent>();

            var jumpComponent = entity.GetComponent<JumpComponent>();

            var pressedUp = fighterComponent.YAxisInput.Value > 0.25f;
            var mover = entity.GetComponent<Mover>();

            var sprite = entity.GetComponent<SpriteRenderer>();
            var fighterOnFloorYValue = Constants.FighterOnFloor(sprite);

            // Start the jump
            if (pressedUp)
            {
                if (entity.Position.Y >= fighterOnFloorYValue)
                {
                    jumpComponent.CurrentYVelocity = JumpComponent.InitialJump;
                    var motion = new Vector2(0, jumpComponent.CurrentYVelocity) * Time.DeltaTime;
                    mover.CalculateMovement(ref motion, out var res);
                    mover.ApplyMovement(motion);
                }
            }


            if (entity.Position.Y < fighterOnFloorYValue)
            {
                jumpComponent.CurrentYVelocity += JumpComponent.Decay;
                var motion = new Vector2(0, jumpComponent.CurrentYVelocity) * Time.DeltaTime;
                mover.CalculateMovement(ref motion, out var res);
                mover.ApplyMovement(motion);
            }

            if (entity.Position.Y > fighterOnFloorYValue)
            {
                entity.Position = new Vector2(
                    entity.Position.X,
                    Constants.FighterOnFloor(sprite)
                );
                jumpComponent.CurrentYVelocity = 0;
            }
        }
    }
}
