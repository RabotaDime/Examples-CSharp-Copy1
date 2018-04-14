using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorClock
{
    public partial class ClockForm : Form
    {
        public float AlarmTime = 0;
        public float Hour = 0;
        public float Minute = 0;
        public float Second = 0;
        public float Second2 = 0;

        public ClockVisualStyle ClockStyle = new ClockVisualStyle ();

        public ClockVisualStyle.ClockArrow[] AllArrows = new ClockVisualStyle.ClockArrow [5];
        public Vector2D[] AllVectors = new Vector2D [5]
        {
            new Vector2D { },
            new Vector2D { },
            new Vector2D { },
            new Vector2D { },
            new Vector2D { },
        };



        public ClockForm ()
        {
            InitializeComponent();

            for (int I = 0; I < AllArrows.Length; I++)
                AllArrows[I] = ClockStyle.Arrows.All[I];

            ClockStyle.Numbers.SecondaryMinutesFont = this.MinFontLabel.Font;
            ClockStyle.Numbers.PrimaryMinutesFont   = this.BMinFontLabel.Font;
            ClockStyle.Numbers.HoursFont            = this.HrsFontLabel.Font;
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
            float aBaseX,
            float aBaseY,
            Vector2D aV,
            ClockVisualStyle.ClockArrow aArrowStyle,
            ClockVisualStyle aClockStyle
        )
        {
            aCanvas.DrawLine
            (
                aArrowStyle.Style.LinePen,
                aBaseX - (aV.A * (aClockStyle.Size + aArrowStyle.LineBackwardTip.Constant) * aArrowStyle.LineBackwardTip.Scaled),
                aBaseY - (aV.B * (aClockStyle.Size + aArrowStyle.LineBackwardTip.Constant) * aArrowStyle.LineBackwardTip.Scaled),
                aBaseX + (aV.A * (aClockStyle.Size + aArrowStyle.LineSize.Constant) * aArrowStyle.LineSize.Scaled),
                aBaseY + (aV.B * (aClockStyle.Size + aArrowStyle.LineSize.Constant) * aArrowStyle.LineSize.Scaled)
            );

            aCanvas.FillEllipse
            (
                aArrowStyle.Style.FillBrush,
                aBaseX - aArrowStyle.CircleSize.Constant,
                aBaseY - aArrowStyle.CircleSize.Constant,
                2 * aArrowStyle.CircleSize.Constant,
                2 * aArrowStyle.CircleSize.Constant
            );
        }

        public void RenderClockLabel
        (
            Graphics aCanvas,
            string aCaption,
            float aBaseX,
            float aBaseY,
            Vector2D aV,
            SizeFactor aPos,
            StyleInfo aStyle,
            Font aFont,
            ClockVisualStyle aClockStyle
        )
        {
            float TextRectSize = 100.0f;
            RectangleF TR = new RectangleF
            (
                aBaseX + (aV.A * (aClockStyle.Size + aPos.Constant) * aPos.Scaled) - (TextRectSize / 2),
                aBaseY + (aV.B * (aClockStyle.Size + aPos.Constant) * aPos.Scaled) - (TextRectSize / 2),
                TextRectSize,
                TextRectSize
            );

            StringFormat Fmt = new StringFormat
            {
                Alignment       = StringAlignment.Center,
                LineAlignment   = StringAlignment.Center
            };

            aCanvas.DrawString(aCaption, aFont, aStyle.FillBrush, TR, Fmt);
        }

        public void RenderClockMark
        (
            Graphics aCanvas,
            float aBaseX,
            float aBaseY,
            Vector2D aV,
            SizeFactor aPosSize,
            StyleInfo aStyle,
            ClockVisualStyle aClockStyle
        )
        {
            aCanvas.DrawLine
            (
                aStyle.LinePen,
                aBaseX + (aV.A * aClockStyle.Size * aPosSize.Scaled),
                aBaseY + (aV.B * aClockStyle.Size * aPosSize.Scaled),
                aBaseX + (aV.A * (aClockStyle.Size + aPosSize.Constant) * aPosSize.Scaled),
                aBaseY + (aV.B * (aClockStyle.Size + aPosSize.Constant) * aPosSize.Scaled)
            );
        }

        public void RenderClock
        (
            Graphics aCanvas,
            float aBaseX,
            float aBaseY,
            ClockVisualStyle aStyle
        )
        {
            for (int M = 1, H = 1; M <= 60; M++)
            {
                bool IsHourLineMark = (M % 5 == 0);

                Vector2D LineVector = Vector2D.UnitVectorFromAngleD( GetClockAngleM(M) );

                if (IsHourLineMark)
                {
                    RenderClockMark(aCanvas, aBaseX, aBaseY, LineVector, ClockStyle.LineMarks.HourPosSize,
                        ClockStyle.LineMarks.Hours, ClockStyle);
                }
                else
                {
                    RenderClockMark(aCanvas, aBaseX, aBaseY, LineVector, ClockStyle.LineMarks.MinPosSize,
                        ClockStyle.LineMarks.Minutes, ClockStyle);
                }

                RenderClockLabel(aCanvas, M.ToString(), aBaseX, aBaseY, LineVector,
                    aStyle.Numbers.MinutesPosition,
                    IsHourLineMark ? aStyle.Numbers.PrimaryMinutes : aStyle.Numbers.SecondaryMinutes,
                    IsHourLineMark ? aStyle.Numbers.PrimaryMinutesFont : aStyle.Numbers.SecondaryMinutesFont,
                    aStyle
                );

                if (IsHourLineMark)
                {
                    RenderClockLabel(aCanvas, H.ToString(), aBaseX, aBaseY, LineVector,
                        aStyle.Numbers.HoursPosition,
                        aStyle.Numbers.Hours,
                        aStyle.Numbers.HoursFont,
                        aStyle
                    );

                    H++;
                }
            }

            for (int N = 0; N < AllArrows.Length; N++)
            {
                RenderClockArrow(aCanvas, aBaseX, aBaseY, AllVectors[N], AllArrows[N], ClockStyle);
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
                this.Second2  = N.Second + (N.Millisecond / 1000.0f);

                this.Text = $"{this.Hour,00:F3} : {this.Minute,00:F3} : {this.Second,00:F3}";

                this.Invalidate();
                this.Update();
            }

        }

        private void ClockForm_Paint (object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;

            int CX = this.ClientRectangle.Width / 2;
            int CY = this.ClientRectangle.Height / 2; // HrsTrack.Bottom + (this.ClientRectangle.Height - HrsTrack.Bottom) / 2;


            AllVectors[0] = Vector2D.UnitVectorFromAngleD( GetClockAngleM(this.AlarmTime) );
            AllVectors[1] = Vector2D.UnitVectorFromAngleD( GetClockAngleM(this.Second2) );
            AllVectors[2] = Vector2D.UnitVectorFromAngleD( GetClockAngleH(this.Hour) );
            AllVectors[3] = Vector2D.UnitVectorFromAngleD( GetClockAngleM(this.Minute) );
            AllVectors[4] = Vector2D.UnitVectorFromAngleD( GetClockAngleM(this.Second) );

            Vector2D HourVector = AllVectors[2];
            Vector2D MinVector  = AllVectors[3];

            float AngleBetween_H_M = HourVector.GetAngleBetween(MinVector) * -1.0f;

            float PieSize = 150.0f;

            using
            (
                Brush G1 = new SolidBrush(Color.FromArgb(128, Color.Gold)) /* new LinearGradientBrush
                (
                    new PointF
                    {
                        X = MinVector.A * PieSize,
                        Y = MinVector.B * PieSize,
                    },
                    new PointF
                    {
                        X = HourVector.A * PieSize + 1,
                        Y = HourVector.B * PieSize + 1,
                    },
                    ClockStyle.Arrows.Minute.Style.LineColor,
                    ClockStyle.Arrows.Hour.Style.LineColor
                ) */
            )
            {
                G.FillPie
                (
                    G1,
                    CX - PieSize,
                    CY - PieSize,
                    2 * PieSize,
                    2 * PieSize,
                    GetClockAngleH(this.Hour),
                    MathUtils.RadToDeg(AngleBetween_H_M)
                );
            }

            RenderClock(G, CX, CY, ClockStyle);

            G.DrawArc
            (
                Pens.Orange,
                CX - 150.0f,
                CY - 150.0f,
                2  * 150.0f,
                2  * 150.0f,
                GetClockAngleH(this.Hour),
                MathUtils.RadToDeg(AngleBetween_H_M)
            );
        }
    }
}
