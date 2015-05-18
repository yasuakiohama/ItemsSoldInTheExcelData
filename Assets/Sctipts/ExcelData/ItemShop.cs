using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData
{
    /// <summary>
    /// Itemsのエクセルデータ設定用クラス
    /// シートをsepalateしない
    /// </summary>
    public class ItemShop
    {
        public ItemShop()
        {
            sheets = new List<Entity_ItemShop.Sheet> ();
            sheets.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Key.ITEMSHOP]) as Entity_ItemShop).sheets);
        }

        //シートの名前
        //GetParamsByNameに利用
        public enum SheetName
        {
            Shop1,
            Shop2,
            Shop3,
        }

        /// <summary>
        /// シートの配列を習得する
        /// </summary>
        /// <value>The sheets.</value>
        public List<Entity_ItemShop.Sheet> sheets {
            get;
            private set;
        }

        /// <summary>
        /// paramのリストを習得する
        /// </summary>
        /// <returns>The parameters by name.</returns>
        /// <param name="sheetName">Sheet name.</param>
        public List<Entity_ItemShop.Param> GetParamsByName(string sheetName)
        {
            return sheets.Find (s => s.name.Equals (sheetName)).list;
        }
    }
}