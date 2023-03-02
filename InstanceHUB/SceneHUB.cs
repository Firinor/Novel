using FirInstanceCell;
using UnityEngine;

public static class SceneHUB
{
    public static InstanceCell<MonoBehaviour> SceneManager = new InstanceCell<MonoBehaviour>();
    public static InstanceCell<MonoBehaviour> MenuSceneManager = new InstanceCell<MonoBehaviour>();
    public static InstanceCell<MonoBehaviour> ReadingRoomSceneManager = new InstanceCell<MonoBehaviour>();

    public static InstanceCell<Camera> Camera = new InstanceCell<Camera>();
}
