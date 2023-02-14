using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDistributorOperator : MonoBehaviour
{
    [SerializeField]
    private ScenePosition scenePosition;

    void Awake()

    {
        DontDestroyOnLoad(this);
        SceneManager.SetSceneToPosition(transform, scenePosition);
    }
}
