using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_ItemList : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public double ID;
		public string name;
		public string text;
		public double price;
		public double maxHaveNum;
	}
}