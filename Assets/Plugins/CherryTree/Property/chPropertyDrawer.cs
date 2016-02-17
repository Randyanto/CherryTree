
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
// 2016/02/05  Randy  Initial version
//------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Linq;
 
namespace CherryTree {
        
    // reference : https://github.com/lordofduct/spacepuppy-unity-framework/blob/366017cfd315003d943f839e6c9d51f6efe07cd8/SpacepuppyBaseEditor/Base/Inspectors/TagSelectorPropertyDrawer.cs    
    [CustomPropertyDrawer(typeof(chTagSelectorAttribute))]
    public class chTagSelectorPropertyDrawer : PropertyDrawer {
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (property.propertyType == SerializedPropertyType.String) {
                EditorGUI.BeginProperty(position, label, property);
                
                chTagSelectorAttribute attrib = this.attribute as chTagSelectorAttribute;

                if (attrib.AllowUntagged) {
                    property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
                } else {                    
                    
                    string[] tags = UnityEditorInternal.InternalEditorUtility.tags.Where(
                                            str => (str != chUnityTags.UNTAGGED)
                                    ).ToArray();                    
                    string stag = property.stringValue;
                    int index = -1;
                    for (int i = 0; i < tags.Length; i++) {                        
                        if (tags[i] == stag) {
                            index = i;
                            break;
                        }
                    }

                    index = EditorGUI.Popup(position, label.text, index, tags);     
                    
                    if (index >= 0) {
                        property.stringValue = tags[index];
                    } else {
                        property.stringValue = null;
                    }
                    
                }

                EditorGUI.EndProperty();
            } else {
                EditorGUI.PropertyField(position, property, label);
            }

        }
        
    } // end class
    
} // end namespace