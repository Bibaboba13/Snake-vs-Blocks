using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loss : MonoBehaviour
{
    public void UiLossActive()
    {
        gameObject.SetActive(true);
    }
    public void UILossHide()
    {
        gameObject.SetActive(false);
    }
}
