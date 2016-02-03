
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Initial version
// 2016/02/03  Add namespace
//             Add constructor and change static to non-static
//             Add logger
//------------------------------------------

using UnityEngine;
using System.Collections.Generic;
      
namespace CherryTree {

    public class chDict<T> where T:Object {

        //> VARIABLES
                
        private readonly Dictionary<string, T> _dict; // only can be set in constructor
        public readonly Dictionary<string, T>.KeyCollection Keys; // only can be set in constructor

        //> PUBLIC

        // constructor
        public chDict(T[] objs) {                 
            #if UNITY_EDITOR || DEBUG    
            // only run this script on Unity editor or DEBUG mode

            // if array is null
            if (objs == null) {
                Log("input array is NULL");
                return;
            }               

            // if array length is smaller or equal to zero 
            int length = objs.Length;
            if (length <= 0) {
                Log("input array length must be greater than ZERO");
                return;
            }       

            #endif

            // if array is NOT null and its length is larger than zero
            _dict = new Dictionary<string, T>();
            for (int i=0; i<length; i++) {
                _dict.Add (objs[i].name, objs[i]);            
            }             

            // save Keys
            Keys = _dict.Keys;
        }             
            

        public T GetObj(string key) {
            #if UNITY_EDITOR || DEBUG
            // only run this script in Unity editor or DEBUG mode

            // check if object is loaded into dictionary
            if (!_dict.ContainsKey(key)) {
                Log(key + " is not loaded");
                return null;
            }   

            #endif      

            return _dict[key];
        }


        //> PRIVATE

        #if UNITY_EDITOR || DEBUG
        // only run this script in Unity editor or DEBUG mode

        private void Log(string msg) {                 
            Debug.Log("[chDict] " + msg);
        }         

        #endif

    } // end class
        
} // end namespace
