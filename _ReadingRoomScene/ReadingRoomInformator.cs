using System.Collections.Generic;
using UnityEngine;

public class ReadingRoomInformator : SinglBehaviour<ReadingRoomInformator>
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject dialog;
    [SerializeField]
    private DialogNode[] dialogNodes;
    [SerializeField]
    private MapCanvasOperator mapCanvasOperator;


    public void Awake()
    {
        dialogNodes = mapCanvasOperator.GetDialogParent().GetComponentsInChildren<DialogNode>();
    }

    public static GameObject GetMap() => instance.map;

    public static GameObject GetDialog() => instance.dialog;
    public static DialogNode[] GetDialogNodes() => instance.dialogNodes;
}
