using PlasticPipe.PlasticProtocol.Messages;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Puzzle
{
    public abstract class InformationPackage
    {
        protected InformationPackage(Sprite puzzleBackground,
            UnityAction successPuzzleAction, UnityAction failedPuzzleAction = null)
        {
            this.successPuzzleAction += successPuzzleAction;
            this.failedPuzzleAction += failedPuzzleAction;
            this.puzzleBackground = puzzleBackground;
        }
        public UnityAction successPuzzleAction;
        public UnityAction failedPuzzleAction;
        public Sprite puzzleBackground { get; }

    }
}
