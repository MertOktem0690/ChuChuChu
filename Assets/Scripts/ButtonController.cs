using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public bool isClicked;
    public Sprite sprite1, sprite2;

    public void ChangeButton()
    {
        isClicked = !isClicked;
        if(isClicked)
        {
            gameObject.GetComponent<Image>().sprite = sprite2;
        }else
        {
            gameObject.GetComponent<Image>().sprite = sprite1;
        }
    }
}
