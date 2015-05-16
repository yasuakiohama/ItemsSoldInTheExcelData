using UnityEngine;

namespace MasterData
{
//	public class Item
//	{
//		private static Entity_item1 entity_item1;
//		public static void Init()
//		{
//			entity_item1 = Resources.Load ("ExcelData/param1") as Entity_item1;
//
//
//			foreach (var sheet in entity_item1.sheets) {
//				foreach (var param in sheet.list) {
//				}
//			}
//
//
//		}
//
//		public static Entity_item1.Sheet GetSheet(string sheetName)
//		{
//			return entity_item1.sheets.Find ((s) => s.name.Equals (sheetName));
//		}
//
//		public static Entity_item1.Param GetParam(Entity_item1.Sheet sheet, string string_data)
//		{
//			return sheet.list.Find ((s) => s.string_data.Equals (string_data));
//		}
//
//		public static Entity_item1.Param GetParam(string sheetName, string string_data)
//		{
//			Entity_item1.Sheet sheet = GetSheet (sheetName);
//			return sheet.list.Find ((s) => s.string_data.Equals (string_data));
//		}
//
//		public static void DegugLog()
//		{
//			foreach (var sheet in entity_item1.sheets) {
//				Debug.Log ("------sheet.name------" + sheet.name);
//				foreach (var param in sheet.list) {
//					Debug.Log (
//						"param.ID;          " + param.ID + "\n" +
//						"param.string_data; " + param.string_data + "\n" +
//						"param.int_data;    " + param.int_data + "\n" +
//						"param.double_data; " + param.double_data + "\n" +
//						"param.bool_data;   " + param.bool_data + "\n" +
//						"param.math_1;      " + param.math_1 + "\n" +
//						"param.math_2;      " + param.math_2        
//					);
//					foreach (var data in param.array) {
//						Debug.Log ("param.array" + data);
//					}
//				}
//			}
//		}
//	}
}