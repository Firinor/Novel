using UnityEngine;

public class SceneDistributorInformator : MonoBehaviour
{
    [SerializeField]
    private bool isEnable;
    [SerializeField]
    private ScenePosition scenePosition;
    [SerializeField]
    private Transform fallbackTransform;

    void Awake()
    {
        if(SceneManager.instance == null)
            gameObject.transform.SetParent(fallbackTransform);
        else
            SceneManager.SetSceneToPosition(gameObject, scenePosition);

        if (!isEnable)
        {
            gameObject.SetActive(false);
        }
    }
}
