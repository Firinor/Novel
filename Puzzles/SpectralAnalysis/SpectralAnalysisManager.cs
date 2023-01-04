using FirCleaner;
using FirUnityEditor;
using UnityEngine;

namespace Puzzle.PortalBuild
{
    public class SpectralAnalysisManager : PuzzleOperator, IOptionsSwitchHandler
    {
        [SerializeField, NullCheck]
        private GameObject mainSpecter;
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

        private void Awake()
        {
            if(AtomInformator == null)
                AtomInformator = GetComponent<AtomsInformator>();
        }

        void OnEnable()
        {
            ClearPuzzle();
            DeleteAllInBoxComponents();
            CreateNewObjectsInBox();
            DeleteAllSpecterComponents();
            CreateNewSpecterObjects();
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

        private void CreateNewObjectsInBox()
        {
            for (int i = 0; i < portalBuildPackage.IngredientsCount;)
            {
                i++;
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
                this.specterComponentOperator.Refresh();
                this.specterComponentOperator = null;
                BoxWithComponent.SetActive(false);
            }
            else
            {
                this.specterComponentOperator = specterComponentOperator;
                BoxWithComponent.SetActive(true);
            }
            
        }

        public void ResetOptions()
        {
            
        }
    }
}
