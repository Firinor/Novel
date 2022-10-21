using FirUnityEditor;
using System.Threading;
using UnityEngine;

public class DialogManager : SinglBehaviour<DialogManager>
{
    [SerializeField, NullCheck]
    private GameObject dialog;
    [SerializeField, NullCheck]
    private DialogOperator dialogOperator;

    private CancellationTokenSource cancellationTokenSource;

    public static bool IsCancellationRequested { get => instance.cancellationTokenSource.IsCancellationRequested; }

    void Awake()
    {
        SingletoneCheck(this);
        dialogOperator.SingletoneCheck(dialogOperator);

        cancellationTokenSource = new CancellationTokenSource();
    }

    public static void ActivateDialog(float dialogButtonXPosition)
    {
        instance.dialog.SetActive(true);
        instance.cancellationTokenSource = new CancellationTokenSource();
        ReadingRoomManager.CheckMap(dialogButtonXPosition);
    }

    public static void StopDialog()
    {
        instance.cancellationTokenSource.Cancel();
    }
}
