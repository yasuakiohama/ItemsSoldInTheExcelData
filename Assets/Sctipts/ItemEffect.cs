using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemEffect : MonoBehaviour
{
    public void Init (string ShopKey)
    {
        string text = "";
        string effect = ExcelData.Language.GetRowByKey (ExcelData.Language.Key.TEXT_ITEM_NANE.ToString ()).message [1];

        foreach (Entity_ItemShop.Param param in ExcelData.ItemShop.GetParamsByName(ShopKey)) {
            Entity_Items.Param item = ExcelData.Items.GetRowByKey (param.key);
            string effectName = ExcelData.Language.GetRowByKey (item.message).message [1];
            effectName = effectName.Replace (ExcelData.Option.Replace (0), item.effect.ToString ());
            effectName = effectName.Replace (ExcelData.Option.Replace (1), ExcelData.Language.GetRowByKey (item.type).message [0]);
            text += effect + ":" + effectName + "\n";
        }
        GetComponent<Text> ().text = text;
    }
}
