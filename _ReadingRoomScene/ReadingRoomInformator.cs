using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingRoomInformator : SinglBehaviour<ReadingRoomInformator>
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject dialog;
    private GameObject options;

    public static GameObject GetMap()
    {
        return instance.map;
    }

    public static GameObject GetDialog()
    {
        return instance.dialog;
    }
}
