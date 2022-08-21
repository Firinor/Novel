using System.Collections.Generic;
using UnityEngine;

namespace TacticalPanicCode
{
    public class DB : SinglBehaviour<DB>//Top-manager
    {
        [SerializeField]
        private List<CharacterInformator> unitInformators;

        void Awake()
        {
            SingletoneCheck(this);
        }

        private CharacterInformator GetUnitInformatorByName(string name)
        {
            return unitInformators.Find(x => x.Name == name);
        }
    }
}
