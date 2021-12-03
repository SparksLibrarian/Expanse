using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOR_DiceSystem;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkCourierTrailblazer : PassiveAbilityBase
    {
		public override void BeforeGiveDamage(BattleDiceBehavior behavior)
		{
			BattlePlayingCardDataInUnitModel card = behavior.card;
			int? num;
			if (card == null)
			{
				num = null;
			}
			else
			{
				BattleUnitModel target = card.target;
				num = ((target != null) ? new int?(target.speedDiceResult[behavior.card.targetSlotOrder].value) : null);
			}
			int? num2 = num;
			BattlePlayingCardDataInUnitModel card2 = behavior.card;
			int? num3 = (card2 != null) ? new int?(card2.speedDiceResultValue) : null;
			if (num2.GetValueOrDefault() < num3.GetValueOrDefault() & (num2 != null & num3 != null))
			{
				BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
				if (battleCardResultLog != null)
				{
					battleCardResultLog.SetPassiveAbility(this);
				}
				behavior.ApplyDiceStatBonus(new DiceStatBonus
				{
					dmg = 3
				});
			}
		}
	}

}
