using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.SearchObjects
{
    public class ObjectToSearchOperator : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private int keyIngredientNumber;

        private SearchObjectsOperator puzzleOperator;

        internal void SetPuzzleOperator(SearchObjectsOperator puzzleOperator)
        {
            this.puzzleOperator = puzzleOperator;
        }
        internal void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
            image.SetNativeSize();
        }
        internal void SetRecipeSprite(Sprite sprite)
        {
            SetSprite(sprite);
            image.color = Color.black;
            image.raycastTarget = false;
            enabled = false;
        }
        internal void AddToRecipe(int number)
        {
            keyIngredientNumber = number;
        }
        internal void Success()
        {
            //puzzleOperator.Particles(Camera.main.WorldToScreenPoint(transform.position),
            //    success: true);
            //image.color = Color.white;
        }
    }
}