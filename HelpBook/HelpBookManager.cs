using FirUnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class HelpBookManager : MonoBehaviour
{
    private List<int> listOfPages;

    [SerializeField, NullCheck]
    private GameObject[] pages;
    private int pageIndex;


    private void Awake()
    {
        listOfPages = new List<int>();
        for(int i = 0; i < pages.Length; i++)
        {
            listOfPages.Add(i);
        }
    }

    private void OnEnable()
    {
        ShowPage();
    }

    public void AddPage(int page)
    {
        listOfPages.Add(page);
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
