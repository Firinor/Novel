using FirUnityEditor;
using UnityEngine;

namespace Puzzle
{
    public class FindObjectPuzzleHUBInformator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private MonoBehaviour findObjectManager;
        [SerializeField, NullCheck]
        private GameObject findObject;


        void Awake()
        {
            PuzzleHUB.FindObjectManager.SetValue(findObjectManager);
            PuzzleHUB.FindObject.SetValue(findObject);

            Destroy(this);
        }
    }
}
