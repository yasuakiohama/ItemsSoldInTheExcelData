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
    public class Items
    {
        public Items()
        {
            param = new List<Entity_Items.Param> ();
            param.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Type.ITEMS]) as Entity_Items).param);
        }

        public enum Row : int
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

        public List<Entity_Items.Param> param {
            get;
            private set;
        }

        public Entity_Items.Param GetRowByKey(string key)
        {
            return param.Where (s => s.key == key).ToArray () [0];
        }
    }
}