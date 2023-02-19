using FirUnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundInformator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private Image Image;
    [SerializeField, NullCheck]
    private Button Button;

    void Awake()
    {
        BackgroundHUB.Image.SetValue(Image);
        BackgroundHUB.Button.SetValue(Button);
    }
}
