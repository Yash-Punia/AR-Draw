using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsController : MonoBehaviour
{
    private bool isUIhidden;

    private void Start()
    {
        isUIhidden = false;
    }

    public void ToggleMenu()
    {
        if(!isUIhidden)
        {
            gameObject.SetActive(false);
            isUIhidden = true;
        }
        else
        {
            gameObject.SetActive(true);
            isUIhidden = false;
        }
    }
}