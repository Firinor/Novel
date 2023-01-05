using FirCleaner;
using FirUnityEditor;
using Puzzle.PortalBuild;
using System;
using System.Collections.Generic;
using System.Text;
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
    private Sprite standardSprite;
    [SerializeField, NullCheck]
    private SpectralAnalysisManager spectralAnalysisManager;

    private List<int> recipe;

    public void OffsetToTheSide(int direction)
    {
        
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
        
        Texture2D texture = new Texture2D(atomsInformator.AtomSpriteWidth, 1);
        for (int i = 0; i < texture.width; i++)
        {
            texture.SetPixel(i, 0, Color.black);
        }
        
        for (int i = 0; i < recipe.Count; i++)
        {
            Texture2D incomingTexture = atomsInformator.Atoms[recipe[i]].Sprite.texture;

            for (int j = 0; j < texture.width; j++)
            {
                Color texturePixel = texture.GetPixel(j, 0);
                Color incomingPixel = incomingTexture.GetPixel(j, 60);
                float incomingPixelRed = Math.Max(incomingPixel.r, texturePixel.r);
                float incomingPixelGreen = Math.Max(incomingPixel.g, texturePixel.g);
                float incomingPixelBlue = Math.Max(incomingPixel.b, texturePixel.b);
                
                texture.SetPixel(j, 0, new Color(incomingPixelRed, incomingPixelGreen, incomingPixelBlue));
            }
            texture.Apply();
        }

        Sprite mainSprite = Sprite.Create(
            texture, standardSprite.textureRect, new Vector2(.5f, .5f));
        mainSpecter.sprite = mainSprite;
    }
}
