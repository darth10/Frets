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
