using UnityEngine;

public class SceneDistributorOperator : MonoBehaviour
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
