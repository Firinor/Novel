using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : SinglBehaviour<CanvasManager>
{
    [SerializeField]
    private Canvas mainCanvas;
    [SerializeField]
    private CanvasScaler mainCanvasScaler;

    public static float ScreenHeight { get => instance.mainCanvasScaler.referenceResolution.y; }
    public static float ScreenWeight { get => instance.mainCanvasScaler.referenceResolution.x; }
}
