
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Initial version
//------------------------------------------

using UnityEngine;
using System.Collections.Generic;

public static class ctDict<T> where T:Object {
	
	// USAGE: objDict = ctDict<objType>.CreateDict(arr); 
	public static Dictionary<string, T> CreateDict(T[] objs){
		// if array is null
		if (objs == null) return null;
		
		// if array length is smaller or equal to zero 
		int length = objs.Length;
		if (length <= 0) return null;			
		
		// if array is NOT null and its length is larger than zero
		Dictionary<string, T> dict = new Dictionary<string, T>();
		for (int i=0; i<length; i++){
			dict.Add(objs[i].name, objs[i]);			
		}
		return dict;				
	}		
		
}
