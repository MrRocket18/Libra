
namespace ProjectLIB
{
    partial class ChooseWay
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
            this.OnlyDatabutton = new System.Windows.Forms.Button();
            this.OnlyAffiliationbutton = new System.Windows.Forms.Button();
            this.AllChangebutton = new System.Windows.Forms.Button();
            this.Backbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OnlyDatabutton
            // 
            this.OnlyDatabutton.BackColor = System.Drawing.Color.Chartreuse;
            this.OnlyDatabutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OnlyDatabutton.Location = new System.Drawing.Point(502, 112);
            this.OnlyDatabutton.Name = "OnlyDatabutton";
            this.OnlyDatabutton.Size = new System.Drawing.Size(247, 141);
            this.OnlyDatabutton.TabIndex = 0;
            this.OnlyDatabutton.Text = "Изменить только данные книги";
            this.OnlyDatabutton.UseVisualStyleBackColor = false;
            this.OnlyDatabutton.Click += new System.EventHandler(this.OnlyDatabutton_Click);
            // 
            // OnlyAffiliationbutton
            // 
            this.OnlyAffiliationbutton.BackColor = System.Drawing.Color.Chartreuse;
            this.OnlyAffiliationbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OnlyAffiliationbutton.Location = new System.Drawing.Point(91, 112);
            this.OnlyAffiliationbutton.Name = "OnlyAffiliationbutton";
            this.OnlyAffiliationbutton.Size = new System.Drawing.Size(247, 141);
            this.OnlyAffiliationbutton.TabIndex = 1;
            this.OnlyAffiliationbutton.Text = "Изменить только принадлежность книги";
            this.OnlyAffiliationbutton.UseVisualStyleBackColor = false;
            this.OnlyAffiliationbutton.Click += new System.EventHandler(this.OnlyAffiliationbutton_Click);
            // 
            // AllChangebutton
            // 
            this.AllChangebutton.BackColor = System.Drawing.Color.Chartreuse;
            this.AllChangebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllChangebutton.Location = new System.Drawing.Point(893, 112);
            this.AllChangebutton.Name = "AllChangebutton";
            this.AllChangebutton.Size = new System.Drawing.Size(247, 141);
            this.AllChangebutton.TabIndex = 2;
            this.AllChangebutton.Text = "Изменить всё";
            this.AllChangebutton.UseVisualStyleBackColor = false;
            this.AllChangebutton.Click += new System.EventHandler(this.AllChangebutton_Click);
            // 
            // Backbutton
            // 
            this.Backbutton.BackColor = System.Drawing.Color.Red;
            this.Backbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Backbutton.Location = new System.Drawing.Point(552, 341);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(99, 69);
            this.Backbutton.TabIndex = 5;
            this.Backbutton.Text = "Назад";
            this.Backbutton.UseVisualStyleBackColor = false;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(437, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выберите, что хотите изменить";
            // 
            // ChooseWay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.AllChangebutton);
            this.Controls.Add(this.OnlyAffiliationbutton);
            this.Controls.Add(this.OnlyDatabutton);
            this.Name = "ChooseWay";
            this.Text = "ChooseWay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OnlyDatabutton;
        private System.Windows.Forms.Button OnlyAffiliationbutton;
        private System.Windows.Forms.Button AllChangebutton;
        private System.Windows.Forms.Button Backbutton;
        private System.Windows.Forms.Label label1;
    }
}