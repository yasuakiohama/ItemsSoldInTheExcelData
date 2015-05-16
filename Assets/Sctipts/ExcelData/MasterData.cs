using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData {
	public partial class MasterData : MonoSingleton<MasterData>
	{
		public ScriptableObject[] entity {
			get;
			private set;
		}

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

		public static readonly string[] testlist;

		public override void OnInitialize()
		{
			List<string> temp;
			temp = new List<string> (Path);
			entity = new ScriptableObject[(int)Type.MAX];
			foreach (var path in temp.Select( (value, index) => new { value, index } )) {
				entity [path.index] = Resources.Load (EXCEL_DATA + path.value) as ScriptableObject;
			}
		}
	}
}