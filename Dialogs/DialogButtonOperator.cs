using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogButtonOperator : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMeshPro;
    [SerializeField]
    private Button button;

    public void SetWay(DialogNode node)
    {
        textMeshPro.text = node.Description;
        button.onClick.AddListener(node.StartDialog);
    }
}
