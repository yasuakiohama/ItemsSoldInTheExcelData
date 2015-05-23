using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_Item : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public int ID;
		public string key;
		public int price;
		public int type;
		public int effect;
		public int name;
	}
}