// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkYujinOverbreathing
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

namespace GoldSparkPassives
{
  public class PassiveAbility_GoldSparkYujinOverbreathing : PassiveAbilityBase
  {
    public override string debugDesc => "Restore 2 Light upon using a page whose original Cost is 4 or higher.";

    public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
    {
      if (curCard.card.GetOriginCost() < 4)
        return;
      this.owner.cardSlotDetail.RecoverPlayPoint(2);
    }
  }
}
