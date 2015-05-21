using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData
{
    /// <summary>
    /// Itemsのエクセルデータ設定用クラス
    /// シートをsepalateしている
    /// </summary>
    public static class Items
    {
        //行データ
        //直接配列番号に入れて使用する
        public enum Row
        {
            ITEM_HP_PORTION,
            ITEM_MP_PORTION,
            ITEM_BOMB,
            ITEM_FIRE,
            ITEM_THUNDER,
            ITEM_BURIZADO,
            ITEM_QUAKE,
            ITEM_DRAIN,
            ITEM_METEOR,

            //この上に変数を追加
            MAX,
        }

        /// <summary>
        /// paramを習得する
        /// </summary>
        /// <value>The parameter.</value>
        private static List<Entity_Items.Param> _param;

        /// <summary>
        /// ゲームが始まってから最初に呼ばれるまで初期化しない
        /// </summary>
        private static void Init()
        {
            _param = new List<Entity_Items.Param> ();
            _param.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.ITEMS]) as Entity_Items).param);
        }

        /// <summary>
        /// キーデータを利用して行データを習得
        /// </summary>
        /// <returns>The row by key.</returns>
        /// <param name="key">Key.</param>
        public static Entity_Items.Param GetRowByKey(string key)
        {
            if (_param == null) {
                Init ();
            }
            return _param.Find (s => s.key.Equals (key));
        }

        /// <summary>
        /// キーデータを利用して行データを習得
        /// </summary>
        /// <returns>The row by key.</returns>
        /// <param name="key">Key.</param>
        public static Entity_Items.Param GetRowById(int id)
        {
            if (_param == null) {
                Init ();
            }

            if (id < 0 || id >= (int)Row.MAX) {
                return null;
            }

            return _param [id];
        }
    }
}