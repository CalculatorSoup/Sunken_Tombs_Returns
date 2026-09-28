using R2API;
using RoR2;
using RoR2.CharacterAI;
using SunkenTombWorm.Content;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SunkenTombWorm
{
    public class AcridPrefab
    {
        public static GameObject newBody = PrefabAPI.InstantiateClone(Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Croco/CrocoBody.prefab").WaitForCompletion(), "STWormCrocoMonsterBody", true);
        public static GameObject newMaster = PrefabAPI.InstantiateClone(Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Croco/CrocoMonsterMaster.prefab").WaitForCompletion(), "STWormCrocoMonsterMaster", true);
            

        public static void Start()
        {
            ContentAddition.AddBody(newBody);
            ContentAddition.AddMaster(newMaster);

            SetupAcridPrefab();
        }
        public static void SetupAcridPrefab()
        {

            CharacterMaster cm = newMaster.GetComponent<CharacterMaster>();

            cm.bodyPrefab = newBody;

            // no regen, more base damage
            CharacterBody cb = newBody.GetComponent<CharacterBody>();

            cb.baseRegen = 0;
            cb.levelRegen = 0;
            cb.baseDamage = 30;
            cb.levelDamage = 6;

            //prioritize players
            BaseAI bai = newMaster.GetComponent<BaseAI>();

            bai.prioritizePlayers = true;


            //no more doing that I think. Or at least it'll only do it one time. I think
            var skillDrivers = newMaster.GetComponents<RoR2.CharacterAI.AISkillDriver>();
            foreach (RoR2.CharacterAI.AISkillDriver driver in skillDrivers)
            {
                if (driver.customName == "LeapAwayFromEnemy")
                {
                    driver.maxTimesSelected = 0;
                }
            }
        }
    }
}



