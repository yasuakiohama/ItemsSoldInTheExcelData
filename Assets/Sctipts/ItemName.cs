using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemName : MonoBehaviour
{
    public void Init (string shopKey)
    {
        string text = "";
        string name = ExcelData.Language.GetRowByKey (ExcelData.Language.Key.TEXT_ITEM_NANE.ToString()).message [0];

        foreach (Entity_ItemShop.Param param in ExcelData.ItemShop.GetParamsByName(shopKey)) {
            Entity_Items.Param item = ExcelData.Items.GetRowByKey (param.key);
            string itemName = ExcelData.Language.GetRowByKey (item.message).message [0];
            text += "ID:" + param.ID.ToString () + " " + name + ":" + itemName + "\n";
        }
        GetComponent<Text> ().text = text;
    }
}
