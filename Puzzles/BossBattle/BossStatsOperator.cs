namespace Puzzle.BossBattle
{
    public class BossStatsOperator : StatsOperator
    {
        public void SetStats(BossBattlePackage bossBattlePackage)
        {
            speed = bossBattlePackage.BossSpeed;
            energy = bossBattlePackage.BossEnergy;
            defense = bossBattlePackage.BossDefence;
            SetStats();
        }
    }
}
