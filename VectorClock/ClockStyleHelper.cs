﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorClock
{
    public class ClockVisualStyle
    {
        public ArrowsSet        Arrows      = new ArrowsSet();
        public LineMarksSet     LineMarks   = new LineMarksSet();
        public NumbersSet       Numbers     = new NumbersSet();
        public float            Size        = 235.0f;



        public class ClockArrow
        {
            public StyleInfo Style = new StyleInfo (false) { LineColor = Color.Black, LineWidth = 2.0f, FillColor = Color.Black };

            public SizeFactor LineSize         = new SizeFactor { Constant = 0, Scaled = 0.95f };
            public SizeFactor LineBackwardTip  = new SizeFactor { Constant = 0, Scaled = 0.15f };
            public SizeFactor CircleSize       = new SizeFactor { Constant = 10.0f };

            //public Vector2D Vector;

            public ClockArrow ()
            {
            }

            public ClockArrow (Color aBaseColor, float aLineWidth, float aCircleRadius,
                float aFwdPos, float aBckPos)
            {
                this.LineSize.Scaled        = aFwdPos;
                this.LineBackwardTip.Scaled = aBckPos;

                this.Style.LineColor = aBaseColor;
                this.Style.LineWidth = aLineWidth;
                this.Style.FillColor = aBaseColor;

                this.CircleSize.Constant = aCircleRadius;

                this.Style.AutoRegenerateStyle = true;
                this.Style.RegenerateStyle();
            }
        }

        public class ArrowsSet
        {
            public ClockArrow Hour      = new ClockArrow (Color.DodgerBlue  , 6.0f, 14.5f, 0.70f, 0.15f);
            public ClockArrow Minute    = new ClockArrow (Color.Orange      , 4.0f,  9.5f, 0.95f, 0.15f);
            public ClockArrow Second    = new ClockArrow (Color.Red         , 2.0f,  7.5f, 0.95f, 0.15f);
            public ClockArrow SecGhost  = new ClockArrow (Color.FromArgb(64, Color.DimGray), 1.0f,  0.0f, 0.95f, 0.00f);
            public ClockArrow Alarm     = new ClockArrow (Color.DarkGray    , 5.0f,  0.0f, 0.55f, 0.15f);

            public ClockArrow UserArr1  = new ClockArrow (Color.Aquamarine  , 3.0f,  0.0f, 0.75f, 0.15f);
            public ClockArrow UserArr2  = new ClockArrow (Color.Fuchsia     , 3.0f,  0.0f, 0.75f, 0.15f);
            public ClockArrow UserArr3  = new ClockArrow (Color.Black       , 1.0f,  0.0f, 0.50f, 0.15f);

            public ClockArrow[] All     = new ClockArrow [8];

            public ArrowsSet ()
            {
                All[0] = SecGhost;
                All[1] = Alarm;
                All[2] = Hour;
                All[3] = Minute;
                All[4] = Second;

                All[5] = UserArr1;
                All[6] = UserArr2;
                All[7] = UserArr3;
            }
        }

        public class LineMarksSet
        {
            public StyleInfo Minutes    = new StyleInfo (true) { LineColor = Color.LightGreen, LineWidth = 1.0f };
            public StyleInfo Hours      = new StyleInfo (true) { LineColor = Color.LightGreen, LineWidth = 3.0f };

            public SizeFactor MinPosSize    = new SizeFactor { Scaled = 1.000f, Constant = -20.0f };
            public SizeFactor HourPosSize   = new SizeFactor { Scaled = 1.004f, Constant = -30.0f };
        }

        public class NumbersSet
        {
            public StyleInfo PrimaryMinutes     = new StyleInfo (true) { FillColor = Color.DimGray };
            public StyleInfo SecondaryMinutes   = new StyleInfo (true) { FillColor = Color.DimGray };
            public StyleInfo Hours              = new StyleInfo (true) { FillColor = Color.Black   };

            public Font PrimaryMinutesFont      = SystemFonts.DefaultFont;
            public Font SecondaryMinutesFont    = SystemFonts.DefaultFont;
            public Font HoursFont               = SystemFonts.DefaultFont;

            public SizeFactor MinutesPosition   = new SizeFactor { Constant = 0, Scaled = 1.10f };
            public SizeFactor HoursPosition     = new SizeFactor { Constant = 0, Scaled = 0.78f };
        }
    }



    public class StyleInfo : IDisposable
    {
        private Color   _LineColor;
        private float   _LineWidth;
        private Color   _FillColor;

        private Brush   _AutoGeneratedBrush;
        private Pen     _AutoGeneratedPen;

        public StyleInfo () : this (true) { }

        public StyleInfo (bool aUseAutoResourceGeneration)
        {
            this.AutoRegenerateStyle = aUseAutoResourceGeneration;
        }

        public bool AutoRegenerateStyle;

        public Color LineColor
        {
            get { return _LineColor; }
            set
            {
                if (_LineColor != value)
                {
                    _LineColor = value;
                    RegenerateStyle();
                }
            }
        }

        public float LineWidth
        {
            get { return _LineWidth; }
            set
            {
                if (_LineWidth != value)
                {
                    _LineWidth = value;
                    RegenerateStyle();
                }
            }
        }

        public Color FillColor
        {
            get { return _FillColor; }
            set
            {
                if (_FillColor != value)
                {
                    _FillColor = value;
                    RegenerateStyle();
                }
            }
        }

        public Brush    FillBrush   { get { return _AutoGeneratedBrush; } }
        public Pen      LinePen     { get { return _AutoGeneratedPen;   } }



        public void RegenerateStyle ()
        {
            if (! AutoRegenerateStyle) return;

            if (_AutoGeneratedBrush != null) _AutoGeneratedBrush    .Dispose(); 
            if (_AutoGeneratedPen   != null) _AutoGeneratedPen      .Dispose();

            _AutoGeneratedPen       = new Pen (_LineColor, _LineWidth);
            _AutoGeneratedBrush     = new SolidBrush (_FillColor);
        }



        #region IDisposable
        private bool IsDisposed = false; // To detect redundant calls

        protected virtual void Dispose (bool aDisposeManaged)
        {
            if (IsDisposed) return;

            if (aDisposeManaged)
            {
                if (_AutoGeneratedBrush != null) _AutoGeneratedBrush    .Dispose(); 
                if (_AutoGeneratedPen   != null) _AutoGeneratedPen      .Dispose();
            }

            IsDisposed = true;
        }

        public void Dispose ()
        {
            Dispose(true);
        }
        #endregion
    }



    public class SizeFactor
    {
        public float Constant;
        public float Scaled;
    }



}
