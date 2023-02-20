using FirUnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHUBInformator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private Image image;
    [SerializeField, NullCheck]
    private Button button;
    [SerializeField, NullCheck]
    private Canvas canvas;

    void Awake()
    {
        BackgroundHUB.Image.SetValue(image);
        BackgroundHUB.Button.SetValue(button);
        BackgroundHUB.Canvas.SetValue(canvas);
    }
}
