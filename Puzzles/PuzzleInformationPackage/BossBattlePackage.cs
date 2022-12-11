using System;
using UnityEngine.Events;
using UnityEngine;

namespace Puzzle
{
    [Serializable]
    public class BossBattlePackage : InformationPackage
    {
        [SerializeField]
        [Range(3, 1024)]
        private int bossHealth = 3;
        [SerializeField]
        [Range(3, 1024)]
        private int heroHealth = 3;
        //[SerializeField]
        //[Range(1, 1024)]
        //private float bossSpeed = 1;
        //[SerializeField]
        //[Range(1, 1024)]
        //private float heroSpeed = 1;

        public int BossHealth { get => bossHealth; }
        public int HeroHealth { get => heroHealth; }
        //public float BossSpeed { get => bossSpeed; }
        //public float HeroSpeed { get => heroSpeed; }

        public BossBattlePackage(int bossHealth, int heroHealth, float bossSpeed, float heroSpeed,
            Sprite puzzleBackground, UnityAction successPuzzleDialog = null, UnityAction failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            this.bossHealth = Mathf.Clamp(bossHealth, 3, 1024);
            this.heroHealth = Mathf.Clamp(heroHealth, 3, 1024);
            //this.bossSpeed = Mathf.Clamp(bossSpeed, 1, 1024);
            //this.heroSpeed = Mathf.Clamp(heroSpeed, 1, 1024);
        }
    }
}
