
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Initial version
//------------------------------------------

using UnityEngine;
using System.Collections.Generic;
        
public class ctAudioDict : MonoBehaviour {

    public AudioClip[] audioClips;
    private Dictionary<string, AudioClip> _audioDict;

    void Awake () {        
        // create sound dictionary
        _audioDict = ctDict<AudioClip>.CreateDict(audioClips);
    }
        
    public AudioClip GetAudioClip(string key){

        #if UNITY_EDITOR
        // only run this script in Unity editor 

        // check if audio clip is loaded into dictionary
        if (!_audioDict.ContainsKey(key)){
            Debug.LogWarning(string.Format("[ctSound] {0} is not loaded",key));
            return null;
        }   

        #endif      

        return _audioDict[key];
    }

} // end class          
    