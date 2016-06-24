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
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Mario
{
	public partial class MainForm : Form
	{
		private Capture _capture;
		private CascadeClassifier _cascadeClassifier;
		Point _controller;
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
		private Direction _direction_mario;

		private System.Collections.Generic.List<Fire> _availableFire;
		private int _timeBetweenTwoFire;
		private int _numFire = 0;
		private bool _flagFire;

		public MainForm()
		{
			InitializeComponent();

			_capture = new Capture();
			_cascadeClassifier = new CascadeClassifier(Application.StartupPath + "\\haarcascade_frontalface_default.xml");

			_availableFire = new System.Collections.Generic.List<Fire>();
			_player = new WMPLib.WindowsMediaPlayer();
			_player.URL = "MainTheme.mp3";
			_timeBetweenTwoFire = 0;
			_flagFire = false;
			this.KeyPreview = true;
			tmrMario.Start();
			letaGoSound.Play();
			lblGameOver.Visible = false;
			lblWin.Visible = false;
			txtHistoryStates.Text = "";
			txtCurrentState.Text = "";
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_controller = new Point(330, 270);
			imgbFace.Image = _capture.QueryFrame();
			normalMonster = new NormalMonster("normalMonster", new Point(571, 222));
			Manager.SpriteManager.Instance.GetSpriteWithName("normalMonster").SetContainer(this.pnlMainGame);
			thorn = new Thorn("thorn", new Point(219, 220));
			Manager.SpriteManager.Instance.GetSpriteWithName("thorn").SetContainer(this.pnlMainGame);
			finalMonster = new FinalMonster("finalMonster", new Point(1091, 160));
			Manager.SpriteManager.Instance.GetSpriteWithName("finalMonster").SetContainer(this.pnlMainGame);
			finalMonster2 = new FinalMonster("finalMonster2", new Point(900, 160));
			Manager.SpriteManager.Instance.GetSpriteWithName("finalMonster2").SetContainer(this.pnlMainGame);
			mario = new Mario.GameObjects.Mario("mario", new Point(12, 209));
			Manager.SpriteManager.Instance.GetSpriteWithName("mario").SetContainer(this.pnlMainGame);
			redMushroom = new RedMushroom("redMushroom", new Point(430, 218));
			Manager.SpriteManager.Instance.GetSpriteWithName("redMushroom").SetContainer(this.pnlMainGame);
			blueMushroom = new BlueMushroom("blueMushroom", new Point(700, 218));
			Manager.SpriteManager.Instance.GetSpriteWithName("blueMushroom").SetContainer(this.pnlMainGame);
			lblLife.Text = "Life: " + mario.Life.ToString();
			_player.controls.play();
			txtHistoryStates.MaxLength = 6000;
		}

		private void tmrMario_Tick(object sender, EventArgs e)
		{
			UpdateController();
			using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
			{
				if (imageFrame != null)
				{
					Image<Gray, Byte> grayframe = imageFrame.Convert<Gray, byte>();
					Rectangle[] faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
					_controller.X = 330;
					_controller.Y = 270;
					foreach (Rectangle face in faces)
					{
						imageFrame.Draw(face, new Bgr(Color.White), 1);
						_controller.X = face.X + face.Width / 2;
						_controller.Y = face.Y + face.Height / 2;
						break;
					}
				}

				imgbFace.Image = imageFrame.Flip(FlipType.Horizontal);
				//_faces = null;
			}

			normalMonster.UpdateState();
			normalMonster.Move();
			finalMonster.UpdateState();
			finalMonster.Move();
			finalMonster2.UpdateState();
			finalMonster2.Move();


			int mario_life = mario.Life;

			mario.Move();
			UpdateCurrentState();
			if (mario._sprite.Position.X > 180 && mario._sprite.Position.X < 241)
			{
				mario.CollideThorn(thorn);
			}
			if (mario._sprite.Position.X > 410 && mario._sprite.Position.X < 800)
			{
				mario.CollideMonster(normalMonster);
			}
			if (mario._sprite.Position.X > 861 && mario._sprite.Position.X < 1250)
			{
				mario.CollideMonster(finalMonster);
				mario.CollideMonster(finalMonster2);
			}
			if (mario._sprite.Position.X > 391 && mario._sprite.Position.X < 850)
			{
				mario.CollideMushroom(redMushroom);
				mario.CollideMushroom(blueMushroom);
			}

			if (mario_life != mario.Life)
			{
				lblLife.Text = "Life: " + mario.Life.ToString();
			}
			//Hết mạng
			if (mario.Life == 0)
			{
				if (txtHistoryStates.Text.Length >= txtHistoryStates.MaxLength)
				{
					txtHistoryStates.Clear();
				}
				txtHistoryStates.Text += "Game Over";
				txtHistoryStates.SelectionStart = txtHistoryStates.Text.Length;
				txtHistoryStates.ScrollToCaret();
				mario.Die();
				gameOverSound.Play();
				tmrMario.Stop();
				lblGameOver.Visible = true;
			}

			//về đích
			else
			{
				if (mario._sprite.ImageSpr.Location.X >= 1320)
				{
					if (txtHistoryStates.Text.Length >= txtHistoryStates.MaxLength)
					{
						txtHistoryStates.Clear();
					}
					txtHistoryStates.Text += "You Win";
					txtHistoryStates.SelectionStart = txtHistoryStates.Text.Length;
					txtHistoryStates.ScrollToCaret();
					lblWin.Visible = true;
					mapClearSound.Play();
					_player.controls.stop();
					tmrMario.Stop();
				}
			}
			if (_flagFire)
			{
				_timeBetweenTwoFire = (_timeBetweenTwoFire + 1) % 10;
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
					if (temp_sprite.Position.X >= this.Width + 10 || temp_sprite.Position.X < -10)
					{
						Manager.SpriteManager.Instance.RemoveWithName(_availableFire[i].Name);
						_availableFire.Remove(_availableFire[i]);
					}
					else
					{
						//điều chỉnh hướng bay của lửa theo hướng quay mặt của Mario
						_availableFire[i].Move();

						//Kiểm tra va chạm của đạn với các monsters
						if (_availableFire[i]._sprite.Position.X > 400 && _availableFire[i]._sprite.Position.X < 1250)
						{
							_availableFire[i].CollideMonster(normalMonster);
							_availableFire[i].CollideMonster(finalMonster);
							_availableFire[i].CollideMonster(finalMonster2);
						}
					}
				}
			}
		}

		private void UpdateController()
		{
			if (!mario.Moving)
			{
				if (_controller.X >= 440)
				{
					if (!mario.BlueMushroomEaten)
					{
						mario.Direct = Direction.left;
						_direction_mario = Direction.left;
					}
					else
					{
						{
							mario.Direct = Direction.right;
							_direction_mario = Direction.right;
						}
					}
					mario.ChangeNormal(_direction_mario);
					mario.ChangeSoldier(_direction_mario);
					mario.Moving = true;
				}
				else if (_controller.X < 220)
				{
					if (!mario.BlueMushroomEaten)
					{
						mario.Direct = Direction.right;
						_direction_mario = Direction.right;
					}
					else
					{
						mario.Direct = Direction.left;
						_direction_mario = Direction.left;
					}
					mario.ChangeNormal(_direction_mario);
					mario.ChangeSoldier(_direction_mario);
					mario.Moving = true;
				}
				if (_controller.Y < 179)
				{
					if (mario.Jumping == 0)
					{
						mario.Jumping = 1;
						mario.Moving = true;
					}
				}
			}
			else
			{
				if (mario.Jumping == 0)
				{
					mario.Direct = Direction.stay;
					mario.Moving = false;
				}
			}
		}
		private void UpdateCurrentState()
		{
			if (txtHistoryStates.Text.Length >= txtHistoryStates.MaxLength)
			{
				txtHistoryStates.Text = "";
			}
			if (txtCurrentState.Text != mario.StringCurrentState)
			{
				txtCurrentState.Text = mario.StringCurrentState;
				txtHistoryStates.Text += txtCurrentState.Text + System.Environment.NewLine;
				txtHistoryStates.SelectionStart = txtHistoryStates.Text.Length;
				txtHistoryStates.ScrollToCaret();
			}
		}
		private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
			{
				this.Close();

			}
			if (e.KeyChar == (char)Keys.Enter)
			{
				Application.Restart();
			}
			if (!_flagFire)
			{
				if (mario.Life == 2)
				{
					if (e.KeyChar == (char)Keys.Space)
					{
						//Đặt lại vị trí của lửa bay ra đúng vị trí của nồng súng
						int x = mario._sprite.Position.X + mario._sprite.ImageSpr.Width;
						int y = mario._sprite.Position.Y + 10;
						if (_direction_mario == Direction.left)
						{
							x -= 20;
						}
						_availableFire.Add(new Fire("fire" + _numFire.ToString(), new Point(x, y), _direction_mario));
						Manager.SpriteManager.Instance.GetSpriteWithName("fire" + _numFire.ToString()).SetContainer(this.pnlMainGame);
						_flagFire = true;
						_timeBetweenTwoFire = 0;
						_numFire++;
						fireSound.Play();
					}
				}
			}
		}
	}
}