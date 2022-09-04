namespace Overlay
{
    partial class FormOverlay
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //this is for checking the game window
        private nint handleWindowGame;


        /// <summary>
        ///  Clean up any resources being used.
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
        /// <summary>
        /// Update the window when the game window has changed size.
        /// </summary>
        private void HookWindowUpdate()
        {
            if (handleWindowGame == ImportWindow.GetForegroundWindow())
            {
                if (ImportWindow.GetWindowRect(handleWindowGame, out Rect sizeWindowGame))
                {
                    this.Size = new Size(sizeWindowGame.Right - sizeWindowGame.Left, sizeWindowGame.Bottom - sizeWindowGame.Top);
                    this.Top = sizeWindowGame.Top;
                    this.Left = sizeWindowGame.Left;
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                }
            }
            else
            {
                this.Size = Size.Empty;
                this.Top = 0;
                this.Left = 0;

                this.WindowState = FormWindowState.Minimized;
            }
        }
        /// <summary>
        /// Makes the window transparent
        /// </summary>
        /// <exception cref="Exception">The method WindowTransparent can not be called prior to the window being initialized.</exception>
        private void WindowTransparent()
        {
            if (this.IsHandleCreated is false)
                throw new Exception("The method WindowTransparent can not be called prior to the window being initialized.");

            var extendedStyle = ImportWindow.GetWindowLongPtr(this.Handle, -20 /*GwlExstyle*/);
            ImportWindow.SetWindowLongPtr(this.Handle, -20 /*GwlExstyle*/, extendedStyle | (nint)0x00000020 /*WsExTransparent*/);
        }
        /// <summary>
        /// Find the game window by name.
        /// </summary>
        /// <param name="name">Name the game window.</param>
        /// <returns>true if ptr is found or false if not.</returns>
        private bool SearchWindowGame(string name)
        {
            var ptr = ImportWindow.FindWindow(name);

            if (ptr == IntPtr.Zero)
            {
                return false;
            }
            else
            {
                handleWindowGame = ptr;
                return true;
            }
        }



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdateGraphics = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UpdateGraphics
            // 
            this.UpdateGraphics.Enabled = true;
            this.UpdateGraphics.Interval = 16;
            this.UpdateGraphics.Tick += new System.EventHandler(this.UpdateGraphics_Tick);
            // 
            // FormOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(419, 249);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOverlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOverlay";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.FormOverlay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UpdateGraphics;
    }
}