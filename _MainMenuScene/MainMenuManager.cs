using System;
using UnityEditor;
using UnityEngine;

public enum MenuMarks { baner, credits, saves, options, off };

public class MainMenuManager : SinglBehaviour<MainMenuManager>, IScenePanel
{
    private static GameObject baner;
    private static GameObject credits;
    private static GameObject saves;

    private MainMenuInformator mainMenuInformator;

    public void SetAllInstance()
    {
        SingletoneCheck(this);
        SceneManager.ScenePanel = this;

        mainMenuInformator = GetComponent<MainMenuInformator>();
        mainMenuInformator.SingletoneCheck(mainMenuInformator);//Singltone

        baner = MainMenuInformator.GetBaner();
        credits = MainMenuInformator.GetCredits();
        saves = MainMenuInformator.GetSaves();
    }

    public static void SwitchPanels(MenuMarks mark)
    {
        instance.DiactiveAllPanels();
        switch (mark)
        {
            case MenuMarks.baner:
                baner.SetActive(true);
                break;
            case MenuMarks.credits:
                credits.SetActive(true);
                break;
            case MenuMarks.saves:
                saves.SetActive(true);
                break;
            case MenuMarks.options:
                SceneManager.SwitchPanel(SceneDirection.options);
                break;
            case MenuMarks.off:
                SceneManager.SwitchPanel(SceneDirection.off);
                break;
            default:
                new Exception("Unrealized bookmark!");
                break;
        }
    }

public void SwitchPanels(int mark)
    {
        SwitchPanels((MenuMarks)mark);
    }

    public void DiactiveAllPanels()
    {
        //baner.SetActive(false);
        credits.SetActive(false);
        saves.SetActive(false);
        SceneManager.DiactiveAllPanels();
    }

    public void BasicPanelSettings()
    {
        SwitchPanels(MenuMarks.baner);
    }
}
