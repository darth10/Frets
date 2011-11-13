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
    /// Represents a tuning
    /// </summary>
    public sealed class Tuning
    {
        String[] _tuning;
        TuningMode _mode;

        /// <summary>
        /// Gets the tuning mode of the tuning
        /// </summary>
        public TuningMode TuningMode
        {
            get { return _mode; }
        }

        /// <summary>
        /// Gets the string value in the tuning
        /// </summary>
        /// <param name="index">Index of the string</param>
        /// <returns>Value of the string</returns>
        public String this[int index]
        {
            get { return _tuning[index]; }
        }

        /// <summary>
        /// Gets the number of strings in the tuning
        /// </summary>
        public int Length
        {
            get { return _tuning.Length; }
        }


        /// <summary>
        /// Creates a tuning
        /// </summary>
        /// <param name="mode">Tuning mode of the tuning</param>
        public Tuning(TuningMode mode)
        {
            _mode = mode;

            switch (mode)
            {
                case TuningMode.StandardTuning:
                case TuningMode.StandardTuning_6String:
                    _tuning = new String[] { "e", "a", "d", "g", "b", "e" };
                    break;
                case TuningMode.ATuning_6String:
                    _tuning = new String[] { "a", "d", "g", "c", "e", "a" };
                    break;
                case TuningMode.BTuning_6String:
                    _tuning = new String[] { "b", "e", "a", "d", "f#", "b" };
                    break;
                case TuningMode.CTuning_6String:
                    _tuning = new String[] { "c", "f", "a#", "d#", "g", "c" };
                    break;
                case TuningMode.DTuning_6String:
                    _tuning = new String[] { "d", "g", "c", "f", "a", "d" };
                    break;
                case TuningMode.DropATuning_6String:
                    _tuning = new String[] { "a", "e", "a", "d", "f#", "b" };
                    break;
                case TuningMode.DropDTuning_6String:
                    _tuning = new String[] { "d", "a", "d", "g", "b", "e" };
                    break;
                case TuningMode.DropCTuning_6String:
                    _tuning = new String[] { "c", "g", "c", "f", "a", "d" };
                    break;
                case TuningMode.StandardTuning_7String:
                    _tuning = new String[] { "b", "e", "a", "d", "g", "b", "e" };
                    break;
                case TuningMode.ATuning_7String:
                    _tuning = new String[] { "a", "d", "g", "c", "f", "a", "d" };
                    break;
                case TuningMode.CTuning_7String:
                    _tuning = new String[] { "c", "f", "a#", "d#", "g#", "c", "f" };
                    break;
                case TuningMode.CSharpTuning_7String:
                    _tuning = new String[] { "a#", "d#", "g#", "c#", "f#", "a#", "d#" };
                    break;
                case TuningMode.DTuning_7String:
                    _tuning = new String[] { "d", "g", "c", "f", "a#", "d", "g" };
                    break;
                case TuningMode.DropATuning_7String:
                    _tuning = new String[] { "a", "e", "a", "d", "f#", "b", "e" };
                    break;
                case TuningMode.DropGTuning_7String:
                    _tuning = new String[] { "g", "d", "g", "c", "f", "a", "d" };
                    break;
                case TuningMode.DropGSharpTuning_7String:
                    _tuning = new String[] { "g#", "d#", "g#", "c#", "f#", "a#", "d#" };
                    break;
                case TuningMode.DropFSharpTuning_7String:
                    _tuning = new String[] { "f#", "c#", "f#", "b", "e", "g#", "c#" };
                    break;
                case TuningMode.StandardTuning_8String:
                    _tuning = new String[] { "f#", "b", "e", "a", "d", "g", "b", "e" };
                    break;
                case TuningMode.ATuning_8String:
                    _tuning = new String[] { "a", "d", "g", "c", "f", "a", "d", "g" };
                    break;
                case TuningMode.FTuning_8String:
                    _tuning = new String[] { "fь", "bь", "eь", "aь", "dь", "gь", "bь", "eь" };
                    break;
                case TuningMode.DropDSharpTuning_8String:
                    _tuning = new String[] { "eь", "bь", "eь", "aь", "dь", "gь", "bь", "eь" };
                    break;
                case TuningMode.DropETuning_8String:
                    _tuning = new String[] { "e", "b", "e", "a", "d", "g", "b", "e" };
                    break;
            }
        }

        /// <summary>
        /// Gets the length of the longest string value in the tuning 
        /// </summary>
        /// <param name="tuning">Tuning</param>
        /// <returns>Length of the longest string</returns>
        public static int GetLongestStringLength(Tuning tuning)
        {
            int max=0;
            for (int i = 0; i < tuning.Length; i++)
            {
                if (tuning[i].Length > max)
                    max = tuning[i].Length;
            }

            return max;
        }
    }

    /// <summary>
    /// Represents a tuning mode
    /// </summary>
    public enum TuningMode
    {
        StandardTuning,
        StandardTuning_6String,
        StandardTuning_7String,
        StandardTuning_8String,

        ATuning_6String,
        BTuning_6String,
        CTuning_6String,
        DTuning_6String,
        DropATuning_6String,
        DropCTuning_6String,
        DropDTuning_6String,

        ATuning_7String,
        CTuning_7String,
        CSharpTuning_7String,
        DTuning_7String,
        DropATuning_7String,
        DropGTuning_7String,
        DropGSharpTuning_7String,
        DropFSharpTuning_7String,

        ATuning_8String,
        FTuning_8String,
        DropDSharpTuning_8String,
        DropETuning_8String
    }
}
