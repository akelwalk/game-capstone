using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNotebook : MonoBehaviour
{
    public GameObject notebook;
    void Update()
    {
        
    }

    public void hide() {
        notebook.SetActive(false);
    }

    public void display() {
        notebook.SetActive(true);
    }
}
