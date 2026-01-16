using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blenderRenderSrv
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        private string filePath = string.Empty;
        private bool filePathIsNull = true;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // Apply the rounded corners (25 is the radius)
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (filePathIsNull) {
                MessageBox.Show("Please select a file first");
                fileDialogCheck();
                return;
            }
            if (File.Exists(filePath))
            {
                string srvIp = txtIp.Text; 
                int port = int.Parse(txtPort.Text);

                if (port < 0)
                {
                    MessageBox.Show("Invalid Port");
                    return;
                }
                else if (srvIp.Length <= 0) {
                    MessageBox.Show("Invalid IPv4 address");
                    return;
                }


                    using (TcpClient client = new TcpClient(srvIp, port))
                    using (NetworkStream nwStream = client.GetStream())
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        // Stream the file data to the network
                        fs.CopyTo(nwStream);
                        nwStream.Flush();
                        Console.WriteLine("File sent!");
                    }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {

            fileDialogCheck();
        }
        private void fileDialogCheck()
        {

            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "blend files (*.blend)|*.blend";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            if (filePath == string.Empty)
            {
                MessageBox.Show("Error: couln't capture filename");
            }
            else
            {
                filePathIsNull = false;
            }
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
