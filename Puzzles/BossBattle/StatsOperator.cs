using FirUnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.BossBattle
{
    public class StatsOperator : MonoBehaviour
    {
        [SerializeField]
        private int MaxHealth = 3;
        private int health;

        protected float speed = 1;
        protected float energy = 1;
        protected float defense = 1;

        private float speedCooldown = 0;

        [SerializeField, NullCheck]
        private Slider slider;
        [SerializeField, NullCheck]
        private TextMeshProUGUI opponentName;
        [SerializeField, NullCheck]
        private Image skill;
        [SerializeField, NullCheck]
        private Image skillBase;
        [Space]
        [SerializeField, NullCheck]
        private TextMeshProUGUI speedText;
        [SerializeField, NullCheck]
        private TextMeshProUGUI defenseText;
        [SerializeField, NullCheck]
        private TextMeshProUGUI energyText;

        public void SetHP(int value)
        {
            slider.maxValue = value;
            slider.value = value;
            MaxHealth = value;
            health = value;
        }

        public void ActivateSkill()
        {

        }

        public void Cooldown()
        {

        }

        protected virtual void SetStats()
        {
            speedText.text = speed.ToString();
            energyText.text = energy.ToString();
            defenseText.text = defense.ToString();
        }

        internal bool Damage()
        {
            health--;
            slider.value = health;

            return health <= 0;
        }
    }
}
