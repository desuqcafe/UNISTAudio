using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    private bool isButtonClicked = false;

    public TextMeshProUGUI textMeshProUGUI1;
public TextMeshProUGUI textMeshProUGUI2;
public TextMeshProUGUI textMeshProUGUI3;

public GameObject gameObject1;
public GameObject gameObject2;
public GameObject gameObject3;

public void ButtonClicked(int buttonIndex)
{
    TextMeshProUGUI textMeshProUGUI;
    GameObject gameObject;

    switch (buttonIndex)
    {
        case 1:
            textMeshProUGUI = textMeshProUGUI1;
            gameObject = gameObject1;
            break;
        case 2:
            textMeshProUGUI = textMeshProUGUI2;
            gameObject = gameObject2;
            break;
        case 3:
            textMeshProUGUI = textMeshProUGUI3;
            gameObject = gameObject3;
            break;
        default:
            Debug.LogError("Invalid button index: " + buttonIndex);
            return;
    }

    if (isButtonClicked)
    {
        textMeshProUGUI.color = Color.gray;
        gameObject.SetActive(false);
    }
    else
    {
        textMeshProUGUI.color = Color.green;
        gameObject.SetActive(true);
    }
    
    isButtonClicked = !isButtonClicked;
}
}
