using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_ItemShop : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int shopId;
		public int itemId;
	}
}