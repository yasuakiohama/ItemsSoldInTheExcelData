using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData
{
    public static class Language
    {
        public enum Key
        {
            TEXT_ITEM_HP_PORTION,
            TEXT_ITEM_MP_PORTION,
            TEXT_ITEM_BOMB,
            TEXT_ITEM_FIRE,
            TEXT_ITEM_THUNDER,
            TEXT_ITEM_BURIZADO,
            TEXT_ITEM_QUAKE,
            TEXT_ITEM_DRAIN,
            TEXT_ITEM_METEOR,
            TEXT_ITEM_TYPE_DAMAGE,
            TEXT_ITEM_TYPE_HEAL,
            TEXT_ITEM_NANE,
        }

        /// <summary>
        /// 今回は言語データを全て渡す場面はないためprivateにした。
        /// </summary>
        private static List<Entity_Language.Param> _param = null;

        /// <summary>
        /// ゲームが始まってから最初に呼ばれるまで初期化しない
        /// </summary>
        private static void Init()
        {
            Setting (Application.systemLanguage);
        }

        /// <summary>
        /// 呼び出す言語を指定する
        /// 今回は日本は日本語、それ以外は英語にする
        /// </summary>
        /// <param name="systemLanguage">System language.</param>
        private static void Setting(SystemLanguage systemLanguage)
        {
            _param = new List<Entity_Language.Param> ();
            switch (systemLanguage) {
            case SystemLanguage.Japanese:
                _param.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.LANGUAGE] + systemLanguage) as Entity_Language).param);
                return;
            default:
                _param.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.LANGUAGE] + SystemLanguage.English.ToString()) as Entity_Language).param);
                return;
            }
        }

        /// <summary>
        /// 行データを呼び出す
        /// </summary>
        /// <returns>The row by key.</returns>
        /// <param name="key">Key.</param>
        public static Entity_Language.Param GetRowByKey(string key)
        {
            if (_param == null) {
                Init ();
            }
            return _param.Find (s => s.key.Equals (key));
        }

        /// <summary>
        /// デバック用に言語を変換する処理
        /// </summary>
        /// <param name="systemLanguage">System language.</param>
        public static void DebugChangeLanguage(SystemLanguage systemLanguage)
        {
            Setting (systemLanguage);
        }
    }
}
