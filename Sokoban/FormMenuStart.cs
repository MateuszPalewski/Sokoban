using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class FormMenuStart : Form
    {
        public string filename;
        public FormMenuStart()
        {
            InitializeComponent();
            comboBoxSelect.Items.Add("Ala");
            comboBoxSelect.Items.Add("Ma");
            comboBoxSelect.Items.Add("Kota");
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            if (radioButtonFile.Checked)
            {
                Form form = new FormGame(filename);
                form.ShowDialog();
                
            }
            else
            {
                Form form = new FormGame("C:\\mapa.txt");
                form.ShowDialog();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filename = openFileDialog.FileName;

                    string[] tempName = filename.Split('\\');
                    buttonSelectFile.Text = tempName[tempName.Length-1];
                }
            }
        }
    }
}
