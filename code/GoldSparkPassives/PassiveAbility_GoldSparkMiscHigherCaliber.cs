// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkMiscHigherCaliber
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using LOR_DiceSystem;

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkMiscHigherCaliber : PassiveAbilityBase
  {
    public override string debugDesc => "Ranged Dice Power +1";

    public override void BeforeGiveDamage(BattleDiceBehavior behavior)
    {
      if (behavior.card.card.GetSpec().Ranged != CardRange.Far)
        return;
      this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
      behavior.ApplyDiceStatBonus(new DiceStatBonus()
      {
        power = 1
      });
    }
  }
}
