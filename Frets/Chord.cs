using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frets
{
    /// <summary>
    /// Represents a chord
    /// </summary>
    public sealed class Chord
    {
        int _nStrings;
        int[] _strings;
        ChordFlags _flags;

        /// <summary>
        /// Gets or sets the flags for the chord
        /// </summary>
        public ChordFlags ChordFlags
        {
            get { return _flags; }
            set { _flags = value; }
        }

        /// <summary>
        /// Gets or sets an individual string in the chord
        /// </summary>
        /// <param name="index">Index of the string</param>
        /// <returns>Value of string at specified index</returns>
        public int this[int index]
        {
            get
            {
                if (index < 0)
                    return _strings[_strings.Length + index];
                else
                    return _strings[index];
            }
            set
            {
                if (index < 0)
                    _strings[_strings.Length + index] = value;
                else
                    _strings[index] = value;
            }
        }

        /// <summary>
        /// Gets or sets the strings of the chord as an array
        /// </summary>
        public int[] Strings
        {
            get { return _strings; }
            set
            {
                if (_nStrings != value.Length)
                    throw new ApplicationException(String.Format("'values' should be of length {0}", _nStrings));

                _strings = value;
            }
        }

        /// <summary>
        /// Creates a chord
        /// </summary>
        public Chord()
        {
            _strings = new int[7];
            InitializeStringsToValue(-1);
            _nStrings = _strings.Length;
            _flags = ChordFlags.None;
        }


        /// <summary>
        /// Creates a chord
        /// </summary>
        /// <param name="strings">Number of strings in the chord</param>
        public Chord(int strings)
        {
            _strings = new int[strings];
            InitializeStringsToValue(-1);
            _nStrings = _strings.Length;
            _flags = ChordFlags.None;
        }

        /// <summary>
        /// Creates a chord
        /// </summary>
        /// <param name="flags">Flags for the chord</param>
        /// <param name="strings">Number of strings in the chord</param>
        /// <param name="values">Values of individual strings in the chord</param>
        public Chord(ChordFlags flags, int strings, params int[] values)
        {
            if (strings != values.Length)
                throw new ApplicationException(String.Format("'values' should be of length {0}", strings));

            _nStrings = strings;
            _strings = values;
            _flags = flags;
        }

        /// <summary>
        /// Creates a chord
        /// </summary>
        /// <param name="flags">Flags for the chord</param>
        /// <param name="strings">Number of strings in the chord</param>
        /// <param name="family">Chord family of the chord</param>
        /// <param name="type">Chord type of the chord</param>
        public Chord(ChordFlags flags, int strings, ChordFamily family, ChordType type)
        {
            _strings = new int[strings];
            InitializeStringsToValue(0);
            _nStrings = strings;
            _flags = flags;

            #region Template for any chord type
            //this[-6] = 0; this[-5] = 0; this[-4] = 0; this[-3] = 0; this[-2] = 0; this[-1] = 0;
            //switch (family)
            //{
            //    case ChordFamily.C:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.D:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.E:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.F:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.G:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.A:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.B:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.CSharp:
            //    case ChordFamily.DFlat:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.DSharp:
            //    case ChordFamily.EFlat:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.FSharp:
            //    case ChordFamily.GFlat:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.GSharp:
            //    case ChordFamily.AFlat:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //    case ChordFamily.ASharp:
            //    case ChordFamily.BFlat:
            //        InitializeStringsToValue(-1);
            //        this[-6] = -1; this[-5] = -1; this[-4] = -1; this[-3] = -1; this[-2] = -1; this[-1] = -1;
            //        break;
            //} 
            #endregion

            switch (type)
            {
                case ChordType.Major:
                    #region Major chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 3; this[-5] = 3; this[-4] = 2; this[-3] = 0; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 1; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 3; this[-3] = 2; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 2; this[-4] = 0; this[-3] = 0; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 2; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 4; this[-2] = 4; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 4; this[-4] = 3; this[-3] = 1; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 4; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 4; this[-3] = 3; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 4; this[-5] = 3; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 4;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 3; this[-2] = 3; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Minor:
                    #region Minor chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 3; this[-4] = 1; this[-3] = 0; this[-2] = 4; this[-1] = 3;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 3; this[-1] = 1;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 0; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 3; this[-3] = 1; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 0; this[-3] = 3; this[-2] = 3; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 2; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 4; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            this[-6] = 0; this[-5] = -1; this[-4] = 2; this[-3] = 1; this[-2] = 2; this[-1] = 4;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 4; this[-1] = 2;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 4; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 1; this[-3] = 4; this[-2] = 4; this[-1] = 4;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 3; this[-2] = 3; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Suspended_4th:
                    #region Suspended 4th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 3; this[-5] = 3; this[-4] = 3; this[-3] = 0; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 2; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 3; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 3; this[-4] = 0; this[-3] = 0; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 2; this[-2] = 3; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 4; this[-2] = 5; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(4);
                            this[-6] = 4; this[-5] = 4; this[-4] = 6; this[-3] = 6; this[-2] = 7; this[-1] = 4;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 1; this[-2] = 4; this[-1] = 4;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 4; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(4);
                            this[-6] = 4; this[-5] = 4; this[-4] = 6; this[-3] = 6; this[-2] = 4; this[-1] = 4;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 4; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Augmented_5th:
                    #region Augmented 5th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = 2; this[-5] = -1; this[-4] = 4; this[-3] = 3; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = -1; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = -1; this[-4] = 3; this[-3] = 2; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 2; this[-4] = 1; this[-3] = 0; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            this[-6] = 1; this[-5] = 0; this[-4] = 3; this[-3] = 2; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(3);
                            this[-6] = 3; this[-5] = -1; this[-4] = 5; this[-3] = 4; this[-2] = 4; this[-1] = 3;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 3; this[-3] = 2; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            this[-6] = 3; this[-5] = 2; this[-4] = 1; this[-3] = 0; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = -1; this[-4] = 4; this[-3] = 3; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 4;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = -1; this[-4] = 4; this[-3] = 3; this[-2] = 3; this[-1] = 2;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Diminished_5th:
                    #region Diminished 5th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 4; this[-3] = 5; this[-2] = 4; this[-1] = 2;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = 1; this[-5] = -1; this[-4] = 3; this[-3] = 1; this[-2] = 3; this[-1] = 1;
                            break;
                        case ChordFamily.E:
                            InitializeStringsToValue(-1);
                            this[-6] = 3; this[-5] = -1; this[-4] = 5; this[-3] = 3; this[-2] = 5; this[-1] = 3;
                            break;
                        case ChordFamily.F:
                            this[-6] = 1; this[-5] = 2; this[-4] = 3; this[-3] = 1; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 4; this[-4] = 0; this[-3] = 3; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            this[-6] = 5; this[-5] = 6; this[-4] = 7; this[-3] = 5; this[-2] = 4; this[-1] = 5;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = 1; this[-5] = -1; this[-4] = 3; this[-3] = 4; this[-2] = 3; this[-1] = 1;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            this[-6] = 0; this[-5] = -1; this[-4] = 2; this[-3] = 0; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = 2; this[-5] = -1; this[-4] = 4; this[-3] = 2; this[-2] = 4; this[-1] = 2;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            this[-6] = 2; this[-5] = 0; this[-4] = 4; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 4; this[-5] = 5; this[-4] = 0; this[-3] = 4; this[-2] = 3; this[-1] = 4;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            this[-6] = 0; this[-5] = 1; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 0;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Major_6th:
                    #region Major 6th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 2; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 0; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 1; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 3; this[-4] = 3; this[-3] = 5; this[-2] = 3; this[-1] = 5;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 2; this[-4] = 0; this[-3] = 0; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 4; this[-2] = 4; this[-1] = 4;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 1; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 4; this[-4] = 4; this[-3] = 6; this[-2] = 4; this[-1] = 6;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 4; this[-5] = 3; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 3; this[-2] = 3; this[-1] = 3;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Minor_6th:
                    #region Minor 6th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 3; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 0; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 3; this[-3] = 1; this[-2] = 3; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 0; this[-5] = 1; this[-4] = 0; this[-3] = 0; this[-2] = 3; this[-1] = 0;
                            break;
                        case ChordFamily.A:
                            this[-6] = 2; this[-5] = 0; this[-4] = 2; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 0; this[-3] = 1; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            this[-6] = 0; this[-5] = 4; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 4;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 4; this[-4] = 4; this[-3] = 6; this[-2] = 4; this[-1] = 5;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 1; this[-3] = 1; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 3; this[-2] = 3; this[-1] = 3;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Suspended_7th:
                    #region Suspended 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 3; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 0; this[-3] = 2; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 1; this[-3] = 3; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 3; this[-4] = 0; this[-3] = 0; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 0; this[-2] = 3; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 2; this[-3] = 2; this[-2] = 5; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 4; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 1; this[-2] = 2; this[-1] = 4;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 2; this[-3] = 4; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(4);
                            this[-6] = 4; this[-5] = 4; this[-4] = 4; this[-3] = 6; this[-2] = 4; this[-1] = 4;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 1; this[-3] = 1; this[-2] = 3; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Dominant_7th:
                    #region Dominant 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 3; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 1; this[-2] = 3; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 2; this[-4] = 0; this[-3] = 0; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 0; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 2; this[-2] = 4; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 4; this[-4] = 3; this[-3] = 1; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 4; this[-5] = 3; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 1; this[-2] = 3; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Augmented_7th:
                    #region Augmented 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 2; this[-3] = 3; this[-2] = 1; this[-1] = 4;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 0; this[-3] = 3; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 0; this[-3] = 1; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 1; this[-3] = 2; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 2; this[-4] = 1; this[-3] = 0; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.A:
                            this[-6] = 1; this[-5] = 4; this[-4] = 3; this[-3] = 0; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 1; this[-3] = 2; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 3; this[-3] = 4; this[-2] = 2; this[-1] = 5;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 1; this[-3] = 4; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 2; this[-3] = 3; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(4);
                            this[-6] = 4; this[-5] = 4; this[-4] = 4; this[-3] = 6; this[-2] = 4; this[-1] = 4;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 3; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 2;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Flat5_7th:
                    #region Flat-5 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 2; this[-3] = 3; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 0; this[-3] = 1; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 2; this[-3] = 3; this[-2] = 3; this[-1] = 4;
                            break;
                        case ChordFamily.F:
                            this[-6] = 1; this[-5] = 0; this[-4] = 1; this[-3] = 2; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 3; this[-3] = 4; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 1; this[-3] = 0; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 1; this[-3] = 2; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 3; this[-3] = 4; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 1; this[-3] = 2; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 2; this[-3] = 3; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 0; this[-3] = 1; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            this[-6] = 0; this[-5] = 1; this[-4] = 2; this[-3] = 1; this[-2] = 3; this[-1] = 4;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Major_7th:
                    #region Major 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 0; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 1; this[-3] = 1; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 2; this[-3] = 2; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 2; this[-4] = 0; this[-3] = 0; this[-2] = 0; this[-1] = 2;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 1; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 3; this[-2] = 4; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 4; this[-4] = 3; this[-3] = 1; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 3; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 3; this[-3] = 3; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 3; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 2; this[-2] = 3; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.MajorMinor_7th:
                    #region Major-minor 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 1; this[-3] = 0; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 1; this[-3] = 0; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            InitializeStringsToValue(3);
                            this[-6] = 3; this[-5] = 5; this[-4] = 4; this[-3] = 3; this[-2] = 3; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 2; this[-4] = 4; this[-3] = 3; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 4;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 3; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 1; this[-3] = 1; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 2; this[-2] = 2; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Minor_7th:
                    #region Minor 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 0; this[-3] = 0; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            InitializeStringsToValue(3);
                            this[-6] = 3; this[-5] = 5; this[-4] = 3; this[-3] = 3; this[-2] = 3; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 0; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 0; this[-3] = 2; this[-2] = 0; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 4; this[-2] = 2; this[-1] = 4;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 2; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 2; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 3; this[-3] = 1; this[-2] = 2; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.AugmentedMajor_7th:
                    #region Augmented major 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 1; this[-2] = 0; this[-1] = 0;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 5; this[-4] = 4; this[-3] = 3; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = -1; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            this[-6] = 0; this[-5] = 0; this[-4] = 2; this[-3] = 2; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 3; this[-5] = 2; this[-4] = 1; this[-3] = 0; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = -1; this[-3] = 1; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = -1; this[-3] = 3; this[-2] = 4; this[-1] = 3;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 4; this[-4] = 3; this[-3] = 2; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 1; this[-3] = 0; this[-2] = 3; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 3; this[-3] = 3; this[-2] = 3; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 1; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 0; this[-3] = 2; this[-2] = 3; this[-1] = 2;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.HalfDiminished_7th:
                    #region Half-diminished 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.D:
                            this[-6] = 1; this[-5] = -1; this[-4] = 0; this[-3] = 1; this[-2] = 1; this[-1] = 1;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 1; this[-4] = 0; this[-3] = 0; this[-2] = 3; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 2; this[-4] = 1; this[-3] = 1; this[-2] = 4; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            InitializeStringsToValue(3);
                            this[-6] = 3; this[-5] = 4; this[-4] = 3; this[-3] = 3; this[-2] = 6; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 1; this[-3] = 0; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.B:
                            this[-6] = 1; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            this[-6] = 0; this[-5] = 2; this[-4] = 2; this[-3] = 4; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = 2; this[-5] = -1; this[-4] = 1; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 3; this[-4] = 2; this[-3] = 2; this[-2] = 5; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 2; this[-5] = 2; this[-4] = 0; this[-3] = 1; this[-2] = 0; this[-1] = 2;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 2; this[-3] = 1; this[-2] = 2; this[-1] = 4;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Diminished_7th:
                    #region Diminished 7th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.D:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 0; this[-3] = 1; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 1; this[-4] = 2; this[-3] = 0; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 2; this[-4] = 3; this[-3] = 1; this[-2] = 3; this[-1] = 1;
                            break;
                        case ChordFamily.G:
                            this[-6] = 0; this[-5] = 1; this[-4] = 2; this[-3] = 0; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.A:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 0; this[-3] = 1; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 0; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 3; this[-4] = 4; this[-3] = 2; this[-2] = 4; this[-1] = 2;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 0; this[-3] = 1; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = -1; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 3;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Major_9th:
                    #region Major 9th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            this[-6] = 0; this[-5] = 3; this[-4] = 2; this[-3] = 3; this[-2] = 3; this[-1] = 0;
                            break;
                        case ChordFamily.D:
                            this[-6] = 0; this[-5] = 0; this[-4] = 0; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 0; this[-3] = 1; this[-2] = 0; this[-1] = 2;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 3;
                            break;
                        case ChordFamily.G:
                            this[-6] = 0; this[-5] = 0; this[-4] = 0; this[-3] = 0; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.A:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 2; this[-3] = 2; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 1; this[-3] = 2; this[-2] = 2; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 2; this[-4] = 1; this[-3] = 1; this[-2] = 2; this[-1] = 1;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 1; this[-4] = 1; this[-3] = 3; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 4;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 1; this[-4] = 0; this[-3] = 1; this[-2] = 1; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
                case ChordType.Diminished_9th:
                    #region Diminished 9th chords
                    switch (family)
                    {
                        case ChordFamily.C:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 3; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.D:
                            this[-6] = 0; this[-5] = 0; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.E:
                            this[-6] = 0; this[-5] = 2; this[-4] = 0; this[-3] = 1; this[-2] = 0; this[-1] = 1;
                            break;
                        case ChordFamily.F:
                            InitializeStringsToValue(1);
                            this[-6] = 1; this[-5] = 3; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.G:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 3; this[-3] = 1; this[-2] = 0; this[-1] = 3;
                            break;
                        case ChordFamily.A:
                            InitializeStringsToValue(-1);
                            this[-6] = 2; this[-5] = -1; this[-4] = 5; this[-3] = 3; this[-2] = 2; this[-1] = 5;
                            break;
                        case ChordFamily.B:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 2; this[-4] = 1; this[-3] = 2; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.CSharp:
                        case ChordFamily.DFlat:
                            InitializeStringsToValue(-1);
                            this[-6] = -1; this[-5] = 4; this[-4] = 3; this[-3] = 4; this[-2] = 3; this[-1] = 4;
                            break;
                        case ChordFamily.DSharp:
                        case ChordFamily.EFlat:
                            this[-6] = 0; this[-5] = 1; this[-4] = 1; this[-3] = 0; this[-2] = 2; this[-1] = 0;
                            break;
                        case ChordFamily.FSharp:
                        case ChordFamily.GFlat:
                            InitializeStringsToValue(2);
                            this[-6] = 2; this[-5] = 4; this[-4] = 2; this[-3] = 3; this[-2] = 2; this[-1] = 3;
                            break;
                        case ChordFamily.GSharp:
                        case ChordFamily.AFlat:
                            this[-6] = 2; this[-5] = 0; this[-4] = 1; this[-3] = 1; this[-2] = 1; this[-1] = 2;
                            break;
                        case ChordFamily.ASharp:
                        case ChordFamily.BFlat:
                            this[-6] = 1; this[-5] = 1; this[-4] = 0; this[-3] = 1; this[-2] = 0; this[-1] = 1;
                            break;
                    }
                    break;
                    #endregion
            }
        }

        private String[] GetStrings()
        {
            String[] retVal = new String[_nStrings];
            for (int i = 0; i < _nStrings; i++)
            {
                retVal[i] = _strings[i].ToString();
            }
            return retVal;
        }

        private void InitializeStringsToValue(int value)
        {
            for (int i = 0; i < 7; i++)
            {
                _strings[i] = value;
            }
        }

        /// <summary>
        /// Gets a string representation of the chord
        /// </summary>
        /// <returns>String representation of the chord</returns>
        public override string ToString()
        {
            String flag = "";
            switch (_flags)
            {
                case ChordFlags.PalmMute:
                    flag = "(PM)";
                    break;
                case ChordFlags.Harmonic:
                    flag = "(H)";
                    break;
                case Frets.ChordFlags.None:
                default:
                    break;
            }
            return String.Format("[{0}]{1}", String.Join(",", GetStrings()), flag);
        }

        /// <summary>
        /// Checks if a value is a valid string 
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>True if the string value is valid</returns>
        public static bool IsValidString(int value)
        {
            if (value > 24 || value < -9)
                return false;
            return true;
        }

        /// <summary>
        /// Converts a string representation of a chord into a chord object
        /// </summary>
        /// <param name="s">String representation of the chord</param>
        /// <returns>Chord object</returns>
        public static Chord Parse(String s)
        {
            Chord retVal = null;
            try
            {
                int last = s.IndexOf("]");
                String chordStr = s.Substring(0, last).Trim(new char[] { '[', ']' });
                String flagStr = s.Substring(last + 1).Trim(new char[] { '(', ')' });
                String[] chords = chordStr.Split(',');

                retVal = new Chord(chords.Length);
                for (int i = 0; i < chords.Length; i++)
                    retVal[i] = int.Parse(chords[i]);

                if (flagStr == "H")
                    retVal.ChordFlags = ChordFlags.Harmonic;
                else if (flagStr == "PM")
                    retVal.ChordFlags = ChordFlags.PalmMute;
            }
            catch (Exception) { throw; }
            
            return retVal;
        }
    }

    /// <summary>
    /// Special string values
    /// </summary>
    public class SpecialStrings
    {
        public static int NotPlayed         { get { return -2; } }
        public static int Pull              { get { return -3; } }
        public static int HammerDown        { get { return -4; } }
        public static int SlideDown         { get { return -5; } }
        public static int SlideUp           { get { return -6; } }
        public static int FullBend          { get { return -7; } }
        public static int HalfBend          { get { return -8; } }
        public static int QuarterBend       { get { return -9; } }
    }
 
    /// <summary>
    /// Represents flags for a chord
    /// </summary>
    public enum ChordFlags
    {
        None,
        PalmMute,
        Harmonic
    }
}
