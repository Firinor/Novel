using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.PortalBuild
{
    public class AtomComponentOperator : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textComponent;
        [SerializeField]
        private Image colorBall;
        [SerializeField]
        private Image specter;
        [SerializeField]
        private PortalBuildManager portalBuildManager;

        [SerializeField]
        private AtomComponent atomComponent;
        public AtomComponent AtomComponent { get { return atomComponent; } }

        private void Awake()
        {
            Refresh();
        }

        public void SetValue(AtomComponent component)
        {
            atomComponent = component;
        }
        public void SetManager(PortalBuildManager portalBuildManager)
        {
            this.portalBuildManager = portalBuildManager;
        }


        public void Refresh()
        {
            if (atomComponent == null)
            {
                atomComponent = new AtomComponent(textComponent.text, colorBall.color, specter.sprite);
                return;
            }

            textComponent.text = atomComponent.Designation;
            colorBall.color = atomComponent.Color;
            specter.sprite = atomComponent.Sprite;
        }

        public void OnPipette()
        {
            portalBuildManager.SelectNewComponent(this);
        }
    }
}