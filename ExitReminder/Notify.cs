using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExitReminder
{
	public partial class Notify : Form
	{
		private int counter;
		private int hauteur;
		private Size taille;

		public Notify()
		{
			InitializeComponent();
		}

		private void Notify_Load(object sender, EventArgs e)
		{

			counter = 0;
			TopMost = true;
			taille = new Size(this.Size.Width,0);
			hauteur = this.Size.Height;
			label3.Text = SharedInfo.actualProcessName;

			if (!SharedInfo.panel_backgound_color.IsEmpty)
				panel1.BackColor = SharedInfo.panel_backgound_color;

			apparition.Start();
		}

		private void Apparition_Tick(object sender, EventArgs e)
		{
			//1 appel toutes les 50 ms -> 20 appels par seconde
			//4 secondes (0-3) = 80 appels
			if (counter > 80)
			{
				if (Opacity > 0)
				{
					Opacity -= 0.05;
				}
				if (Opacity==0) {
					SharedInfo.change_action = false;
					apparition.Stop();
					Close();
				}
			}
			else
			{
				if (Opacity < 1)
				{
					Opacity += 0.1;
				}

				if (taille.Height < hauteur)
				{
					taille.Height += hauteur / 8;
					this.Size = taille;
				}
			}
			label2.Text = "Non ( " + (4-(counter / 20)).ToString() + " )";
			counter++;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SharedInfo.change_action = true;
			apparition.Stop();
			Close();
		}

		private void Non_click(object sender, EventArgs e)
		{
			SharedInfo.change_action = false;
			apparition.Stop();
			Close();
		}
	}
}
