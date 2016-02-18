
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
// 2016/02/03  Randy  Initial version
// 2016/02/04  Randy  Add copyright
//------------------------------------------

using UnityEngine;

namespace CherryTree {

    public class chAudioPlayer : chAudioSource {

        //> VARIABLES

        public chAudioLoader loader;        

        //> PUBLIC
        
        public void Play(string key, bool force = true) {
            base.Play(loader.GetAudioClip(key), force);
        }

        public void PlayOneShot(string key) {
            base.PlayOneShot(loader.GetAudioClip(key));
        }

        //> LOG

#if UNITY_EDITOR || DEBUG
// only run this script in Unity editor or DEBUG mode

        private void Log(string msg) {  
            Debug.Log("[chAudioPlayer] " + msg);
        }         

#endif

    } // end class

} // end namespace
