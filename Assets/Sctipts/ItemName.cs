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
    public void Init (string shopKey)
    {
        string text = "";
        string name = Language.GetRowByKey ((int)Language.ID.TEXT_ITEM_NANE).message;

        foreach (var param in ItemShop.GetParamsByName(shopKey)) {
            var item = Item.GetRowById (param.itemId);
            string itemName = Language.GetRowByKey (item.name).message;
            text += OneLineText (item.ID.ToString (), name, itemName);
        }
        GetComponent<Text> ().text = text;
    }

    public string OneLineText(string id, string name, string itemName)
    {
        return "ID:" + id + " " + name + ":" + itemName + "\n";
    }
}
