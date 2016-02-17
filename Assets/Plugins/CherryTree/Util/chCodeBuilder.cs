
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
// 2013/03/05  Ken    Initial version
// 2016/02/17  Randy  Change print function with body
//------------------------------------------

using System.Collections;

namespace CherryTree {
   
    public class chCodeBuilder {

        public string tabStr = "    ";
        public string ws = " ";
        public string commentStart = "//";
        private System.Text.StringBuilder sb = new System.Text.StringBuilder();        

        public chCodeBuilder p(string text) { sb.Append(text); return this; }
        public chCodeBuilder pn() { sb.Append(System.Environment.NewLine); return this; }
        public chCodeBuilder pn(string text) { sb.Append(text).Append(System.Environment.NewLine); return this; } //print line
        public chCodeBuilder ps(string text) { sb.Append(text).Append(ws); return this; } //print space
        public chCodeBuilder tab() { sb.Append(tabStr); return this; }
        public chCodeBuilder enter() { sb.Append(System.Environment.NewLine); return this; }
        public chCodeBuilder space() { sb.Append(ws); return this; }
        public chCodeBuilder pc(string text) { return ps(commentStart).p(text); } //print comment
        public chCodeBuilder pcn(string text) { return ps(commentStart).pn(text); }
        public chCodeBuilder pf(string sig) { //print function
            return ps(sig).pn("{}");
        }
        public chCodeBuilder pf(string sig, string body) {
            return ps(sig).pn("{").p(body).pn("}");
        }        
        public override string ToString() {
            return sb.ToString();
        }

    } // end class
        
} // end namespace
