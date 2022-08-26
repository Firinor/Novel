using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReadingRoomMarks { map, dialog, options, off };

public class ReadingRoomManager : SinglBehaviour<ReadingRoomManager>, IScenePanel
{
    private static GameObject map;
    private static GameObject dialog;

    private ReadingRoomInformator readingRoomInformator;

    public void SetAllInstance()
    {
        SingletoneCheck(this);
        SceneManager.ScenePanel = this;

        readingRoomInformator = GetComponent<ReadingRoomInformator>();
        readingRoomInformator.SingletoneCheck(readingRoomInformator);//Singltone

        map = ReadingRoomInformator.GetMap();
        dialog = ReadingRoomInformator.GetDialog();
    }

    public static void SwitchPanels(ReadingRoomMarks mark)
    {
        instance.DiactiveAllPanels();
        switch (mark)
        {
            case ReadingRoomMarks.map:
                map.SetActive(true);
                break;
            case ReadingRoomMarks.dialog:
                dialog.SetActive(true);
                break;
            case ReadingRoomMarks.options:
                SceneManager.SwitchPanels(SceneDirection.options);
                break;
            case ReadingRoomMarks.off:
                break;
            default:
                new Exception("Unrealized bookmark!");
                break;
        }
    }

    public void SwitchPanels(int mark)
    {
        SwitchPanels((ReadingRoomMarks)mark);
    }

    public void DiactiveAllPanels()
    {
        map.SetActive(false);
        dialog.SetActive(false);
        SceneManager.DiactiveAllPanels();
    }

    public void BasicPanelSettings()
    {
        SwitchPanels(ReadingRoomMarks.map);
    }
}
