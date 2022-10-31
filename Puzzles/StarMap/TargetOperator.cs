using FirUnityEditor;
using Puzzle.StarMap;
using UnityEngine;
using UnityEngine.UI;

public class TargetOperator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private Button button;
    [SerializeField, NullCheck]
    private StarMapOperator starMapOperator;
    
    public void CheckAnswer()
    {
        starMapOperator.CheckAnswer();
    }

    public void SetButtonActivity(bool v)
    {
        button.gameObject.SetActive(v);
    }
}
