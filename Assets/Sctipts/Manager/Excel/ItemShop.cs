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
        private static List<Entity_ItemShop.Sheet> m_list = null;
        private static Dictionary<int, List<Entity_ItemShop.Param>> m_map = null;
        private static Dictionary<int, List<Entity_ItemShop.Param>> map {
            get {
                if (m_map == null) {
                    m_list = new List<Entity_ItemShop.Sheet> ();
                    m_list.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.ITEMSHOP]) as Entity_ItemShop).sheets);
                    m_map = new Dictionary<int, List<Entity_ItemShop.Param>> ();
                    foreach (var sheet  in m_list) {
                        SheetName sheetName = new SheetName ();
                        try {
                            sheetName = (SheetName)Enum.Parse (typeof(SheetName), sheet.name);
                        } catch (ArgumentException e) {
                            Debug.Log (e.Message);
                        }
                        m_map.Add ((int)sheetName, sheet.list);
                    }
                    return m_map;
                }
                return m_map;
            }
        }

        public static List<Entity_ItemShop.Param> GetPalamById(int id)
        {
            try {
                return map [id];
            } catch (KeyNotFoundException e) {
                Debug.LogError ("Entity_Item Error ID:" + id + "\n" + e.Message);
                return null;
            }
        }

        public static Entity_ItemShop.Param GetRowById(int id, int paramId)
        {
            try {
                return GetPalamById (id) [paramId];
            } catch (IndexOutOfRangeException e) {
                Debug.LogError ("Entity_Item Error ID:" + paramId + "\n" + e.Message);
                return null;
            }
        }
    }
}