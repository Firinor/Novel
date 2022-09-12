using UnityEngine;

public class LanguageDialogButtonOperator : LanguageOperator
{
    [SerializeField]
    private DialogNode dialogNode;

    protected override void SetText()
    {
        Text.text = dialogNode.GetHeader();
    }
}
