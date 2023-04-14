using FirUnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class HelpBookManager : MonoBehaviour, IHelpBook
{
    private List<int> listOfPages;

    [SerializeField, NullCheck]
    private GameObject[] pages;
    private int pageIndex;
    [SerializeField, NullCheck]
    private GameObject helpBookButton;

    private void Awake()
    {
        listOfPages = new List<int>();
    }

    private void OnEnable()
    {
        ShowPage();
    }

    public void AddBookButton()
    {
        helpBookButton.SetActive(true);
    }

    public void AddPage(int page)
    {
        listOfPages.Add(page);
    }
    public void AddPages(int[] pages)
    {
        foreach (int page in pages)
        {
            AddPage(page);
        }
    }

    public void PageForward()
    {
        pageIndex++;
        if(pageIndex >= listOfPages.Count)
        {
            pageIndex = 0;
        }
        ShowPage();
    }

    public void PageBackward()
    {
        pageIndex--;
        if(pageIndex < 0)
        {
            pageIndex = listOfPages.Count-1;
        }
        ShowPage();
    }

    private void ShowPage()
    {
        DisableAllPages();
        EnablePage(pageIndex);
    }

    private void EnablePage(int pageIndex)
    {
        pages[listOfPages[pageIndex]].SetActive(true);
    }

    private void DisableAllPages()
    {
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
    }

    public void HelpBookButtonClick()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
