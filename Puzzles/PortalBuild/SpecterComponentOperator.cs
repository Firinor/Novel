using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.PortalBuild
{
    public class SpecterComponentOperator : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textComponent;
        [SerializeField]
        private Image colorBall;
        [SerializeField]
        private Image specter;

        private string designation;
        private Color color;
        private Sprite sprite;

        private static int index = 1;

        private void Awake()
        {
            SetValue(PortalBuildManager.colorsInformator.Atoms[index]);
            index++;
            
            Refresh();
        }

        public void SetValue(SpecterComponent component)
        {
            designation = component.Designation;
            color = component.Color;
            sprite = component.Sprite;
        }

        private void Refresh()
        {
            textComponent.text = designation;
            colorBall.color = color;
            specter.sprite = sprite;
        }

        public void OnPipette()
        {

        }
    }
}