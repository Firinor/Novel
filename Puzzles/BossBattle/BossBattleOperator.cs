using UnityEngine;

namespace Puzzle.BossBattle
{
    public class BossBattleOperator : PuzzleOperator
    {
        private int bossHealth = 3;
        private int heroHealth = 3;
        private float bossSpeed = 1;
        private float heroSpeed = 1;

        public void SetPuzzleInformationPackage(BossBattlePackage bossBattlePackage)
        {
            bossHealth = bossBattlePackage.BossHealth;
            heroHealth = bossBattlePackage.HeroHealth;
            bossSpeed = bossBattlePackage.BossSpeed;
            heroSpeed = bossBattlePackage.HeroSpeed;
            SetVictoryEvent(bossBattlePackage.successPuzzleAction);
            SetFailEvent(bossBattlePackage.failedPuzzleAction);
            SetBackground(bossBattlePackage.PuzzleBackground);
        }
    }
}
