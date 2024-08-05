namespace pomodoro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblTimer = new Label();
            btnPlayPause = new InventorySystem.Controls.CustomButton();
            btnReset = new InventorySystem.Controls.CustomButton();
            lblSession = new Label();
            progressBar = new ProgressBar();
            comboBoxSessionType = new WinFormsApp1.Controls.CustomComboBox();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.Font = new Font("Verdana", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.ForeColor = Color.OldLace;
            lblTimer.Location = new Point(47, 96);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(360, 123);
            lblTimer.TabIndex = 0;
            lblTimer.Text = "00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPlayPause
            // 
            btnPlayPause.BackColor = Color.Wheat;
            btnPlayPause.BackgroundColor = Color.Wheat;
            btnPlayPause.BorderColor = Color.Black;
            btnPlayPause.BorderRadius = 20;
            btnPlayPause.BorderSize = 0;
            btnPlayPause.FlatAppearance.BorderSize = 0;
            btnPlayPause.FlatStyle = FlatStyle.Flat;
            btnPlayPause.Font = new Font("Verdana", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlayPause.ForeColor = Color.Black;
            btnPlayPause.Location = new Point(111, 280);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(217, 44);
            btnPlayPause.TabIndex = 5;
            btnPlayPause.Text = "Start";
            btnPlayPause.TextColor = Color.Black;
            btnPlayPause.UseVisualStyleBackColor = false;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(64, 64, 64);
            btnReset.BackgroundColor = Color.FromArgb(64, 64, 64);
            btnReset.BorderColor = Color.Black;
            btnReset.BorderRadius = 20;
            btnReset.BorderSize = 0;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Verdana", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.OldLace;
            btnReset.Location = new Point(136, 377);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(164, 42);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.TextColor = Color.OldLace;
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // lblSession
            // 
            lblSession.BackColor = Color.Transparent;
            lblSession.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSession.ForeColor = Color.OldLace;
            lblSession.Location = new Point(79, 71);
            lblSession.Name = "lblSession";
            lblSession.Size = new Size(288, 37);
            lblSession.TabIndex = 7;
            lblSession.Text = "0 of 0 sessions";
            lblSession.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(79, 222);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(288, 14);
            progressBar.TabIndex = 8;
            // 
            // comboBoxSessionType
            // 
            comboBoxSessionType.BackColor = Color.OldLace;
            comboBoxSessionType.BorderColor = Color.Olive;
            comboBoxSessionType.BorderSize = 1;
            comboBoxSessionType.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxSessionType.Font = new Font("Segoe UI", 10F);
            comboBoxSessionType.ForeColor = Color.DimGray;
            comboBoxSessionType.IconColor = Color.Olive;
            comboBoxSessionType.ListBackColor = Color.FromArgb(230, 228, 245);
            comboBoxSessionType.ListTextColor = Color.DimGray;
            comboBoxSessionType.Location = new Point(125, 28);
            comboBoxSessionType.MinimumSize = new Size(200, 30);
            comboBoxSessionType.Name = "comboBoxSessionType";
            comboBoxSessionType.Padding = new Padding(1);
            comboBoxSessionType.Size = new Size(200, 30);
            comboBoxSessionType.TabIndex = 11;
            comboBoxSessionType.Texts = "";
            comboBoxSessionType.OnSelectedIndexChanged += comboBoxSessionType_OnSelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(450, 450);
            Controls.Add(comboBoxSessionType);
            Controls.Add(progressBar);
            Controls.Add(lblSession);
            Controls.Add(btnReset);
            Controls.Add(btnPlayPause);
            Controls.Add(lblTimer);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pomodoro";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTimer;
        private InventorySystem.Controls.CustomButton btnPlayPause;
        private InventorySystem.Controls.CustomButton btnReset;
        private Label lblSession;
        private ProgressBar progressBar;
        private WinFormsApp1.Controls.CustomComboBox comboBoxSessionType;
    }
}
