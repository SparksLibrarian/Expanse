using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOR_DiceSystem;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkCourierViper : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(this.owner.faction);
            for (int i = 0; i < 3 && aliveList.Count > 0; i++)
            {
                BattleUnitModel battleUnitModel = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                aliveList.Remove(battleUnitModel);
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 1);
            }
        }
    }
}
