using FirUnityEditor;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.BossBattle
{
    public class MagicBulletOperator : MonoBehaviour
    {
        private BossBattleOperator bossBattleOperator;

        [SerializeField]
        private bool doDamageToPlayer;
        [SerializeField, NullCheck]
        private RectTransform rectTransform;
        [SerializeField, NullCheck]
        private RectTransform childRectTransform;

        [HideInInspector]
        public bool expansion = true;
        [SerializeField]
        private float expansionSpeed = 100;
        [SerializeField]
        private float reductionSpeed = 300;
        [SerializeField]
        private float damageSize = 500;
        [SerializeField]
        private float attenuationSize = 75;

        void Awake()
        {
            if(bossBattleOperator == null)
                bossBattleOperator = GetComponentInParent<BossBattleOperator>();

            SetParameters();
        }

        public void SetParameters()
        {
            rectTransform.sizeDelta = new Vector2(damageSize, damageSize);
        }

        public void SetBossBattleOperator(BossBattleOperator bossBattleOperator)
        {
            this.bossBattleOperator = bossBattleOperator;

        }

        void Update()
        {
            if (expansion == doDamageToPlayer)
            {
                childRectTransform.sizeDelta += Vector2.one * Time.deltaTime * expansionSpeed;
            }
            else
            {
                childRectTransform.sizeDelta -= Vector2.one * Time.deltaTime * reductionSpeed;
            }

            if(childRectTransform.sizeDelta.x < attenuationSize)
            {
                Destroy(gameObject);
            }
            if (childRectTransform.sizeDelta.x > damageSize)
            {
                Damage();
                Destroy(gameObject);
            }
        }

        private void Damage()
        {
            if(doDamageToPlayer)
                bossBattleOperator.DamagePlayer();
            else
                bossBattleOperator.DamageBoss();
        }
    }
}
