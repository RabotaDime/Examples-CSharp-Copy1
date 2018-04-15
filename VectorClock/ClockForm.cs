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

        public NumericUpDown[] ClockInputs = new NumericUpDown [4];



        public ClockForm ()
        {
            InitializeComponent();

            for (int I = 0; I < AllArrows.Length; I++)
                AllArrows[I] = ClockStyle.Arrows.All[I];

            ClockStyle.Numbers.SecondaryMinutesFont = this.MinFontLabel.Font;
            ClockStyle.Numbers.PrimaryMinutesFont   = this.BMinFontLabel.Font;
            ClockStyle.Numbers.HoursFont            = this.HrsFontLabel.Font;

            ClockInputs[0] = this.numericUpDown1;
            ClockInputs[1] = this.numericUpDown2;
            ClockInputs[2] = this.numericUpDown3;
            //ClockInputs[3] = this.numericUpDown4;
            //ClockInputs[4] = this.numericUpDown5;
        }



        public const float HoursCycleBase = 12.0f;
        public const float MinSecCycleBase = 60.0f;

        public static Angle GetClockAngleH (float HoursValue)
        {
            //  Вычитаем превышение часов более 12
            float Hours = HoursValue - ((float) Math.Round(HoursValue / HoursCycleBase) * HoursCycleBase);
            float Result = (360.0f / HoursCycleBase) * (Hours);
            return new Angle (Result - 90.0f, AngleType.Degrees);
        }

        public static Angle GetClockAngleM (float MinSecValue)
        {
            //  Вычитаем превышение часов более 12
            float Mins = MinSecValue - ((float) Math.Round(MinSecValue / MinSecCycleBase) * MinSecCycleBase);
            float Result = (360.0f / MinSecCycleBase) * (Mins);
            return new Angle (Result - 90.0f, AngleType.Degrees);
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

                Vector2D LineVector = Vector2D.UnitVectorFromAngle( GetClockAngleM(M) );

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

                this.UpdateClockUserInputs();    

                this.Text = $"{this.Hour,00:F3} : {this.Minute,00:F3} : {this.Second,00:F3}";

                this.Invalidate();
                this.Update();
            }

        }

        private void UpdateClockUserInputs ()
        {
            var InputValues = new float [5]
            {
                this.Hour,
                this.Minute,
                this.Second,
                0,
                0,
            };

            int I = 0;
            foreach (NumericUpDown InputCtrl in ClockInputs) if (InputCtrl != null)
            {
                InputCtrl.ValueChanged -= NumericInput_ValueChanged;

                InputCtrl.Value = (decimal) InputValues[I++];

                InputCtrl.ValueChanged += NumericInput_ValueChanged;
            }
        }

        private void ClockForm_Paint (object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;

            int CX = this.ClientRectangle.Width / 2;
            int CY = this.ClientRectangle.Height / 2; // HrsTrack.Bottom + (this.ClientRectangle.Height - HrsTrack.Bottom) / 2;


            AllVectors[0] = Vector2D.UnitVectorFromAngle( GetClockAngleM(this.AlarmTime) );
            AllVectors[1] = Vector2D.UnitVectorFromAngle( GetClockAngleM(this.Second2) );
            AllVectors[2] = Vector2D.UnitVectorFromAngle( GetClockAngleH(this.Hour) );
            AllVectors[3] = Vector2D.UnitVectorFromAngle( GetClockAngleM(this.Minute) );
            AllVectors[4] = Vector2D.UnitVectorFromAngle( GetClockAngleM(this.Second) );

            Vector2D HourVector = AllVectors[2];
            Vector2D MinVector  = AllVectors[3];
            Vector2D SecVector  = AllVectors[4];

            Angle AngleBetween_H_M = new Angle(HourVector.GetAngleBetween2(MinVector).Radians * -1.0f, AngleType.Radians);
            Angle AngleBetween_M_S = new Angle(MinVector.GetAngleBetween2(SecVector).Radians * -1.0f, AngleType.Radians);

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
                    GetClockAngleM(this.Minute).Degrees,
                    AngleBetween_M_S.Degrees
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
                GetClockAngleM(this.Minute).Degrees,
                AngleBetween_M_S.Degrees
            );

            label1.Text = SecVector.Angle.Degrees.ToString();
        }



        private void NumericInput_ValueChanged (object aSender, EventArgs e)
        {
            ShowCurrentTimeCheckBox.Checked = false;

            this.Hour       = (float) numericUpDown1.Value;
            this.Minute     = (float) numericUpDown2.Value;
            this.Second     = (float) numericUpDown3.Value;
            this.Second2    = this.Second;

            this.Invalidate();
            this.Update();
        }

        private void LinkLabel1_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCurrentTimeCheckBox.Checked = false;

            this.Hour       = 0;
            this.Minute     = 0;
            this.Second     = 0;
            this.Second2    = this.Second;

            UpdateClockUserInputs();

            this.Invalidate();
            this.Update();
        }
    }
}
