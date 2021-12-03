// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkCourierGreataxe
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using LOR_DiceSystem;

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkCourierGreataxe : PassiveAbilityBase
  {
    private const int _powAdd = 2;
    private const int _powRed = -2;

    public override string debugDesc => "Slash Dice Power +2, Pierce & Blunt Dice Power -2.";

    public override void BeforeRollDice(BattleDiceBehavior behavior)
    {
      base.BeforeRollDice(behavior);
      switch (behavior.Detail)
      {
        case BehaviourDetail.Slash:
          this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
          behavior.ApplyDiceStatBonus(new DiceStatBonus()
          {
            power = 2
          });
          break;
        case BehaviourDetail.Penetrate:
        case BehaviourDetail.Hit:
          this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
          behavior.ApplyDiceStatBonus(new DiceStatBonus()
          {
            power = -2
          });
          break;
      }
    }
  }
}
