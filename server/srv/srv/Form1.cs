using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srv
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

        // Set the port and IP (IPAddress.Any listens on all local network interfaces)
        public int port = 5001;
        private TcpListener listener;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.FormBorderStyle = FormBorderStyle.None;
        }


        private void btnEnable_Click(object sender, EventArgs e)
        {

            handleRequest();
        }

        private void handleRequest()
        {
            int tPort = int.Parse(txtPort.Text);
            if (txtBlenderpath.Text.Length == 0 || string.IsNullOrEmpty(txtBlenderpath.Text)){
                MessageBox.Show("blender path is invalid: empty");

            } else if (txtPort.Text.Length == 0 || tPort < 0)
            {
                MessageBox.Show("port is invalid: empty or negative");
            }


            port = tPort;


            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            Console.WriteLine("Waiting for a connection...");

            string sfp = @"C:\blsrv\data.dat";
            string sfpDir = @"C:\blsrv\";
            if (!Directory.Exists(sfp)) {
                Directory.CreateDirectory(sfpDir);
            }

            using (TcpClient client = listener.AcceptTcpClient())
            using (NetworkStream nwStream = client.GetStream())
            using (FileStream fs = new FileStream(sfp, FileMode.Create))
            {
                // Copy the network stream directly to the file stream
                nwStream.CopyTo(fs);
                Console.WriteLine("File received successfully!");
            }
            if (File.Exists(sfp))
            {
                string newSfp = @"C:\blsrv\data.blend";
                if (File.Exists(newSfp))
                {
                    bool nameExist = true;
                    int curInd = 1;
                    while (nameExist)
                    {
                        string testPath = @"C:\blsrv\file";
                        testPath += "_" + curInd.ToString() + ".blend";
                        if (!File.Exists(testPath))
                        {
                            nameExist = false;
                            newSfp = testPath;
                            Console.WriteLine(testPath);
                        }
                        else
                        {
                            curInd++;
                            Console.WriteLine(curInd.ToString());
                        }
                    }
                }
                Console.WriteLine(newSfp);
                File.Move(sfp, newSfp); // changes file extension to
                string bfp = txtBlenderpath.Text;

                WindowsIdentity curUser = WindowsIdentity.GetCurrent();
                string pyPath = $@"C:\users\{curUser.Name}\documents\autorender.py";

                openBlenderFile(bfp, newSfp, pyPath);
            }
        }

        public void openBlenderFile(string blenderPath, string newSfp, string pyPath)
        {
            try
            {
                string args = $"-b \"{newSfp}\" -P \"{pyPath}\"";
                if (checkHeadless.Checked == false)
                {
                    args = $"\"{newSfp}\" -P \"{pyPath}\"";
                }
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = blenderPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        Console.WriteLine(line);
                    }
                    process.WaitForExit();
                }

                    Process.Start(startInfo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCloseConn_Click(object sender, EventArgs e)
        {
            listener.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();
            string deviceIP = Dns.GetHostByName(hostname).AddressList[0].ToString();
            lblSoftware.Text = "blenderRenderSrv: SRV at " + hostname + ":" + deviceIP;
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
            if (listener != null)
            {
                listener.Stop(); 
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
