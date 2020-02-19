using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class IdleSystem : FighterStateProcessingSystem
    {
        public IdleSystem() : base(typeof(Idle))
        { }

        public override void Process(Entity entity)
        {
            base.Process(entity);

            var yInput = yAxis(entity);
            var xInput = xAxis(entity);

            if (isTryingToTaunt(tauntButton(entity)))
            {
                cleanupForStateChange(entity);
                addState<NeutralAttack>(entity);
            }

            else if (isTryingToUp(yInput))
            {
                cleanupForStateChange(entity);
                addState<Jump>(entity);
            }

            else if (isTryingToDown(yInput))
            {
                cleanupForStateChange(entity);
                addState<Crouch>(entity);
            }

            else if (isTryingToLeft(xInput) || isTryingToRight(xInput))
            {
                cleanupForStateChange(entity);
                addState<Walk>(entity);
            }
        }

        protected override void cleanupForStateChange(Entity entity)
        {
            entity.RemoveComponent<Idle>();
        }
    }
}
