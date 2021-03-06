using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public class Language_importer : AssetPostprocessor
{
    private static readonly string filePath = "Assets/Resources/ExcelData/Language/Language.xls";
    private static readonly string[] sheetNames = { "Japanese","English", };
    
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
                    var exportPath = "Assets/Resources/ExcelData/Language/" + sheetName + ".asset";
                    
                    // check scriptable object
                    var data = (Entity_Language)AssetDatabase.LoadAssetAtPath(exportPath, typeof(Entity_Language));
                    if (data == null)
                    {
                        data = ScriptableObject.CreateInstance<Entity_Language>();
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
                        
                        var p = new Entity_Language.Param();
			
					cell = row.GetCell(0); p.ID = (cell == null ? 0.0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.key = (cell == null ? "" : cell.StringCellValue);
					p.message = new string[2];
					cell = row.GetCell(2); p.message[0] = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.message[1] = (cell == null ? "" : cell.StringCellValue);

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
