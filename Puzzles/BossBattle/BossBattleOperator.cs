using FirUnityEditor;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.BossBattle
{
    public class BossBattleOperator : PuzzleOperator
    {
        [SerializeField]
        private int bossMaxHealth = 3;
        [SerializeField]
        private int heroMaxHealth = 3;
        private int bossHealth;
        private int heroHealth;
        [SerializeField, NullCheck]
        private Slider bossHealthSlider;
        [SerializeField, NullCheck]
        private Slider heroHealthSlider;

        private float bossSpeed = 1;
        private float bossSpeedCooldown = 1;
        private float heroSpeed = 1;
        private float heroSpeedCooldown = 1;

        [SerializeField, NullCheck]
        private RectTransform bossBulletParent;
        [SerializeField, NullCheck]
        private RectTransform heroBulletParent;
        [SerializeField, NullCheck]
        private GameObject bossBulletPrefab;
        [SerializeField, NullCheck]
        private GameObject heroBulletPrefab;

        void OnEnable()
        {
            SetHP(bossHealthSlider, ref bossHealth, bossMaxHealth);
            SetHP(heroHealthSlider, ref heroHealth, heroMaxHealth);
        }

        private void SetHP(Slider slider, ref int currentHP, int value)
        {
            slider.maxValue = value;
            slider.value = value;
            currentHP = value;
        }

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

        internal void DamagePlayer()
        {
            heroHealth--;
            heroHealthSlider.value = heroHealth;

            if(heroHealth <= 0)
            {
                LosePuzzle();
            }
        }

        internal void DamageBoss()
        {
            bossHealth--;
            bossHealthSlider.value = bossHealth;

            if (bossHealth <= 0)
            {
                SuccessfullySolvePuzzle();
            }
        }
    }
}
