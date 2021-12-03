// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.EnemyTeamStageManager_Satin
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using CustomMapUtility;

namespace GoldSparkPassives
{
  public class EnemyTeamStageManager_Satin : EnemyTeamStageManager
  {
    public override void OnWaveStart() => CustomMapHandler.InitCustomMap("Satin", (MapManager) new SatinMapManager());

    public override void OnRoundStart() => CustomMapHandler.EnforceMap();
  }
}
