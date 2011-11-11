using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frets
{
    public partial class FretControl : UserControl
    {
        private int _stringWidth = 30;

        protected Rectangle _stringRect;
        protected int _nStrings;
        protected Pen _darkPen, _lightPen;
        protected Brush _cursorBrush, _chordStringBrush;
        protected Color _darkColor = Color.Black, _lightColor = Color.Gray, _bgColor = Color.Ivory, _cursorColor = Color.LightGreen, _chordColor = Color.Navy;
        protected Size _cursorSize = new Size(50, 21);
        protected int _cursorPosition = 1;
        protected SortedDictionary<int, Rectangle> _stringMatrix;
        protected Chord _currentChord;
        protected Font _chordFont;

        public int CursorPosition
        {
            get { return _cursorPosition; }
            set { if ((value >= 1) && (value <= _nStrings)) _cursorPosition = value; _drawer.Invalidate(); }
        }

        public Size CursorSize
        {
            get { return _cursorSize; }
            set { _cursorSize = value; _drawer.Invalidate(); }
        }

        public Color ChordColor
        {
            get { return _chordColor; }
            set { _chordColor = value; InitializeColors(); _drawer.Invalidate(); }
        }

        public Color CursorColor
        {
            get { return _cursorColor; }
            set { _cursorColor = value; InitializeColors(); _drawer.Invalidate(); }
        }

        public Color BackgroundColor
        {
            get { return _bgColor; }
            set { _bgColor = value; InitializeColors(); _drawer.Invalidate(); }
        }

        public Color SecondaryColor
        {
            get { return _lightColor; }
            set { _lightColor = value; InitializeColors(); _drawer.Invalidate(); }
        }

        public Color PrimaryColor
        {
            get { return _darkColor; }
            set { _darkColor = value; InitializeColors(); _drawer.Invalidate(); }
        }

        public int this[int index]
        {
            get { return _currentChord[index - 1]; }
            set
            {
                if (Chord.IsValidString(value))
                    _currentChord[index - 1] = value;

                _drawer.Invalidate();
            }
        }

        public FretControl()
        {
            this._nStrings = 7;         //KoЯn spec

            InitializeComponent();            
            InitializeDrawingComponents();
        }

        public FretControl(GuitarMode mode)
        {
            this._nStrings = Guitar.GetStringCount(mode);

            InitializeComponent();
            InitializeDrawingComponents();
        }

        protected void InitializeDrawingComponents()
        {
            InitializeColors();
            _stringMatrix = new SortedDictionary<int, Rectangle>();
            _currentChord = new Chord(_nStrings);
            Point center = new Point(_drawer.Width / 2, _drawer.Height / 2);
            int rectHeight = (_nStrings + 1) * _stringWidth;
            int rectWidth = _drawer.Width - 10;
            this._stringRect = new Rectangle((center.X - rectWidth / 2), (center.Y - rectHeight / 2), rectWidth, rectHeight);

            //init _stringMatrix
            Rectangle r;
            int x = center.X - _cursorSize.Width / 2;
            int y = _stringRect.Location.Y;
            for (int i = 1; i <= _nStrings; i++)
            {
                r = new Rectangle(new Point(x, (y + i * _stringWidth - _cursorSize.Height / 2)), _cursorSize);
                _stringMatrix.Add(i, r);
            }

            this._drawer.Paint += new PaintEventHandler(_drawer_Paint);
        }

        protected void InitializeColors()
        {
            _darkPen = new Pen(_darkColor, 2);
            _lightPen = new Pen(_lightColor, 2);
            _cursorBrush = new SolidBrush(_cursorColor);
            _chordStringBrush = new SolidBrush(_chordColor);
        }

        public void Clear()
        {
            _currentChord = new Chord(_nStrings);
            _drawer.Invalidate();
        }

        void _drawer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(_bgColor);

            //draw main rectangle
            e.Graphics.DrawRectangle(_darkPen, _stringRect);

            //draw cursor
            e.Graphics.FillRectangle(_cursorBrush, _stringMatrix[_cursorPosition]);

            //draw strings
            int y;
            for (int i = 1; i <= _nStrings; i++)
            {
                y = _stringRect.Location.Y + _stringWidth * i;
                e.Graphics.DrawLine(_lightPen, _stringRect.Location.X, y, _stringRect.Location.X + _stringRect.Width, y);
            }

            //draw chord strings
            int toShow = -1;
            Point chordStringLocation;
            RectangleF chordStringRect;
            String toDraw = "";
            SizeF strSize;
            for (int i = 1; i <= _nStrings; i++)
            {
                chordStringLocation = new Point(_stringRect.Location.X + _stringRect.Width / 2, _stringRect.Location.Y + i * _stringWidth);
                toShow = _currentChord[i - 1];
                
                if (toShow != -1)
                {
                    if (toShow == SpecialStrings.Pull)
                    {
                        toDraw = "p";
                    }
                    else if (toShow == SpecialStrings.HammerDown)
                    {
                        toDraw = "h";
                    }
                    else if (toShow == SpecialStrings.SlideUp)
                    {
                        toDraw = "/";
                    }
                    else if (toShow == SpecialStrings.SlideDown)
                    {
                        toDraw = "\\";
                    }
                    else if (toShow == SpecialStrings.NotPlayed)
                    {
                        toDraw = "x";
                    }
                    else if (toShow == SpecialStrings.FullBend)
                    {
                        toDraw = "b";
                    }
                    else if (toShow == SpecialStrings.HalfBend)
                    {
                        toDraw = "b|2";
                    }
                    else if (toShow == SpecialStrings.QuarterBend)
                    {
                        toDraw = "b|4";
                    }
                    else
                    {
                        toDraw = toShow.ToString();
                    }

                    strSize = e.Graphics.MeasureString(toDraw, this.Font);
                    chordStringRect = new RectangleF(chordStringLocation.X - strSize.Width / 2, chordStringLocation.Y - strSize.Height / 2, strSize.Width, strSize.Height);
                    e.Graphics.DrawString(toDraw, this.Font, _chordStringBrush, chordStringRect);
                }
            }
        }
    }
}
