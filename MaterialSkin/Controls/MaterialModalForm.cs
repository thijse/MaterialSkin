using MaterialSkin.Animations;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    /// <summary>
    /// MaterialModalForm is a Form that is meant to be used a Modal Form. Call with ShowMaterialDialog() instead of ShowDialog()
    /// </summary>
    public class MaterialModalForm : MaterialForm
    {

        private AnimationManager _AnimationManager = new AnimationManager();
        private bool CloseAnimation                = false;
        private Form _formOverlay                  = null;

        /// <summary>
        /// Constructor Setting up the animation manager
        /// </summary>
        public MaterialModalForm()
        {
            if (DesignMode) return;
            _AnimationManager.AnimationType        = AnimationType.EaseOut;
            _AnimationManager.Increment            = 0.03;
            _AnimationManager.OnAnimationProgress += _AnimationManager_OnAnimationProgress;
        }

        public DialogResult ShowMaterialDialog(Form ParentForm) 
        {
            _formOverlay = new Form
            {
                BackColor       = Color.Black,
                Opacity         = 0.5,
                MinimizeBox     = false,
                MaximizeBox     = false,
                Text            = "",
                ShowIcon        = false,
                ControlBox      = false,
                FormBorderStyle = FormBorderStyle.None,
                Size            = new Size(ParentForm.Width, ParentForm.Height),
                ShowInTaskbar   = false,
                Owner           = ParentForm,
                Visible         = true,
                Location        = new Point(ParentForm.Location.X, ParentForm.Location.Y),
                Anchor          = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            return ShowDialog(ParentForm);
        }


        /// <summary>
        /// Sets up the Starting Location and starts the Animation
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            Location = new Point(Convert.ToInt32(Owner.Location.X + (Owner.Width / 2) - (Width / 2)), Convert.ToInt32(Owner.Location.Y + (Owner.Height / 2) - (Height / 2)));
            _AnimationManager.StartNewAnimation(AnimationDirection.In);
            
        }

        /// <summary>
        /// Animates the Form slides
        /// </summary>
        void _AnimationManager_OnAnimationProgress(object sender)
        {
            if (CloseAnimation)
            {
                Opacity = _AnimationManager.GetProgress();
            }
        }

        /// <summary>
        /// Overrides the Closing Event to Animate the Slide Out
        /// </summary>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (DesignMode) return;
            if (_formOverlay != null)
            {
                _formOverlay.Visible = false;
                _formOverlay.Close();
                _formOverlay.Dispose();
                _formOverlay = null;
            }

            DialogResult res = this.DialogResult;

            base.OnClosing(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (DesignMode) return false;
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
