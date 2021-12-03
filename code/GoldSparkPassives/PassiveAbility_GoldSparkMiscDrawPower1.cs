namespace GoldSparkPassives
{
    internal class PassiveAbility_GoldSparkDrawPower1 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            this.owner.allyCardDetail.DrawCards(1);
        }
    }
}
