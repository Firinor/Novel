using FirUnityEditor;
using UnityEngine;

namespace Dialog
{
    public class DialogInformator : SinglBehaviour<DialogInformator>
    {
        [SerializeField, NullCheck]
        private IReadingSceneManager readingSceneManager;
        public static IReadingSceneManager readingManager { get => instance.readingSceneManager; }

        void Awake()
        {
            SingletoneCheck(this);
            readingSceneManager = GetComponent<IReadingSceneManager>();
        }
    }
}
