using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelData {
	/// <summary>
	/// ItemListのエクセルデータ設定用クラス
	/// </summary>
	public partial class MasterData : MonoSingleton<MasterData>
	{
		//行データ
		public enum ItemList : int
		{
			HP,
			MP,
			Boom,
			fire,
			sanda,
		};

		public List<Entity_ItemList.Param> itemList{
			get;
			private set;
		}

		void InitItemList()
		{
			itemList = new List<Entity_ItemList.Param> ();
			itemList.AddRange ((Resources.Load (EXCEL_DATA + Path [(int)Type.ITEM_LIST]) as Entity_ItemList).param);
		}
	}
}