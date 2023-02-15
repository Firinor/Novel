using FirUnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundInformator : SinglBehaviour<BackgroundInformator>
{
    [SerializeField, NullCheck]
    private Image image;
    public Image Image { get { return image; } }

    [SerializeField, NullCheck]
    private Button button;
    public Button Button { get { return button; } }

    private void Awake()
    {
        SingletoneCheck(this);
    }
}
