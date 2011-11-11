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
