using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;
using EXE_Emulator_2000;

namespace EXE_Emulator
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = EXE_Emulator_2000.Properties.Resources.tumblr_mu2lreeZOD1sumwtyo1_1280;
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SoundPlayer player = new SoundPlayer(@"passport.wav");
            player.PlayLooping(); 
        }

        private void launchProcess(string process)
        {
            Process notepad = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(process);
            psi.WindowStyle = ProcessWindowStyle.Normal;
            notepad.StartInfo = psi;

            notepad.Start();
            notepad.WaitForInputIdle(3000);

            SetParent(notepad.MainWindowHandle, this.Handle);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "EXE Binaries|*exe";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;
            dialog.InitialDirectory = @"C:\Windows";
            dialog.FileName = "notepad.exe";

            DialogResult okay = dialog.ShowDialog();

            if (okay == DialogResult.OK)
            {
                launchProcess(dialog.FileName);
            }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quite franky, one would need help to even make something like this.", "ISN'T IT JUST GLORIOUS, MARGARET?");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }
    }
}
