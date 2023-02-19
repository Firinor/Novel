using Puzzle;
using System.Threading;
using UnityEngine;

namespace Dialog
{
    public class DialogManager : SinglBehaviour<DialogManager>
    {
        private static GameObject dialog
        {
            get
            {
                return DialogHUB.DialogObject.GetValue();
            }
        }
        private static DialogOperator dialogOperator
        {
            get
            {
                return (DialogOperator)DialogHUB.DialogOperator.GetValue();
            }
        }
        private static IReadingSceneManager sceneManager
        {
            get
            {
                return (IReadingSceneManager)ReadingRoomHUB.ReadingRoomManager.GetValue();
            }
        }

        private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public static bool IsCancellationRequested { get => cancellationTokenSource.IsCancellationRequested; }

        public static void ActivateDialog(RectTransform dialogButtonRectTransform)
        {
            dialog.SetActive(true);
            cancellationTokenSource = new CancellationTokenSource();
            sceneManager.CheckMap(dialogButtonRectTransform);
        }

        public static void StopDialog()
        {
            cancellationTokenSource.Cancel();
        }

        public static void Options()
        {
            sceneManager.SwitchPanelsToOptions();
        }
        public static void SwithToPuzzle(InformationPackage informationPackage, string additional = "")
        {
            sceneManager.SwithToPuzzle(informationPackage, additional);
        }
    }
}
