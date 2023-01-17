using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogButtonOperator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    [SerializeField]
    private Button button;

    public void SetWay(DialogNode node, string description)
    {
        textMeshPro.text = description;
        button.onClick.AddListener(node.StartDialog);
    }
}
