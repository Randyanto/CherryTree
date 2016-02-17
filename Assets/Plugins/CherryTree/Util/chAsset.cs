
// Copyright (c) 2015 Kuanying Chou, Yonathan Randyanto
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
// 2013/03/14  Ken    Initial version
//------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Text;

namespace CherryTree {

    public static class chAsset {

        public static string GetPath() {
            return Application.dataPath;                        
        }

        public static void WriteTextFile(string path, string content) { //>>> what if file exists?
            //Debug.Log ("before writing to \""+path+"\"");
            System.IO.File.WriteAllText(path, content);

            AssetDatabase.ImportAsset(path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            //Debug.Log ("done writing to \""+path+"\"");
        }

        public static string ReadTextFile(string path) {
            System.IO.StreamReader reader = new System.IO.StreamReader(
                    path);
            int lineNumber = 0;
            string line = null;
            StringBuilder sb = new StringBuilder();
            while ((line = reader.ReadLine()) != null) {
                sb.Append(line).Append(System.Environment.NewLine);
                lineNumber++;
            }
            reader.Close();
            return sb.ToString();
        }

    } // end class

} // end namespace
