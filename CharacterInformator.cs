using UnityEngine;

namespace TacticalPanicCode
{
    [CreateAssetMenu(menuName = "Character/Character info", fileName = "CharInfo")]
    public class CharacterInformator : ScriptableObject
    {
        [Tooltip("Name of unit")]
        [SerializeField]
        private string unitName;
        public string Name { get { return unitName; } }

        [Tooltip("Sprite of unit")]
        [SerializeField]
        private Sprite sprite;
        public Sprite unitSprite { get { return sprite; } }

        [Tooltip("Image of the portrait of the unit's face")]
        [SerializeField]
        private Sprite face;
        public Sprite unitFace { get { return face; } }
    }
}
