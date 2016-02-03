
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Initial version
// 2016/02/03  Add namespace
//             Add logger
//             Automatically add AudioSource if there is no AudioSource attached
//------------------------------------------

using UnityEngine;
    
namespace CherryTree {

    public class chAudioSource : MonoBehaviour {

        //> VARIABLES

        private AudioSource _source;
        private float _initialVol;

        //> EVENT

        public virtual void Awake() {
            Initialize();
        }

        public virtual void OnDestroy() {
            Mute ();
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

            // save initial volume
            _initialVol = _source.volume;
        }            
            
        //> PUBLIC

        public void Play(AudioClip clip, bool force = true) {
            // force the audio player to stop
            if (_source.isPlaying && force) {
                Stop();
            }

            // if the audio player is not playing then play
            if (!_source.isPlaying){
                _source.clip = clip;
                _source.Play();    
            } 
        }            

        public void PlayOneShot(AudioClip clip) {
            // play the audio clip and can't be stopped
            _source.PlayOneShot (clip);
        }

        public void Stop() {
            // stop the audio
            _source.Stop();
        }

        public void Mute() {
            // PlayOneShot can't be stopped so one of the solution is to MUTE the AudioSource
            _source.volume = 0;
        }

        public void Unmute() {
            // reset the volume into initial volume
            _source.volume = _initialVol;
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
