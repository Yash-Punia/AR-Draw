using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushHolderController : MonoBehaviour
{
    public GameObject brushColorsHolder;
    private bool isHolderActive;
    // Start is called before the first frame update
    void Start()
    {
        isHolderActive = false;
        brushColorsHolder.SetActive(false);
    }

    public void ToggleBrushColorHolder()
    {
        if (!isHolderActive)
        {
            brushColorsHolder.SetActive(true);
            isHolderActive = true;
        }
        else
        {
            brushColorsHolder.SetActive(false);
            isHolderActive = false;
        }
    }
}
