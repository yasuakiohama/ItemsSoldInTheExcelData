using UnityEngine;
using System.Collections;
using ExcelData;

public class TEST : MonoBehaviour
{
	void Start ()
	{
//		Debug.Log (MasterData.instance.Item.param [0].name);
		Debug.Log (((Entity_ItemList)MasterData.instance.entity [(int)MasterData.Type.ITEM_LIST]).param [(int)MasterData.ItemList.fire].name);
	}
}
