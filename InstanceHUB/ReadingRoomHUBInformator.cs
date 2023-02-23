using FirUnityEditor;
using UnityEngine;

public class ReadingRoomHUBInformator : SinglBehaviour<ReadingRoomHUBInformator>
{
    [SerializeField, NullCheck]
    private GameObject map;
    [SerializeField, NullCheck]
    private MonoBehaviour readingRoomManager;
    [SerializeField, NullCheck]
    private MonoBehaviour mapCanvasOperator;

    void Awake()
    {
        ReadingRoomHUB.Map.SetValue(map);
        ReadingRoomHUB.ReadingRoomManager.SetValue(readingRoomManager);
        ReadingRoomHUB.MapCanvasOperator.SetValue(mapCanvasOperator);
        Destroy(this);
    }
}
