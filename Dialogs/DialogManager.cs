using Puzzle;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    public class DialogManager : SinglBehaviour<DialogManager>
    {
        [SerializeField]
        private int foregroundSortingOrder;
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
        private static Canvas backgroundCanvas
        {
            get
            {
                return BackgroundHUB.Canvas.GetValue();
            }
        }

        private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public static bool IsCancellationRequested { get => cancellationTokenSource.IsCancellationRequested; }

        private void Awake()
        {
            SingletoneCheck(this);
        }
        public static void ActivateDialog(RectTransform dialogButtonRectTransform)
        {
            backgroundCanvas.sortingOrder = instance.foregroundSortingOrder;
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
