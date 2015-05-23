using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Excel
{
    /// <summary>
    /// Itemのエクセルデータ設定用クラス
    /// シートをsepalateしている
    /// </summary>
    public static class ItemShop
    {
        //行データ
        //直接配列番号に入れて使用する
        public enum ID : int
        {
            Shop1 = 500001,
            Shop2,
            Shop3,
        }

        private static List<Entity_ItemShop.Param> m_list = null;
        private static List<Entity_ItemShop.Param> list {
            get {
                if (m_list == null) {
                    m_list = new List<Entity_ItemShop.Param> ();
                    m_list.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.ITEMSHOP]) as Entity_ItemShop).param);
                }
                return m_list;
            }
        }

        public static List<Entity_ItemShop.Param> GetRowsById(int id)
        {
            return list.Where (s => s.shopId == id).ToList ();
        }
    }
}