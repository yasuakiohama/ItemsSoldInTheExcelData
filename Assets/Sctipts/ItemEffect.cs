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
        string effect = Language.GetRowByKey (Language.Key.TEXT_ITEM_NANE).message [1];

        foreach (var param in ItemShop.GetParamsByName(ShopKey)) {
            var item = Items.GetRowByKey (param.key);
            string effectName = Language.GetRowByKey (item.message).message [1];
            effectName = Option.Replace (effectName, 0, item.effect.ToString ());
            effectName = Option.Replace (effectName, 1, Language.GetRowByKey (item.type).message [0]);
            text += effect + ":" + effectName + "\n";
        }
        GetComponent<Text> ().text = text;
    }
}
