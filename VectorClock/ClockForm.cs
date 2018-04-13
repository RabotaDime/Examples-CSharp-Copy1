using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorClock
{
    public partial class ClockForm : Form
    {
        public float Hour = 0;
        public float Minute = 0;
        public float Second = 0;



        public ClockForm ()
        {
            InitializeComponent();
        }



        public const float HoursCycleBase = 12.0f;
        public const float MinSecCycleBase = 60.0f;

        public static float GetClockAngleH (float HoursValue)
        {
            //  Вычитаем превышение часов более 12
            float Hours = HoursValue - ((float) Math.Round(HoursValue / HoursCycleBase) * HoursCycleBase);
            float Result = (360.0f / HoursCycleBase) * (Hours);
            return (Result - 90.0f);
        }

        public static float GetClockAngleM (float MinSecValue)
        {
            //  Вычитаем превышение часов более 12
            float Mins = MinSecValue - ((float) Math.Round(MinSecValue / MinSecCycleBase) * MinSecCycleBase);
            float Result = (360.0f / MinSecCycleBase) * (Mins);
            return (Result - 90.0f);
        }



        public void RenderClockArrow
        (
            Graphics aCanvas,
            Vector2D aV,
            float aBaseX,
            float aBaseY,
            float aSizeValue,
            float aSizeFactor,
            float aBackwardTipSize,
            Color aColor,
            float aWidth
        )
        {
            using (var ArrowPen = new Pen(aColor, aWidth))
            {

            }
        }

        public void RenderClockText
        (
            Graphics aCanvas,
            Vector2D aV,
            string aCaption,
            float aBaseX,
            float aBaseY,
            float aPosValue,
            float aPosFactor,

            Font aTextFont,
            Brush aTextFill
        )
        {
            float TextRectSize = 100.0f;
            RectangleF TR = new RectangleF
            (
                aBaseX + (aV.A * aPosValue * aPosFactor) - (TextRectSize / 2),
                aBaseY + (aV.B * aPosValue * aPosFactor) - (TextRectSize / 2),
                TextRectSize,
                TextRectSize
            );

            StringFormat Fmt = new StringFormat
            {
                Alignment       = StringAlignment.Center,
                LineAlignment   = StringAlignment.Center
            };

            aCanvas.DrawString(aCaption, aTextFont, aTextFill, TR, Fmt);
        }

        public void RenderClockFace
        (
            Graphics aCanvas,
            Vector2D aV,
            float aBaseX,
            float aBaseY,
            float aClockSize,
            Color aHrsLinesColor,
            float aHrsLinesWidth,
            float aHrsLinesSize,
            Color aMinLinesColor,
            float aMinLinesWidth,
            float aMinLinesSize
        )
        {
            //  Круг минутных меток-линий и цифр
            using (var LinesPen = new Pen(aMinLinesColor, aMinLinesWidth))
            {
                for (int M = 0; M < 60; M++)
                {
                    bool IsPrimaryLine = (M % 5 == 0);

                    Vector2D V = Vector2D.UnitVectorFromAngleD( GetClockAngleM(M) );

                    //  Минутная линия-метка
                    aCanvas.DrawLine
                    (
                        LinesPen,
                        aBaseX + (V.A * (aClockSize - aMinLinesSize)),
                        aBaseY + (V.B * (aClockSize - aMinLinesSize)),
                        aBaseX + (V.A * aClockSize),
                        aBaseY + (V.B * aClockSize)
                    );

                    //  Цифры минут
                    RenderClockText(aCanvas, V, M.ToString(), aBaseX, aBaseY, aClockSize, 1.10f,
                        IsPrimaryLine ? BMinFontLabel.Font : MinFontLabel.Font,
                        IsPrimaryLine ? Brushes.DimGray : Brushes.LightGray
                    );
                }
            }

            //  Часы
            using (var LinesPen = new Pen(aMinLinesColor, aMinLinesWidth))
            {
            }
        }



        private void TimerObject_Tick (object sender, EventArgs e)
        {
            if (ShowCurrentTimeCheckBox.Checked)
            {
                DateTime N = DateTime.Now;

                this.Hour     = N.Hour + (N.Minute / 60.0f);
                this.Minute   = N.Minute + (N.Second / 60.0f);
                this.Second   = N.Second;

                this.Invalidate();
                this.Update();
            }
        }
    }
}
