using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Excel
{
    /// <summary>
    /// Itemsのエクセルデータ設定用クラス
    /// シートをsepalateしない
    /// </summary>
    public static class ItemShop
    {
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
        private static List<Entity_ItemShop.Sheet> _sheets;

        /// <summary>
        /// ゲームが始まってから最初に呼ばれるまで初期化しない
        /// </summary>
        private static void Init()
        {
            _sheets = new List<Entity_ItemShop.Sheet> ();
            _sheets.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.ITEMSHOP]) as Entity_ItemShop).sheets);
        }

        /// <summary>
        /// paramのリストを習得する
        /// </summary>
        /// <returns>The parameters by name.</returns>
        /// <param name="sheetName">Sheet name.</param>
        public static List<Entity_ItemShop.Param> GetParamsByName(string sheetName)
        {
            if (_sheets == null) {
                Init ();
            }
            return _sheets.Find (s => s.name.Equals (sheetName)).list;
        }
    }
}