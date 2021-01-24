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
    public partial class CustomPanel : Panel
    {

        private bool playerOnTitle;
        public bool PlayerOnTitle
        {
            get
            {
                return playerOnTitle;
            }
            set
            {
                playerOnTitle = value;
                if (!playerOnTitle) playerInHole=false;
                if (playerOnTitle && titleTypeEnum == TitleTypeEnum.Hole) playerInHole = true;
                setImage();
                return;
            }
        }

        private bool chestOnTitle;
        public bool ChestOnTitle
        {
            get
            {
                return chestOnTitle;
            }
            set
            {
                chestOnTitle = value;
                if (!chestOnTitle) chestInHole = false;
                if (chestOnTitle && titleTypeEnum == TitleTypeEnum.Hole) chestInHole = true;
                setImage();
                return;
            }
        }

        public bool chestInHole;
        public bool playerInHole;
       

        public TitleTypeEnum titleTypeEnum;

        public CustomPanel(TitleTypeEnum titleTypeEnum)
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);
            this.titleTypeEnum = titleTypeEnum;

            if (titleTypeEnum == TitleTypeEnum.Player) playerOnTitle = true;
            else playerOnTitle = false;
            
            if (titleTypeEnum == TitleTypeEnum.Chest) chestOnTitle = true;
            else chestOnTitle = false;
            
            setImage();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void setImage()
        {
            if (playerOnTitle)
            {
                if (playerInHole) 
                {
                    this.BackgroundImage = Properties.Resources.Gracz_w_dziurze;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.Gracz;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            else if (chestOnTitle)
            {
                if (chestInHole)
                {
                    this.BackgroundImage = Properties.Resources.Skrzynia_w_dziurze;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }

                else
                {
                    this.BackgroundImage = Properties.Resources.Skrzynia;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            else
            {
                switch (titleTypeEnum)
                {
                    case TitleTypeEnum.Wall:
                        this.BackgroundImage = Properties.Resources.Ściana;
                        break;
                    case TitleTypeEnum.Empty:
                        this.BackgroundImage = Properties.Resources.Empty;
                        break;
                    case TitleTypeEnum.Hole:
                        this.BackgroundImage = Properties.Resources.Dziura;
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    default:
                        this.BackgroundImage = Properties.Resources.Empty;
                        break;
                }
            }

        }
    }
}
