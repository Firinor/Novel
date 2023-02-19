using FirInstanceCell;
using UnityEngine;

public static class ReadingRoomHUB
{
    public static InstanceCell<GameObject> Map = new InstanceCell<GameObject>();
    public static InstanceCell<object> ReadingRoomManager = new InstanceCell<object>();
    public static InstanceCell<object> MapCanvasOperator = new InstanceCell<object>();
}
