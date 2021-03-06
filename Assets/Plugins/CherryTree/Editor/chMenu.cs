﻿using UnityEngine;
using UnityEditor;
using System;
using System.Text;
using System.IO;

namespace CherryTree {

    public class chMenu {

        [MenuItem("CherryTree/Create Constants from Unity Tags")]
        static void CreateCsEnumFromUnityTags() {

            string moduleName = "CherryTree";                                  
            string className = "chUnityTags";
            string extension = ".cs";
            string path = String.Format("Assets/Plugins/{0}/", moduleName);
            string fullPath = path + className + extension;
                        
            if (File.Exists(fullPath)) {
                AssetDatabase.DeleteAsset(fullPath);
            }
            
            // outputs "Assets/Plugins/CherryTree/chUnityTags.cs"
            // if "Assets/Plugins/CherryTree/chUnityTags.cs" file does not already exist.
            // if "Assets/Plugins/CherryTree/chUnityTags.cs" already exists
            // it outputs "Assets/Plugins/CherryTree/chUnityTags 1.cs" 
            fullPath = AssetDatabase.GenerateUniqueAssetPath(fullPath);

            // if fullPath is empty then Plugins/CherryTree/ folder doesn't exist
            if (fullPath == "") {
                Debug.Log(String.Format("Please create Plugins/{0}/ folder first!", moduleName));            
            } else {

                string[] unityTags = UnityEditorInternal.InternalEditorUtility.tags;
                StringBuilder sb = new StringBuilder();
                foreach (string tag in unityTags) {
                    sb.Append("\t\t") // double tab
                      .AppendFormat("public const string {0} = \"{1}\";", tag.ToUpper(), tag)
                      .Append("\r\n"); // print carriage return and new line
                }
                sb.Append("\t");

                chCodeBuilder cb = new chCodeBuilder();
                cb.pcn("Code generated by chMenu")
                  .pn("namespace " + moduleName + " {")
                  .pn()
                  .tab().pf("public class " + className, sb.ToString())                  
                  .pn()
                  .pn("}");

                chAsset.WriteTextFile(fullPath, cb.ToString());
                Debug.Log("file \"" + path + className + extension + "\" created");   
                             
            }                                    
        }                


    } // end class

} // end namespace

