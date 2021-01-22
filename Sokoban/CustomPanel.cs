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

        private TitleTypeEnum titleTypeEnum;
        public TitleTypeEnum TitleTypeEnum { get { return titleTypeEnum; } set
            {
                titleTypeEnum = value;
                setColor();
            }
        }


        public CustomPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        private void setColor()
        {
            switch (titleTypeEnum)
            {
                case TitleTypeEnum.Wall:
                    this.BackColor = Color.Gray;
                    break;
                case TitleTypeEnum.Player:
                    this.BackColor = Color.Pink;
                    break;
                case TitleTypeEnum.Empty:
                    this.BackColor = Color.White;
                    break;
                case TitleTypeEnum.Hole:
                    this.BackColor = Color.Black;
                    break;
                case TitleTypeEnum.Chest:
                    this.BackColor = Color.Brown;
                    break;
                case TitleTypeEnum.PlayerInHole:
                    this.BackColor = Color.Red;
                    break;
                case TitleTypeEnum.ChestInHole:
                    this.BackColor = Color.Blue;
                    break;
                default:
                    this.BackColor = Color.White;
                    break;
            }
        }
    }
}
