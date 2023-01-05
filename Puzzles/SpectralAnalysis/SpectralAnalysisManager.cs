using FirCleaner;
using FirMath;
using FirUnityEditor;
using GluonGui.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Puzzle.PortalBuild
{
    public class SpectralAnalysisManager : PuzzleOperator, IOptionsSwitchHandler
    {
        [SerializeField, NullCheck]
        private MainSpecterOperator mainSpecter;
        [SerializeField, NullCheck]
        private Transform specterComponentsParent;
        [SerializeField, NullCheck]
        private GameObject specterComponentPrefab;
        [SerializeField, NullCheck]
        private GameObject BoxWithComponent;
        [SerializeField, NullCheck]
        private Transform BoxComponentParent;
        [SerializeField, NullCheck]
        private GameObject BoxComponentPrefab;

        public static AtomsInformator AtomInformator;
        public AtomComponentOperator specterComponentOperator;

        [SerializeField]
        private PortalBuildPackage portalBuildPackage;

        private List<int> answer;

        private void Awake()
        {
            if(AtomInformator == null)
                AtomInformator = GetComponent<AtomsInformator>();
        }

        void OnEnable()
        {
            ClearPuzzle();
            CreateNewObjectsInBox();
            CreateNewSpecterObjects();
            answer = GameMath.AFewCardsFromTheDeck(
                portalBuildPackage.RecipeCount, portalBuildPackage.IngredientsCount);

            mainSpecter.GenetareNewSpecter(answer);
        }

        public override void ClearPuzzle()
        {
            base.ClearPuzzle();
            DeleteAllSpecterComponents();
            DeleteAllInBoxComponents();
            mainSpecter.DestroyAnswerAtoms();
        }
        private void DeleteAllSpecterComponents()
        {
            GameCleaner.DeleteAllChild(specterComponentsParent);
        }

        private void DeleteAllInBoxComponents()
        {
            GameCleaner.DeleteAllChild(BoxComponentParent);
        }

        public void SetPuzzleInformationPackage(PortalBuildPackage portalBuildPackage)
        {
            this.portalBuildPackage = portalBuildPackage;
            SetVictoryEvent(portalBuildPackage.successPuzzleAction);
            SetFailEvent(portalBuildPackage.failedPuzzleAction);
            SetBackground(portalBuildPackage.PuzzleBackground);
        }

        public void CheckAnswer()
        {
            mainSpecter.GenerateAnswerAtoms();
            List<int> playerHand = CheckPlayerHand();
            if (GameMath.IsSetsOfCardsMatch(playerHand, answer, countMustBeSame: false, checkOnlyFirstHand: true))
            {
                SuccessfullySolvePuzzle();
            }
            else
            {
                LosePuzzle();
            }
        }

        private List<int> CheckPlayerHand()
        {
            List<int> playerHand = new List<int>();
            AtomComponentOperator[] playerAtoms = 
                specterComponentsParent.GetComponentsInChildren<AtomComponentOperator>();

            foreach(AtomComponentOperator atomOperator in playerAtoms)
            {
                playerHand.Add(atomOperator.AtomComponent.Number);
            }

            return playerHand;
        }

        private void CreateNewObjectsInBox()
        {
            for (int i = 0; i < portalBuildPackage.IngredientsCount; i++)
            {
                GameObject Atom = Instantiate(BoxComponentPrefab, BoxComponentParent);
                AtomComponentOperator atomOperator = Atom.GetComponent<AtomComponentOperator>();
                atomOperator.SetValue(AtomInformator.Atoms[i]);
                atomOperator.SetManager(this);
            }
        }

        private void CreateNewSpecterObjects()
        {
            for (int i = 0; i < portalBuildPackage.RecipeCount; i++)
            {
                GameObject Specter = Instantiate(specterComponentPrefab, specterComponentsParent);
                AtomComponentOperator atomOperator = Specter.GetComponent<AtomComponentOperator>();
                atomOperator.SetManager(this);
            }
        }

        public void SelectNewComponent(AtomComponentOperator specterComponentOperator)
        {
            if (BoxWithComponent == null)
                Debug.Log("BoxWithComponent == null");

            if (BoxWithComponent.activeSelf)
            {
                this.specterComponentOperator.SetValue(specterComponentOperator.AtomComponent);
                BoxWithComponentOff();
            }
            else
            {
                this.specterComponentOperator = specterComponentOperator;
                BoxWithComponent.SetActive(true);
            }
        }

        public void BoxWithComponentOff()
        {
            specterComponentOperator = null;
            BoxWithComponent.SetActive(false);
        }

        public void ResetOptions()
        {
            
        }
    }
}
