using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net.Sockets;
using System.IO;

namespace blenderRenderSrv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {

            string receiverIp = "192.168.1.50"; 
            int port = 5000;
            string filePath = @"C:\path\to\your\file.zip";

            using (TcpClient client = new TcpClient(receiverIp, port))
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
}
