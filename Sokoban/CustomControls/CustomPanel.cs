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
                setColor();
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
                setColor();
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
            
            setColor();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void setColor()
        {
            if (playerOnTitle)
            {
                if (playerInHole) this.BackColor = Color.Pink;
                else this.BackColor = Color.Green;
            }
            else if (chestOnTitle)
            {
                if (chestInHole) this.BackColor = Color.Gold;
                else this.BackColor = Color.Brown;

            }
            else
            {
                switch (titleTypeEnum)
                {
                    case TitleTypeEnum.Wall:
                        this.BackColor = Color.Gray;
                        break;
                    case TitleTypeEnum.Empty:
                        this.BackColor = Color.White;
                        break;
                    case TitleTypeEnum.Hole:
                        this.BackColor = Color.Black;
                        break;
                    default:
                        this.BackColor = Color.White;
                        break;
                }
            }

        }
    }
}
