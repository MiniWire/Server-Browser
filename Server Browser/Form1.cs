using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
/*
public int Send(
	byte[] dgram,
	int bytes,
	string hostname,
	int port
)

"37.120.164.114", 27024
*/


namespace Server_Browser
{
    public partial class Form1 : Form
    {
        UdpClient udpclient = new UdpClient(88);
        Byte[] QueryData = { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00, };
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 88);

        public Form1()
        {
            InitializeComponent();
            
        }

        public  void Form1_Load(object sender, EventArgs e)
        {
             
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetAnswer(27023);
        }
        private String GetAnswer(int SERVERPORT)
        {
            try
            {
                udpclient.Send(QueryData, QueryData.Length, "37.120.164.114", SERVERPORT);
            }
            catch (Exception X)
            {
                MessageBox.Show("couldnt connect");
            }
            try
            {

                Byte[] receiveBytes = udpclient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                //DEBUG
                //textBox1.Text= returnData.ToString()+ RemoteIpEndPoint.Address.ToString() + RemoteIpEndPoint.Port.ToString();
                return returnData;
               
            }
            catch (Exception Y)
            {
                MessageBox.Show("no Answer");
                return null;
            }
            
        }


    }
    
}
