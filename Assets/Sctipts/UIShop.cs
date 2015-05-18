using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ExcelData;

public class UIShop : MonoBehaviour
{
    ItemName itemName;
    ItemEffect itemEffect;

    enum ButtonName
    {
        ShopButton1,
        ShopButton2,
        ShopButton3,
    }

    void Awake ()
    {
        itemName = transform.FindChild ("Name").GetComponent<ItemName> ();
        itemEffect = transform.FindChild ("Effect").GetComponent<ItemEffect> ();   
    }

    public void ButtonDown(GameObject buttonGameObject)
    {
        ButtonName buttonName = (ButtonName)Enum.Parse (typeof(ButtonName), buttonGameObject.name);
        switch (buttonName) {
        case ButtonName.ShopButton1:
            itemName.Init (ItemShop.SheetName.Shop1.ToString ());
            itemEffect.Init (ItemShop.SheetName.Shop1.ToString ());
            break;
        case ButtonName.ShopButton2:
            itemName.Init (ItemShop.SheetName.Shop2.ToString ());
            itemEffect.Init (ItemShop.SheetName.Shop2.ToString ());
            break;
        case ButtonName.ShopButton3:
            itemName.Init (ItemShop.SheetName.Shop3.ToString ());
            itemEffect.Init (ItemShop.SheetName.Shop3.ToString ());
            break;
        }
    }
}
