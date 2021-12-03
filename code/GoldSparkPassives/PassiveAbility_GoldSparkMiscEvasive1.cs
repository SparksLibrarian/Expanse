// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkMiscEvasive1
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using LOR_DiceSystem;

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkMiscEvasive1 : PassiveAbilityBase
  {
    public override string debugDesc => "Evade Dice Power +1";

    public override void BeforeRollDice(BattleDiceBehavior behavior)
    {
      if (behavior.Detail != BehaviourDetail.Evasion)
        return;
      this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
      behavior.ApplyDiceStatBonus(new DiceStatBonus()
      {
        power = 1
      });
    }
  }
}
