using UnityEngine;

public class DialogManager : SinglBehaviour<DialogManager>
{
    [SerializeField]
    private GameObject dialog;
    [SerializeField]
    private DialogOperator dialogOperator;

    void Awake()
    {
        SingletoneCheck(this);
        dialogOperator.SingletoneCheck(dialogOperator);
    }

    public static void ActivateDialog()
    {
        instance.dialog.SetActive(true);
    }
}
