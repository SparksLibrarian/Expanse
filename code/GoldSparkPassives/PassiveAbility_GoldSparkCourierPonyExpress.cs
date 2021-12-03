using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOR_DiceSystem;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkCourierPonyExpress : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            if (this.owner.IsDead())
                return;

            int count1 = BattleObjectManager.instance.GetList(this.owner.faction).Count;
            int count2 = BattleObjectManager.instance.GetAliveList(this.owner.faction).Count;

            if (count1 <= 1)
                return;

            this.owner.battleCardResultLog?.SetPassiveAbility(this);
            if (count1 == count2)
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 1, this.Owner);
            if (count2 == 1)
                return;
            this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Binding, 2, this.Owner);
        }
    }

}
