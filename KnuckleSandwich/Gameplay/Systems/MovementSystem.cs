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
        const float _moveSpeed = 3f;
        Mover _mover = new Mover();

        public MovementSystem() : base(
            new Matcher()
            .All(typeof(FighterComponent)))
        { }

        public override void Process(Entity entity)
        {
            var fighterComponent = entity.GetComponent<FighterComponent>();

            var leftRightMovement = new Vector2(
                fighterComponent.XAxisInput,
                0);

            if (leftRightMovement != Vector2.Zero)
            {
                var movement = leftRightMovement * _moveSpeed * Time.DeltaTime;

                _mover.CalculateMovement(ref movement, out var res);
                _mover.ApplyMovement(movement);
            }
        }
    }
}
