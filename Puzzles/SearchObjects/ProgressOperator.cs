using System.Collections.Generic;
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

        private List<ObjectToSearchOperator> objectsToSearch;
        private int ingredientCount;

        internal void SetObjects(List<ObjectToSearchOperator> objectsToSearch)
        {
            this.objectsToSearch = objectsToSearch;
            ingredientCount = objectsToSearch.Count;
        }

        internal bool ActivateIngredient(int keyIngredientNumber)
        {
            ObjectToSearchOperator objectToSearch = objectsToSearch[keyIngredientNumber - 1];
            objectToSearch.Success();

            //recipe.Remove(blackIngredient);
            ingredientCount--;
            return ingredientCount == 0;
        }
    }
}
