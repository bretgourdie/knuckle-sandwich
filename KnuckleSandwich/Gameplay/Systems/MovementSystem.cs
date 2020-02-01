using KnuckleSandwich.Gameplay.Components;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Systems
{
    class MovementSystem : EntityProcessingSystem
    {
        const float _moveSpeed = 150f;

        public MovementSystem() : base(
            new Matcher()
            .All(
                typeof(FighterComponent),
                typeof(Mover),
                typeof(JumpComponent)
            )
        )
        { }

        public override void Process(Entity entity)
        {
            var fighterComponent = entity.GetComponent<FighterComponent>();

            if (fighterComponent.XAxisInput != Vector2.Zero.X)
            {
                var mover = entity.GetComponent<Mover>();

                var leftRightMovement = new Vector2(
                    fighterComponent.XAxisInput,
                    0);

                var movement = leftRightMovement * _moveSpeed * Time.DeltaTime;

                mover.CalculateMovement(ref movement, out var res);
                mover.ApplyMovement(movement);
            }
        }
    }
}
