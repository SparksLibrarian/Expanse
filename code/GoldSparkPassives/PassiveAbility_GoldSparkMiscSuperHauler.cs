using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldSparkPassives
{
  public class PassiveAbility_SuperHauler : PassiveAbilityBase
  {
    public override void OnSucceedAttack(BattleDiceBehavior behavior)
    {
        this.owner.RecoverHP(2);
        this.owner.breakDetail.RecoverBreak(2);
    }
  }
}
