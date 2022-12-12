using FirUnityEditor;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.BossBattle
{
    public class BossBattleOperator : PuzzleOperator
    {
        [SerializeField, NullCheck]
        private BossStatsOperator bossStatsOperator;
        [SerializeField, NullCheck]
        private HeroStatsOperator heroStatsOperator;

        [Space]
        [SerializeField, NullCheck]
        private Image redScreen;
        [SerializeField, Range(0,1)]
        private float redAlfaCeiling;
        [SerializeField]
        private float redAlfaFillingTime;
        [SerializeField]
        private float redAlfaDecreasingTime;

        [Space]
        [SerializeField, NullCheck]
        private RectTransform bossBulletParent;
        [SerializeField, NullCheck]
        private RectTransform heroBulletParent;
        [SerializeField, NullCheck]
        private GameObject bossBulletPrefab;
        [SerializeField, NullCheck]
        private GameObject heroBulletPrefab;

        public void SetPuzzleInformationPackage(BossBattlePackage bossBattlePackage)
        {
            bossStatsOperator.SetHP(bossBattlePackage.BossHealth);
            heroStatsOperator.SetHP(bossBattlePackage.HeroHealth);
            SetVictoryEvent(bossBattlePackage.successPuzzleAction);
            SetFailEvent(bossBattlePackage.failedPuzzleAction);
            SetBackground(bossBattlePackage.PuzzleBackground);
        }

        public override void StartPuzzle()
        {
            
        }

        internal void DamagePlayer()
        {
            StopCoroutine(RedScreen());
            StartCoroutine(RedScreen());

            bool isDead = heroStatsOperator.Damage();

            if (isDead)
            {
                LosePuzzle();
            }
        }

        private IEnumerator RedScreen()
        {
            redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, 0f);
            float timer;
            float startTime = Time.time;
            float deltaOfEscapsedTime;
            while (redScreen.color.a < redAlfaCeiling)
            {
                timer = Time.time - startTime;
                deltaOfEscapsedTime = timer / redAlfaFillingTime;

                redScreen.color = 
                    new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, deltaOfEscapsedTime);
                yield return null;
            }

            startTime = Time.time;

            while (redScreen.color.a > 0f)
            {
                timer = Time.time - startTime;
                deltaOfEscapsedTime = redAlfaCeiling - timer * redAlfaCeiling / redAlfaDecreasingTime;

                redScreen.color =
                    new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, deltaOfEscapsedTime);
                yield return null;
            }
            redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, 0f);
        }

        internal void DamageBoss()
        {
            bool isDead = bossStatsOperator.Damage();

            if (isDead)
            {
                SuccessfullySolvePuzzle();
            }
        }
    }
}
