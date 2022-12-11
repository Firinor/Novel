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

        private float speed = 1;
        private float speedCooldown = 1;

        private float deffense = 1;
        private float energy = 1;

        [SerializeField, NullCheck]
        private Slider slider;
        [SerializeField, NullCheck]
        private TextMeshProUGUI opponentName;
        [SerializeField, NullCheck]
        private Image skill;
        [Space]
        [SerializeField, NullCheck]
        private TextMeshProUGUI speedText;
        [SerializeField, NullCheck]
        private TextMeshProUGUI deffenseText;
        [SerializeField, NullCheck]
        private TextMeshProUGUI energyText;

        public void SetHP(int value)
        {
            slider.maxValue = value;
            slider.value = value;
            MaxHealth = value;
            health = value;
        }

        internal bool Damage()
        {
            health--;
            slider.value = health;

            return health <= 0;
        }
    }
}
