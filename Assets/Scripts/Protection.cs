using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Protection : MonoBehaviour
{
    public Button btn;
    [NonSerialized] public bool isProtected;

    public void PressBtn()
    {
        StartCoroutine(UsePotion());
    }

    IEnumerator UsePotion()
    {
        isProtected = true;
        yield return new WaitForSeconds(3f);
        isProtected = false;
        btn.gameObject.SetActive(false);
        

    }
}
