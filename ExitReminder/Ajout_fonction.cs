using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExitReminder
{
    public partial class Ajout_fonction : Form
    {
        public Ajout_fonction()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SharedInfo.actualProcessAction = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			SharedInfo.actualProcessAction = textBox1.Text;
            Close();
        }

		private void Ajout_fonction_Load(object sender, EventArgs e)
		{
			if (SharedInfo.actualProcessAction != "")
				textBox1.Text = SharedInfo.actualProcessAction;
		}
	}
}
