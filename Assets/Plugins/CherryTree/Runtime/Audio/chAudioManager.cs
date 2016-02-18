
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
//------------------------------------------
// 2016/02/04  Randy  Initial version
// 2016/02/18  Randy  Can mute, unmute, pause, or unpause audio players in the mute list
//------------------------------------------

using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CherryTree {

    public class chAudioManager : MonoBehaviour {                       

        [Serializable]
        public struct AudioPlayer {
            [chTagSelector(AllowUntagged = false, order = 0)]            
            public string tag;
            public chAudioPlayer player;
        }

        // array just for interface in the inspector
        public AudioPlayer[] audioPlayers;

        // each audio players in the dictionary can be accessed by key which is a unity tag
        private Dictionary<string, chAudioPlayer> _dict;
        // all audio players in the mute list can be paused, unpaused, muted, or unmuted at the same time
        private List<chAudioSource> _muteList;

        //> EVENTS

        void Awake() {            
            Initialize();
        }

        //> INITIALIZE

        private void Initialize() {                 
            // create AudioPlayer dictionary
            _dict = audioPlayers.ToDictionary(x => x.tag, x => x.player);
            // create AudioPlayer list
            _muteList = audioPlayers.Select(x => (chAudioSource)x.player).ToList();
        }

        //> PUBLIC

        public chAudioPlayer GetAudioPlayer(string tag) {
            return _dict[tag];
        }

        public void AddToMuteList(chAudioPlayer audioPlayer) {
            AddToMuteList((chAudioSource)audioPlayer);
        }

        public void AddToMuteList(chAudioSource audioSource) {            
            if (!_muteList.Contains(audioSource)) {
                _muteList.Add(audioSource);
            }            
        }

        public void PauseAll() {
            ForEachInList(Pause);
        }

        public void UnPauseAll() {
            ForEachInList(UnPause);
        }

        public void MuteAll() {
            ForEachInList(Mute);
        }

        public void UnMuteAll() {
            ForEachInList(UnMute);
        }

        //> PRIVATE

        private void ForEachInList(Action<chAudioSource> doThis) {
            int length = _muteList.Count;
            for (int i = 0; i < length; i++) {
                doThis(_muteList[i]);                
            }
        }

        private void Pause(chAudioSource audioPlayer) {
            audioPlayer.Pause();
        }

        private void UnPause(chAudioSource audioPlayer) {
            audioPlayer.UnPause();
        }

        private void Mute(chAudioSource audioPlayer) {
            audioPlayer.Mute();
        }

        private void UnMute(chAudioSource audioPlayer) {
            audioPlayer.UnMute();
        }

        //> LOG

#if UNITY_EDITOR || DEBUG
        // only run this script in Unity editor or DEBUG mode

        private void Log(string msg) {
            Debug.Log("[chAudioManager] " + msg);
        }

#endif

    } // end class

} // end namespace