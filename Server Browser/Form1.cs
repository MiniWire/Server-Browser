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
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        Answer ans;
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
        public void button1_Click(object sender, EventArgs e)
        {
            ans = GetAnswer(27024);
            if (ans != null)
            {
                MessageBox.Show(ans.Name);
            }
            else
            {
                MessageBox.Show("ITS NULL");
            }
            
        }
        public Answer GetAnswer(int SERVERPORT)
        {
            Answer PRIVVAR;
            try
            {
                udpclient.Send(QueryData,QueryData.Length, "37.120.164.114", SERVERPORT);
            }
            catch (Exception X)
            {
            }
            try
            {
                Byte[] receiveBytes = udpclient.Receive(ref RemoteIpEndPoint);
                //string returnData = Encoding.ASCII.GetString(receiveBytes);
                //MessageBox.Show(returnData.ToString()+ RemoteIpEndPoint.Address.ToString() + RemoteIpEndPoint.Port.ToString());
                PRIVVAR = ByteArrayToObject(receiveBytes);
                MessageBox.Show(PRIVVAR.Name);
                return PRIVVAR;
            }
            catch (Exception Y)
            {
                return null;
            }
            
        }

        public Answer ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Answer obj = (Answer)binForm.Deserialize(memStream);
            return obj;
        }

        public class Answer
        {
            public byte Header;
            public byte Protocol;
            public string Name;
            public string Map;
            public string Folder;
            public string Game;
            public byte Players;
            public byte MaxPlayers;
            public byte Bots;
            public byte ServerType;
            public byte Environment;
            public byte PW;
            public byte VAC;
        };
    }
    
    
    
}
