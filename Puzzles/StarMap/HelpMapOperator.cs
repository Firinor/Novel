using FirUnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.StarMap
{
    public class HelpMapOperator : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] maps;
        [SerializeField, NullCheck]
        private Image image;

        public void SwitchMap(int i)
        {
            if (maps != null && maps.Length > i)
            {
                image.sprite = maps[i];
            }
        }
    }
}
