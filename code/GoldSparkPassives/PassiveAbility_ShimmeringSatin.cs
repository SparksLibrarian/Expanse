// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_ShimmeringSatin
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using CustomMapUtility;

namespace GoldSparkPassives
{
  public class PassiveAbility_ShimmeringSatin : PassiveAbilityBase
  {
    private int _massAttackCount;
    private bool _activated;
    private int _dmgReduction;

    public override void OnWaveStart() => CustomMapHandler.InitCustomMap("Satin", (MapManager) new SatinMapManager());

    public override void OnRoundStart()
    {
      CustomMapHandler.EnforceMap(1);
      this.SetCards();
    }

    private void SetCards()
    {
      this.owner.allyCardDetail.ExhaustAllCards();
      this.AddNewCard(new LorId("SpookysExpanse", 59));
      this.AddNewCard(new LorId("SpookysExpanse", 60));
      this.AddNewCard(new LorId("SpookysExpanse", 60));
      this.AddNewCard(new LorId("SpookysExpanse", 61));
      this.AddNewCard(new LorId("SpookysExpanse", 62));
      this.AddNewCard(new LorId("SpookysExpanse", 63));
      this.AddNewCard(new LorId("SpookysExpanse", 64));
      this.AddNewCard(new LorId("SpookysExpanse", 65));
      this.AddNewCard(new LorId("SpookysExpanse", 65));
    }

    private void AddNewCard(LorId id) => this.owner.allyCardDetail.AddTempCard(id)?.SetCostToZero();
  }
}
