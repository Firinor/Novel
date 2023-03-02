using FirUnityEditor;
using UnityEngine;

public class SceneHUBInformator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private MonoBehaviour sceneManager;
    [SerializeField, NullCheck]
    private Camera mainCamera;

    void Awake()
    {
        SceneHUB.SceneManager.SetValue(sceneManager);
        SceneHUB.Camera.SetValue(mainCamera);

        Destroy(this);
    }
}
