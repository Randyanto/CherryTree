using UnityEngine;
using CherryTree; // don't forget to use CherryTree namespace
   
public class ExampleDict : MonoBehaviour {

    public GameObject[] prefabs;
    private chDict<GameObject> objDict;

    void Awake() {
        
        // create objects dictionary
        objDict = new chDict<GameObject>(prefabs);

        // log every loaded sounds
        foreach (string key in objDict.Keys) {
            Debug.Log(key + " is loaded");
        }

    }

} // end class   
    