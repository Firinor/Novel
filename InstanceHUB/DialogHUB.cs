using FirInstanceCell;
using UnityEngine;

public static class DialogHUB
{
    public static InstanceCell<GameObject> DialogObject = new InstanceCell<GameObject>();
    public static InstanceCell<object> DialogManager = new InstanceCell<object>();
    public static InstanceCell<object> DialogOperator = new InstanceCell<object>();
    public static InstanceCell<Canvas> Canvas = new InstanceCell<Canvas>();
}
