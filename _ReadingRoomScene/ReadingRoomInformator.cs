using UnityEngine;

public class ReadingRoomInformator : SinglBehaviour<ReadingRoomInformator>
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject dialog;
    [SerializeField]
    private MapCanvasOperator mapCanvasOperator;

    public static GameObject GetMap() => instance.map;

    public static GameObject GetDialog() => instance.dialog;
}
