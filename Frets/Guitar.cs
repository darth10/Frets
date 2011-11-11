using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frets
{
    /// <summary>
    /// Represents a guitar that can create and print chords
    /// </summary>
    public class Guitar
    {
        int _nStrings;
        Tuning _tuning;

        /// <summary>
        /// Gets or sets the tuning mode of the guitar
        /// </summary>
        public TuningMode Tuning
        {
            get { return _tuning.TuningMode; }
            set { _tuning = new Tuning(value); }
        }

        /// <summary>
        /// Creates a guitar
        /// </summary>
        public Guitar()
        {
            _nStrings = 7;      //KoЯn spec
        }

        /// <summary>
        /// Creates a guitar
        /// </summary>
        /// <param name="mode">Guitar mode</param>
        public Guitar(GuitarMode mode)
        {
            _nStrings = Guitar.GetStringCount(mode);
        }

        /// <summary>
        /// Returns the string count of a specified guitar mode
        /// </summary>
        /// <param name="mode">Guitar mode</param>
        /// <returns>Number of strings in the guitar mode</returns>
        public static int GetStringCount(GuitarMode mode)
        {
            switch (mode)
            {
                case GuitarMode.SixString:
                    return 6;
                case GuitarMode.SevenString:
                    return 7;
                case GuitarMode.EightString:
                    return 8;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// Creates a chord
        /// </summary>
        /// <param name="chordflags">Flags for the chord</param>
        /// <param name="chords">Individual chord values</param>
        /// <returns>Generated chord</returns>
        public Chord PlayChord(ChordFlags chordflags,params int[] chords)
        {
            if (chords.Length != _nStrings)
                throw new ApplicationException(String.Format("'values' should be of length {0}", _nStrings));

            return new Chord(chordflags, _nStrings, chords);
        }

        /// <summary>
        /// Creates a chord
        /// </summary>
        /// <param name="chordflags">Flags for the chord</param>
        /// <param name="chordFamily">Chord family</param>
        /// <param name="chordType">Chord type</param>
        /// <returns>Generated chord</returns>
        public Chord PlayChord(ChordFlags chordflags, ChordFamily chordFamily, ChordType chordType)
        {
            return new Chord(chordflags, _nStrings, chordFamily, chordType);
        }

        /// <summary>
        /// Prints a list of chords
        /// </summary>
        /// <param name="chords">List of chords</param>
        /// <param name="maxChordsInLine">Maximum number of chords in a single line</param>
        /// <returns>String representation of the list of chords</returns>
        public String PrintChords(List<Chord> chords, int maxChordsInLine)
        {
            return FretMap.PrintChords(chords, _tuning.TuningMode, maxChordsInLine);
        }

        /// <summary>
        /// Prints a list of phrases
        /// </summary>
        /// <param name="phrases">List of phrases</param>
        /// <param name="maxChordsInLine">Maximum number of chords in a single line</param>
        /// <returns>String representation of the list of phrases</returns>
        public String PrintChords(List<Phrase> phrases, int maxChordsInLine)
        {
            return FretMap.PrintChords(phrases, _tuning.TuningMode, maxChordsInLine);
        }
    }

    /// <summary>
    /// Represents a guitar mode
    /// </summary>
    public enum GuitarMode
    {
        SixString,
        SevenString,
        EightString
    }
}
