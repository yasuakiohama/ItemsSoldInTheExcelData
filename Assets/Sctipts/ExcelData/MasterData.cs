using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData {
	public partial class MasterData : MonoSingleton<MasterData>
	{
		private const string EXCEL_DATA = "ExcelData/";

		public static readonly string[] Path = {
			"Item_List",
			"Item_Shop",
		};

		public enum Type : int
		{
			ITEM_LIST,
			ITEM_SHOP,

			//
			MAX
		};

		public override void OnInitialize()
		{
			InitItemList ();
		}
	}
}