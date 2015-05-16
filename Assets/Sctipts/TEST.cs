using UnityEngine;
using System.Collections;
using ExcelData;

public class TEST : MonoBehaviour
{
	void Start ()
	{
		Debug.Log (MasterData.instance.itemList [(int)MasterData.ItemList.fire].name);
	}
}
