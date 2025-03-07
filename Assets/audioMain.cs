using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMain : MonoBehaviour
{
    private IEnumerator audioCoroutine;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioCoroutine = audio1();
        StartCoroutine(audioCoroutine);
    }

    private IEnumerator audio1()
    {
        while (true)
        {
            if (audioSource.isPlaying == false)
            {
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(1);
        }
    }
}
