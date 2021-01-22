using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class FormGame : Form
    {
        public FormGame(string filename)
        {
            InitializeComponent();

            List<string> map = initMap(filename);
            CustomPanel[,] panelList = loadMap(map);
            initSizeGrid(panelList);

           
            resizeGrid();
        }

        /// <summary>
        /// Zmiana wielkości siatki
        /// </summary>
        private void resizeGrid()
        {
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

        /// <summary>
        /// Wczytywanie mapy ze ścieżki, i podzielenie na wiersze
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> initMap(string path)
        {
            List<string> result = new List<string>();

            result = File.ReadAllLines(path).ToList();

            return result;
        }

        /// <summary>
        /// Załadowanie wielkości mapy z pliku
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        private CustomPanel[,] loadMap(List<string> map)
        {
            int height = map.Count;
            int width = 0;
            foreach(string s in map)
            {
                if (s.Length > width)
                {
                    width = s.Length;
                }
            }
            CustomPanel[,] result = new CustomPanel[height, width];
            for (int i=0; i< height; i++)
            {
                int temp = map[i].Length;
                for (int j= 0; j< width; j++)
                {

                    result[i, j] = new CustomPanel();
                    result[i, j].Dock = DockStyle.Fill;
                    result[i, j].Margin = new Padding(0);
                    result[i, j].Padding = new Padding(0);
                    if (j < temp)
                    {
                        switch (char.ToUpper(map[i][j]))
                        {
                            case 'X':
                                result[i, j].TitleTypeEnum = TitleTypeEnum.Wall;

                                break;
                            case 'G':
                                result[i, j].TitleTypeEnum = TitleTypeEnum.Player;
                                break;
                            case 'P':
                                result[i, j].TitleTypeEnum = TitleTypeEnum.Empty;
                                break;
                            case 'O':
                                result[i, j].TitleTypeEnum = TitleTypeEnum.Hole;
                                break;
                            case 'S':
                                result[i, j].TitleTypeEnum = TitleTypeEnum.Chest;
                                break;
                            default:
                                result[i, j].TitleTypeEnum = TitleTypeEnum.Empty;
                                break;


                        }
                            
                    }
                   else{
                        result[i, j].TitleTypeEnum = TitleTypeEnum.Wall;
                        }

                }
            }
            return result;
        }

        /// <summary>
        /// Zainicjowanie wysokości i szerokości grida + wsadzenie paneli do komórek grida
        /// </summary>
        /// <param name="panels"></param>
        private void initSizeGrid(CustomPanel[,] varPanels)
        {
            int x = varPanels.GetLength(0);//pierwszy wymiar oznacza wysokość, a drugi oznacza szerokość  
            int y = varPanels.GetLength(1);

            tableLayoutPanelGame.ColumnCount = y;
            tableLayoutPanelGame.RowCount = x;
            
            for (int i = 0; i < x; i++)
            {

                for (int j = 0; j < y; j++)
                {
                    
                    tableLayoutPanelGame.Controls.Add(varPanels[i, j], j, i);

                }
                
            }

        }

    }
}
