using UnityEngine;

public class MapCanvasOperator : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogParent;

    public GameObject GetDialogParent() => dialogParent;
    public void Options() => ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
    public void Exit() => SceneManager.SwitchPanels(SceneDirection.exit);
}
