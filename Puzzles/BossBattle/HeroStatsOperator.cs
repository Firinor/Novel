namespace Puzzle.BossBattle
{
    public class HeroStatsOperator : StatsOperator
    {
        public void SetStats(BossBattlePackage bossBattlePackage)
        {
            speed = bossBattlePackage.HeroSpeed;
            energy = bossBattlePackage.HeroEnergy;
            defense = bossBattlePackage.HeroDefence;
            SetStats();
        }
    }
}
