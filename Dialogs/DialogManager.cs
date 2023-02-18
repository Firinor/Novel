using FirUnityEditor;
using Puzzle;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dialog
{
    public class DialogManager : SinglBehaviour<DialogManager>
    {
        [SerializeField, NullCheck]
        private GameObject dialog;
        [SerializeField, NullCheck]
        private DialogOperator dialogOperator;
        [SerializeField, NullCheck]
        private IReadingSceneManager sceneManager;

        private CancellationTokenSource cancellationTokenSource;

        public static bool IsCancellationRequested { get => instance.cancellationTokenSource.IsCancellationRequested; }

        void Awake()
        {
            SingletoneCheck(this);
            dialogOperator.SingletoneCheck(dialogOperator);
            sceneManager = DialogInformator.readingManager;

            cancellationTokenSource = new CancellationTokenSource();
            DontDestroyOnLoad(this);
        }

        public static void ActivateDialog(RectTransform dialogButtonRectTransform)
        {
            instance.dialog.SetActive(true);
            instance.cancellationTokenSource = new CancellationTokenSource();
            instance.sceneManager.CheckMap(dialogButtonRectTransform);
        }

        public static void StopDialog()
        {
            instance.cancellationTokenSource.Cancel();
        }

        public static void Options()
        {
            instance.sceneManager.SwitchPanelsToOptions();
        }
        public static void SwithToPuzzle(InformationPackage informationPackage, string additional = "")
        {
            instance.sceneManager.SwithToPuzzle(informationPackage, additional);
        }
    }
}
