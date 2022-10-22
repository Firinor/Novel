using FirUnityEditor;
using UnityEngine;

namespace FirGames
{
    public class StoryInformator : SinglBehaviour<StoryInformator>
    {
        [SerializeField, NullCheck]
        public CharacterInformator Skull;
        [SerializeField, NullCheck]
        public CharacterInformator WhiteNecromant;
        [SerializeField, NullCheck]
        public CharacterInformator Yanus;
        [SerializeField, NullCheck]
        public CharacterInformator Archmagister;
        [SerializeField, NullCheck]
        public CharacterInformator Varus;
        [SerializeField, NullCheck]
        public CharacterInformator LordCarlos;
        [SerializeField, NullCheck]
        public CharacterInformator Karim;
        [SerializeField, NullCheck]
        public CharacterInformator GnomGuard;

        [Space]
        [SerializeField, NullCheck]
        public Sprite Lab;
        [SerializeField, NullCheck]
        public Sprite World;
        [SerializeField, NullCheck]
        public Sprite Memorial;
        [SerializeField, NullCheck]
        public Sprite Office;

        void Awake()
        {
            SingletoneCheck(this);
        }
    }
}
