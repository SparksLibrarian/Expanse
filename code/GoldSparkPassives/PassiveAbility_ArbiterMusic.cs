// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_ArbiterMusic
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using CustomMapUtility;

namespace GoldSparkPassives
{
  public class PassiveAbility_ArbiterDummy : PassiveAbilityBase
  {
    public override void OnWaveStart() => CustomMapHandler.InitCustomMap("Arbiter", (MapManager) new ArbiterMapManager());

    public override void OnRoundStart() => CustomMapHandler.EnforceMap();
  }
}
