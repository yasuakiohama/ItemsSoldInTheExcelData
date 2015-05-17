using UnityEngine;
using System.Collections;

public class ButtonDown : MonoBehaviour
{
    public UIShop uIShop;

    public void OnButtonDown()
    {
        uIShop.ButtonDown (gameObject.name);
    }
}
