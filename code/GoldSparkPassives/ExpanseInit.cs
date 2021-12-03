// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.ExpanseInit
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using HarmonyLib;
using LOR_DiceSystem;
using Mod;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UI;
using UnityEngine;

namespace GoldSparkPassives
{
  public class ExpanseInit : ModInitializer
  {
    public static string packageId = "SpookysExpanse";
    public static string path;
    public static Dictionary<string, Sprite> ArtWorks = new Dictionary<string, Sprite>();
    public static Dictionary<string, AudioClip> CustomSound;

    public override void OnInitializeMod()
    {
      Harmony harmony = new Harmony("LOR.Expanse_MOD");
      MethodInfo method1 = typeof (ExpanseInit).GetMethod("BookModel_SetXmlInfo");
      harmony.Patch((MethodBase) typeof (BookModel).GetMethod("SetXmlInfo", AccessTools.all), postfix: new HarmonyMethod(method1));
      ExpanseInit.path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
      ExpanseInit.GetArtWorks(new DirectoryInfo(ExpanseInit.path + "/ArtWork"));
      ExpanseInit.CustomSound = ExpanseInit.PrepareAudioClips();
      ExpanseInit.RemoveError();
      MethodInfo method2 = typeof (ExpanseInit).GetMethod("UISpriteDataManager_GetStoryIcon");
      harmony.Patch((MethodBase) typeof (UISpriteDataManager).GetMethod("GetStoryIcon", AccessTools.all), new HarmonyMethod(method2));
    }

    public static Dictionary<string, AudioClip> PrepareAudioClips() => new Dictionary<string, AudioClip>()
    {
      {
        "Shiva",
        ExpanseInit.Mp3toAudioClip(ExpanseInit.path + "/BGM/Shiva.mp3")
      },
      {
        "Bethel",
        ExpanseInit.Mp3toAudioClip(ExpanseInit.path + "/BGM/Bethel.mp3")
      }
    };

    public static AudioClip Mp3toAudioClip(string path)
    {
      Mp3FileReader mp3FileReader = new Mp3FileReader(path);
      WaveFileWriter.CreateWaveFile(path + ".wav", (IWaveProvider) mp3FileReader);
      WAV wav = new WAV(File.ReadAllBytes(path + ".wav"));
      AudioClip audioClip = AudioClip.Create("cove", wav.SampleCount, 1, wav.Frequency, false);
      audioClip.SetData(wav.LeftChannel, 0);
      File.Delete(path + ".wav");
      return audioClip;
    }

    public static void ChangeEnemyTeamTheme()
    {
      MapManager currentMapObject = SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject;
      currentMapObject.mapBgm[0] = ExpanseInit.CustomSound["Bethel"];
      currentMapObject.mapBgm[1] = ExpanseInit.CustomSound["Bethel"];
      currentMapObject.mapBgm[2] = ExpanseInit.CustomSound["Bethel"];
      SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(currentMapObject.mapBgm);
    }

    public static void ChangeEnemyTeamThemeAssimilation() => SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(new AudioClip[3]
    {
      ExpanseInit.CustomSound["Bethel"],
      ExpanseInit.CustomSound["Bethel"],
      ExpanseInit.CustomSound["Bethel"]
    });

    public static void ChangeEnemyTeamThemePhase1()
    {
      MapManager currentMapObject = SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject;
      currentMapObject.mapBgm[0] = ExpanseInit.CustomSound["Shiva"];
      currentMapObject.mapBgm[1] = ExpanseInit.CustomSound["Shiva"];
      currentMapObject.mapBgm[2] = ExpanseInit.CustomSound["Shiva"];
      SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(currentMapObject.mapBgm);
    }

    public static bool InitCustomMap(MapManager m)
    {
      m.mapBgm = new AudioClip[3];
      m.mapBgm[0] = ExpanseInit.CustomSound["Shiva"];
      m.mapBgm[1] = ExpanseInit.CustomSound["Shiva"];
      m.mapBgm[2] = ExpanseInit.CustomSound["Shiva"];
      foreach (Component componentsInChild in m.GetComponentsInChildren<Component>())
      {
        SpriteRenderer spriteRenderer1 = componentsInChild as SpriteRenderer;
        if (!((UnityEngine.Object) spriteRenderer1 == (UnityEngine.Object) null))
        {
          if (!(spriteRenderer1.name == "BG"))
          {
            SpriteRenderer spriteRenderer2 = spriteRenderer1;
            if (spriteRenderer2.name.Contains("Floor"))
            {
              Texture2D texture = ExpanseInit.ArtWorks["Floor"].texture;
              spriteRenderer2.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float) texture.width, (float) texture.height), new Vector2(0.5f, 0.2f), spriteRenderer2.sprite.pixelsPerUnit, 0U, SpriteMeshType.FullRect);
              continue;
            }
          }
          else
          {
            Texture2D texture = ExpanseInit.ArtWorks["Background"].texture;
            spriteRenderer1.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float) texture.width, (float) texture.height), new Vector2(0.5f, 0.2f), spriteRenderer1.sprite.pixelsPerUnit, 0U, SpriteMeshType.FullRect);
            continue;
          }
        }
        if (componentsInChild.name != m.name && !componentsInChild.name.Contains("Background") && !componentsInChild.name.Contains("Frame") && !componentsInChild.name.Contains("GroundSprites") && componentsInChild.name != "Camera" && componentsInChild.name != "BG" && !componentsInChild.name.Contains("Floor"))
          componentsInChild.gameObject.SetActive(false);
      }
      return true;
    }

    public static void RemoveError()
    {
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      stringList1.Add("0Harmony");
      stringList1.Add("NAudio");
      foreach (string errorLog1 in Singleton<ModContentManager>.Instance.GetErrorLogs())
      {
        string errorLog = errorLog1;
        if (stringList1.Exists((Predicate<string>) (x => errorLog.Contains(x))))
          stringList2.Add(errorLog);
      }
      foreach (string str in stringList2)
        Singleton<ModContentManager>.Instance.GetErrorLogs().Remove(str);
    }

    public static void BookModel_SetXmlInfo(
      BookModel __instance,
      BookXmlInfo ____classInfo,
      ref List<DiceCardXmlInfo> ____onlyCards)
    {
      if (!(__instance.BookId.packageId == ExpanseInit.packageId))
        return;
      ____onlyCards.AddRange(____classInfo.EquipEffect.OnlyCard.Select<int, DiceCardXmlInfo>((Func<int, DiceCardXmlInfo>) (id => ItemXmlDataList.instance.GetCardItem(new LorId(ExpanseInit.packageId, id)))));
    }

    public static void GetArtWorks(DirectoryInfo dir)
    {
      if (dir.GetDirectories().Length != 0)
      {
        foreach (DirectoryInfo directory in dir.GetDirectories())
          ExpanseInit.GetArtWorks(directory);
      }
      foreach (FileInfo file in dir.GetFiles())
      {
        Texture2D texture2D = new Texture2D(2, 2);
        texture2D.LoadImage(File.ReadAllBytes(file.FullName));
        Sprite sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, (float) texture2D.width, (float) texture2D.height), new Vector2(0.0f, 0.0f));
        string withoutExtension = Path.GetFileNameWithoutExtension(file.FullName);
        ExpanseInit.ArtWorks[withoutExtension] = sprite;
      }
    }

    public static void ChangeEnemyTeamTheme(string bgmName)
    {
      MapManager currentMapObject = SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject;
      currentMapObject.mapBgm[0] = ExpanseInit.CustomSound[bgmName];
      currentMapObject.mapBgm[1] = ExpanseInit.CustomSound[bgmName];
      currentMapObject.mapBgm[2] = ExpanseInit.CustomSound[bgmName];
      SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(currentMapObject.mapBgm);
    }

    public static bool UISpriteDataManager_GetStoryIcon(
      UISpriteDataManager __instance,
      ref UIIconManager.IconSet __result,
      string story)
    {
      if (!ExpanseInit.ArtWorks.ContainsKey(story))
        return true;
      __result = new UIIconManager.IconSet()
      {
        type = story,
        icon = ExpanseInit.ArtWorks[story],
        iconGlow = ExpanseInit.ArtWorks[story]
      };
      return false;
    }
  }
}
