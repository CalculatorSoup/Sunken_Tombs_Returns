using RoR2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenTombWorm
{
    public class STSaleStarBuff : MonoBehaviour
    {
        public void ReverseNerfStar()
        {
            if (SunkenTomb.scaleStar.Value)
            {
                ChildLocator cl = gameObject.GetComponent<ChildLocator>();
                cl.TryFindChild("Encounters", out Transform encounterHolder);
                for (int i = 0; i < encounterHolder.transform.childCount; i++)
                {
                    Transform encounter = encounterHolder.GetChild(i);
                    if (encounter.name.Contains("Star"))
                    {
                        encounter.GetComponent<BossGroup>().scaleRewardsByPlayerCount = true;
                    } else
                    {
                        //Log.Debug("a star's not quite what you are; if I say this once, all's well so far");
                    }
                }
            }
        }
    }
}

