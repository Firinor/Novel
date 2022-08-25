using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/New dialog", fileName = "Dialog")]
public class DialogInformator : ScriptableObject
{
    public List<SpeakersPhrase> Dialog;
    public int Length { get { return Dialog == null ? 0 : Dialog.Count; } }

    public SpeakersPhrase this[int index]
    {
        get => Dialog[index];
    }

    [System.Serializable]
    public class SpeakersPhrase
    {
        public Sprite background;
        public CharacterInformator Speaker;
        public PositionOnTheStage Position;
        public TextInformator[] texts;

        public string text { get => Array.Find(texts, x => x.language == PlayerManager.Language).text; }
    }
}


