using FirInstanceCell;
using UnityEngine;

namespace Puzzle
{
    public static class PuzzleHUB
    {
        public static InstanceCell<GameObject> FindObject = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> TetraQuestion = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> FindDifference = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> SearchObjects = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> SpectralAnalysis = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> StarMap = new InstanceCell<GameObject>();
        public static InstanceCell<GameObject> BossBattle = new InstanceCell<GameObject>();
        public static InstanceCell<MonoBehaviour> FindObjectManager = new InstanceCell<MonoBehaviour>();
        public static InstanceCell<MonoBehaviour> TetraQuestionManager = new InstanceCell<MonoBehaviour>();
        public static InstanceCell<MonoBehaviour> FindDifferencesManager = new InstanceCell<MonoBehaviour>();
        public static InstanceCell<MonoBehaviour> SearchObjectsManager = new InstanceCell<MonoBehaviour>();
        public static InstanceCell<MonoBehaviour> SpectralAnalysisManager = new InstanceCell<MonoBehaviour>();
        public static InstanceCell<MonoBehaviour> StarMapManager = new InstanceCell<MonoBehaviour>();
        public static InstanceCell<MonoBehaviour> BossBattleManager = new InstanceCell<MonoBehaviour>();
    }
}
