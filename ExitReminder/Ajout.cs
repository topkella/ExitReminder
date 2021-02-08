using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExitReminder
{
    public partial class Ajout : Form
    {
        public Ajout()
        {
            InitializeComponent();
        }

        private void Ajout_Load(object sender, EventArgs e)
        {
            Process[] temp_process;
            ArrayList list_process = new ArrayList();

            int i, j;

            temp_process = Process.GetProcesses();

            //supression des processus doublons
            for(i = 0; i < temp_process.Length; i++)
            {
                for (j = 0; j < temp_process.Length; j++) {
                    if (i != j&&temp_process[i]!=null&& temp_process[j] != null)
                    {
                        if (temp_process[i].ProcessName.Equals(temp_process[j].ProcessName))
                        {
                            temp_process[j] = null;
                        }
                    }
                }
            }

            //recopiage du tableau troué
            for (i = 0; i < temp_process.Length; i++)
            {
                if (temp_process[i] != null)
                    list_process.Add(temp_process[i]);
            }
           
            foreach (Process p in list_process)
            {
                ListViewItem t = listView1.Items.Add(p.ProcessName);
				t.SubItems.Add(p.MainWindowTitle);
			}
            
 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SharedInfo.actualProcessName = "";
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SharedInfo.actualProcessName = listView1.SelectedItems[0].SubItems[0].Text;
            this.Close();
        }

		private void Actualiser_clicked(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			Ajout_Load(sender, e);
		}
	}
}
