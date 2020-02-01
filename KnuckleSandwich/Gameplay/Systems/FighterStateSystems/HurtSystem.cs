using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class HurtSystem : FighterStateProcessingSystem
    {
        const float stunTime = 0.25f;

        public HurtSystem() : base(typeof(Hurt))
        { }

        public override void Process(Entity entity)
        {
            var fc = entity.GetComponent<FighterState>();

            if (fc.TimeSpentInState > stunTime)
            {
                entity.RemoveComponent<Hurt>();
                addState<Idle>(entity);
            }
        }
    }
}
