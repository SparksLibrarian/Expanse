// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkCourierSpecialDelivery
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using LOR_DiceSystem;

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkCourierSpecialDelivery : PassiveAbilityBase
  {
    private const int _powAdd = 1;
    private const int _powRed = -1;

    public override string debugDesc => "Blunt & Defensive Dice Power +1, Slash & Pierce Dice Power -1.";

    public override void BeforeRollDice(BattleDiceBehavior behavior)
    {
      base.BeforeRollDice(behavior);
      switch (behavior.Detail)
      {
        case BehaviourDetail.Slash:
        case BehaviourDetail.Penetrate:
          this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
          behavior.ApplyDiceStatBonus(new DiceStatBonus()
          {
            power = -1
          });
          break;
        case BehaviourDetail.Hit:
        case BehaviourDetail.Guard:
        case BehaviourDetail.Evasion:
          this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
          behavior.ApplyDiceStatBonus(new DiceStatBonus()
          {
            power = 1
          });
          break;
      }
    }
  }
}
