using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData
{
    /// <summary>
    /// Itemsのエクセルデータ設定用クラス
    /// sepalate seetにチェックを着けてある。
    /// </summary>
    public class ItemShop
    {
        public ItemShop()
        {
            sheets = new List<Entity_ItemShop.Sheet> ();
            sheets.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Type.ITEMSHOP]) as Entity_ItemShop).sheets);
        }

        public enum SheetName
        {
            Shop1,
            Shop2,
            Shop3,
        }

        public List<Entity_ItemShop.Sheet> sheets {
            get;
            private set;
        }

        public List<Entity_ItemShop.Param> GetSheetParams(string sheetName)
        {
            return sheets.Where (s => s.name == sheetName).ToArray () [0].list;
        }
    }
}

//private List<Entity_ItemShop.Sheet> m_sheets = null;
//public List<Entity_ItemShop.Sheet> sheets
//{
//    get
//    {
//        if( m_sheets != null )
//        {
//            return m_sheets;
//        }
//
//        m_sheets = new List<Entity_ItemShop.Sheet> ();
//        m_sheets.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Type.ITEMSHOP]) as Entity_ItemShop).sheets);
//        return m_sheets;
//    }
//}