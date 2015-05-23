using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Manager.Excel;

public class ItemName : MonoBehaviour
{
    public void Init (int shopKey)
    {
        string text = "";
        string name = Language.GetRowById ((int)Language.ID.TEXT_ITEM_NANE).message;

        foreach (var param in ItemShop.GetRowsById(shopKey)) {
            var item = Item.GetRowById (param.itemId);
            string itemName = Language.GetRowById (item.name).message;
            text += OneLineText (item.ID.ToString (), name, itemName);
        }
        GetComponent<Text> ().text = text;
    }

    public string OneLineText(string id, string name, string itemName)
    {
        return "ID:" + id + " " + name + ":" + itemName + "\n";
    }
}
