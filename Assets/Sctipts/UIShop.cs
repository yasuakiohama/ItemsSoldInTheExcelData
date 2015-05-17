using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIShop : MonoBehaviour
{
    ItemName itemName;
    ItemEffect itemEffect;

    void Awake ()
    {
        itemName = transform.FindChild ("Name").GetComponent<ItemName> ();
        itemEffect = transform.FindChild ("Effect").GetComponent<ItemEffect> ();
	}

    public void ButtonDown(string shopKey)
    {
        itemName.Init (shopKey);
        itemEffect.Init (shopKey);
    }
}
