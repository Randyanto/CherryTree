
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
// 2016/02/02  Initial version
// 2016/02/03  Add namespace
//             Add "Sort AudioClips" context menu
// 2016/02/04  Add copyright
// 2016/02/05  Use Linq
//------------------------------------------

using UnityEngine;
using System.Linq;
using System.Collections.Generic;        

namespace CherryTree {

    public class chAudioLoader : MonoBehaviour {

        public AudioClip[] audioClips;        
        private Dictionary<string, AudioClip> _audioDict;

        //> EVENTS

        void Awake() {
            Initialize();
        }

        //> INITIALIZE

        private void Initialize() {
            // create AudioClip dictionary            
            _audioDict = audioClips.ToDictionary(x => x.name, x => x);
        }            

        //> PUBLIC
        
        public AudioClip GetAudioClip(string key) {
            return _audioDict[key];
        }

        //> EDITOR

#if UNITY_EDITOR
// only run this script in Unity editor or DEBUG mode    

        [ContextMenu("Sort AudioClips")]
        void SortAudioClips() {
            System.Array.Sort(audioClips, (a,b) => a.name.CompareTo(b.name));
            Debug.Log(this.name + " AudioClips are sorted");
        }

#endif

    } // end class

} // end namespace
          
    