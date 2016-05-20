using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mario.GameObjects;

namespace Mario
{
	public partial class MainForm : Form
	{
		private NormalMonster normalMonster;
		private FinalMonster finalMonster;
		private Thorn thorn;
        private Mario.GameObjects.Mario mario;

		public System.Windows.Forms.PictureBox GetPictureBoxWithName(string name)
		{
			return (System.Windows.Forms.PictureBox)this.Controls.Find(name, true).FirstOrDefault();
		}
		public MainForm()
		{
			InitializeComponent();
			timer1.Start();
            tmrMario.Start();
            lblGameOver.Visible = false;

            //khai báo các đối tượng 
            normalMonster = new NormalMonster("normalMonster", new Point(571, 188));
            Manager.SpriteManager.Instance.GetSpriteWithName("normalMonster").SetContainer(this);
            thorn = new Thorn("thorn", new Point(219, 188));
            Manager.SpriteManager.Instance.GetSpriteWithName("thorn").SetContainer(this);
            finalMonster = new FinalMonster("finalMonster", new Point(1091, 130));
            Manager.SpriteManager.Instance.GetSpriteWithName("finalMonster").SetContainer(this);
            mario = new Mario.GameObjects.Mario("mario", new Point(12, 177));
            Manager.SpriteManager.Instance.GetSpriteWithName("mario").SetContainer(this);

            //Nếu Mario chết thì game sẽ dừng lại vào dòng "gameover" sẽ xuất hiện
            if (mario.Get_life() == 0)
            {
                mario.Die();
                timer1.Stop();
                tmrMario.Stop();
                lblGameOver.Visible = true;
            }
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			normalMonster.UpdateState();
			normalMonster.Move();
			finalMonster.UpdateState();
			finalMonster.Move();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			
        }

        private void tmrMario_Tick(object sender, EventArgs e)
        {
            mario.Move();
            mario.Change("Monster");
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    mario._left = false;
                    break;
                case Keys.Right:
                    mario._right = false;
                    break;
                case Keys.Up:
                    mario._jump = false;
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    mario._left = true;
                    break;
                case Keys.Right:
                    mario._right = true;
                    break;
                case Keys.Up:
                    mario._jump = true;
                    break;
            }
        }
    }
}
