using System.Threading;
using UnityEngine;

public class DialogManager : SinglBehaviour<DialogManager>
{
    [SerializeField]
    private GameObject dialog;
    [SerializeField]
    private DialogOperator dialogOperator;

    private CancellationTokenSource cancellationTokenSource;

    public static bool IsCancellationRequested { get => instance.cancellationTokenSource.IsCancellationRequested; }

    void Awake()
    {
        SingletoneCheck(this);
        dialogOperator.SingletoneCheck(dialogOperator);

        cancellationTokenSource = new CancellationTokenSource();
    }

    public static void ActivateDialog()
    {
        instance.dialog.SetActive(true);
        instance.cancellationTokenSource = new CancellationTokenSource();
    }

    public static void StopDialog()
    {
        instance.cancellationTokenSource.Cancel();
    }
}
