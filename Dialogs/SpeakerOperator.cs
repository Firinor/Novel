using UnityEngine;

public class SpeakerOperator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer image;
    [SerializeField]
    private Transform imageTransform;
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
        unitScale = speaker.UnitScale;
        ToTheBackground();
    }

    public void ToTheBackground()
    {
        image.color = speakerOnBackgroundColor;
        image.sortingOrder = backgroundSortingOrder;
        imageTransform.localScale = scaleOnBackground * unitScale;
    }

    public void ToTheForeground()
    {
        image.color = Color.white;
        image.sortingOrder = foregroundSortingOrder;
        imageTransform.localScale = Vector3.one * unitScale;
    }
}
