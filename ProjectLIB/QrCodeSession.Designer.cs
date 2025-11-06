namespace ProjectLIB
{
    partial class QrCodeSession
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
            this.InfoBookTextBox = new System.Windows.Forms.TextBox();
            this.InfoBookLabel = new System.Windows.Forms.Label();
            this.GiveOutButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.DecommissButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoBookTextBox
            // 
            this.InfoBookTextBox.BackColor = System.Drawing.Color.White;
            this.InfoBookTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoBookTextBox.Location = new System.Drawing.Point(21, 99);
            this.InfoBookTextBox.Multiline = true;
            this.InfoBookTextBox.Name = "InfoBookTextBox";
            this.InfoBookTextBox.Size = new System.Drawing.Size(408, 225);
            this.InfoBookTextBox.TabIndex = 0;
            // 
            // InfoBookLabel
            // 
            this.InfoBookLabel.AutoSize = true;
            this.InfoBookLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoBookLabel.Location = new System.Drawing.Point(118, 56);
            this.InfoBookLabel.Name = "InfoBookLabel";
            this.InfoBookLabel.Size = new System.Drawing.Size(197, 24);
            this.InfoBookLabel.TabIndex = 1;
            this.InfoBookLabel.Text = "Информация о книге";
            // 
            // GiveOutButton
            // 
            this.GiveOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GiveOutButton.Location = new System.Drawing.Point(21, 358);
            this.GiveOutButton.Name = "GiveOutButton";
            this.GiveOutButton.Size = new System.Drawing.Size(113, 42);
            this.GiveOutButton.TabIndex = 2;
            this.GiveOutButton.Text = "Выдать";
            this.GiveOutButton.UseVisualStyleBackColor = true;
            this.GiveOutButton.Click += new System.EventHandler(this.GiveOutButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReturnButton.Location = new System.Drawing.Point(165, 358);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(113, 42);
            this.ReturnButton.TabIndex = 3;
            this.ReturnButton.Text = "Вернуть";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // DecommissButton
            // 
            this.DecommissButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecommissButton.Location = new System.Drawing.Point(316, 358);
            this.DecommissButton.Name = "DecommissButton";
            this.DecommissButton.Size = new System.Drawing.Size(113, 42);
            this.DecommissButton.TabIndex = 4;
            this.DecommissButton.Text = "Списать";
            this.DecommissButton.UseVisualStyleBackColor = true;
            this.DecommissButton.Click += new System.EventHandler(this.DecommissButton_Click);
            // 
            // QrCodeSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 450);
            this.Controls.Add(this.DecommissButton);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.GiveOutButton);
            this.Controls.Add(this.InfoBookLabel);
            this.Controls.Add(this.InfoBookTextBox);
            this.Name = "QrCodeSession";
            this.Text = "QrCodeSession";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QrCodeSession_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InfoBookTextBox;
        private System.Windows.Forms.Label InfoBookLabel;
        private System.Windows.Forms.Button GiveOutButton;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button DecommissButton;
    }
}