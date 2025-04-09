using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{
    public List<GameObject> pages1 = new List<GameObject>();
    public List<GameObject> pages2 = new List<GameObject>();
    private int pageNum = 0;

    public GameObject coffeeMenu;
    public GameObject teaMenu;
    public GameObject blankMenu;

    public GameObject customerPage;
    private AudioSource audioSource;
    private List<GameObject> pages;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        
        if (MainManager.Instance.getLevel() < 10) {
            pages = pages1;
        }
        else if (MainManager.Instance.getLevel() < 20) {
            pages = pages2;
        }
        pages = pages2; //TESTING PURPOSES
        pages[0].SetActive(true);
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

    public void openLastDrinkPage() {
        audioSource.Play();
        GameObject currentPage = pages[pageNum];
        currentPage.SetActive(true);
        blankMenu.SetActive(false);
    }
}
