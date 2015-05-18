using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExcelData;

public class ItemEffect : MonoBehaviour
{
    public void Init (string ShopKey)
    {
        string text = "";
        string effect = Language.GetRowByKey (Language.Key.TEXT_ITEM_NANE.ToString ()).message [1];

        foreach (Entity_ItemShop.Param param in ItemShop.GetParamsByName(ShopKey)) {
            Entity_Items.Param item = Items.GetRowByKey (param.key);
            string effectName = Language.GetRowByKey (item.message).message [1];
            effectName = effectName.Replace (Option.Replace (0), item.effect.ToString ());
            effectName = effectName.Replace (Option.Replace (1), Language.GetRowByKey (item.type).message [0]);
            text += effect + ":" + effectName + "\n";
        }
        GetComponent<Text> ().text = text;
    }
}
