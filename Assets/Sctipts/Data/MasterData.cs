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
            DIRECTORY + "Item_Shop",
        };

        public enum Type : int
        {
            ITEMS,
            LANGUAGE,
            ITEM_SHOP,

            //
            MAX
        };

        public static Items items = new Items ();
        public static Language language = new Language ();
    }
}