using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExcelData;

public class ItemName : MonoBehaviour
{
    public void Init (string shopKey)
    {
        string text = "";
        string name = Language.GetRowByKey (Language.Key.TEXT_ITEM_NANE.ToString()).message [0];

        foreach (Entity_ItemShop.Param param in ItemShop.GetParamsByName(shopKey)) {
            Entity_Items.Param item = Items.GetRowByKey (param.key);
            string itemName = Language.GetRowByKey (item.message).message [0];
            text += "ID:" + param.ID.ToString () + " " + name + ":" + itemName + "\n";
        }
        GetComponent<Text> ().text = text;
    }
}
