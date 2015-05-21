using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData
{
    /// <summary>
    /// エクセルデータを利用したOption
    /// </summary>
    public static class Option
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

        /// <summary>
        /// 任意の文字列をテキストに埋め込むための処理
        /// </summary>
        /// <param name="ID">I.</param>
        public static string Replace(int Id)
        {
            return "$" + Id.ToString () + "$";
        }

        public static string Replace(string oldValue, int Id,  string newValue)
        {
            return oldValue.Replace (Replace (Id), newValue);
        }
    }
}