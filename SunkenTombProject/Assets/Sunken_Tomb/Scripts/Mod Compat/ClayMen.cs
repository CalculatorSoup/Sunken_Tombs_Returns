using R2API;
using RoR2;
using SunkenTombWorm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClayMen;

namespace SunkenTombWorm
{
    public class ClayMenCompat
    {
        public static void AddEnemies()
        {
            var spawnInfo = new ClayMen.StageSpawnInfo(SunkenTomb.mapName, 0);
            var spawnInfoLoop = new ClayMen.StageSpawnInfo(SunkenTomb.mapName, 5);

            if (SunkenTomb.toggleClayMen.Value && !ClayMenPlugin.StageList.Contains(spawnInfo) && !ClayMenPlugin.StageList.Contains(spawnInfoLoop)) //checking if the stage isn't already in the stage list to avoid adding an extra spawn card
            {
                DirectorAPI.Helpers.AddNewMonsterToStage(ClayMen.ClayMenContent.ClayManCard, false, DirectorAPI.Stage.Custom, SunkenTomb.mapName);
                //Log.Info("Clay Man added to Sunken Tombs (wormsworms)'s spawn pool.");
            }
        }
    }
}