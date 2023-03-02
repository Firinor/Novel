using FirUnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class AllPuzzleHUBInformator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private GameObject victoryButton;
        [SerializeField, NullCheck]
        private GameObject failButton;
        [SerializeField, NullCheck]
        private GameObject retryButton;

        [SerializeField, NullCheck]
        private GameObject helpButtons;
        [SerializeField, NullCheck]
        private Button exitButton;
        [SerializeField, NullCheck]
        private Button optionsButton;

        [SerializeField, NullCheck]
        private TextMeshProUGUI timerText;

        [SerializeField, NullCheck]
        private ParticleSystem successParticleSystem;
        [SerializeField, NullCheck]
        private ParticleSystem successParticleSystem2;
        [SerializeField, NullCheck]
        private ParticleSystem errorParticleSystem;
        [SerializeField, NullCheck]
        private ParticleSystem errorParticleSystem2;


        void Awake()
        {
            AllPuzzleHUB.VictoryButton.SetValue(victoryButton);
            AllPuzzleHUB.FailButton.SetValue(failButton);
            AllPuzzleHUB.RetryButton.SetValue(retryButton);

            AllPuzzleHUB.HelpButtons.SetValue(helpButtons);
            AllPuzzleHUB.ExitButton.SetValue(exitButton);
            AllPuzzleHUB.OptionsButton.SetValue(optionsButton);

            AllPuzzleHUB.TimerText.SetValue(timerText);

            AllPuzzleHUB.SuccessParticleSystem.SetValue(successParticleSystem);
            AllPuzzleHUB.SuccessParticleSystem2.SetValue(successParticleSystem2);
            AllPuzzleHUB.ErrorParticleSystem.SetValue(errorParticleSystem);
            AllPuzzleHUB.ErrorParticleSystem2.SetValue(errorParticleSystem2);

            Destroy(this);
        }
    }
}
