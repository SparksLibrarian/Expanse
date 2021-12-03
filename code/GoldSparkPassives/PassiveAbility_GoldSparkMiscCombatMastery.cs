// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkMiscCombatMastery
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkMiscCombatMastery : PassiveAbilityBase
  {
    public override string debugDesc => "Dice Power +1";

    public override void BeforeRollDice(BattleDiceBehavior behavior)
    {
      this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
      behavior.ApplyDiceStatBonus(new DiceStatBonus()
      {
        power = 1
      });
    }
  }
}
