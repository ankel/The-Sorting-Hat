namespace TheSortingHat {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.inputTxtb = new System.Windows.Forms.TextBox();
            this.randomizeBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTxtb
            // 
            this.inputTxtb.Location = new System.Drawing.Point(17, 18);
            this.inputTxtb.Multiline = true;
            this.inputTxtb.Name = "inputTxtb";
            this.inputTxtb.Size = new System.Drawing.Size(464, 54);
            this.inputTxtb.TabIndex = 0;
            this.inputTxtb.Validating += new System.ComponentModel.CancelEventHandler(this.inputTxtb_Validating);
            // 
            // randomizeBttn
            // 
            this.randomizeBttn.Location = new System.Drawing.Point(502, 18);
            this.randomizeBttn.Name = "randomizeBttn";
            this.randomizeBttn.Size = new System.Drawing.Size(131, 54);
            this.randomizeBttn.TabIndex = 1;
            this.randomizeBttn.Text = "Randomize!";
            this.randomizeBttn.UseVisualStyleBackColor = true;
            this.randomizeBttn.Click += new System.EventHandler(this.randomizeBttn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 338);
            this.Controls.Add(this.randomizeBttn);
            this.Controls.Add(this.inputTxtb);
            this.Name = "MainForm";
            this.Text = "Sort it";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTxtb;
        private System.Windows.Forms.Button randomizeBttn;
    }
}

