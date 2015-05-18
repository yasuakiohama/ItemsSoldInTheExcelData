using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData
{
    public class Language
    {
        /// <summary>
        /// 初回呼び出し時に一度言語を選択する。
        /// 以後ずっとそのまま
        /// </summary>
        public Language()
        {
            Setting (Application.systemLanguage);
        }

        /// <summary>
        /// 呼び出す言語を指定する
        /// 今回は日本は日本語、それ以外は英語にする
        /// </summary>
        /// <param name="systemLanguage">System language.</param>
        public void Setting(SystemLanguage systemLanguage)
        {
            param = new List<Entity_Language.Param> ();
            switch (systemLanguage) {
            case SystemLanguage.Japanese:
                param.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Key.LANGUAGE] + systemLanguage) as Entity_Language).param);
                return;
            default:
                param.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Key.LANGUAGE] + SystemLanguage.English.ToString()) as Entity_Language).param);
                return;
            }
        }

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
        private List<Entity_Language.Param> param = null;

        /// <summary>
        /// 行データを呼び出す
        /// </summary>
        /// <returns>The row by key.</returns>
        /// <param name="key">Key.</param>
        public Entity_Language.Param GetRowByKey(string key)
        {
            return param.Where (s => s.key == key).ToArray () [0];
        }

        /// <summary>
        /// デバック用に言語を変換する処理
        /// </summary>
        /// <param name="systemLanguage">System language.</param>
        public void DebugChangeLanguage(SystemLanguage systemLanguage)
        {
            Setting (systemLanguage);
        }
    }
}
