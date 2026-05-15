using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HG;
using R2API;
using R2API.AddressReferencedAssets;
using R2API.Utils;
using RoR2;
using SunkenTombWorm.Content;
using RoR2.ContentManagement;
using RoR2BepInExPack.GameAssetPaths;
using RoR2BepInExPack.GameAssetPathsBetter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Diagnostics;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using RoR2.Navigation;
using SunkenTombWorm.EntityStates.AcridCage;
//Copied from Broadcast Perch copied from a private Unity project I use for testing maps copied from Ancient Observatory copied from Wetland Downpour copied from Fogbound Lagoon copied from Nuketown


#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete
[assembly: HG.Reflection.SearchableAttribute.OptIn]

namespace SunkenTombWorm
{
    [BepInPlugin(GUID, Name, Version)]
    public class SunkenTomb : BaseUnityPlugin
    {
        public const string Author = "wormsworms";

        public const string Name = "Sunken_Tombs_Returns";

        public const string Version = "1.1.1";

        public const string GUID = Author + "." + Name;

        public static SunkenTomb instance;

        public static ConfigEntry<bool> enableRegular;
        public static ConfigEntry<bool> enableSimulacrum;
        public static ConfigEntry<bool> stage1Simulacrum;
        public static ConfigEntry<bool> waterMuffle;

        public static ConfigEntry<bool> toggleSandCrab;
        public static ConfigEntry<bool> toggleColossus;

        public static ConfigEntry<bool> toggleClayMen;

        public const string mapName = "sunkentombs_wormsworms";
        public const string simuName = "itsunkentombs_wormsworms";

        private void Awake()
        {
            instance = this;

            Log.Init(Logger);

            ConfigSetup();

            ContentManager.collectContentPackProviders += GiveToRoR2OurContentPackProviders;

            RoR2.Language.collectLanguageRootFolders += CollectLanguageRootFolders;

            On.RoR2.MusicController.StartIntroMusic += MusicController_StartIntroMusic;

            AddEntityStates();

            SceneManager.sceneLoaded += SceneSetup;

            RoR2.RoR2Application.onLoadFinished += AddModdedEnemies;

        }
        
        public static void AddModdedEnemies()
        {
            if (IsEnemiesReturns.enabled)
            {
                EnemiesReturnsCompat.AddEnemies(); //Sand Crab, Colossus
            }
            if (IsClayMen.enabled)
            {
                ClayMenCompat.AddEnemies();
            }
        }

        private void MusicController_StartIntroMusic(On.RoR2.MusicController.orig_StartIntroMusic orig, RoR2.MusicController self)
        {
            orig(self);
            AkSoundEngine.PostEvent("STWorms_Play_Music_System", self.gameObject);
        }

        public void AddEntityStates()
        {
            ContentAddition.AddEntityState<Open>(out _); //acrid cage open state
            ContentAddition.AddEntityState<Closed>(out _); //acrid cage closed state
        }

        private void Destroy()
        {
            RoR2.Language.collectLanguageRootFolders -= CollectLanguageRootFolders;
        }

        private static void GiveToRoR2OurContentPackProviders(ContentManager.AddContentPackProviderDelegate addContentPackProvider)
        {
            addContentPackProvider(new ContentProvider());
        }

        public void CollectLanguageRootFolders(List<string> folders)
        {
            folders.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(base.Info.Location), "Language"));
            folders.Add(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(base.Info.Location), "Plugins/Language"));
        }

        private void SceneSetup(Scene newScene, LoadSceneMode loadSceneMode)
        {
            if (newScene.name == mapName)
            {
                AmbienceSetup();

                Transform geyserHolder = GameObject.Find("HOLDER: Jump Pads/Geysers").transform;
                for (int i = 0; i < geyserHolder.childCount; i++)
                {
                    GameObject geyserRing1 = geyserHolder.GetChild(i).GetChild(0).GetChild(0).gameObject;
                    GameObject geyserRing2 = geyserHolder.GetChild(i).GetChild(0).GetChild(1).gameObject;
                    geyserRing1.GetComponent<MeshRenderer>().material = SunkenTombContent.terrainMaterial;
                    geyserRing2.GetComponent<MeshRenderer>().material = SunkenTombContent.terrainMaterial;
                }
            } else if (newScene.name == simuName)
            {
                AmbienceSetup();

                Transform geyserHolder = GameObject.Find("HOLDER: Jump Pads/Geysers").transform;
                for (int i = 0; i < geyserHolder.childCount; i++)
                {
                    GameObject geyserRing1 = geyserHolder.GetChild(i).GetChild(0).GetChild(0).gameObject;
                    GameObject geyserRing2 = geyserHolder.GetChild(i).GetChild(0).GetChild(1).gameObject;
                    geyserRing1.GetComponent<MeshRenderer>().material = SunkenTombContent.itTerrainMaterial;
                    geyserRing2.GetComponent<MeshRenderer>().material = SunkenTombContent.itTerrainMaterial;
                }
            }

        }
        private void AmbienceSetup()
        {
            GameObject ambience = GameObject.Find("SceneInfo/Ambience");
            AkBank bank = ambience.GetComponent<AkBank>();
            AkAmbient[] ambientList = ambience.GetComponents<AkAmbient>();
            AkAmbient ambient1 = ambientList[0];
            AkAmbient ambient2 = ambientList[1];
            if (bank)
            {
                WwiseBankReference arenaSound = Addressables.LoadAssetAsync<WwiseBankReference>("Wwise/E925DE37-300D-46A0-A4A1-B3CE1EE6B43F.asset").WaitForCompletion();
                WwiseEventReference startArenaSound = Addressables.LoadAssetAsync<WwiseEventReference>("Wwise/26967A93-FF27-4D90-A29F-5564145B1EF5.asset").WaitForCompletion();
                WwiseEventReference stopSound = Addressables.LoadAssetAsync<WwiseEventReference>("Wwise/6F2ADD1C-BD55-431F-A62F-80CCD5F9631D.asset").WaitForCompletion();
                bank.data.WwiseObjectReference = arenaSound;
                ambient1.data.WwiseObjectReference = startArenaSound;
                ambient2.data.WwiseObjectReference = stopSound;
            }
        }

        private void ConfigSetup()
        {
            enableRegular =
                base.Config.Bind<bool>("00 - Stages",
                                       "Enable Sunken Tombs",
                                       true,
                                       "If true, Sunken Tombs can appear in regular runs.");
            enableSimulacrum =
                base.Config.Bind<bool>("00 - Stages",
                                       "Enable Simulacrum Variant",
                                       true,
                                       "If true, Sunken Tombs can appear in the Simulacrum.");
            stage1Simulacrum =
                base.Config.Bind<bool>("00 - Stages",
                                       "Enable Simulacrum Variant on Stage 1",
                                       true,
                                       "If false, Sunken Tombs will only appear after clearing at least one stage in the Simulacrum, like Commencement.");
            waterMuffle =
                base.Config.Bind<bool>("00 - Stages",
                                       "Underwater Music Muffling",
                                       false,
                                       "If true, music will be muffled while underwater in Sunken Tombs.");

            toggleSandCrab =
                base.Config.Bind<bool>("01 - Monsters: EnemiesReturns",
                                       "Enable Sand Crab",
                                       true,
                                       "If true, Sand Crabs will appear in Sunken Tombs.");
            toggleColossus =
                base.Config.Bind<bool>("01 - Monsters: EnemiesReturns",
                                       "Enable Colossus",
                                       false,
                                       "If true, Collossi will appear in Sunken Tombs.");
            toggleClayMen =
                base.Config.Bind<bool>("03 - Monsters: Misc.",
                                       "Enable Clay Man",
                                       true,
                                       "If true, Clay Men will appear in Sunken Tombs.");

        }
    }
}
