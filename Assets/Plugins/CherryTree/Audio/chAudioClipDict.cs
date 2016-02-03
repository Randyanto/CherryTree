
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Initial version
// 2016/02/03  Add namespace
//------------------------------------------

using UnityEngine;
        
namespace CherryTree {

    public class chAudioClipDict : MonoBehaviour {

        public AudioClip[] audioClips;
        private chDict<AudioClip> _audioDict;

        void Awake() {        
            // create sound dictionary
            _audioDict = new chDict<AudioClip>(audioClips);
        }

        public AudioClip GetAudioClip(string key) {
            return _audioDict.GetObj(key);
        }

    } // end class

} // end namespace
          
    