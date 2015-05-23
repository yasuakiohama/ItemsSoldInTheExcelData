using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Excel
{
    public static class Language
    {
        public enum ID
        {
            TEXT_ITEM_HP_PORTION = 1000001,
            TEXT_ITEM_HP_PORTION_H,
            TEXT_ITEM_MP_PORTION,
            TEXT_ITEM_MP_PORTION_H,
            TEXT_ITEM_BOMB,
            TEXT_ITEM_BOMB_H,
            TEXT_ITEM_FIRE,
            TEXT_ITEM_THUNDER,
            TEXT_ITEM_BURIZADO,
            TEXT_ITEM_QUAKE,
            TEXT_ITEM_DRAIN,
            TEXT_ITEM_METEOR,

            TEXT_ITEM_TYPE_DAMAGE = 3000001,
            TEXT_ITEM_TYPE_HEAL,
            TEXT_ITEM_NANE,
            TEXT_ITEM_EFFECT,
            TEXT_HP,
            TEXT_MP,
        }


        /// <summary>
        /// 今回は言語データを全て渡す場面はないためprivateにした。
        /// </summary>
        private static List<Entity_Language.Param> m_list = null;
        private static Dictionary<int, Entity_Language.Param> m_map = null;
        private static Dictionary<int, Entity_Language.Param> map {
            get {
                if (m_map == null) {
                    Setting (Application.systemLanguage);
                }
                return m_map;
            }
        }

        /// <summary>
        /// 呼び出す言語を指定する
        /// 今回は日本は日本語、それ以外は英語にする
        /// </summary>
        /// <param name="systemLanguage">System language.</param>
        private static void Setting(SystemLanguage systemLanguage)
        {
            m_list = new List<Entity_Language.Param> ();
            switch (systemLanguage) {
            case SystemLanguage.Japanese:
                m_list.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.LANGUAGE] + systemLanguage) as Entity_Language).param);
                break;
            default:
                m_list.AddRange ((Resources.Load (Option.PATH [(int)Option.Key.LANGUAGE] + SystemLanguage.English.ToString ()) as Entity_Language).param);
                break;
            }
            m_map = new Dictionary<int, Entity_Language.Param> ();
            foreach (var param  in m_list) {
                m_map.Add (param.ID, param);
            }
        }

        public static string GetMessageById(int id)
        {
            try {
                return map [id].message;
            } catch (KeyNotFoundException e) {
                Debug.LogError ("Entity_Item Error ID:" + id + "\n" + e.Message);
                return null;
            }
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
