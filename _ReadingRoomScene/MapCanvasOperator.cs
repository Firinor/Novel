using UnityEngine;

public class MapCanvasOperator : MonoBehaviour
{
    public void Options() => ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
    public void Exit() => SceneManager.SwitchPanels(SceneDirection.exit);
}
