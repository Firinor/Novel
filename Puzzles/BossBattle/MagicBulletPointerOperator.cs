using FirUnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.BossBattle
{
    public class MagicBulletPointerOperator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, NullCheck]
        private MagicBulletOperator magicBulletOperator;

        public void OnPointerEnter(PointerEventData eventData)
        {
            magicBulletOperator.expansion = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            magicBulletOperator.expansion = true;
        }
    }
}
