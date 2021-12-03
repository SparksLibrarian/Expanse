using System;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkLonelyattheTop : PassiveAbilityBase
    {
		public override void OnRoundEnd()
		{
			if (!BattleObjectManager.instance.GetAliveList(this.owner.faction).Exists((BattleUnitModel x) => x != this.owner))
			{
				BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
				if (battleCardResultLog != null)
				{
					battleCardResultLog.SetPassiveAbility(this);
				}
				this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 2, this.owner);
				this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 2, this.owner);
				this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 3, this.owner);
				this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, 3, this.owner);
				this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.BreakProtection, 3, this.owner);
			}
		}
	}
}
