using FirUnityEditor;
using Puzzle.PortalBuild;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MainSpecterOperator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private Image mainSpecter;
    [SerializeField, NullCheck]
    private Sprite standardSprite;
    [SerializeField, NullCheck]
    private SpectralAnalysisManager spectralAnalysisManager;

    public void OffsetToTheSide(int direction)
    {
        GenetareNewSpecter();
    }

    public void GenetareNewSpecter()//Sprite atomSpecter)
    {
        AtomsInformator atomsInformator = SpectralAnalysisManager.AtomInformator;
        
        Texture2D texture = new Texture2D(atomsInformator.AtomSpriteWidth, 1);
        for (int i = 0; i < texture.width; i++)
        {
            texture.SetPixel(i, 0, Color.black);
        }
        
        //for (int i = 1; i < atomsInformator.AtomCount; i++)
        for (int i = 1; i <= 3; i++)
        {
            Texture2D incomingTexture = atomsInformator.Atoms[i].Sprite.texture;

            for (int j = 0; j < texture.width; j++)
            {
                Color texturePixel = texture.GetPixel(j, 0);
                Color incomingPixel = incomingTexture.GetPixel(j, 60);
                float incomingPixelRed = Math.Max(incomingPixel.r, texturePixel.r);
                float incomingPixelGreen = Math.Max(incomingPixel.g, texturePixel.g);
                float incomingPixelBlue = Math.Max(incomingPixel.b, texturePixel.b);
                
                texture.SetPixel(j, 0, new Color(incomingPixelRed, incomingPixelGreen, incomingPixelBlue));
                texture.Apply();
            }
        }

        Sprite mainSprite = Sprite.Create(
            texture, standardSprite.textureRect, new Vector2(.5f, .5f));
        mainSpecter.sprite = mainSprite;
    }
}
