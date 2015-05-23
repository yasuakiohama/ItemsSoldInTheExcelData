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
    public static class Item
    {
        //行データ
        //直接配列番号に入れて使用する
        public enum ID : int
        {
            ITEM_HP_PORTION = 4000001,
            ITEM_HP_PORTION_H,
            ITEM_MP_PORTION,
            ITEM_MP_PORTION_H,

            ITEM_BOMB = 4000101,
            ITEM_BOMB_H,

            ITEM_FIRE = 4000201,
            ITEM_THUNDER,
            ITEM_BURIZADO,
            ITEM_QUAKE,
            ITEM_DRAIN,
            ITEM_METEOR,
        }

        public enum Type : int
        {
            TYPE_HEAL_HP = 20001,
            TYPE_HEAL_MP,
            TYPE_DAMAGE,
        }

        private static List<Entity_Item.Param> m_list = null;
        private static Dictionary<int, Entity_Item.Param> m_map = null;
        private static Dictionary<int, Entity_Item.Param> map {
            get {
                if (m_map == null) {
                    m_list = new List<Entity_Item.Param> ();
                    m_list.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.ITEM]) as Entity_Item).param);
                    m_map = new Dictionary<int, Entity_Item.Param> ();
                    foreach (var param  in m_list) {
                        m_map.Add (param.ID, param);
                    }
                }
                return m_map;
            }
        }

        public static Entity_Item.Param GetRowById(int id)
        {
            try {
                return map [id];
            } catch (KeyNotFoundException e) {
                Debug.LogError ("Entity_Item Error ID:" + id + "\n" + e.Message);
                return new Entity_Item.Param ();
            }
        }

        public static Entity_Item.Param[] ToArray()
        {
            return map.Values.ToArray ();
        }
    }
}