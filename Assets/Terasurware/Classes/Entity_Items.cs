using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_Items : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public double ID;
		public string key;
		public double price;
		public double maxHaveNum;
		public string type;
		public double effect;
		public string message;
	}
}