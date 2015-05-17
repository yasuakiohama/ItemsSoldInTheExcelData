using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;

public class TestShopName : MonoBehaviour
{
    void Start ()
    {
        string text = "";
        string name = MasterData.language.GetRowByKey (Language.Row.ITEM_NANE.ToString()).message [0];

        foreach (var param in MasterData.items.param.Select( (value, index) => new { value, index } )) {
            string itemName = MasterData.language.GetRowByKey (param.value.message).message [0];
            text += "ID:" + param.index.ToString () + " " + name + ":" + itemName + "\n";
        }
        GetComponent<Text> ().text = text;
    }
}

//Debug.Log (
//    "param.value.ID         " + param.value.ID + "\n" +
//    "param.value.key        " + param.value.key + "\n" +
//    "param.value.maxHaveNum " + param.value.maxHaveNum + "\n" +
//    "param.value.price      " + param.value.price + "\n" +
//    "param.value.type       " + param.value.type + "\n" +
//    "m1                     " + MasterData.language.GetRowByKey (param.value.message).message[0] + "\n" +
//    "m2                     " + MasterData.language.GetRowByKey (param.value.message).message[1] + "\n" +
//    "種類                    " + MasterData.language.GetRowByKey (param.value.type).message[0]
//);