using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{
    public List<GameObject> pages = new List<GameObject>();
    private int pageNum = 0;
    
    public void pageFlip() {
        GameObject currentPage = pages[pageNum];
        currentPage.SetActive(false);
        pageNum++;
        if (pageNum >= pages.Count) {
            pageNum = 0;
        }
        GameObject newPage = pages[pageNum];
        newPage.SetActive(true);
    }
}
