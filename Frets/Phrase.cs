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
using System.Collections;
using System.Linq;
using System.Text;

namespace Frets
{
    /// <summary>
    /// Represents a list of chords or a phrase
    /// </summary>
    public sealed class Phrase
    {
        private SortedDictionary<int, Chord> _chords;

        /// <summary>
        /// Gets the chords of the phrase
        /// </summary>
        public SortedDictionary<int, Chord> Chords
        {
            get { return _chords; }
        }

        /// <summary>
        /// Gets or sets a chord of the phrase
        /// </summary>
        /// <param name="index">Index of the chord</param>
        /// <returns>Chord at specified index</returns>
        public Chord this[int index]
        {
            get 
            {
                if (index < 0)
                    return _chords[_chords.Count + index];
                else
                    return _chords[index]; 
            }
            set
            {
                if (index < 0)
                    _chords[_chords.Count + index] = value;
                else
                    _chords[index] = value;
            }
        }

        /// <summary>
        /// Creates a phrase
        /// </summary>
        public Phrase()
        {
            _chords = new SortedDictionary<int, Chord>();
        }

        /// <summary>
        /// Appends a chord to the phrase
        /// </summary>
        /// <param name="c">Chord to append</param>
        public void Add(Chord c)
        {
            this._chords.Add(_chords.Count, c);
        }

        /// <summary>
        /// Returns the chords of a phrase as a generic list
        /// </summary>
        /// <returns>List of chords</returns>
        public List<Chord> ToList()
        {
            List<Chord> retVal = new List<Chord>();
            for (int i = 0; i < _chords.Count; i++)
                retVal.Add(_chords[i]);

            return retVal;
        }
    }
}
