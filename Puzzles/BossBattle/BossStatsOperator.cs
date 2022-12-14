using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.BossBattle
{
    public class BossStatsOperator : StatsOperator
    {
        public void SetStats(BattleStats[] battleStages)
        {
            if(battleStages.Length == 0)
                return;

            statsStages = new List<BattleStats>(battleStages);
            statsStages.Sort();
            stats = statsStages[statsStages.Count-1];
            Debug.Log(statsStages.Remove(stats));
            SetHP(stats.Health);
            SetStatsToText();
        }

        public override void Cooldown(bool boost)
        {
            if (skillBase.enabled)
                ActivateSkill();

            base.Cooldown(boost);
        }

        public override bool Damage()
        {
            bool result = base.Damage();


            return result;
        }
    }
}
