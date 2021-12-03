using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOR_DiceSystem;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkRobinPlayer : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.TargetDice.Type == BehaviourType.Standby)
                return;
            this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase)this);
            behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus()
            {
                power = -2
            });
        }

        private readonly KeywordBuf[] BUF_ARRAY = new KeywordBuf[3]
        {
            KeywordBuf.Strength,
            KeywordBuf.Quickness,
            KeywordBuf.Endurance
        };

        public override void OnRoundStart()
        {
            base.OnRoundStart();
            KeywordBuf buf = this.BUF_ARRAY[UnityEngine.Random.Range(0, this.BUF_ARRAY.Length)];
            this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(buf, 1, null);
        }
    }
}
