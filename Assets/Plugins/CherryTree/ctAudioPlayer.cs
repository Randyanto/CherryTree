
// https://github.com/Randyanto/CherryTree
//------------------------------------------
// 2016/02/02  Initial version
//------------------------------------------

using UnityEngine;
    
[RequireComponent( typeof(AudioSource))]
public class ctAudioPlayer : MonoBehaviour {

    private AudioSource _player;
    private float _initialVol;

    void Awake () {
        // this.audio is obsolete in Unity 5 so the AudioSource must be cached
        _player = this.GetComponent<AudioSource>();
        // save initial volume
        _initialVol = _player.volume;
    }

    public void Play(AudioClip clip, bool force = true){
        // force the audio player to stop
        if (_player.isPlaying && force){
            Stop();
        }

        // if the audio player is not playing then play
        if (!_player.isPlaying){
            _player.clip = clip;
            _player.Play();    
        } 
    }

    public void PlayOneShot(AudioClip clip){
        // play the audio clip and can't be stopped
        _player.PlayOneShot(clip);
    }

    public void Stop(){
        // stop the audio
        _player.Stop();
    }

    public void Mute(){
        // PlayOneShot can't be stopped so one of the solution is to MUTE the AudioSource
        _player.volume = 0;
    }

    public void Unmute(){
        // reset the volume into initial volume
        _player.volume = _initialVol;
    }

} // end class
