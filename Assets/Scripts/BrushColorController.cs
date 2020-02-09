using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushColorController : MonoBehaviour
{
    public GameObject brushColorHolderButton;
    public GameObject brushColorHolder;

    public void SetBrushColor()
    {
        brushColorHolderButton.GetComponent<Image>().color = gameObject.GetComponent<Image>().color;
        brushColorHolder.SetActive(false);
    }
}
