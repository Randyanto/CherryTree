
// Copyright (c) 2015 Yonathan Randyanto
// https://github.com/Randyanto/CherryTree
// 
// This software is provided 'as-is', without any express or implied warranty. In
// no event will the authors be held liable for any damages arising from the use
// of this software.
// 
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it freely,
// subject to the following restrictions:
// 
// 1. The origin of this software must not be misrepresented; you must not claim
// that you wrote the original software. If you use this software in a product,
// an acknowledgment in the product documentation would be appreciated but is not
// required.
// 
// 2. Altered source versions must be plainly marked as such, and must not be
// misrepresented as being the original software.
// 
// 3. This notice may not be removed or altered from any source distribution.
//
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Randy  Initial version
// 2016/02/03  Randy  Add namespace
//             Randy  Add logger
//             Randy  Automatically add AudioSource if there is no AudioSource attached
// 2016/02/18  Randy  Add Pause, UnPause
//                    Change Mute and UnMute implementation
//------------------------------------------

using UnityEngine;
    
namespace CherryTree {

    public class chAudioSource : MonoBehaviour {
        
        //> VARIABLES

        private AudioSource _source;        

        //> EVENTS

        public virtual void Awake() {
            Initialize();
        }

        public virtual void OnDestroy() {
            Mute ();
            Stop();
        }

        public virtual void OnEnable() {
            UnMute();
        }

        public virtual void OnDisable() {
            Mute();
            Stop();
        }            

        //> INITIALIZE

        private void Initialize() {
            // this.audio is obsolete in Unity 5 so the AudioSource must be cached
            _source = this.GetComponent<AudioSource>();

            // if there is NO audio source then add one
            if (_source == null) {
                _source = this.gameObject.AddComponent<AudioSource>();
            }            
        }            
            
        //> PUBLIC
            
        //return the length of clip if succeed if not then return 0
        public float Play(AudioClip clip, bool force = true) {
            // force the audio player to stop
            if (_source.isPlaying && force) {
                Stop();
            }

            // if the audio player is not playing then play
            float clipLength = 0;
            if (!_source.isPlaying){
                clipLength = clip.length;
                _source.clip = clip;
                _source.Play();    
            }

            return clipLength;
        }

        //return the length of clip
        public float PlayOneShot(AudioClip clip) {
            // play the audio clip and can't be stopped
            _source.PlayOneShot(clip);
            return clip.length;
        }

        public void Pause() {            
            _source.Pause();
        }

        public void UnPause() {                        
            _source.UnPause();
        }

        public void Stop() {            
            _source.Stop();
        }

        public void Mute() {            
            _source.mute = true;            
        }

        public void UnMute() {
            _source.mute = false;            
        }

        //> LOG

        #if UNITY_EDITOR || DEBUG
        // only run this script in Unity editor or DEBUG mode

        private void Log(string msg) {                 
            Debug.Log("[chAudioSource] " + msg);
        }         

        #endif

    } // end class
        
} // end namespace
