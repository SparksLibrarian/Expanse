// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkYujinKizuna
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkYujinKizuna : PassiveAbilityBase
  {
    private int _stack;

    public override string debugDesc => "After an ally dies, gain 1 Strength and Endurance for the rest of the Act.";

    public override void OnWaveStart() => this._stack = 0;

    public override void OnRoundStart()
    {
      if (this._stack <= 0)
        return;
      this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, this._stack, this.owner);
      this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, this._stack, this.owner);
    }

    public override void OnDieOtherUnit(BattleUnitModel unit)
    {
      if (unit.faction != this.owner.faction || this._stack >= 99)
        return;
      ++this._stack;
    }
  }
}
