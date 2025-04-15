using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoverAnimEnd : MonoBehaviour
{
   public Pages pages;
   public void coverFlipEnd() {
      gameObject.SetActive(false);
      pages.beginGame();
   }
}
