using FirUnityEditor;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Nand
{
    public class LineFieldOperator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, NullCheck]
        private NandManager nandManager;

        public List<OutputOperator> inputs;

        [HideInInspector]
        public OutputOperator pickedOutput;

        private void Awake()
        {
            inputs = new List<OutputOperator>();
            var foundInputs = gameObject.GetComponentsInChildren<OutputOperator>();
            foreach (var input in foundInputs)
            {
                inputs.Add(input);
            }
        }

        public void Addinput(OutputOperator input)
        {
            inputs.Add(input);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("RecipeOperator pointer enter");
            nandManager.PointerOnField = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("RecipeOperator pointer exit");
            nandManager.PointerOnField = false;
        }
    }
}
