using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Manager.Excel;
using UnityEngine.EventSystems;

public class UIShop : MonoBehaviour
{
    bool changeFlage = false;
    Text[] itemNameText;
    Text itemEffectText;
    int selectItemShop = 0;
    enum ButtonName
    {
        ShopButton1,
        ShopButton2,
        ShopButton3,
        ChangeLanguage,
    }

    void Awake ()
    {
        itemNameText = transform.FindChild ("ItemList").GetComponentsInChildren<Text> ();
        itemEffectText = transform.FindChild ("Effect").GetComponent<Text> ();   
        Init ();
    }

    public void OnButtonClick (GameObject gameObject)
    {
        try {
            ButtonName buttonName = (ButtonName)Enum.Parse (typeof(ButtonName), gameObject.name);
            switch (buttonName) {
            case ButtonName.ShopButton1:
                selectItemShop = (int)ItemShop.SheetName.Shop1;
                break;
            case ButtonName.ShopButton2:                
                selectItemShop = (int)ItemShop.SheetName.Shop2;
                break;
            case ButtonName.ShopButton3:                
                selectItemShop = (int)ItemShop.SheetName.Shop3;
                break;
            case ButtonName.ChangeLanguage:
                if (changeFlage) {
                    Language.DebugChangeLanguage (SystemLanguage.Japanese);
                    changeFlage = false;
                } else {
                    Language.DebugChangeLanguage (SystemLanguage.English);
                    changeFlage = true;
                }
                break;
            }
            Init ();
        } catch (ArgumentException e) {
            Debug.Log (e.Message);
        }
    }

    private void Init()
    {
        InitItemName (selectItemShop);
        ItemEffectInit (selectItemShop);
    }

    private void InitItemName (int shopKey)
    {
        foreach(var text in itemNameText){
            text.transform.parent.gameObject.SetActive (false);
        }
        string name = Language.GetMessageById ((int)Language.ID.TEXT_ITEM_NANE);
        foreach (var param in ItemShop.GetPalamById(shopKey).Select((value,index) => new {value,index})) {
            var item = Item.GetRowById (param.value.itemId);
            string itemName = Language.GetMessageById (item.name);
            itemNameText [param.index].transform.parent.gameObject.SetActive (true);
            itemNameText [param.index].text = ItemNameOneLineText (item.ID.ToString (), name, itemName);
        }
    }

    private void ItemEffectInit (int shopKey)
    {
        string effect = Language.GetMessageById ((int)Language.ID.TEXT_ITEM_EFFECT);        
        var item = Item.GetRowById (ItemShop.GetRowById (shopKey, 0).itemId);
        string effectName = Language.GetMessageById (item.type);
        effectName = Option.Replace (effectName, 0, item.effect.ToString ());
        itemEffectText.text = ItemEffectOneLineText (effect, effectName);
    }

    public void ItemEffectInit (GameObject gameobject)
    {
        string effect = Language.GetMessageById ((int)Language.ID.TEXT_ITEM_EFFECT);        
        var item = Item.GetRowById (ItemShop.GetRowById (selectItemShop, int.Parse (gameobject.name)).itemId);
        string effectName = Language.GetMessageById (item.type);
        effectName = Option.Replace (effectName, 0, item.effect.ToString ());
        itemEffectText.text = ItemEffectOneLineText (effect, effectName);
    }

    private string ItemEffectOneLineText(string effect, string effectName)
    {
        return effect + ":" + effectName + "\n";
    }

    private string ItemNameOneLineText(string id, string name, string itemName)
    {
        return "ID:" + id + " " + name + ":" + itemName + "\n";
    }
}
