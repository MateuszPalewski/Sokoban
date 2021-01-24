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
        private CustomPanel[,] panelList;
        private List<string> file;
        public FormGame(string filename)
        {
            InitializeComponent();

            List<string> map = initMap(filename);
            file = map;
            panelList = loadMap(map);
            initSizeGrid(panelList);
            
            resizeGrid();
        }

        public FormGame(List<string> newMap)
        {
            InitializeComponent();

            List<string> map = newMap;
            file = map;
            panelList = loadMap(map);
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

                    if (j < temp)
                    {
                        switch (char.ToUpper(map[i][j]))
                        {
                            case 'X':

                                result[i, j] = new CustomPanel(TitleTypeEnum.Wall);
                                break;
                            case 'G':
                                result[i, j] = new CustomPanel(TitleTypeEnum.Player);
                                break;
                            case 'P':
                                result[i, j] = new CustomPanel(TitleTypeEnum.Empty);
                                break;
                            case 'O':
                                result[i, j] = new CustomPanel(TitleTypeEnum.Hole);
                                break;
                            case 'S':
                                result[i, j] = new CustomPanel(TitleTypeEnum.Chest);
                                break;
                            default:
                                result[i, j] = new CustomPanel(TitleTypeEnum.Empty);
                                break;


                        }
                    }
                   else{
                        result[i, j] = new CustomPanel(TitleTypeEnum.Wall);
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int panelHeight = panelList.GetLength(0);//pierwszy wymiar oznacza wysokość, a drugi oznacza szerokość  
            int panelWidth = panelList.GetLength(1);
            int x = 0,y = 0;
            for(int i=0; i< panelHeight; i++)
            {
                for (int j=0; j<panelWidth; j++)
                {
                    if (panelList[i, j].PlayerOnTitle)
                    {
                        x = i;
                        y = j;          //koordynaty gracza
                    }
                }
            }

            switch (keyData)
            {
                case Keys.Up:
                case Keys.W:
                    if (panelList[x-1,y].titleTypeEnum != TitleTypeEnum.Wall)
                    {
                        if (panelList[x - 1, y].ChestOnTitle)
                        {
                            if (panelList[x - 2, y].titleTypeEnum != TitleTypeEnum.Wall && !panelList[x - 2, y].ChestOnTitle)
                            {
                                Console.WriteLine("W lub Góra");
                                panelList[x - 1, y].ChestOnTitle = false;
                                panelList[x - 2, y].ChestOnTitle = true;
                            }
                        }
                        else
                        {
                            panelList[x, y].PlayerOnTitle = false;
                            panelList[x - 1, y].PlayerOnTitle = true;
                        }
                    }
                    break;
                case Keys.Down:
                case Keys.S:
                    if(panelList[x + 1, y].titleTypeEnum != TitleTypeEnum.Wall)
                    {
                        if (panelList[x + 1, y].ChestOnTitle)
                        {
                            if (panelList[x + 2, y].titleTypeEnum != TitleTypeEnum.Wall && !panelList[x + 2, y].ChestOnTitle)
                            {
                                Console.WriteLine("S lub Dół");
                                panelList[x + 1, y].ChestOnTitle = false;
                                panelList[x + 2, y].ChestOnTitle = true;
                            }
                        }
                        else
                        {
                            panelList[x, y].PlayerOnTitle = false;
                            panelList[x + 1, y].PlayerOnTitle = true;
                        }
                    }
                    break;
                case Keys.Left:
                case Keys.A:
                    if(panelList[x, y - 1].titleTypeEnum != TitleTypeEnum.Wall)
                    {
                        if (panelList[x, y - 1].ChestOnTitle)
                        {
                            if (panelList[x, y - 2].titleTypeEnum != TitleTypeEnum.Wall && !panelList[x, y - 2].ChestOnTitle)
                            {
                                Console.WriteLine("A lub lewo");
                                panelList[x, y - 1].ChestOnTitle = false;
                                panelList[x, y - 2].ChestOnTitle = true;
                            }
                        }
                        else
                        {
                            panelList[x, y].PlayerOnTitle = false;
                            panelList[x, y - 1].PlayerOnTitle = true;
                        }
                    }
                    break;
                case Keys.Right:
                case Keys.D:
                    if(panelList[x, y + 1].titleTypeEnum != TitleTypeEnum.Wall)
                    {
                        if (panelList[x, y + 1].ChestOnTitle)
                        {
                            if (panelList[x, y + 2].titleTypeEnum != TitleTypeEnum.Wall && !panelList[x, y + 2].ChestOnTitle)
                            {
                                Console.WriteLine("D lub prawo");
                                panelList[x, y + 1].ChestOnTitle = false;
                                panelList[x, y + 2].ChestOnTitle = true;
                            }
                        }
                        else
                        {
                            panelList[x, y].PlayerOnTitle = false;
                            panelList[x, y + 1].PlayerOnTitle = true;
                        }
                    }
                    break;

                case Keys.R:
                    reset();
                    break;

                default:
                    Console.WriteLine("Default");
                    break;
            }

            bool checkWin= true;
            for (int i = 0; i < panelHeight; i++)
            {
                for (int j = 0; j < panelWidth; j++)
                {
                    if (panelList[i, j].titleTypeEnum == TitleTypeEnum.Hole)
                        if (!panelList[i, j].chestInHole) checkWin = false;
                }
            }
            if (checkWin)
            {
                MessageBox.Show("Brawo, wygrałeś!", "Zwycięstwo", MessageBoxButtons.OK);
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        /// <summary>
        /// 
        /// </summary>
        private void reset()
        {
            tableLayoutPanelGame.Controls.Clear();
            
            panelList = loadMap(file);
            initSizeGrid(panelList);
        }

    }
    
}
