// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_WillEGO
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using System;

namespace GoldSparkPassives
{
  public class PassiveAbility_WillEGO : PassiveAbilityBase
  {
    public override void OnRoundEnd()
    {
      if (BattleObjectManager.instance.GetAliveList(this.owner.faction).Exists((Predicate<BattleUnitModel>) (x => x != this.owner)))
        return;
      this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase) this);
      this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2, this.owner);
    }

    public override void OnRoundStart()
    {
      this.AddEgo();
      if (this.owner.emotionDetail.EmotionLevel < 3)
        this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2, this.owner);
      else
        this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 3, this.owner);
    }

    public void AddEgo()
    {
      this.owner.personalEgoDetail.AddCard(new LorId("SpookysExpanse", 201));
      if (this.owner.emotionDetail.EmotionLevel > 2)
        this.owner.personalEgoDetail.AddCard(new LorId("SpookysExpanse", 202));
      if (this.owner.emotionDetail.EmotionLevel <= 4)
        return;
      this.owner.personalEgoDetail.AddCard(new LorId("SpookysExpanse", 203));
    }
  }
}
