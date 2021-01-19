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
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();

            tableLayoutPanelGame.ColumnCount = 10;
            tableLayoutPanelGame.RowCount = 10;
            Panel[,] panels = new Panel[10,10];

            Boolean boolColor = true;
            for (int i = 0; i<10; i++)
            {
                
                for(int j = 0; j<10; j++)
                {
                    panels[i, j] = new Panel();
                    panels[i, j].Dock = DockStyle.Fill;
                    panels[i, j].Margin = new Padding(0);
                    panels[i, j].Padding = new Padding(0);
                    boolColor = !boolColor;
                    panels[i, j].BackColor = boolColor ? Color.Green : Color.Blue;
                    tableLayoutPanelGame.Controls.Add(panels[i, j], i, j);

                }
                boolColor =! boolColor;
            }

            tableLayoutPanelGame.RowStyles.Clear();
            tableLayoutPanelGame.ColumnStyles.Clear();
            for (int i = 1; i <= tableLayoutPanelGame.RowCount; i++)
            {
                tableLayoutPanelGame.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
            }
            for (int i = 1; i <= tableLayoutPanelGame.ColumnCount; i++)
            {
                tableLayoutPanelGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
            }

        }
    }
}
