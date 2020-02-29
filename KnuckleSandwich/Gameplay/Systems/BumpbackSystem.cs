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
    class BumpbackSystem : EntityProcessingSystem
    {
        const float _knockbackDecay = 5f;

        public BumpbackSystem() : base(
            new Matcher().All(
                typeof(FighterComponent)
                ))
        { }

        public override void Process(Entity entity)
        {
            var fc = entity.GetComponent<FighterComponent>();

            if (fc.KnockbackVelocity != 0f)
            {
                var mover = entity.GetComponent<Mover>();

                mover.ApplyMovement(
                    new Vector2(
                        fc.KnockbackVelocity,
                        0));

                var amountToSubtract = _knockbackDecay;

                if (fc.KnockbackVelocity < 0)
                {
                    amountToSubtract *= -1;
                }

                fc.KnockbackVelocity -= amountToSubtract;
            }
        }
    }
}
