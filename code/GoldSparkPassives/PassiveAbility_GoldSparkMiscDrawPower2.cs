namespace GoldSparkPassives
{
    internal class PassiveAbility_GoldSparkDrawPower2 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            this.owner.allyCardDetail.DrawCards(2);
        }
    }
}
