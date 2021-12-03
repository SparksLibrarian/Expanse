using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkMiscStatusDamageImmune : EmotionCardAbilityBase
    {
        public override bool IsImmuneDmg(DamageType type, KeywordBuf keyword = KeywordBuf.None)
        {
            if (type == DamageType.Buf)
            {
                if (keyword <= KeywordBuf.Bleeding)
                {
                    if (keyword != KeywordBuf.Burn && keyword != KeywordBuf.Bleeding)
                        goto label_5;
                }
                else if (keyword != KeywordBuf.Fairy && keyword != KeywordBuf.Emotion_Sin)
                    goto label_5;
                return true;
            }
            label_5:
            return base.IsImmuneDmg(type, keyword);
        }
    }

}
