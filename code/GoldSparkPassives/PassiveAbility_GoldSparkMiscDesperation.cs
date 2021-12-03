using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace GoldSparkPassives
{

    public class PassiveAbility_GoldSparkMiscDesperation : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            double missing = this.owner.MaxHp - this.owner.hp;
            double missing_precent = Math.Floor(missing / this.owner.MaxHp);
            int stacks = (int)Math.Min(Math.Floor(missing_precent / 30), 2);

            this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, stacks);
            this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, stacks);
            this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, stacks);
        }
        
    }
}