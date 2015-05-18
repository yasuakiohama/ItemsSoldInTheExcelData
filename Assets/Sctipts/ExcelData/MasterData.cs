using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData
{
    /// <summary>
    /// エクセルデータを利用したマスターデータ
    /// </summary>
    public static class MasterData
    {
        public const string ExcelData_DIRECTORY = "ExcelData/";
        public const string LANGUAGE_DIRECTORY = "Language/";

        /// <summary>
        /// Resourcesのパス
        /// Typeとセットになって呼び出される
        /// 例:(Resources.Load (MasterData.PATH [(int)MasterData.Key.ITEMS]) as Entity_Items
        /// </summary>
        public static readonly string[] PATH = {
            ExcelData_DIRECTORY + typeof(Items).Name,
            ExcelData_DIRECTORY + LANGUAGE_DIRECTORY,
            ExcelData_DIRECTORY + typeof(ItemShop).Name,
        };

        //リソールを呼び出すキー
        public enum Key : int
        {
            ITEMS,
            LANGUAGE,
            ITEMSHOP,


            //この上に変数を追加
            MAX
        };

        /*
         * 以下のような形で宣言する
         * 各クラスは最初に利用される時、Resourcesからデータを読み込める
        private static Class m_class = null;
        public static Class class {
            get {
                if (m_class != null) {
                    return m_class;
                }
                m_class = new Class ();
                return m_class;
            }
        }
        */

        private static Items m_items = null;
        public static Items items {
            get {
                if (m_items != null) {
                    return m_items;
                }
                m_items = new Items ();
                return m_items;
            }
        }

        private static Language m_language = null;
        public static Language language {
            get {
                if (m_language != null) {
                    return m_language;
                }
                m_language = new Language ();
                return m_language;
            }
        }

        private static ItemShop m_itemShop = null;
        public static ItemShop itemShop {
            get {
                if (m_itemShop != null) {
                    return m_itemShop;
                }
                m_itemShop = new ItemShop ();
                return m_itemShop;
            }
        }

        public static string Replace(int ID)
        {
            return "$" + ID.ToString () + "$";
        }
    }
}