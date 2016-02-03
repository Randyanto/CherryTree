
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Initial version
// 2016/02/03  Add namespace
//             Add "Sort AudioClips" context menu
//------------------------------------------

using UnityEngine;
        
namespace CherryTree {

    public class chAudioClipDict : MonoBehaviour {

        public AudioClip[] audioClips;
        private chDict<AudioClip> _audioDict;

        //> EVENTS

        void Awake() {        
            // create sound dictionary
            _audioDict = new chDict<AudioClip>(audioClips);
        }

        //> PUBLIC

        public AudioClip GetAudioClip(string key) {
            return _audioDict.GetObj(key);
        }

        //> EDITOR

        #if UNITY_EDITOR

        [ContextMenu("Sort AudioClips")]
        void SortAudioClips() {
            System.Array.Sort(audioClips, (a,b) => a.name.CompareTo(b.name));
            Debug.Log(this.name + " AudioClips are sorted");
        }

        #endif

    } // end class

} // end namespace
          
    