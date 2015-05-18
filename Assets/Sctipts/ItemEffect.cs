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
        string effect = MasterData.language.GetRowByKey (Language.Key.TEXT_ITEM_NANE.ToString ()).message [1];

        foreach (Entity_ItemShop.Param param in MasterData.itemShop.GetParamsByName(ShopKey)) {
            Entity_Items.Param item = MasterData.items.GetRowByKey (param.key);
            string effectName = MasterData.language.GetRowByKey (item.message).message [1];
            effectName = effectName.Replace (MasterData.Replace (0), item.effect.ToString ());
            effectName = effectName.Replace (MasterData.Replace (1), MasterData.language.GetRowByKey (item.type).message [0]);
            text += effect + ":" + effectName + "\n";
        }
        GetComponent<Text> ().text = text;
    }
}
