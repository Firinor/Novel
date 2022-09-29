using UnityEngine;
using UnityEngine.UI;

public class PuzzleOperator : MonoBehaviour
{
    private PuzzleInformator puzzleInformator;
    [SerializeField]
    private Image box;
    [SerializeField]
    private GameObject IngredientPrefab;
    [SerializeField]
    private Transform IngredientParent;

    void Awake()
    {
        if(puzzleInformator == null)
        {
            puzzleInformator = GetComponent<PuzzleInformator>();
        }
    }

    public void StartFindObjectPuzzle()
    {
        box.sprite = puzzleInformator.OpenAlchemicalBox;
        box.SetNativeSize();

        Sprite[] AlchemicalIngredientssprites = puzzleInformator.AlchemicalIngredientssprites;
        int length = AlchemicalIngredientssprites.Length;

        AlchemicalIngredientOperator keyIngredient = 
            Instantiate(IngredientPrefab, IngredientParent).GetComponent<AlchemicalIngredientOperator>();
        keyIngredient.SetSprite(AlchemicalIngredientssprites[0]);
        keyIngredient.SetWinEvent();

        for (int i = 1; i < length; i++)
        {
            Instantiate(IngredientPrefab, IngredientParent)
                .GetComponent<AlchemicalIngredientOperator>().SetSprite(AlchemicalIngredientssprites[i]);
        }

    }
}
