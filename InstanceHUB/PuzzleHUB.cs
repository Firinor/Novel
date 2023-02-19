using FirInstanceCell;
using UnityEngine;

public static class PuzzleHUB
{
    public static InstanceCell<GameObject> FindObject = new InstanceCell<GameObject>();
    public static InstanceCell<GameObject> TetraQuestion = new InstanceCell<GameObject>();
    public static InstanceCell<GameObject> FindDifference = new InstanceCell<GameObject>();
    public static InstanceCell<GameObject> SearchObjects = new InstanceCell<GameObject>();
    public static InstanceCell<GameObject> SpectralAnalysis = new InstanceCell<GameObject>();
    public static InstanceCell<GameObject> StarMap = new InstanceCell<GameObject>();
    public static InstanceCell<GameObject> BossBattle = new InstanceCell<GameObject>();
    public static InstanceCell<object> FindObjectManager = new InstanceCell<object>();
    public static InstanceCell<object> TetraQuestionManager = new InstanceCell<object>();
    public static InstanceCell<object> FindDifferencesManager = new InstanceCell<object>();
    public static InstanceCell<object> SearchObjectsManager = new InstanceCell<object>();
    public static InstanceCell<object> SpectralAnalysisManager = new InstanceCell<object>();
    public static InstanceCell<object> StarMapManager = new InstanceCell<object>();
    public static InstanceCell<object> BossBattleManager = new InstanceCell<object>();
}
