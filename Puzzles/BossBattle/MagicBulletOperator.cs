using FirUnityEditor;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.BossBattle
{
    public class MagicBulletOperator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private BossBattleOperator bossBattleOperator;

        [SerializeField, NullCheck]
        private RectTransform rectTransform;

        private bool expansion = true;
        [SerializeField]
        private float expansionSpeed = 100;
        [SerializeField]
        private float reductionSpeed = 300;
        [SerializeField]
        private float damageSize = 500;
        [SerializeField]
        private float attenuationSize = 75;

        public void setBossBattleOperator(BossBattleOperator bossBattleOperator)
        {
            this.bossBattleOperator = bossBattleOperator;
        }

        void Update()
        {
            if (expansion)
            {
                rectTransform.sizeDelta += Vector2.one * Time.deltaTime * expansionSpeed;
            }
            else
            {
                rectTransform.sizeDelta -= Vector2.one * Time.deltaTime * reductionSpeed;
            }

            if(rectTransform.sizeDelta.x < attenuationSize)
            {
                Destroy(gameObject);
            }
            if (rectTransform.sizeDelta.x > damageSize)
            {
                DamagePlayer();
                Destroy(gameObject);
            }
        }

        private void DamagePlayer()
        {
            bossBattleOperator.DamagePlayer();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            expansion = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            expansion = true;
        }
    }
}
