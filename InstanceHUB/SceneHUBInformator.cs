using FirUnityEditor;
using UnityEngine;

public class SceneHUBInformator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private MonoBehaviour SceneManager;

    void Awake()
    {
        SceneHUB.SceneManager.SetValue(SceneManager);
        Destroy(this);
    }
}
