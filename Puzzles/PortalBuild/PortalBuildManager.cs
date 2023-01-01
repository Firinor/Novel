using FirUnityEditor;
using UnityEngine;

namespace Puzzle.PortalBuild
{
    public class PortalBuildManager : PuzzleOperator, IOptionsSwitchHandler
    {
        [SerializeField, NullCheck]
        private GameObject mainSpecter;
        [SerializeField, NullCheck]
        private GameObject specterComponentsParent;
        [SerializeField, NullCheck]
        private GameObject specterComponentPrefab;
        public static ColorsInformator colorsInformator;

        private void Awake()
        {
            if(colorsInformator == null)
                colorsInformator = GetComponent<ColorsInformator>();
        }
        public void ResetOptions()
        {
            
        }
    }
}
