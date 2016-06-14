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
using System.Media;//thu vien de goi SoundPlayer
using WMPLib; // thu vien de goi WindowsMediaPlayer
namespace Mario
{
	public partial class MainForm : Form
    {
        //------Khoi tao----- 
        private WindowsMediaPlayer _player;
        public SoundPlayer fireSound = new SoundPlayer("smw_fireball.wav");
        public SoundPlayer powerUpSound = new SoundPlayer("smw_powerup.wav");
        public SoundPlayer gameOverSound = new SoundPlayer("smw_gameover.wav");
        public SoundPlayer eatBlueMushroomSound = new SoundPlayer("smw_1-up.wav");
        public SoundPlayer jumpSmallSound = new SoundPlayer("smw_jumpsmall.wav");
        public SoundPlayer mapClearSound = new SoundPlayer("smw_stageclear.wav");
        public SoundPlayer letaGoSound = new SoundPlayer("smw_letago.wav");
        private NormalMonster normalMonster;
		private FinalMonster finalMonster;
        private FinalMonster finalMonster2;
        private Thorn thorn;
        private Mario.GameObjects.Mario mario;
        private RedMushroom redMushroom;
        private BlueMushroom blueMushroom;
        
        private System.Collections.Generic.List<Fire> _availableFire;
        private int _timeBetweenTwoFire;
        private int _numFire = 0;
        private bool _flagFire;

        public System.Windows.Forms.PictureBox GetPictureBoxWithName(string name)
		{
			return (System.Windows.Forms.PictureBox)this.Controls.Find(name, true).FirstOrDefault();
		}
		public MainForm()
		{
			InitializeComponent();
            
            _availableFire = new System.Collections.Generic.List<Fire>();
            _player = new WMPLib.WindowsMediaPlayer();
            _player.URL = @"F:\MUSIC for MARIO file convert MP3\MainTheme.mp3";
            _timeBetweenTwoFire = 0;
            
            _flagFire = false;

            
            timer1.Start();
            tmrMario.Start();
            letaGoSound.Play();
            tmrFire.Start();
            lblGameOver.Visible = false;
            lblWin.Visible = false;
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			normalMonster.UpdateState();
			normalMonster.Move();
			finalMonster.UpdateState();
			finalMonster.Move();
            finalMonster2.UpdateState();
            finalMonster2.Move();
        }

		private void MainForm_Load(object sender, EventArgs e)
        {
            normalMonster = new NormalMonster("normalMonster", new Point(571, 188));
            Manager.SpriteManager.Instance.GetSpriteWithName("normalMonster").SetContainer(this);
            thorn = new Thorn("thorn", new Point(219, 188));
            Manager.SpriteManager.Instance.GetSpriteWithName("thorn").SetContainer(this);
            finalMonster = new FinalMonster("finalMonster", new Point(1091, 130));
            Manager.SpriteManager.Instance.GetSpriteWithName("finalMonster").SetContainer(this);
            finalMonster2 = new FinalMonster("finalMonster2", new Point(900, 130));
            Manager.SpriteManager.Instance.GetSpriteWithName("finalMonster2").SetContainer(this);
            mario = new Mario.GameObjects.Mario("mario", new Point(12, 177));
            Manager.SpriteManager.Instance.GetSpriteWithName("mario").SetContainer(this);
            redMushroom = new RedMushroom("redMushroom", new Point(430, 184));
            Manager.SpriteManager.Instance.GetSpriteWithName("redMushroom").SetContainer(this);
            blueMushroom = new BlueMushroom("blueMushroom", new Point(700, 184));
            Manager.SpriteManager.Instance.GetSpriteWithName("blueMushroom").SetContainer(this);
            _player.controls.play();
        }

        private void tmrMario_Tick(object sender, EventArgs e)
        {
            mario.Move();
            mario.CollideThorn(thorn);
            mario.CollideMonster(normalMonster);
            mario.CollideMonster(finalMonster);
            mario.CollideMushroom(redMushroom);
            mario.CollideMushroom(blueMushroom);
            
            //Hết mạng
            if (mario.Get_life() == 0)
            {
                mario.Die();
                gameOverSound.Play();
                timer1.Stop();
                tmrMario.Stop();
                tmrFire.Stop();
                lblGameOver.Visible = true;
            }

            //về đích
           else
            {
                if (mario._sprite.ImageSpr.Location.X >= 1322)
                {
                    timer1.Stop();
                    tmrMario.Stop();
                    lblWin.Visible = true;
                    mapClearSound.Play();
                    _player.controls.stop();
                }
            }
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
                    jumpSmallSound.Play();
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    mario._left = true;
                    mario._moveLeft = true;
                    mario._moveRight = false;

                    if (mario.Get_life() == 1)
                    {
                        mario._sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMario_Inverse;
                    }
                    else if (mario.Get_life() == 2)
                    {
                        mario._sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMarioSoldier_Inverse;
                    }
                    break;
                case Keys.Right:
                    mario._right = true;
                    mario._moveLeft = false;
                    mario._moveRight = true;

                    if (mario.Get_life() == 1)
                    {
                        mario._sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMario;
                    }
                    else if (mario.Get_life() == 2)
                    {
                        mario._sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMarioSoldier;
                    }
                    break;
                case Keys.Up:
                    mario._jump = true;
                    break;
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_flagFire)
            {
                _timeBetweenTwoFire = 0;
                _flagFire = true;
            }
            else
            {
                return;
            }

            if (_timeBetweenTwoFire == 0)
            {
                if (mario.Get_life() == 2)
                {
                    if (e.KeyChar == (char)Keys.Space)
                    {
                        //Đặt lại vị trí của lửa bay ra đúng vị trí của nồng súng
                        int _x = mario._sprite.Position.X + mario._sprite.ImageSpr.Width;
                        int _y = mario._sprite.Position.Y + 10;

                        _availableFire.Add(new Fire("fire" + _numFire.ToString(), new Point(_x, _y)));
                        Manager.SpriteManager.Instance.GetSpriteWithName("fire" + _numFire.ToString()).SetContainer(this);

                        _numFire++;
                        fireSound.Play();
                    }
                }
                
            }

            if(e.KeyChar == (char)Keys.Escape)
            {
                this.Close();

            }
            if (e.KeyChar == (char)Keys.Enter)
                Application.Restart();
        }

        private void tmrFire_Tick(object sender, EventArgs e)
        {
            if (_flagFire)
            {
                _timeBetweenTwoFire = (_timeBetweenTwoFire + 1) % 40;
                if (_timeBetweenTwoFire == 0)
                {
                    _flagFire = false;
                }
            }

            for (int i = 0; i < _availableFire.Count; i++)
            {
                //tao mot thu muc chua picturebox khac, _available[i].Name : ten cua picturebox[i]
                Core.Sprite temp_sprite = new Core.Sprite();
                temp_sprite = Manager.SpriteManager.Instance.GetSpriteWithName(_availableFire[i].Name);

                //Hủy nếu ra khỏi màn hình
                if (temp_sprite != null)
                {
                    if (temp_sprite.Position.X >= this.Width)
                    {
                        Manager.SpriteManager.Instance.RemoveWithName(_availableFire[i].Name);
                        _availableFire.Remove(_availableFire[i]);
                    }
                    else
                    {
                        //điều chỉnh hướng bay của lửa theo hướng quay mặt của Mario
                        if (mario._moveLeft)
                            _availableFire[i].MoveLeft();
                        if (mario._moveRight)
                            _availableFire[i].MoveRight();

                        //Kiểm tra va chạm của đạn với các monsters
                        _availableFire[i].CollideMonster(normalMonster);
                        _availableFire[i].CollideMonster(finalMonster);
                        _availableFire[i].CollideMonster(finalMonster2);
                    }
                }
            }
        }
    }

}
