using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Manager.Excel;

public class ItemEffect : MonoBehaviour
{
    public void Init (int ShopKey)
    {
        string text = "";
        string effect = Language.GetRowById ((int)Language.ID.TEXT_ITEM_EFFECT).message;

        foreach (var param in ItemShop.GetRowsById(ShopKey)) {
            var item = Item.GetRowById (param.itemId);
            string effectName = Language.GetRowById (item.type).message;
            effectName = Option.Replace (effectName, 0, item.effect.ToString ());
            text += effect + ":" + effectName + "\n";
        }
        GetComponent<Text> ().text = text;
    }

    public string OneLineText(string effect, string effectName)
    {
        return effect + ":" + effectName + "\n";
    }
}
