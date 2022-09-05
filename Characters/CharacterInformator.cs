using UnityEngine;

[CreateAssetMenu(menuName = "Character/Character info", fileName = "CharInfo")]
public class CharacterInformator : ScriptableObject
{
    [Tooltip("Name of unit")]
    [SerializeField]
    private string[] unitName;
    public string Name { get { return unitName[(int)PlayerManager.Language]; } }

    [Tooltip("Sprite of unit")]
    [SerializeField]
    private Sprite sprite;
    public Sprite unitSprite { get { return sprite; } }

    [Tooltip("Image of the portrait of the unit's face")]
    [SerializeField]
    private Sprite face;
    public Sprite unitFace { get { return face; } }

    [Tooltip("The growth coefficient can be adjusted using the prefab SpeakerAncor")]
    [SerializeField]
    [Range(0f, 1f)]
    private float unitScale;
    public float UnitScale { get { return unitScale; } }
}
