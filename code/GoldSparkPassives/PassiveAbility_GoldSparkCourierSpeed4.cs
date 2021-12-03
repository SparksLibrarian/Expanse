// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkCourierSpeed4
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkCourierSpeed4 : PassiveAbilityBase
  {
    public override string debugDesc => "Speed Dice Slot +2. Gain an additional Speed die at Emotion Level 3. (Cannot Overlap (Hopefully))";

    public override int SpeedDiceNumAdder()
    {
      BattleUnitModel owner = this.owner;
      int num1;
      if (owner == null)
      {
        num1 = 0;
      }
      else
      {
        int? emotionLevel = owner.emotionDetail?.EmotionLevel;
        int num2 = 3;
        num1 = emotionLevel.GetValueOrDefault() >= num2 & emotionLevel.HasValue ? 1 : 0;
      }
      return num1 != 0 ? 3 : 2;
    }
  }
}
