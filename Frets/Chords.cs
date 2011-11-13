/*
* Copyright (c) 2011, Akhil Wali <akhil.wali.10@gmail.com>
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frets
{
    /// <summary>
    /// Represent the chord family of a chord
    /// </summary>
    public enum ChordFamily
    {
        C, D, E, F, G, A, B,
        CSharp, DSharp, FSharp, GSharp, ASharp,
        DFlat, EFlat, GFlat, AFlat, BFlat
    }

    /// <summary>
    /// Represents the chord type of a chord
    /// </summary>
    public enum ChordType
    {
        Major, 
        Minor,
        
        Suspended_4th,
        Augmented_5th, 
        Diminished_5th,
        
        Major_6th, 
        Minor_6th,
        
        Suspended_7th, 
        Dominant_7th, 
        Augmented_7th, 
        Flat5_7th, 
        Major_7th, 
        MajorMinor_7th, 
        Minor_7th, 
        AugmentedMajor_7th, 
        HalfDiminished_7th,
        Diminished_7th, 
        
        Major_9th,
        Diminished_9th
    }
}
