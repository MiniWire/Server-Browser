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


    //dataGrid.Rows.Add(NAME, PLAYERS, MAP, PW);
*/


namespace Server_Browser
{
    public partial class ServerBrowser : Form
    {
        Form Aboutwindow;
        int[] Portlist ={27020,27021,27022,27023,27024,27025};
        UdpClient udpclient = new UdpClient(88);
        Byte[] QueryData = { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00, };
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 88);

        public ServerBrowser()
        {
            InitializeComponent();  
            Aboutwindow = new About();
        }

        public  void Form1_Load(object sender, EventArgs e)
        {
             
        }
        public void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Portlist.Length; i++)
            {
                Fillin(GetAnswer(Portlist[i]));
            }
            
        }
        public void Fillin(RecievePacket Param)
        {
            
            if (Param != null)
            {
                    if (Param.Map.StartsWith("workshop"))
                {
                    Param.Map = Param.Map.Substring(19);
                }
            
                    dataGrid.Rows.Add(Param.Name, Param.Players.ToString() + "/" + Param.MaxPlayers + "(" + Param.Bots + ")", Param.Map, Param.PW,Param.Port);
                }
            else
            {
                MessageBox.Show("Error Param of method Fillin equals NULL");
            }

        }
        

        public RecievePacket GetAnswer(int SERVERPORT)
        {
            int[] recoffsets = { 6, 0, 0, 0 };
            byte[] TempArray = new byte[100];
            RecievePacket rcv = new RecievePacket();
            try{
                udpclient.Send(QueryData, QueryData.Length, "37.120.164.114", SERVERPORT);
            }
            catch (Exception X)
            {
                MessageBox.Show("could not connect to mini's inc servers. try again or check your connection"+X.Message);
            }
            
                Byte[] receiveBytes = udpclient.Receive(ref RemoteIpEndPoint);
                int offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[0]);
            
                for (int i = recoffsets[0]; i < offsetInt; i++)
                {
                    TempArray[i - recoffsets[0]] = receiveBytes[i];
                }
                char[] cArray = System.Text.Encoding.ASCII.GetString(TempArray).ToCharArray();
                rcv.Name = new string(cArray);//WORKS
                recoffsets[1] = offsetInt + 1;
                offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[1]);
                Array.Clear(TempArray, 0, TempArray.Length);
                for (int i = recoffsets[1]; i < offsetInt; i++)
                {
                    TempArray[i - recoffsets[1]] = receiveBytes[i];
                }
                cArray = System.Text.Encoding.ASCII.GetString(TempArray).ToCharArray();
                rcv.Map = new string(cArray);//WORKS
                recoffsets[2] = offsetInt + 1;
                offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[2]);
                Array.Clear(TempArray, 0, TempArray.Length);
                for (int i = recoffsets[2]; i < offsetInt; i++)
                {
                    TempArray[i - recoffsets[2]] = receiveBytes[i];
                }
                cArray = System.Text.Encoding.ASCII.GetString(TempArray).ToCharArray();
                rcv.Folder = new string(cArray);//WORKS
                recoffsets[3] = offsetInt + 1;
                offsetInt = GetEndOfStringinPacket(receiveBytes, recoffsets[3]);
                Array.Clear(TempArray, 0, TempArray.Length);
                for (int i = recoffsets[3]; i < offsetInt; i++)
                {
                    TempArray[i - recoffsets[3]] = receiveBytes[i];
                }
                cArray = System.Text.Encoding.ASCII.GetString(TempArray).ToCharArray();
                rcv.Game = new string(cArray);//WORKS
                //No Strings anymore
                byte[] PrivArray = { receiveBytes[offsetInt + 1], receiveBytes[offsetInt + 2] };
                rcv.ID = ByteToShort(PrivArray);
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
                rcv.Port = SERVERPORT;
                //MessageBox.Show(rcv.Name);
                return rcv;
        }
            

            
        
        public void Debug(RecievePacket Param)
        {
            MessageBox.Show("J");

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

        static short ByteToShort(byte[] myByteArray)
        {
            return (short)((myByteArray[1] << 8) | (myByteArray[0] << 0));
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (!Aboutwindow.Visible)
            {
                Aboutwindow = new About();
                Aboutwindow.Show();
            }
            
        }

        private void btnTS_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ts3server://37.120.164.114");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string str;
            str = dataGrid.Rows[dataGrid.SelectedRows[0].Index].Cells[4].Value.ToString(); 
            MessageBox.Show(str);
            //System.Diagnostics.Process.Start("steam://connect/37.120.164.114:27020");
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
    public int Port;
};