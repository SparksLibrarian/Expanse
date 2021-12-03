// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkCourierMomentum
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkCourierMomentum : PassiveAbilityBase
  {
    public override int OnAddKeywordBufByCard(BattleUnitBuf buf, int stack)
    {
      if (buf.bufType != KeywordBuf.Quickness)
        return 0;
      this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
      return 1;
    }
  }
}
