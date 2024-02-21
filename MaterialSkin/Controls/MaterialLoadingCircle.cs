//
// Copyright ©2006, 2007, Martin R. Gagné (martingagne@gmail.com)
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   - Redistributions of source code must retain the above copyright notice, 
//     this list of conditions and the following disclaimer.
//
//   - Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
// OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.
//

using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public partial class MaterialLoadingCircle : Control, IMaterialControl
    {
        [Browsable(false)]
        public int Depth { get; set; }

        [Browsable(false)]
        public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;

        [Browsable(false)]
        public MouseState MouseState { get; set; }

        // Constants =========================================================
        private const double NumberOfDegreesInCircle     = 360;
        private const double NumberOfDegreesInHalfCircle = NumberOfDegreesInCircle / 2;

        private const int LargeInnerCircleRadius       = 36;
        private const int LargeOuterCircleRadius       = 40;
        private const int LargeNumberOfSpoke           = 100;
        private const int LargeSpokeThickness          = 10;

        private const int MediumInnerCircleRadius      = 16;
        private const int MediumOuterCircleRadius      = 20;
        private const int MediumNumberOfSpoke          = 72;
        private const int MediumSpokeThickness         = 4;

        private const int SmallInnerCircleRadius       = 8;
        private const int SmallOuterCircleRadius       = 9;
        private const int SmallNumberOfSpoke           = 36;
        private const int SmallSpokeThickness          = 4;

        private const int DefaultInnerCircleRadius       = SmallInnerCircleRadius;
        private const int DefaultOuterCircleRadius       = SmallOuterCircleRadius;
        private const int DefaultNumberOfSpoke           = SmallNumberOfSpoke;
        private const int DefaultSpokeThickness          = SmallSpokeThickness;
        private readonly Color DefaultColor              = Color.Blue;


        // Enumeration =======================================================
        public enum StylePresets
        {
            Small,
            Medium,
            Large
        }

        // Attributes ========================================================
        private Timer        _Timer;
        private bool         _IsTimerActive;
        private int          _NumberOfSpoke;
        private int          _SpokeThickness;
        private int          _ProgressValue;
        private int          _OuterCircleRadius;
        private int          _InnerCircleRadius;
        private PointF       _CenterPoint;
        private Color        _Color;
        private Color[]      _Colors;
        private double[]     _Angles;
        private StylePresets _StylePreset;
        private double       _rotationsSpeed;




        // Properties ========================================================
        /// <summary>
        /// Gets or sets the lightest color of the circle.
        /// </summary>
        /// <value>The lightest color of the circle.</value>
        [TypeConverter("System.Drawing.ColorConverter"),
         Category("LoadingCircle"),
         Description("Sets the color of spoke.")]
        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;

                GenerateColorsPallet();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer circle radius.
        /// </summary>
        /// <value>The outer circle radius.</value>
        [System.ComponentModel.Description("Gets or sets the radius of outer circle."),
         System.ComponentModel.Category("LoadingCircle")]
        public int OuterCircleRadius
        {
            get
            {
                if (_OuterCircleRadius == 0)
                    _OuterCircleRadius = DefaultOuterCircleRadius;

                return _OuterCircleRadius;
            }
            set
            {
                _OuterCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle radius.
        /// </summary>
        /// <value>The inner circle radius.</value>
        [System.ComponentModel.Description("Gets or sets the radius of inner circle."),
         System.ComponentModel.Category("LoadingCircle")]
        public int InnerCircleRadius
        {
            get
            {
                if (_InnerCircleRadius == 0)
                    _InnerCircleRadius = DefaultInnerCircleRadius;

                return _InnerCircleRadius;
            }
            set
            {
                _InnerCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the number of spoke.
        /// </summary>
        /// <value>The number of spoke.</value>
        [System.ComponentModel.Description("Gets or sets the number of spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public int NumberSpoke
        {
            get
            {
                if (_NumberOfSpoke == 0)
                    _NumberOfSpoke = DefaultNumberOfSpoke;

                return _NumberOfSpoke;
            }
            set
            {
                if (_NumberOfSpoke != value && _NumberOfSpoke > 0)
                {
                    _NumberOfSpoke = value;
                    GenerateColorsPallet();
                    GetSpokesAngles();

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:LoadingCircle"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Description("Gets or sets the number of spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public bool Active
        {
            get
            {
                return _IsTimerActive;
            }
            set
            {
                _IsTimerActive = value;
                ActiveTimer();
            }
        }

        /// <summary>
        /// Gets or sets the spoke thickness.
        /// </summary>
        /// <value>The spoke thickness.</value>
        [System.ComponentModel.Description("Gets or sets the thickness of a spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public int SpokeThickness
        {
            get
            {
                if (_SpokeThickness <= 0)
                    _SpokeThickness = DefaultSpokeThickness;

                return _SpokeThickness;
            }
            set
            {
                _SpokeThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rotation speed.
        /// </summary>
        /// <value>The rotation speed.</value>
        [System.ComponentModel.Description("Gets or sets the rotation speed in rotations per second"),
        System.ComponentModel.Category("LoadingCircle")]
        public double RotationSpeed
        {
            get
            {
                return _rotationsSpeed;
            }
            set
            {
                if (value > 0)
                {
                    _rotationsSpeed = value;
                    CalculateTiming();
                }
            }
        }

        private void CalculateTiming()
        {
            if (_Timer != null) _Timer.Interval = (int)(1000.0 / (double)(_rotationsSpeed * NumberSpoke));
        }

        /// <summary>
        /// Quickly sets the style to one of these presets, or a custom style if desired
        /// </summary>
        /// <value>The style preset.</value>
        [Category("LoadingCircle"),
         Description("Quickly sets the style to one of these presets, or a custom style if desired"),
         DefaultValue(typeof(StylePresets), "Custom")]
        public StylePresets StylePreset
        {
            get { return _StylePreset; }
            set
            {
                _StylePreset = value;

                switch (_StylePreset)
                {
                    case StylePresets.Small:
                        SetCircleAppearance(
                            SmallNumberOfSpoke,
                            SmallSpokeThickness, 
                            SmallInnerCircleRadius,
                            SmallOuterCircleRadius);
                        break;
                    case StylePresets.Medium:
                        SetCircleAppearance(
                            MediumNumberOfSpoke,
                            MediumSpokeThickness, 
                            MediumInnerCircleRadius,
                            MediumOuterCircleRadius);
                        break;
                    case StylePresets.Large:
                        SetCircleAppearance(
                            LargeNumberOfSpoke,
                            LargeSpokeThickness, 
                            LargeInnerCircleRadius,
                            LargeOuterCircleRadius);
                        break;
                }
            }
        }

        // Construtor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoadingCircle"/> class.
        /// </summary>
        public MaterialLoadingCircle()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            _Color = SkinManager.ColorScheme.PrimaryColor;

            GenerateColorsPallet();
            GetSpokesAngles();
            GetControlCenterPoint();


            RotationSpeed = 0.3;
            _Timer = new Timer();
            _Timer.Tick += new EventHandler(aTimer_Tick);
            ActiveTimer();

            this.Resize += new EventHandler(LoadingCircle_Resize);
        }

        // Events ============================================================
        /// <summary>
        /// Handles the Resize event of the LoadingCircle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void LoadingCircle_Resize(object sender, EventArgs e)
        {
            GetControlCenterPoint();
        }

        /// <summary>
        /// Handles the Tick event of the aTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void aTimer_Tick(object sender, EventArgs e)
        {
            _ProgressValue = ++_ProgressValue % _NumberOfSpoke;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_NumberOfSpoke > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                int intPosition = _ProgressValue;
                for (int intCounter = 0; intCounter < _NumberOfSpoke; intCounter++)
                {
                    intPosition = intPosition % _NumberOfSpoke;
                    DrawLine(e.Graphics,
                             GetCoordinate(_CenterPoint, _InnerCircleRadius, _Angles[intPosition]),
                             GetCoordinate(_CenterPoint, _OuterCircleRadius, _Angles[intPosition]),
                             _Colors[intCounter], _SpokeThickness);
                    intPosition++;
                }
            }

            base.OnPaint(e);
        }

        // Overridden Methods ================================================
        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        /// </returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            proposedSize.Width =
                (_OuterCircleRadius + _SpokeThickness) * 2;

            return proposedSize;
        }

        // Methods ===========================================================
        /// <summary>
        /// Darkens a specified color.
        /// </summary>
        /// <param name="_objColor">Color to darken.</param>
        /// <param name="_intPercent">The percent of darken.</param>
        /// <returns>The new color generated.</returns>
        private Color Darken(Color _objColor, int _intPercent)
        {
            int intRed = _objColor.R;
            int intGreen = _objColor.G;
            int intBlue = _objColor.B;
            return Color.FromArgb(_intPercent, Math.Min(intRed, byte.MaxValue), Math.Min(intGreen, byte.MaxValue), Math.Min(intBlue, byte.MaxValue));
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        private void GenerateColorsPallet()
        {
            _Colors = GenerateColorsPallet(_Color, Active, _NumberOfSpoke);
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        /// <param name="_objColor">Color of the lightest spoke.</param>
        /// <param name="_blnShadeColor">if set to <c>true</c> the color will be shaded on X spoke.</param>
        /// <returns>An array of color used to draw the circle.</returns>
        private Color[] GenerateColorsPallet(Color _objColor, bool _blnShadeColor, int _intNbSpoke)
        {
            Color[] objColors = new Color[NumberSpoke];

            // Value is used to simulate a gradient feel... For each spoke, the 
            // color will be darken by value in intIncrement.
            byte bytIncrement = (byte)(byte.MaxValue / NumberSpoke);

            //Reset variable in case of multiple passes
            byte PERCENTAGE_OF_DARKEN = 0;

            for (int intCursor = 0; intCursor < NumberSpoke; intCursor++)
            {
                if (_blnShadeColor)
                {
                    if (intCursor == 0 || intCursor < NumberSpoke - _intNbSpoke)
                        objColors[intCursor] = _objColor;
                    else
                    {
                        // Increment alpha channel color
                        PERCENTAGE_OF_DARKEN += bytIncrement;

                        // Ensure that we don't exceed the maximum alpha
                        // channel value (255)
                        if (PERCENTAGE_OF_DARKEN > byte.MaxValue)
                            PERCENTAGE_OF_DARKEN = byte.MaxValue;

                        // Determine the spoke forecolor
                        objColors[intCursor] = Darken(_objColor, PERCENTAGE_OF_DARKEN);
                    }
                }
                else
                    objColors[intCursor] = _objColor;
            }

            return objColors;
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        private void GetControlCenterPoint()
        {
            _CenterPoint = GetControlCenterPoint(this);
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        /// <returns>PointF object</returns>
        private PointF GetControlCenterPoint(Control _objControl)
        {
            return new PointF(_objControl.Width / 2, _objControl.Height / 2 - 1);
        }

        /// <summary>
        /// Draws the line with GDI+.
        /// </summary>
        /// <param name="_objGraphics">The Graphics object.</param>
        /// <param name="_objPointOne">The point one.</param>
        /// <param name="_objPointTwo">The point two.</param>
        /// <param name="_objColor">Color of the spoke.</param>
        /// <param name="_intLineThickness">The thickness of spoke.</param>
        private void DrawLine(Graphics _objGraphics, PointF _objPointOne, PointF _objPointTwo,
                              Color _objColor, int _intLineThickness)
        {
            using(Pen objPen = new Pen(new SolidBrush(_objColor), _intLineThickness))
            {
                objPen.StartCap = LineCap.Round;
                objPen.EndCap = LineCap.Round;
                _objGraphics.DrawLine(objPen, _objPointOne, _objPointTwo);
            }
        }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        /// <param name="_objCircleCenter">The Circle center.</param>
        /// <param name="_intRadius">The radius.</param>
        /// <param name="_dblAngle">The angle.</param>
        /// <returns></returns>
        private PointF GetCoordinate(PointF _objCircleCenter, int _intRadius, double _dblAngle)
        {
            double dblAngle = Math.PI * _dblAngle / NumberOfDegreesInHalfCircle;

            return new PointF(_objCircleCenter.X + _intRadius * (float)Math.Cos(dblAngle),
                              _objCircleCenter.Y + _intRadius * (float)Math.Sin(dblAngle));
        }

        /// <summary>
        /// Gets the spokes angles.
        /// </summary>
        private void GetSpokesAngles()
        {
            _Angles = GetSpokesAngles(NumberSpoke);
        }

        /// <summary>
        /// Gets the spoke angles.
        /// </summary>
        /// <param name="_shtNumberSpoke">The number spoke.</param>
        /// <returns>An array of angle.</returns>
        private double[] GetSpokesAngles(int _intNumberSpoke)
        {
            double[] Angles = new double[_intNumberSpoke];
            double dblAngle = (double) NumberOfDegreesInCircle / _intNumberSpoke;

            for (int shtCounter = 0; shtCounter < _intNumberSpoke; shtCounter++)
                Angles[shtCounter] = (shtCounter == 0 ? dblAngle : Angles[shtCounter - 1] + dblAngle);

            return Angles;
        }

        /// <summary>
        /// Actives the timer.
        /// </summary>
        private void ActiveTimer()
        {
            if (_IsTimerActive)
                _Timer.Start();
            else
            {
                _Timer.Stop();
                _ProgressValue = 0;
            }

            GenerateColorsPallet();
            Invalidate();
        }

        /// <summary>
        /// Sets the circle appearance.
        /// </summary>
        /// <param name="numberSpoke">The number spoke.</param>
        /// <param name="spokeThickness">The spoke thickness.</param>
        /// <param name="innerCircleRadius">The inner circle radius.</param>
        /// <param name="outerCircleRadius">The outer circle radius.</param>
        public void SetCircleAppearance(int numberSpoke, int spokeThickness,
            int innerCircleRadius, int outerCircleRadius)
        {
            NumberSpoke = numberSpoke;
            SpokeThickness = spokeThickness;
            InnerCircleRadius = innerCircleRadius;
            OuterCircleRadius = outerCircleRadius;

            CalculateTiming();
            Invalidate();
        } 
    }
}