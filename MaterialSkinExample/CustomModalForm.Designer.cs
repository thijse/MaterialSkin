namespace MaterialSkinExample
{
    partial class CustomModalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            buttonCancel = new MaterialSkin.Controls.MaterialButton();
            buttonOK = new MaterialSkin.Controls.MaterialButton();
            materialTextBox5 = new MaterialSkin.Controls.MaterialTextBox2();
            materialTextBox4 = new MaterialSkin.Controls.MaterialTextBox2();
            materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox2();
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox2();
            materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialTextBox2();
            SuspendLayout();
            // 
            // materialLabel8
            // 
            materialLabel8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialLabel8.ForeColor = System.Drawing.Color.FromArgb(180, 0, 0, 0);
            materialLabel8.Location = new System.Drawing.Point(7, 80);
            materialLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new System.Drawing.Size(587, 60);
            materialLabel8.TabIndex = 61;
            materialLabel8.Text = "This is a custom modal form. It is very similar to a normal form, but will open aligned to the main form, darkening the main form";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonCancel.Depth = 0;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.HighEmphasis = true;
            buttonCancel.Icon = null;
            buttonCancel.Location = new System.Drawing.Point(445, 405);
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            buttonCancel.Name = "buttonCancel";
            buttonCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            buttonCancel.Size = new System.Drawing.Size(77, 36);
            buttonCancel.TabIndex = 64;
            buttonCancel.Text = "Cancel";
            buttonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonCancel.UseAccentColor = false;
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            buttonOK.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonOK.Depth = 0;
            buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOK.HighEmphasis = true;
            buttonOK.Icon = null;
            buttonOK.Location = new System.Drawing.Point(530, 405);
            buttonOK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            buttonOK.MouseState = MaterialSkin.MouseState.HOVER;
            buttonOK.Name = "buttonOK";
            buttonOK.NoAccentTextColor = System.Drawing.Color.Empty;
            buttonOK.Size = new System.Drawing.Size(64, 36);
            buttonOK.TabIndex = 63;
            buttonOK.Text = "Ok";
            buttonOK.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonOK.UseAccentColor = false;
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // materialTextBox5
            // 
            materialTextBox5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            materialTextBox5.AnimateReadOnly = false;
            materialTextBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            materialTextBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            materialTextBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            materialTextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            materialTextBox5.Cursor = System.Windows.Forms.Cursors.IBeam;
            materialTextBox5.Depth = 0;
            materialTextBox5.Enabled = false;
            materialTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            materialTextBox5.HideSelection = true;
            materialTextBox5.Hint = "This is Disabled";
            materialTextBox5.LeadingIcon = null;
            materialTextBox5.Location = new System.Drawing.Point(237, 207);
            materialTextBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            materialTextBox5.MaxLength = 50;
            materialTextBox5.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox5.Name = "materialTextBox5";
            materialTextBox5.PasswordChar = '\0';
            materialTextBox5.PrefixSuffixText = null;
            materialTextBox5.ReadOnly = false;
            materialTextBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            materialTextBox5.SelectedText = "";
            materialTextBox5.SelectionLength = 0;
            materialTextBox5.SelectionStart = 0;
            materialTextBox5.ShortcutsEnabled = true;
            materialTextBox5.Size = new System.Drawing.Size(333, 48);
            materialTextBox5.TabIndex = 75;
            materialTextBox5.TabStop = false;
            materialTextBox5.Text = "But with value";
            materialTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            materialTextBox5.TrailingIcon = null;
            materialTextBox5.UseSystemPasswordChar = false;
            // 
            // materialTextBox4
            // 
            materialTextBox4.AnimateReadOnly = false;
            materialTextBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            materialTextBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            materialTextBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            materialTextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            materialTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            materialTextBox4.Depth = 0;
            materialTextBox4.Enabled = false;
            materialTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialTextBox4.HideSelection = true;
            materialTextBox4.Hint = "This is Disabled";
            materialTextBox4.LeadingIcon = null;
            materialTextBox4.Location = new System.Drawing.Point(17, 207);
            materialTextBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            materialTextBox4.MaxLength = 50;
            materialTextBox4.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox4.Name = "materialTextBox4";
            materialTextBox4.PasswordChar = '\0';
            materialTextBox4.PrefixSuffixText = null;
            materialTextBox4.ReadOnly = false;
            materialTextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            materialTextBox4.SelectedText = "";
            materialTextBox4.SelectionLength = 0;
            materialTextBox4.SelectionStart = 0;
            materialTextBox4.ShortcutsEnabled = true;
            materialTextBox4.Size = new System.Drawing.Size(213, 48);
            materialTextBox4.TabIndex = 74;
            materialTextBox4.TabStop = false;
            materialTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            materialTextBox4.TrailingIcon = null;
            materialTextBox4.UseSystemPasswordChar = false;
            // 
            // materialTextBox2
            // 
            materialTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            materialTextBox2.AnimateReadOnly = false;
            materialTextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            materialTextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            materialTextBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            materialTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            materialTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            materialTextBox2.Depth = 0;
            materialTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialTextBox2.HideSelection = true;
            materialTextBox2.Hint = "Password";
            materialTextBox2.LeadingIcon = Properties.Resources.baseline_fingerprint_black_24dp;
            materialTextBox2.Location = new System.Drawing.Point(17, 336);
            materialTextBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            materialTextBox2.MaxLength = 50;
            materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.PasswordChar = '●';
            materialTextBox2.PrefixSuffixText = null;
            materialTextBox2.ReadOnly = false;
            materialTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            materialTextBox2.SelectedText = "";
            materialTextBox2.SelectionLength = 0;
            materialTextBox2.SelectionStart = 0;
            materialTextBox2.ShortcutsEnabled = true;
            materialTextBox2.Size = new System.Drawing.Size(553, 48);
            materialTextBox2.TabIndex = 72;
            materialTextBox2.TabStop = false;
            materialTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            materialTextBox2.TrailingIcon = null;
            materialTextBox2.UseSystemPasswordChar = true;
            // 
            // materialTextBox1
            // 
            materialTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            materialTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            materialTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            materialTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            materialTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialTextBox1.HideSelection = true;
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new System.Drawing.Point(17, 143);
            materialTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.PasswordChar = '\0';
            materialTextBox1.PrefixSuffixText = null;
            materialTextBox1.ReadOnly = false;
            materialTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            materialTextBox1.SelectedText = "";
            materialTextBox1.SelectionLength = 0;
            materialTextBox1.SelectionStart = 0;
            materialTextBox1.ShortcutsEnabled = true;
            materialTextBox1.Size = new System.Drawing.Size(553, 48);
            materialTextBox1.TabIndex = 70;
            materialTextBox1.TabStop = false;
            materialTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            materialTextBox1.TrailingIcon = Properties.Resources.baseline_favorite_border_black_24dp;
            materialTextBox1.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField2
            // 
            materialSingleLineTextField2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            materialSingleLineTextField2.AnimateReadOnly = false;
            materialSingleLineTextField2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            materialSingleLineTextField2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            materialSingleLineTextField2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            materialSingleLineTextField2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            materialSingleLineTextField2.Cursor = System.Windows.Forms.Cursors.IBeam;
            materialSingleLineTextField2.Depth = 0;
            materialSingleLineTextField2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            materialSingleLineTextField2.HideSelection = true;
            materialSingleLineTextField2.Hint = "Type here";
            materialSingleLineTextField2.LeadingIcon = null;
            materialSingleLineTextField2.Location = new System.Drawing.Point(17, 272);
            materialSingleLineTextField2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            materialSingleLineTextField2.MaxLength = 50;
            materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.OUT;
            materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            materialSingleLineTextField2.PasswordChar = '\0';
            materialSingleLineTextField2.PrefixSuffixText = null;
            materialSingleLineTextField2.ReadOnly = false;
            materialSingleLineTextField2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            materialSingleLineTextField2.SelectedText = "";
            materialSingleLineTextField2.SelectionLength = 0;
            materialSingleLineTextField2.SelectionStart = 0;
            materialSingleLineTextField2.ShortcutsEnabled = true;
            materialSingleLineTextField2.Size = new System.Drawing.Size(553, 48);
            materialSingleLineTextField2.TabIndex = 71;
            materialSingleLineTextField2.TabStop = false;
            materialSingleLineTextField2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            materialSingleLineTextField2.TrailingIcon = null;
            materialSingleLineTextField2.UseSystemPasswordChar = false;
            // 
            // CustomModalForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(601, 450);
            Controls.Add(materialTextBox5);
            Controls.Add(materialTextBox4);
            Controls.Add(materialTextBox2);
            Controls.Add(materialTextBox1);
            Controls.Add(materialSingleLineTextField2);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(materialLabel8);
            Name = "CustomModalForm";
            Text = "Custom modal form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
        private MaterialSkin.Controls.MaterialButton buttonOK;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox5;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox4;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox2;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox2 materialSingleLineTextField2;
    }
}