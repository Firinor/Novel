using Puzzle.FindObject;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.SearchObjects
{
    public class ProgressOperator : MonoBehaviour
    {
        [SerializeField]
        private SearchObjectsOperator puzzleOperator;
        private List<ObjectToSearchOperator> recipe;
        private int ingredientCount;

        internal void SetResipe(List<ObjectToSearchOperator> recipe)
        {
            this.recipe = recipe;
            ingredientCount = recipe.Count;
        }

        internal bool ActivateIngredient(int keyIngredientNumber)
        {
            ObjectToSearchOperator objectToSearch = recipe[keyIngredientNumber - 1];
            objectToSearch.Success();

            //recipe.Remove(blackIngredient);
            ingredientCount--;
            return ingredientCount == 0;
        }

        public void CreateProgressСounter(ImageWithDifferences imageWithDifferences)
        {
            throw new NotImplementedException();
        }
    }
}
