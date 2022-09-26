using System;
using UnityEngine;
using UnityEngine.UI;

public class MapCanvasOperator : MonoBehaviour
{
    //[SerializeField]
    //private GameObject dialogParent;
    //public GameObject GetDialogParent() => dialogParent;

    [SerializeField]
    private GameObject socialBackground;
    private float width;
    [SerializeField]
    private Scrollbar horizontalScrollbar;

    void Awake()
    {
        width = socialBackground.GetComponent<RectTransform>().sizeDelta.x;
    }

    public void Options() => ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
    public void Exit() => SceneManager.SwitchPanels(SceneDirection.exit);

    public void CorrectScrollbarPosition(float dialogButtonXPosition)
    {
        horizontalScrollbar.value = dialogButtonXPosition / width;
    }
}
