using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeOperator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private PuzzleOperator puzzleOperator;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Color grey;
    private List<AlchemicalIngredientOperator> recipe;
    private int ingredientCount;

    void Awake()
    {
        image.color = grey;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("RecipeOperator pointer enter");
        image.color = Color.white;
        puzzleOperator.PointerOnRecipe = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("RecipeOperator pointer exit");
        image.color = grey;
        puzzleOperator.PointerOnRecipe = false;
    }
    internal void SetResipe(List<AlchemicalIngredientOperator> recipe)
    {
        this.recipe = recipe;
        ingredientCount = recipe.Count;
    }
    internal bool ActivateIngredient(AlchemicalIngredientOperator alchemicalIngredientOperator, int keyIngredientNumber)
    {
        Transform transform = alchemicalIngredientOperator.gameObject.transform;
        alchemicalIngredientOperator.enabled = false;
        transform.SetParent(gameObject.transform, false);
        transform.SetSiblingIndex(keyIngredientNumber-1);
        AlchemicalIngredientOperator blackIngredient = recipe[keyIngredientNumber-1];
        //recipe.Remove(blackIngredient);
        ingredientCount--;
        Destroy(blackIngredient.gameObject, 0.01f);

        return ingredientCount == 0;
    }
}
