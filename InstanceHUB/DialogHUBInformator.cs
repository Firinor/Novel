using FirUnityEditor;
using UnityEngine;

namespace Dialog
{
    public class DialogHUBInformator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private GameObject DialogObject;
        [SerializeField, NullCheck]
        private MonoBehaviour DialogManager;
        [SerializeField, NullCheck]
        private MonoBehaviour DialogOperator;
        [SerializeField, NullCheck]
        private Canvas Canvas;

        public void Awake()
        {
            DialogHUB.DialogObject.SetValue(DialogObject);
            DialogHUB.DialogManager.SetValue(DialogManager);
            DialogHUB.DialogOperator.SetValue(DialogOperator);
            DialogHUB.Canvas.SetValue(Canvas);
            Destroy(this);
        }
    }
}
