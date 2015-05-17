using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data {
    public static class MasterData
    {
        private const string LANGUAGEDIRECTORY = "Language/";
        public const string DIRECTORY = "ExcelData/";

        public static readonly string[] PATH = {
            DIRECTORY + typeof(Items).Name,
            DIRECTORY + LANGUAGEDIRECTORY + Application.systemLanguage.ToString (),
            DIRECTORY + typeof(ItemShop).Name,
        };

        public enum Type : int
        {
            ITEMS,
            LANGUAGE,
            ITEMSHOP,

            //
            MAX
        };

        public static Items items = new Items ();
        public static Language language = new Language ();
        public static ItemShop itemShop = new ItemShop ();

        public static string Replace(int ID)
        {
            return "$" + ID.ToString () + "$";
        }
    }
}