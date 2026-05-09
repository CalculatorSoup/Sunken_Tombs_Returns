using EnemiesReturns;
using EnemiesReturns.Configuration;
using EnemiesReturns.Enemies.Colossus;
using EnemiesReturns.Enemies.MechanicalSpider.Enemy;
using EnemiesReturns.Enemies.SandCrab;
using EnemiesReturns.Enemies.Spitter;
using EnemiesReturns.Enemies.Swift;
using R2API;
using RoR2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenTombWorm
{
    public class EnemiesReturnsCompat
    {
        public static void AddEnemies()
        {
            // Colossus
            if (SunkenTomb.toggleColossus.Value && General.EnableColossus.Value)
            {
                var card = new RoR2.DirectorCard()
                {
                    spawnCard = (RoR2.SpawnCard)(object)ColossusBody.SpawnCards.cscColossusDefault,
                    spawnDistance = RoR2.DirectorCore.MonsterSpawnDistance.Standard,
                    selectionWeight = Colossus.SelectionWeight.Value,
                    minimumStageCompletions = Colossus.MinimumStageCompletion.Value
                };

                var holder = new DirectorAPI.DirectorCardHolder
                {
                    Card = card,
                    MonsterCategory = DirectorAPI.MonsterCategory.Champions
                };

                if (!Colossus.DefaultStageList.Value.Contains(SunkenTomb.mapName))
                {
                    DirectorAPI.Helpers.AddNewMonsterToStage(holder, false, DirectorAPI.Stage.Custom, SunkenTomb.mapName);
                    DirectorAPI.Helpers.RemoveExistingMonsterFromStage(DirectorAPI.Helpers.MonsterNames.StoneTitan, DirectorAPI.Stage.Custom, SunkenTomb.mapName);
                    Log.Info("Colossus added to Sunken Tombs (wormsworms)'s spawn pool.");
                }
                if (!Colossus.DefaultStageList.Value.Contains(SunkenTomb.simuName))
                {
                    DirectorAPI.Helpers.AddNewMonsterToStage(holder, false, DirectorAPI.Stage.Custom, SunkenTomb.simuName);
                    DirectorAPI.Helpers.RemoveExistingMonsterFromStage(DirectorAPI.Helpers.MonsterNames.StoneTitan, DirectorAPI.Stage.Custom, SunkenTomb.simuName);
                    Log.Info("Colossus added to Sunken Tombs (wormsworms)'s simulacrum spawn pool.");
                }

            }

            // Sand Crab
            if (SunkenTomb.toggleSandCrab.Value && General.EnableSandCrab.Value)
            {
                var card = new RoR2.DirectorCard()
                {
                    spawnCard = (RoR2.SpawnCard)(object)SandCrabBody.SpawnCards.cscSandCrabDefault,
                    spawnDistance = RoR2.DirectorCore.MonsterSpawnDistance.Standard,
                    selectionWeight = SandCrab.SelectionWeight.Value,
                    minimumStageCompletions = SandCrab.MinimumStageCompletion.Value
                };

                var holder = new DirectorAPI.DirectorCardHolder
                {
                    Card = card,
                    MonsterCategory = DirectorAPI.MonsterCategory.Minibosses
                };

                if (!SandCrab.DefaultStageList.Value.Contains(SunkenTomb.mapName)) //Checking whether default stage list has this enemy to avoid adding a duplicate spawn card
                {
                    DirectorAPI.Helpers.AddNewMonsterToStage(holder, false, DirectorAPI.Stage.Custom, SunkenTomb.mapName);
                    Log.Info("Sand Crab added to Sunken Tombs (wormsworms)'s spawn pool.");
                }
                if (!SandCrab.DefaultStageList.Value.Contains(SunkenTomb.simuName))
                {
                    DirectorAPI.Helpers.AddNewMonsterToStage(holder, false, DirectorAPI.Stage.Custom, SunkenTomb.simuName);
                    Log.Info("Sand Crab added to Sunken Tombs (wormsworms)'s simulacrum spawn pool.");
                }

            }
        }
    }
}