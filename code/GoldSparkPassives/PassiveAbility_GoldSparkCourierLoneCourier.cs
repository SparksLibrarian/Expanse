// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.PassiveAbility_GoldSparkCourierLoneCourier
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using System;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkCourierLone : PassiveAbilityBase
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
				this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 3, this.owner);
			}
		}
	}
}
