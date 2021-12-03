// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.DiceCardAbility_superyujin
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

namespace GoldSparkPassives
{
  public class DiceCardAbility_superyujin : DiceCardAbilityBase
  {
    public override void OnRollDice()
    {
      if (this.behavior.DiceVanillaValue < 4 || this.behavior.DiceVanillaValue != this.behavior.GetDiceMax())
        return;
      this.behavior.ApplyDiceStatBonus(new DiceStatBonus()
      {
        power = 42
      });
      if (this.owner.faction != Faction.Player)
        return;
      Singleton<StageController>.Instance.ReserveAchievement(AchievementEnum.ONCE_FOUR_BORDER);
    }
  }
}
