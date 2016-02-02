using UnityEngine;
using System.Collections.Generic;

public class ExampleDict : MonoBehaviour {

	public GameObject[] prefabs;
	private Dictionary<string, GameObject> objDict;
	
	void Awake(){
		// create objects dictionary
		objDict = ctDict<GameObject>.CreateDict(prefabs);
		// log every loaded sounds
		foreach (string key in objDict.Keys){
			Debug.Log(key + " is loaded");
		}
	}
	
}
