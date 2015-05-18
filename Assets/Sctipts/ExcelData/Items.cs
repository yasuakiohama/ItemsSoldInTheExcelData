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
    public class Items
    {
        public Items()
        {
            param = new List<Entity_Items.Param> ();
            param.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Key.ITEMS]) as Entity_Items).param);
        }

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
        }

        /// <summary>
        /// paramを習得する
        /// </summary>
        /// <value>The parameter.</value>
        public List<Entity_Items.Param> param {
            get;
            private set;
        }

        /// <summary>
        /// キーデータを利用して行データを習得
        /// </summary>
        /// <returns>The row by key.</returns>
        /// <param name="key">Key.</param>
        public Entity_Items.Param GetRowByKey(string key)
        {
            return param.Where (s => s.key == key).ToArray () [0];
        }
    }
}