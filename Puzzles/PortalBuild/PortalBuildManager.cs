using FirCleaner;
using FirUnityEditor;
using System;
using UnityEngine;

namespace Puzzle.PortalBuild
{
    public class PortalBuildManager : PuzzleOperator, IOptionsSwitchHandler
    {
        [SerializeField, NullCheck]
        private GameObject mainSpecter;
        [SerializeField, NullCheck]
        private Transform specterComponentsParent;
        [SerializeField, NullCheck]
        private GameObject specterComponentPrefab;
        [SerializeField, NullCheck]
        private Transform BoxComponentParent;
        [SerializeField, NullCheck]
        private GameObject BoxComponentPrefab;
        public static ColorsInformator colorsInformator;

        [SerializeField]
        private PortalBuildPackage portalBuildPackage;

        private void Awake()
        {
            if(colorsInformator == null)
                colorsInformator = GetComponent<ColorsInformator>();
        }

        void OnEnable()
        {
            ClearPuzzle();
            DeleteAllInBoxComponentsr();
            CreateNewObjectsInBox();
        }

        private void DeleteAllInBoxComponentsr()
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

        private void CreateNewObjectsInBox()
        {
            for (int i = 0; i < portalBuildPackage.IngredientsCount; i++)
            {
                Instantiate(BoxComponentPrefab, BoxComponentParent);
            }
        }

        public void ResetOptions()
        {
            
        }
    }
}
