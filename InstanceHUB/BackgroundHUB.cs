using FirInstanceCell;
using UnityEngine;
using UnityEngine.UI;

public static class BackgroundHUB
{
    public static InstanceCell<MonoBehaviour> loadingGIF = new InstanceCell<MonoBehaviour>();
    public static InstanceCell<Canvas> Canvas = new InstanceCell<Canvas>();
    public static InstanceCell<Image> Image = new InstanceCell<Image>();
    public static InstanceCell<Button> Button = new InstanceCell<Button>();
}
