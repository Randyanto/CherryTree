
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
// 2016/02/05  Initial version
//------------------------------------------

using UnityEngine;

namespace CherryTree {

    public class chConstant : MonoBehaviour {

        public const int LAYER_DEFAULT = 0;
        public const int LAYER_TRANSPARENTFX = 1;
        public const int LAYER_IGNORERAYCAST = 3;
        public const int LAYER_WATER = 4;

        public const string TAG_UNTAGGED = "Untagged";
        public const string TAG_RESPAWN = "Respawn";
        public const string TAG_FINISH = "Finish";
        public const string TAG_EDITORONLY = "EditorOnly";
        public const string TAG_MAINCAMERA = "MainCamera";
        public const string TAG_GAMECONTROLLER = "GameController";
        public const string TAG_PLAYER = "Player";        

    }

}