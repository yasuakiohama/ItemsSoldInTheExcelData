using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public class Items_importer : AssetPostprocessor
{
    private static readonly string filePath = "Assets/Resources/ExcelData/Items.xls";
    private static readonly string[] sheetNames = { "Items", };
    
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets)
        {
            if (!filePath.Equals(asset))
                continue;

            using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read))
            {
                var book = new HSSFWorkbook(stream);

                foreach (string sheetName in sheetNames)
                {
                    var exportPath = "Assets/Resources/ExcelData/" + sheetName + ".asset";
                    
                    // check scriptable object
                    var data = (Entity_Items)AssetDatabase.LoadAssetAtPath(exportPath, typeof(Entity_Items));
                    if (data == null)
                    {
                        data = ScriptableObject.CreateInstance<Entity_Items>();
                        AssetDatabase.CreateAsset((ScriptableObject)data, exportPath);
                        data.hideFlags = HideFlags.NotEditable;
                    }
                    data.param.Clear();

					// check sheet
                    var sheet = book.GetSheet(sheetName);
                    if (sheet == null)
                    {
                        Debug.LogError("[QuestData] sheet not found:" + sheetName);
                        continue;
                    }

                	// add infomation
                    for (int i=1; i<= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        ICell cell = null;
                        
                        var p = new Entity_Items.Param();
			
					cell = row.GetCell(0); p.ID = (cell == null ? 0.0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.key = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.price = (cell == null ? 0.0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.maxHaveNum = (cell == null ? 0.0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.type = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.effect = (cell == null ? 0.0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.message = (cell == null ? "" : cell.StringCellValue);

                        data.param.Add(p);
                    }
                    
                    // save scriptable object
                    ScriptableObject obj = AssetDatabase.LoadAssetAtPath(exportPath, typeof(ScriptableObject)) as ScriptableObject;
                    EditorUtility.SetDirty(obj);
                }
            }

        }
    }
}
