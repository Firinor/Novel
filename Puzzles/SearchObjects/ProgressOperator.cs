using UnityEngine;

namespace Puzzle.SearchObjects
{
    public class ProgressOperator : MonoBehaviour
    {
        [SerializeField]
        private SearchObjectsOperator puzzleOperator;
        [SerializeField]
        private Transform objectsParent;
        public Transform ObjectsParent { get => objectsParent; }

        private ObjectToSearchOperator[] objectsToSearch;
        private int ingredientCount;

        internal void SetObjects(ObjectToSearchOperator[] objectsToSearch)
        {
            this.objectsToSearch = objectsToSearch;
            ingredientCount = objectsToSearch.Length;
        }

        internal bool ActivateIngredient(int keyIngredientNumber)
        {
            if(ingredientCount <= keyIngredientNumber)
                return false;

            ObjectToSearchOperator objectToSearch = objectsToSearch[keyIngredientNumber - 1];
            objectToSearch.Success();

            //recipe.Remove(blackIngredient);
            ingredientCount--;
            return ingredientCount == 0;
        }
    }
}
