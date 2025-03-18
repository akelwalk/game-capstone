using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{
    public List<GameObject> pages = new List<GameObject>();
    private int pageNum = 0;

    public GameObject coffeeMenu;
    public GameObject teaMenu;

    public GameObject customerPage;
    
    public void pageFlip() {
        Debug.Log("button clicked");
        GameObject currentPage = pages[pageNum];
        currentPage.SetActive(false);
        pageNum++;
        if (pageNum >= pages.Count) {
            pageNum = 0;
        }
        GameObject newPage = pages[pageNum];
        newPage.SetActive(true);
    }

    public void getCoffeeMenu() {
        int c = pages.IndexOf(coffeeMenu);
        if (c == pageNum) {
            return;
        }
        GameObject currentPage = pages[pageNum];
        currentPage.SetActive(false);
        
        pageNum = c;
        coffeeMenu.SetActive(true);

    }

    public void getTeaMenu() {
        int t = pages.IndexOf(teaMenu);

        if (t == pageNum) {
            return;
        }
        GameObject currentPage = pages[pageNum];
        currentPage.SetActive(false);
        pageNum = t;
        teaMenu.SetActive(true);

    }

    public void openLastPage() {
        GameObject currentPage = pages[pageNum];
        currentPage.SetActive(true);
        customerPage.SetActive(false);
    }
}
