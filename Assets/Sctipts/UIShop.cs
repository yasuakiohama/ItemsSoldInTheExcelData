using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ExcelData;

public class UIShop : MonoBehaviour
{
    ItemName itemName;
    ItemEffect itemEffect;

    void Awake ()
    {
        itemName = transform.FindChild ("Name").GetComponent<ItemName> ();
        itemEffect = transform.FindChild ("Effect").GetComponent<ItemEffect> ();   
    }

    public void OnButtonDown(GameObject button)
    {
        switch (button.name) {
        case "ShopButton1":
            itemName.Init (ItemShop.SheetName.Shop1.ToString());
            itemEffect.Init (ItemShop.SheetName.Shop1.ToString());
            break;
        case "ShopButton2":
            itemName.Init (ItemShop.SheetName.Shop2.ToString());
            itemEffect.Init (ItemShop.SheetName.Shop2.ToString());
            break;
        case "ShopButton3":
            itemName.Init (ItemShop.SheetName.Shop3.ToString());
            itemEffect.Init (ItemShop.SheetName.Shop3.ToString());
            break;
        }
    }
}
