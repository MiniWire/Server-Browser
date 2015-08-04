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
using System.Threading;
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
        int[] Portlist ={27020,27021,27021,27022,27023,27024,27025};
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
            GetAnswer(27024);
        }
        

        public RecievePacket GetAnswer(int SERVERPORT)
        {
            int[] recoffsets = { 6, 0, 0, 0 };
            byte[] shitByte = new byte[50];
            RecievePacket rcv = new RecievePacket();
            try
            {
                udpclient.Send(QueryData, QueryData.Length, "37.120.164.114", SERVERPORT);
            }
            catch (Exception X)
            {
                MessageBox.Show("could not connect to the fucking servers. try again or check your connection");
            }

            Byte[] receiveBytes = udpclient.Receive(ref RemoteIpEndPoint);
            int offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[0]);

            for (int i = recoffsets[0]; i<offsetInt; i++)
            {
                shitByte[i-recoffsets[0]] = receiveBytes[i];
            }
            char[]cArray= System.Text.Encoding.ASCII.GetString(shitByte).ToCharArray();
            rcv.Name = new string(cArray);//WORKS
            recoffsets[1] = offsetInt + 1;
            offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[1]);
            Array.Clear(shitByte, 0, shitByte.Length);
            for (int i = recoffsets[1]; i < offsetInt; i++)
            {
                shitByte[i - recoffsets[1]] = receiveBytes[i];
            }
            cArray = System.Text.Encoding.ASCII.GetString(shitByte).ToCharArray();
            rcv.Map = new string(cArray);//WORKS
            recoffsets[2] = offsetInt + 1;
            offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[2]);
            Array.Clear(shitByte, 0, shitByte.Length);
            for (int i = recoffsets[2]; i < offsetInt; i++)
            {
                shitByte[i - recoffsets[2]] = receiveBytes[i];
            }
            cArray = System.Text.Encoding.ASCII.GetString(shitByte).ToCharArray();
            rcv.Folder = new string(cArray);//WORKS
            recoffsets[3] = offsetInt + 1;
            offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[3]);
            Array.Clear(shitByte, 0, shitByte.Length);
            for (int i = recoffsets[3]; i < offsetInt; i++)
            {
                shitByte[i - recoffsets[3]] = receiveBytes[i];
            }
            cArray = System.Text.Encoding.ASCII.GetString(shitByte).ToCharArray();
            rcv.Game = new string(cArray);//WORKS
            //No Strings anymore
            byte[] PrivArray = { receiveBytes[offsetInt + 1], receiveBytes[offsetInt + 2] };
            rcv.ID = ToShort(PrivArray);
            offsetInt += 3;
            rcv.Players = receiveBytes[offsetInt];
            offsetInt += 1;
            rcv.MaxPlayers = receiveBytes[offsetInt];
            offsetInt += 1;
            rcv.Bots = receiveBytes[offsetInt];
            offsetInt += 1;
            rcv.ServerType = receiveBytes[offsetInt];
            offsetInt += 1;
            rcv.Environment = receiveBytes[offsetInt];
            offsetInt += 1;
            rcv.PW = receiveBytes[offsetInt];
            offsetInt += 1;
            rcv.VAC = receiveBytes[offsetInt];
            return rcv;
        }
        public int GetEndOfStringinPacket(byte[] Param, int offset)
        {
            int i = offset;
            while (Param[i] != 0x00)
            {
                i++;

            }
            return i;

        }
        static short ToShort(byte[] myByteArray)
        {
            return (short)((myByteArray[1] << 8) | (myByteArray[0] << 0));
        }
    }
}
public class RecievePacket
{
    public byte Header;
    public byte Protocol;
    public string Name;
    public string Map;
    public string Folder;
    public string Game;
    public short ID;
    public byte Players;
    public byte MaxPlayers;
    public byte Bots;
    public byte ServerType;
    public byte Environment;
    public byte PW;
    public byte VAC;
};