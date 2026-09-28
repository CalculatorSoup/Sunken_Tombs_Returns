using R2API;
using RoR2;
using SS2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenTombWorm
{
    public class Starstorm2Compat
    {
        public static string FindEnemyConfig(string monsterName) //Lamp, Lamp Boss, Acid Bug
        {
            var defstring = "00 - Enemy Disabling.Disable Enemy: " + monsterName;
            var monsterConfig = SS2Config.ConfigMonster.GetConfigEntries();
            foreach (var entry in monsterConfig)
            {
                if (entry.Definition.ToString() == defstring)
                {
                    var configValue = entry.GetSerializedValue();
                    return configValue;
                }
            }
            return "false";

        }

        public static void AddEnemies()
        {
            // Mimic
            var mimicValue = FindEnemyConfig("Mimic");

            if (SunkenTomb.toggleMimic.Value && mimicValue == "false")
            {
                var mimicCard = new RoR2.DirectorCard()
                {
                    spawnCard = SS2Assets.LoadAsset<RoR2.InteractableSpawnCard>("iscMimic", (SS2Bundle)17),
                    spawnDistance = RoR2.DirectorCore.MonsterSpawnDistance.Standard,
                    selectionWeight = 2
                };

                var mimicHolder = new DirectorAPI.DirectorCardHolder
                {
                    Card = mimicCard,
                    InteractableCategory = DirectorAPI.InteractableCategory.Chests
                };
                DirectorAPI.Helpers.AddNewInteractableToStage(mimicHolder, DirectorAPI.Stage.Custom, SunkenTomb.mapName);
                Log.Info("Security Chest added to Sunken Tombs' spawn pool.");

            }

            // Clay Monger
            if (SS2Config.enableBeta.value)
            {
                var mogValue = FindEnemyConfig("Clay Monger");

                if (SunkenTomb.toggleMonger.Value && mogValue == "false")
                {
                    var wayfarerCard = new RoR2.DirectorCard()
                    {
                        spawnCard = SS2Assets.LoadAsset<RoR2.SpawnCard>("cscClayMonger", (SS2Bundle)17),
                        spawnDistance = RoR2.DirectorCore.MonsterSpawnDistance.Standard,
                        selectionWeight = 1
                    };

                    var wayfarerHolder = new DirectorAPI.DirectorCardHolder
                    {
                        Card = wayfarerCard,
                        MonsterCategory = DirectorAPI.MonsterCategory.Champions
                    };
                    DirectorAPI.Helpers.AddNewMonsterToStage(wayfarerHolder, false, DirectorAPI.Stage.Custom, SunkenTomb.mapName);
                    DirectorAPI.Helpers.AddNewMonsterToStage(wayfarerHolder, false, DirectorAPI.Stage.Custom, SunkenTomb.simuName);
                    Log.Info("Clay Monger added to Sunken Tombs' spawn pool.");
                }
            }
        }

    }

}
