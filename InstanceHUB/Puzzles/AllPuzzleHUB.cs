using FirInstanceCell;
using TMPro;
using UnityEngine;

namespace Puzzle 
{
    public static class AllPuzzleHUB
    {
        public static InstanceCell<GameObject> VictoryButton = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> FailButton = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> RetryButton = new InstanceCell<GameObject>();

        public static InstanceCell<GameObject> HelpButtons = new InstanceCell<GameObject>();
        public static InstanceCell<MonoBehaviour> ExitButton = new InstanceCell<MonoBehaviour>();
        public static InstanceCell<MonoBehaviour> OptionsButton = new InstanceCell<MonoBehaviour>();

        public static InstanceCell<TextMeshProUGUI> TimerText = new InstanceCell<TextMeshProUGUI>();

        public static InstanceCell<ParticleSystem> SuccessParticleSystem = new InstanceCell<ParticleSystem>();
        public static InstanceCell<ParticleSystem> SuccessParticleSystem2 = new InstanceCell<ParticleSystem>();
        public static InstanceCell<ParticleSystem> ErrorParticleSystem = new InstanceCell<ParticleSystem>();
        public static InstanceCell<ParticleSystem> ErrorParticleSystem2 = new InstanceCell<ParticleSystem>();
    }
}
