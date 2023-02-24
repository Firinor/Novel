using UnityEngine;

public class SceneDistributorInformator : MonoBehaviour
{
    [SerializeField]
    private bool isEnable;
    [SerializeField]
    private ScenePosition scenePosition;

    void Awake()
    {
        SceneManager.SetSceneToPosition(gameObject, scenePosition);

        if (!isEnable)
        {
            gameObject.SetActive(false);
        }

        Destroy(this);
    }
}
