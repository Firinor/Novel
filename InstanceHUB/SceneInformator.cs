using FirUnityEditor;
using UnityEngine;

namespace Dialog
{
    public class SceneInformator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private MonoBehaviour SceneManager;

        void Awake()
        {
            SceneHUB.SceneManager.SetValue(SceneManager);
        }
    }
}
