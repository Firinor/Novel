using FirCleaner;
using FirUnityEditor;
using Puzzle.PortalBuild;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSpecterOperator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private RectTransform answerAtomsParent;
    [SerializeField, NullCheck]
    private GameObject atomPrefab;
    [SerializeField, NullCheck]
    private Image mainSpecter;
    [SerializeField, NullCheck]
    private Sprite noneSpectrumSprite;
    [SerializeField, NullCheck]
    private SpectralAnalysisManager spectralAnalysisManager;

    private List<int> recipe;
    private List<float> defaultRatio;
    private List<float> recipeRatio;
    private int redOffset;

    void Awake()
    {
        defaultRatio = new List<float>();
        recipeRatio = new List<float>();

        for (int i = 0; i < AtomsInformator.AtomSpriteWidth; i++)
        {
            Color color = noneSpectrumSprite.texture.GetPixel(i, 0);
            defaultRatio.Add(Mathf.Max(color.r, color.g, color.b));
            recipeRatio.Add(1);
        }
    }
    public void OffsetToTheSide(int direction)
    {
        Texture2D texture = mainSpecter.sprite.texture;

        int atomSpriteWidth = AtomsInformator.AtomSpriteWidth;

        redOffset += direction;
        if (redOffset >= atomSpriteWidth)
        {
            redOffset -= atomSpriteWidth;
        }
        if (redOffset < 0)
        {
            redOffset += atomSpriteWidth;
        }

        for (int i = 0; i < atomSpriteWidth; i++)
        {
            Color color = noneSpectrumSprite.texture.GetPixel(i, 0);

            int offset = i + redOffset;
            if (offset >= atomSpriteWidth)
            {
                offset -= atomSpriteWidth;
            }
            
            Color colorWithRatio = color * recipeRatio[offset];

            texture.SetPixel(i, 0, new Color(colorWithRatio.r, colorWithRatio.g, colorWithRatio.b, 1));
        }

        texture.Apply();
    }
    public void DestroyAnswerAtoms()
    {
        GameCleaner.DeleteAllChild(answerAtomsParent);
    }
    public void GenerateAnswerAtoms()
    {
        AtomsInformator atomsInformator = SpectralAnalysisManager.AtomInformator;

        foreach (int atom in recipe)
        {
            GameObject newAtom = Instantiate(atomPrefab, answerAtomsParent);
            newAtom.GetComponent<AtomComponentOperator>().SetValue(atomsInformator.Atoms[atom]);
        }
    }
    public void GenetareNewSpecter(List<int> recipe)
    {
        this.recipe = recipe;

        AtomsInformator atomsInformator = SpectralAnalysisManager.AtomInformator;
        
        Texture2D texture = new Texture2D(AtomsInformator.AtomSpriteWidth, 1);
        for (int i = 0; i < AtomsInformator.AtomSpriteWidth; i++)
        {
            Color color = noneSpectrumSprite.texture.GetPixel(i, 0);
            texture.SetPixel(i, 0, color);
        }
        //recipeRatio
        for (int i = 0; i < recipe.Count; i++)
        {
            Texture2D incomingTexture = atomsInformator.Atoms[recipe[i]].Sprite.texture;

            for (int j = 0; j < texture.width; j++)
            {
                Color texturePixel = texture.GetPixel(j, 0);
                Color incomingPixel = incomingTexture.GetPixel(j, 60);

                //float incomingPixelRed = Math.Max(incomingPixel.r, texturePixel.r);
                //float incomingPixelGreen = Math.Max(incomingPixel.g, texturePixel.g);
                //float incomingPixelBlue = Math.Max(incomingPixel.b, texturePixel.b);
                float pixelRedRatio = texturePixel.r == 0 ? 0 : incomingPixel.r / texturePixel.r;
                float pixelGreenRatio = texturePixel.g == 0 ? 0 : incomingPixel.g / texturePixel.g;
                float pixelBlueRatio = texturePixel.b == 0 ? 0 : incomingPixel.b / texturePixel.b;

                recipeRatio[j] = Mathf.Max(pixelRedRatio, pixelGreenRatio, pixelBlueRatio, recipeRatio[j]);

                Color color = noneSpectrumSprite.texture.GetPixel(j, 0);
                Color colorWithRatio = color * recipeRatio[j];

                texture.SetPixel(j, 0, new Color(colorWithRatio.r, colorWithRatio.g, colorWithRatio.b, 1));
            }
            texture.Apply();
        }

        Sprite mainSprite = Sprite.Create(
            texture, noneSpectrumSprite.textureRect, new Vector2(.5f, .5f));
        mainSpecter.sprite = mainSprite;
    }
}
