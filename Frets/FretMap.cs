using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frets
{
    /// <summary>
    /// Prints chords and phrases
    /// </summary>
    public static class FretMap
    {
        /// <summary>
        /// Prints a list of chords
        /// </summary>
        /// <param name="chords">List of chords</param>
        /// <param name="mode">Tuning mode</param>
        /// <param name="maxChordsInLine">Maximum number of chords in a single line</param>
        /// <returns>String representation of the list of chords</returns>
        public static String PrintChords(List<Chord> chords, TuningMode mode,int maxChordsInLine)
        {
            Tuning _tuning = new Tuning(mode);
            int _nStrings = _tuning.Length;

            StringBuilder retVal = new StringBuilder();
            SortedDictionary<int, StringBuilder> _stringText = new SortedDictionary<int, StringBuilder>();

            bool nextLine = true;
            int chordCount = 0;
            while (nextLine)
            {
                nextLine = false;
                _stringText.Clear();

                if (chords.Count == chordCount)
                {
                    nextLine = false;
                }
                else
                {
                    //get longest string length
                    int maxStringWidth = Tuning.GetLongestStringLength(_tuning);

                    //init strings 
                    for (int i = 1; i <= _nStrings; i++)
                    {
                        _stringText.Add(i, new StringBuilder(_tuning[i - 1].ToUpper().PadLeft(maxStringWidth, ' ') + "["));
                    }

                    //add flags stringbuilder
                    _stringText.Add(-1, new StringBuilder("".PadLeft(maxStringWidth + 1, ' ')));
                        
                    Chord currentChord = null;
                    String toPrint = "";
                    int counter = 1;
                    for (int i = chordCount; i < chords.Count && !nextLine; i++)
                    {
                        currentChord = chords[i];

                        //process chord
                        for (int j = 0; j < currentChord.Strings.Length; j++)
                        {
                            if (currentChord.Strings[j] == SpecialStrings.Pull)
                            {
                                toPrint = "p---";
                            }
                            else if (currentChord.Strings[j] == SpecialStrings.HammerDown)
                            {
                                toPrint = "h---";
                            }
                            else if (currentChord.Strings[j] == SpecialStrings.SlideUp)
                            {
                                toPrint = "/---";
                            }
                            else if (currentChord.Strings[j] == SpecialStrings.SlideDown)
                            {
                                toPrint = "\\---";
                            }
                            else if (currentChord.Strings[j] == SpecialStrings.NotPlayed)
                            {
                                toPrint = "---x";
                            }
                            else if (currentChord.Strings[j] == SpecialStrings.FullBend)
                            {
                                toPrint = "b---";
                            }
                            else if (currentChord.Strings[j] == SpecialStrings.HalfBend)
                            {
                                toPrint = "b|2--";
                            }
                            else if (currentChord.Strings[j] == SpecialStrings.QuarterBend)
                            {
                                toPrint = "b|4--";
                            }
                            else if (currentChord.Strings[j] == -1)
                            {
                                toPrint = "----";
                            }
                            else
                            {
                                //regular chord
                                toPrint = currentChord.Strings[j].ToString().PadLeft(4, '-');
                            }
                            _stringText[j + 1].Append(toPrint);
                        }

                        //process chord flags
                        switch (currentChord.ChordFlags)
                        {
                            case ChordFlags.None:
                                _stringText[-1].Append("    ");
                                break;
                            case ChordFlags.PalmMute:
                                _stringText[-1].Append("  PM");
                                break;
                            case ChordFlags.Harmonic:
                                _stringText[-1].Append("   H");
                                break;
                        }

                        if (counter == maxChordsInLine)
                        {
                            nextLine = true;
                            chordCount += maxChordsInLine;
                        }
                        else counter++;
                    }

                    if (counter != maxChordsInLine)
                    {
                        for (int i = counter; i <= maxChordsInLine; i++)
                        {
                            for (int j = 1; j <= _nStrings; j++)
                            {
                                _stringText[j].Append("----");
                            }

                            _stringText[-1].Append("    ");
                        }
                    }

                    for (int i = 1; i <= _nStrings; i++)
                    {
                        _stringText[i].Append("]\r\n");
                        retVal.Append(_stringText[i].ToString());
                    }
                    retVal.Append(_stringText[-1].ToString());

                    retVal.Append("\r\n\r\n");
                }
            }

            return retVal.ToString();
        }

        /// <summary>
        /// Prints a list of phrases
        /// </summary>
        /// <param name="phrases">List of phrases</param>
        /// <param name="mode">Tuning mode</param>
        /// <param name="maxChordsInLine">Maximum number of chords in a single line</param>
        /// <returns>String representation of the list of phrases</returns>
        public static String PrintChords(List<Phrase> phrases, TuningMode mode, int maxChordsInLine)
        {
            StringBuilder retVal = new StringBuilder();
            for (int i = 0; i < phrases.Count; i++)
            {
                retVal.Append(FretMap.PrintChords(phrases[i].ToList(), mode, maxChordsInLine));
                retVal.Append("\r\n\r\n");
            }
            return retVal.ToString();
        }
    }
}
