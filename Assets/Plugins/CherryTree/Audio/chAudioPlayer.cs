

// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/03  Initial version
//------------------------------------------

using UnityEngine;

namespace CherryTree {

    public class chAudioPlayer : chAudioSource {

        //> VARIABLES

        public chAudioClipDict dictionary;

        override void Awake() {            
            Initialize();
        }            

        //> INITIALIZE

        private void Initialize() {
            base.Awake();

            #if UNITY_EDITOR || DEBUG

            if (dictionary == null) {
                Log("dictionary is NOT set");
            }

            #endif
        }

        //> PUBLIC

        public void Play(string key, bool force = true) {
            base.Play(dictionary.GetAudioClip(key), force);
        }

        public void PlayOneShot(string key) {
            base.PlayOneShot(dictionary.GetAudioClip(key));
        }

        //> LOG

        #if UNITY_EDITOR || DEBUG
        // only run this script in Unity editor or DEBUG mode

        private void Log(string msg) {  
            Debug.Log("[chAudioPlayer] " + msg);
        }         

        #endif
    }


} // end namespace
