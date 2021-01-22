namespace Sokoban
{
    partial class FormMenuStart
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
            this.comboBoxSelect = new System.Windows.Forms.ComboBox();
            this.radioButtonFile = new System.Windows.Forms.RadioButton();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.radioButtonSQL = new System.Windows.Forms.RadioButton();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSelect
            // 
            this.comboBoxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelect.FormattingEnabled = true;
            this.comboBoxSelect.Location = new System.Drawing.Point(285, 201);
            this.comboBoxSelect.Name = "comboBoxSelect";
            this.comboBoxSelect.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelect.TabIndex = 0;
            // 
            // radioButtonFile
            // 
            this.radioButtonFile.AutoSize = true;
            this.radioButtonFile.Location = new System.Drawing.Point(174, 247);
            this.radioButtonFile.Name = "radioButtonFile";
            this.radioButtonFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButtonFile.Size = new System.Drawing.Size(96, 17);
            this.radioButtonFile.TabIndex = 2;
            this.radioButtonFile.TabStop = true;
            this.radioButtonFile.Text = "Wybierz z pliku";
            this.radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.Crimson;
            this.buttonStartGame.Location = new System.Drawing.Point(98, 347);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(403, 72);
            this.buttonStartGame.TabIndex = 3;
            this.buttonStartGame.Text = "Start";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // radioButtonSQL
            // 
            this.radioButtonSQL.AutoSize = true;
            this.radioButtonSQL.Checked = true;
            this.radioButtonSQL.Location = new System.Drawing.Point(184, 205);
            this.radioButtonSQL.Name = "radioButtonSQL";
            this.radioButtonSQL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButtonSQL.Size = new System.Drawing.Size(87, 17);
            this.radioButtonSQL.TabIndex = 4;
            this.radioButtonSQL.TabStop = true;
            this.radioButtonSQL.Text = "Wybierz SQL";
            this.radioButtonSQL.UseVisualStyleBackColor = true;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.buttonSelectFile.Location = new System.Drawing.Point(285, 244);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(120, 23);
            this.buttonSelectFile.TabIndex = 5;
            this.buttonSelectFile.Text = "Wybierz plik";
            this.buttonSelectFile.UseVisualStyleBackColor = false;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(246, 72);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(35, 13);
            this.labelTest.TabIndex = 6;
            this.labelTest.Text = "label1";
            // 
            // FormMenuStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(617, 466);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.radioButtonSQL);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.radioButtonFile);
            this.Controls.Add(this.comboBoxSelect);
            this.Name = "FormMenuStart";
            this.Text = "FormStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelect;
        private System.Windows.Forms.RadioButton radioButtonFile;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.RadioButton radioButtonSQL;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label labelTest;
    }
}