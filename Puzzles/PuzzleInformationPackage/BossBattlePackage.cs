using System;
using UnityEngine.Events;
using UnityEngine;
using FirUnityEditor;

namespace Puzzle
{
    [Serializable]
    public class BossBattlePackage : InformationPackage
    {
        [SerializeField, NullCheck]
        private CharacterInformator boss;
        [SerializeField]
        [Range(3, 1024)]
        private int bossHealth = 3;
        [SerializeField]
        [Range(3, 1024)]
        private int heroHealth = 3;
        [SerializeField]
        [Range(1, 1024)]
        private int bossSpeed = 1;
        [SerializeField]
        [Range(1, 1024)]
        private int heroSpeed = 1;
        [SerializeField]
        [Range(1, 1024)]
        private int bossEnergy = 1;
        [SerializeField]
        [Range(1, 1024)]
        private int heroEnergy = 1;
        [SerializeField]
        [Range(0, 1024)]
        private int bossDefence = 1;
        [SerializeField]
        [Range(0, 1024)]
        private int heroDefence = 1;

        public CharacterInformator Boss { get => boss; }
        public int BossHealth { get => bossHealth; }
        public int HeroHealth { get => heroHealth; }
        public int BossSpeed { get => bossSpeed; }
        public int HeroSpeed { get => heroSpeed; }
        public int BossEnergy { get => bossEnergy; }
        public int HeroEnergy { get => heroEnergy; }
        public int BossDefence { get => bossDefence; }
        public int HeroDefence { get => heroDefence; }

        public BossBattlePackage(CharacterInformator boss, 
            int bossHealth, int heroHealth, int bossSpeed, int heroSpeed,
            int bossEnergy, int heroEnergy, int bossDefence, int heroDefence,
            Sprite puzzleBackground, UnityAction successPuzzleDialog = null, UnityAction failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            this.boss = boss;
            this.bossHealth = Mathf.Clamp(bossHealth, 3, 1024);
            this.heroHealth = Mathf.Clamp(heroHealth, 3, 1024);
            this.bossSpeed = Mathf.Clamp(bossSpeed, 1, 1024);
            this.heroSpeed = Mathf.Clamp(heroSpeed, 1, 1024);
            this.bossEnergy = Mathf.Clamp(bossEnergy, 1, 1024);
            this.heroEnergy = Mathf.Clamp(heroEnergy, 1, 1024);
            this.bossDefence = Mathf.Clamp(bossDefence, 0, 1024);
            this.heroDefence = Mathf.Clamp(heroDefence, 0, 1024);
        }
    }
}
