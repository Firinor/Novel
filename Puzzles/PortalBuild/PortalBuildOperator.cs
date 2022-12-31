using FirUnityEditor;
using UnityEngine;

namespace Puzzle.PortalBuild
{
    public class PortalBuildOperator : PuzzleOperator, IOptionsSwitchHandler
    {
        [SerializeField, NullCheck]
        private GameObject mainSpecter;
        [SerializeField, NullCheck]
        private GameObject specterComponentsParent;
        [SerializeField, NullCheck]
        private GameObject specterComponentPrefab;

        public void ResetOptions()
        {
            
        }
    }
}
