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

        public HurtSystem(IDictionary<Type, FighterState> states) : base(
            states, typeof(Hurt))
        { }

        public override void Process(Entity entity)
        {
            var fc = entity.GetComponent<FighterState>();

            if (fc.TimeSpentInState > stunTime)
            {
                entity.RemoveComponent<Hurt>();
                entity.AddComponent(getState<Idle>());
            }
        }
    }
}
