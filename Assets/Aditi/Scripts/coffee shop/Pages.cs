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
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playPageFlip() {
        audioSource.Play();
    }

    public void pageFlip() {
        Debug.Log("button clicked");
        audioSource.Play();
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
        audioSource.Play();
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
        audioSource.Play();
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
        audioSource.Play();
        GameObject currentPage = pages[pageNum];
        currentPage.SetActive(true);
        customerPage.SetActive(false);
    }
}
