namespace GoldSparkPassives
{
    internal class PassiveAbility_GoldSparkMiscSparkling : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            this.owner.cardSlotDetail.RecoverPlayPoint(1);
            this.owner.allyCardDetail.DrawCards(1);
        }
    }
}