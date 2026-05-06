using HG;
using R2API;
using RoR2;
using RoR2.ContentManagement;
using RoR2.ExpansionManagement;
using RoR2.Networking;
using RoR2BepInExPack.GameAssetPaths;
using ShaderSwapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using static RoR2.Console;
using static UnityEngine.UI.Image;

namespace SunkenTombWorm.Content
{
    public static class SunkenTombContent
    {

        internal const string ScenesAssetBundleFileName = "SunkenTombsWormsScenes";
        internal const string AssetsAssetBundleFileName = "SunkenTombsWormsAssets";

        private static AssetBundle _scenesAssetBundle;
        private static AssetBundle _assetsAssetBundle;

        internal static UnlockableDef[] UnlockableDefs;
        internal static SceneDef[] SceneDefs;

        //Sunken Tomb
        internal static SceneDef mainSceneDef;
        internal static Sprite mainSceneDefPreviewSprite;
        internal static Material mainBazaarSeer;
        internal static Material terrainMaterial;
        internal static CharacterSpawnCard stAcridCard;

        //Simulacrum
        internal static SceneDef simuSceneDef;
        internal static Sprite simuSceneDefPreviewSprite;
        internal static Material simuBazaarSeer;
        internal static Material itTerrainMaterial;


        public static List<Material> SwappedMaterials = new List<Material>();

        internal static IEnumerator LoadAssetBundlesAsync(AssetBundle scenesAssetBundle, AssetBundle assetsAssetBundle, IProgress<float> progress, ContentPack contentPack)
        {
            _scenesAssetBundle = scenesAssetBundle;
            _assetsAssetBundle = assetsAssetBundle;
            
            var upgradeStubbedShaders = _assetsAssetBundle.UpgradeStubbedShadersAsync();
            while (upgradeStubbedShaders.MoveNext())
            {
                yield return upgradeStubbedShaders.Current;
            }

            yield return LoadAllAssetsAsync(assetsAssetBundle, progress, (Action<UnlockableDef[]>)((assets) =>
            {
                contentPack.unlockableDefs.Add(assets);
            }));

            yield return LoadAllAssetsAsync(assetsAssetBundle, progress, (Action<CharacterSpawnCard[]>)((assets) =>
            {
                stAcridCard = assets.First(a => a.name == "cscSTAcrid");
            }));

            yield return LoadAllAssetsAsync(_assetsAssetBundle, progress, (Action<Sprite[]>)((assets) =>
            {
                mainSceneDefPreviewSprite = assets.First(a => a.name == "texSTScenePreview");
                simuSceneDefPreviewSprite = assets.First(a => a.name == "texSTScenePreview");
            }));

            yield return LoadAllAssetsAsync(_assetsAssetBundle, progress, (Action<Material[]>)((assets) =>
            {
                terrainMaterial = assets.First(a => a.name == "matSTTerrain");
                itTerrainMaterial = assets.First(a => a.name == "matITSTTerrain");

            }));

            yield return LoadAllAssetsAsync(_assetsAssetBundle, progress, (Action<SceneDef[]>)((assets) =>
            {
                SceneDefs = assets;
                mainSceneDef = SceneDefs.First(sd => sd.baseSceneNameOverride == SunkenTomb.mapName);
                simuSceneDef = SceneDefs.First(sd => sd.baseSceneNameOverride == SunkenTomb.simuName);
                Log.Debug(mainSceneDef.nameToken);
                contentPack.sceneDefs.Add(assets);
            }));

            mainSceneDef.portalMaterial = R2API.StageRegistration.MakeBazaarSeerMaterial((Texture2D)mainSceneDef.previewTexture);

            var mainTrackDefRequest = Addressables.LoadAssetAsync<MusicTrackDef>("RoR2/Base/Common/MusicTrackDefs/muSong13.asset");
            while (!mainTrackDefRequest.IsDone)
            {
                yield return null;
            }
            var bossTrackDefRequest = Addressables.LoadAssetAsync<MusicTrackDef>("RoR2/Base/Common/MusicTrackDefs/muSong05.asset");
            while (!bossTrackDefRequest.IsDone)
            {
                yield return null;
            }

            //mainSceneDef.mainTrack = mainTrackDefRequest.Result;
            //mainSceneDef.bossTrack = bossTrackDefRequest.Result;

            //simuSceneDef.mainTrack = mainSceneDef.mainTrack;
            //simuSceneDef.bossTrack = mainSceneDef.bossTrack;
            ContentProvider.SetupMusic();

            GameObject acridBody = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Croco/CrocoMonsterMaster.prefab").WaitForCompletion();

            ItemDef umbraItem = Addressables.LoadAssetAsync<ItemDef>("RoR2/Base/InvadingDoppelganger/InvadingDoppelganger.asset").WaitForCompletion();
            ItemDef lensmakersItem = Addressables.LoadAssetAsync<ItemDef>("RoR2/Base/CritGlasses/CritGlasses.asset").WaitForCompletion();
            ItemDef prinstinctsItem = Addressables.LoadAssetAsync<ItemDef>("RoR2/Base/AttackSpeedOnCrit/AttackSpeedOnCrit.asset").WaitForCompletion();
            ItemDef burgerItem = Addressables.LoadAssetAsync<ItemDef>("RoR2/Base/UtilitySkillMagazine/UtilitySkillMagazine.asset").WaitForCompletion();
            
            ItemCountPair umbraItemPair = new ItemCountPair
            {
                itemDef = umbraItem,
                count = 1
            };
            ItemCountPair lensmakersItemPair = new ItemCountPair
            {
                itemDef = lensmakersItem,
                count = 10
            };
            ItemCountPair prinstinctsItemPair = new ItemCountPair
            {
                itemDef = prinstinctsItem,
                count = 1
            };
            ItemCountPair burgerItemPair = new ItemCountPair
            {
                itemDef = burgerItem,
                count = 1
            };

            stAcridCard.prefab = acridBody;
            stAcridCard.itemsToGrant[0] = (umbraItemPair);
            //stAcridCard.itemsToGrant[1] = (lensmakersItemPair);
            //stAcridCard.itemsToGrant[2] = (prinstinctsItemPair);
            //stAcridCard.itemsToGrant[3] = (burgerItemPair);


            if (SunkenTomb.enableRegular.Value)
            {
                R2API.StageRegistration.RegisterSceneDefToNormalProgression(mainSceneDef);
            }

            
            if (SunkenTomb.enableSimulacrum.Value && SunkenTomb.stage1Simulacrum.Value)
            {
                Simulacrum.RegisterSceneToSimulacrum(simuSceneDef, true);
            } else if (SunkenTomb.enableSimulacrum.Value && !SunkenTomb.stage1Simulacrum.Value)
            {
                Simulacrum.RegisterSceneToSimulacrum(simuSceneDef, false);
            }
            

        }

        internal static void Unload()
        {
            _assetsAssetBundle.Unload(true);
            _scenesAssetBundle.Unload(true);
        }

        private static IEnumerator LoadAllAssetsAsync<T>(AssetBundle assetBundle, IProgress<float> progress, Action<T[]> onAssetsLoaded) where T : UnityEngine.Object
        {
            var sceneDefsRequest = assetBundle.LoadAllAssetsAsync<T>();
            while (!sceneDefsRequest.isDone)
            {
                progress.Report(sceneDefsRequest.progress);
                yield return null;
            }

            onAssetsLoaded(sceneDefsRequest.allAssets.Cast<T>().ToArray());

            yield break;
        }
    }
}
