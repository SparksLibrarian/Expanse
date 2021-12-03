// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_ShimmeringWill
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using CustomMapUtility;

namespace GoldSparkPassives
{
  public class PassiveAbility_ShimmeringWill : PassiveAbilityBase
  {
    private int _massAttackCount;
    private bool _activated;
    private int _dmgReduction;

    public override void OnWaveStart() => CustomMapHandler.LoadEnemyTheme("WillTheme.mp3");

    public override void OnRoundStart()
    {
      CustomMapHandler.StartEnemyTheme("WillTheme.mp3");
      this.SetCards();
    }

    private void SetCards()
    {
      this.owner.allyCardDetail.ExhaustAllCards();
      this.AddNewCard(new LorId("SpookysExpanse", 1));
      this.AddNewCard(new LorId("SpookysExpanse", 2));
      this.AddNewCard(new LorId("SpookysExpanse", 3));
      this.AddNewCard(new LorId("SpookysExpanse", 4));
      this.AddNewCard(new LorId("SpookysExpanse", 5));
      this.AddNewCard(new LorId("SpookysExpanse", 6));
      this.AddNewCard(new LorId("SpookysExpanse", 8));
      this.AddNewCard(new LorId("SpookysExpanse", 9));
      this.AddNewCard(new LorId("SpookysExpanse", 11));
    }

    private void AddNewCard(LorId id) => this.owner.allyCardDetail.AddTempCard(id)?.SetCostToZero();
  }
}
