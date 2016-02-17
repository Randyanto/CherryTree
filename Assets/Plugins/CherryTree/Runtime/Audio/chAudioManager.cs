
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

        public AudioPlayer[] audioPlayers;
        private Dictionary<string, chAudioPlayer> _dict;

        //> EVENTS

        void Awake() {            
            Initialize();
        }

        //> INITIALIZE

        private void Initialize() {     
            // create AudioPlayer dictionary
            _dict = audioPlayers.ToDictionary(x => x.tag, x => x.player);            
        }

        //> PUBLIC

        public chAudioPlayer GetAudioPlayer(string tag) {
            return _dict[tag];
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