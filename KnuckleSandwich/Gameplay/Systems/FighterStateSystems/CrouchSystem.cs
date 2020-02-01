﻿using KnuckleSandwich.Gameplay.Components;
using KnuckleSandwich.Gameplay.Components.FighterStates;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleSandwich.Gameplay.Systems.FighterStateSystems
{
    class CrouchSystem : FighterStateProcessingSystem
    {
        public CrouchSystem() : base(typeof(Crouch)) { }

        public override void Process(Entity entity)
        {
            var yAxis = base.yAxis(entity);

            if (attackButton(entity).IsPressed)
            {
                entity.RemoveComponent<Crouch>();
                addState<CrouchAttack>(entity);
            }

            else if (isTryingToDown(yAxis))
            {
                entity.RemoveComponent<Crouch>();
                addState<Idle>(entity);
            }

            else if (isTryingToUp(yAxis))
            {
                entity.RemoveComponent<Crouch>();
                addState<Jump>(entity);
            }
        }
    }
}