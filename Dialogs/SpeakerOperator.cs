using UnityEngine;
using UnityEngine.UI;

public class SpeakerOperator : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Transform imageTransform;
    [SerializeField]
    private Canvas imageCanvas;
    [SerializeField]
    private Color speakerOnBackgroundColor;
    [SerializeField]
    private Vector3 scaleOnBackground;
    
    private float unitScale;

    private static int backgroundSortingOrder = 2;
    private static int foregroundSortingOrder = 3;

    internal void SetCharacter(CharacterInformator speaker)
    {
        image.sprite = speaker.unitSprite;
        image.SetNativeSize();
        unitScale = speaker.UnitScale;
        ToTheBackground();
    }

    public void ToTheBackground()
    {
        image.color = speakerOnBackgroundColor;
        imageCanvas.sortingOrder = DialogOperator.OrderLayer + backgroundSortingOrder;
        imageTransform.localScale = scaleOnBackground * unitScale;
    }

    public void ToTheForeground()
    {
        image.color = Color.white;
        imageCanvas.sortingOrder = DialogOperator.OrderLayer + foregroundSortingOrder;
        imageTransform.localScale = Vector3.one * unitScale;
    }
}
