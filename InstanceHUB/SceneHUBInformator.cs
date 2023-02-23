using FirUnityEditor;
using UnityEngine;

namespace Dialog
{
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
}
