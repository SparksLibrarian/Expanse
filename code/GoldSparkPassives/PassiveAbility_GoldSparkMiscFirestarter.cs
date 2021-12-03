using LOR_DiceSystem;
using System.Collections.Generic;

namespace GoldSparkPassives
{
    public class PassiveAbility_GoldSparkMiscFirestarter : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            base.OnUseCard(curCard);
            if (!this.CheckCondition(curCard))
                return;
            this.owner.battleCardResultLog?.SetPassiveAbility((PassiveAbilityBase)this);
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus()
            {
                power = 1
            });
        }

        private bool CheckCondition(BattlePlayingCardDataInUnitModel card)
        {
            if (card == null)
                return false;
            DiceCardXmlInfo xmlData = card.card.XmlData;
            if (xmlData == null)
                return false;
            if (xmlData.Keywords.Contains("Burn_keyword"))
                return true;
            List<string> abilityKeywords = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords(xmlData);
            for (int index = 0; index < abilityKeywords.Count; ++index)
            {
                if (abilityKeywords[index] == "Burn_keyword")
                    return true;
            }
            foreach (DiceBehaviour behaviour in card.card.GetBehaviourList())
            {
                List<string> keywordsByScript = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords_byScript(behaviour.Script);
                for (int index = 0; index < keywordsByScript.Count; ++index)
                {
                    if (keywordsByScript[index] == "Burn_keyword")
                        return true;
                }
            }
            return false;
        }
    }
}
