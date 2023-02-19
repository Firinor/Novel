using FirUnityEditor;
using UnityEngine;

namespace Dialog
{
    public class DialogInformator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private GameObject DialogObject;
        [SerializeField, NullCheck]
        private MonoBehaviour DialogManager;
        [SerializeField, NullCheck]
        private MonoBehaviour DialogOperator;

        void Awake()
        {
            DialogHUB.DialogObject.SetValue(DialogObject);
            DialogHUB.DialogManager.SetValue(DialogManager);
            DialogHUB.DialogOperator.SetValue(DialogOperator);
        }
    }
}
