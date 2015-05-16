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
		public enum ItemList : int
		{
			HP,
			MP,
			Boom,
			fire,

			MAX
		};
	}
}