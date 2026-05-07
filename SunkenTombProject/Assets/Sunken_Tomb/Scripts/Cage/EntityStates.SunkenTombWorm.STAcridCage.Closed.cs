using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using EntityStates;

namespace SunkenTombWorm.EntityStates.AcridCage
{
    public class Closed : EntityState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            PlayAnimation("Base", "Closed");
        }
    }
}