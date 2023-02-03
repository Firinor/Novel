using FirUnityEditor;
using FirUtilities;
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

        public List<OutputOperator> outputs;
        public List<NandOperator> nands;

        [HideInInspector]
        public OutputOperator pickedOutput;

        private void Awake()
        {
            outputs = new List<OutputOperator>();
            nands = new List<NandOperator>();
            var foundInputs = gameObject.GetComponentsInChildren<OutputOperator>();
            foreach (var input in foundInputs)
            {
                outputs.Add(input);
            }
        }

        public void Addinput(OutputOperator input)
        {
            outputs.Add(input);
        }

        public void AddNand(NandOperator nand)
        {
            nands.Add(nand);
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

        public void ResetAllNand()
        {
            if (nands == null)
                return;

            nands = ArrayUtilities.ÑleanArrayFromNull(nands);
            foreach (var nand in nands)
            {
                nand.ResetSignal();
            }
        }
    }
}
