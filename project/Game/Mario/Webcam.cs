using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Mario
{
	public partial class Webcam : Form
	{
		public Webcam()
		{
			InitializeComponent();
			_capture = new Capture();
			_cascadeClassifier = new CascadeClassifier(Application.StartupPath + "\\haarcascade_frontalface_default.xml");
		}
		private void tmrWebcam_Tick(object sender, EventArgs e)
		{
			//imgbImage.Image = _capture.QueryFrame();
			using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
			{
				if (imageFrame != null)
				{
					var grayframe = imageFrame.Convert<Gray, byte>();
					var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
					foreach (var face in faces)
					{
						imageFrame.Draw(face, new Bgr(Color.White), 1); //the detected face(s) is highlighted here using a box that is drawn around it/them

					}
				}
				imgbBox.Image = imageFrame;
			}
		}

		private void Webcam_Load(object sender, EventArgs e)
		{
			imgbBox.Image = _capture.QueryFrame();
			//		// passing 0 gets zeroth webcam
			//		cap = new Capture(0);
			//		// adjust path to find your xml
			//		haar = new HaarCascade(
			//"..\\..\\..\\..\\lib\\haarcascade_frontalface_alt2.xml");
			_game = new MainForm();
			_game.Show();
		}
		private Capture _capture;
		private CascadeClassifier _cascadeClassifier;
		private MainForm _game;
	}
}
