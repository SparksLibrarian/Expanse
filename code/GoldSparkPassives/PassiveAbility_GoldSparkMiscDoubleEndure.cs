using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkMiscDoubleEndure : PassiveAbilityBase
    {
        public override int OnAddKeywordBufByCard(BattleUnitBuf buf, int stack)
        {
            if (buf.bufType == KeywordBuf.Endurance)
            {
                this.owner.bufListDetail.AddKeywordBufByEtc(buf.bufType, stack);
            }
            return 0;
        }
    }
}
