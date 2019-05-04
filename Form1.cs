using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Proxy_Server
{
    public partial class Form1 : Form
    {
        public static Form1 MyForm;


        public class XClient
        {
            public int id;
            public Socket s;
            public const int BufferSize = 4096;
            public byte[] buff = new byte[BufferSize];
            public ClientConnector conn;

            public XClient(Socket _s, int _id)
            {
                this.s = _s;
                this.id = _id;
            }
        }

        public static List<XClient> Clients = new List<XClient>();

        public XClient GetClientByID(int id)
        {
            for(int i =0; i< Clients.Count; i++)
            {
                if(Clients[i].id == id)
                {
                    return Clients[i];
                }
            }
            return null;
        }

        public void DisconnectClient(int id)
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].id == id)
                {
                    string s_ip = ((IPEndPoint)(Clients[i].s.RemoteEndPoint)).Address.ToString();
                    int client_id = Clients[i].id;
                    string conn_addr = Clients[i].conn.ip.Address.ToString();
                    if (Clients[i].conn.connector.Connected)
                    {
                        Clients[i].conn.Disconnect();
                    }
                    Clients[i].s.Dispose();
                    Clients.Remove(Clients[i]);
                    this.Invoke(new Action(() =>
                    {
                        try
                        {
                            LBClients.Items.Remove("[" + client_id + "] " + s_ip + " -> " + conn_addr);
                        }
                        catch
                        { return; }
                    }));
                }
            }
        }

        public static class Info
        {
            public static Socket _listener;
            public const int Buffer_size = 4096;
            public static byte[] Buffer = new byte[Buffer_size];
            public static bool Running = false;
            public static IPEndPoint IP;
        }





        public Form1()
        {
            InitializeComponent();
            MyForm = this;
        }

        private void BTNStart_Click(object sender, EventArgs e)
        {
            if(Info.Running)
            {
                Info.Running = false;
                DisconnectAll();
                Info._listener.Dispose();
                LBStatus.Text = "Status: Fechado ...";
                BTNStart.Text = "Start";
                return;
            }


            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(TBMyIP.Text), int.Parse(TBMyPort.Text));
                Info.IP = ip;
            }
            catch
            {
                MessageBox.Show("Erro: IP local ou porta invalidos!");
                return;
            }


            try
            {
                Thread Listen_Thread = new Thread(new ThreadStart(Listen));
                Listen_Thread.Start();
            }
            catch
            {
                MessageBox.Show("Erro: Falha ao iniciar socket local!");
                return;
            }
        }

        private void Listen()
        {
            try
            {
                Info._listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Info._listener.Bind(Info.IP);
                Info._listener.Listen(25);
                Info.Running = true;
                this.Invoke(new Action(() =>
                {
                    BTNStart.Text = "Close";
                    LBStatus.Text = "Status: Aguardando conexões ...";
                }));
                Info._listener.BeginAccept(new AsyncCallback(AcceptCallback), Info._listener);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            if(!Info.Running) { return; }

            Socket s = (Socket)ar.AsyncState;
            try
            {
                Socket s_client = s.EndAccept(ar);
                int client_id = s_client.GetHashCode();

                Clients.Add(new XClient(s_client, client_id));


                XClient client = GetClientByID(client_id);
                if(client == null) { return; }
                //MessageBox.Show("Client conectado: " + client_id.ToString());

                string ip_redirect = TBRedirectIP.Text;

                Uri uriResult;
                IPAddress ip;
                bool result = Uri.TryCreate(ip_redirect, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (result)
                {
                    ip = Dns.GetHostAddresses(uriResult.Host)[0];
                }
                else
                {
                    IPAddress.TryParse(ip_redirect, out ip);
                }

                IPEndPoint direct = new IPEndPoint(ip, int.Parse(TBRedirectPort.Text));

                ClientConnector conn = new ClientConnector(client, direct);
                client.conn = conn;

                Thread.Sleep(600);
                this.Invoke(new Action(() =>
                {
                    string s_ip = ((IPEndPoint)(client.s.RemoteEndPoint)).Address.ToString();
                    LBClients.Items.Add("[" + client.id + "] " + s_ip + " -> " + client.conn.ip.Address.ToString());
                }));

                client.s.BeginReceive(client.buff, 0, XClient.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), client);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            finally
            {
                if (Info.Running)
                {
                    s.BeginAccept(new AsyncCallback(AcceptCallback), s);
                }
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            XClient client = (XClient)ar.AsyncState;
            try
            {
                if(client == null) { return; }
                if(client.s == null) { return; }
                if (!client.s.Connected) { return; }

                int bytes_receive = client.s.EndReceive(ar);

                if(bytes_receive > 0)
                {
                    byte[] data = new byte[bytes_receive];
                    Array.Copy(client.buff, data, bytes_receive);

                    HandlePacket(client, data);
                    client.buff = new byte[XClient.BufferSize];
                    client.s.BeginReceive(client.buff, 0, XClient.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), client);
                }
                else
                {
                    // disconnect client
                    DisconnectClient(client.id);
                    return;
                }
            }
            catch
            {
                // disconnect client; error operand
                DisconnectClient(client.id);
                return;
            }
        }


        public void Send(XClient client, byte[] data)
        {
            try
            {
                if(client.s.Connected)
                    client.s.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), client.s);
            }
            catch
            {
                return;
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket s = (Socket)ar.AsyncState;
            try
            {
                s.EndSend(ar);
            }
            catch
            {
                return;
            }
        }

        private void HandlePacket(XClient client, byte[] data)
        {
            try
            {
                client.conn.Send(data);
            }
            catch
            {
                return;
            }
        }

        private void BTNKickClient_Click(object sender, EventArgs e)
        {
            try
            {
                if(LBClients.SelectedItem == null) { return; }
                string client_id = (string)LBClients.SelectedItem;
                string parsed = client_id.Split('[')[1];
                string parsed2 = client_id.Split(']')[0];
                string parsed3 = parsed2.Replace("[", "");
                int client = int.Parse(parsed3);
                DisconnectClient(client);
            }
            catch(Exception er)
            {
                MessageBox.Show(er.ToString());
                return;
            }
        }

        private void BTNDisconnectAll_Click(object sender, EventArgs e)
        {
            DisconnectAll();
        }

        private void DisconnectAll()
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                DisconnectClient(Clients[i].id);
            }
        }

        // CLIENT --------------------------------------------------------
       /*
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * */

        public class ClientConnector
        {
            public XClient client;
            public IPEndPoint ip;
            public Socket connector;

            public const int buffer_size = 4096;
            private byte[] buffer = new byte[buffer_size];


            public void Disconnect()
            {
                try
                {
                    connector.Close();
                    connector.Dispose();
                }
                catch
                {
                    return;
                }
            }


            public ClientConnector(XClient _client, IPEndPoint _ip)
            {
                this.client = _client;
                this.ip = _ip;

                try
                {
                    connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    connector.BeginConnect(ip, new AsyncCallback(ConnectCallback), connector);
                }
                catch
                {
                    return;
                }

            }

            private void ConnectCallback(IAsyncResult ar)
            {
                Socket s = (Socket)ar.AsyncState;
                try
                {
                    s.EndConnect(ar);

                    s.BeginReceive(buffer, 0, buffer_size, SocketFlags.None, new AsyncCallback(ReceiveCB), s);
                }
                catch
                {
                    return;
                }
            }


            public void Send(byte[] data)
            {
                try
                {
                    if(connector.Connected)
                    {
                        connector.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), connector);
                    }
                }
                catch
                {
                    return;
                }
            }
            private void SendCallback(IAsyncResult ar)
            {
                try
                {
                    Socket s = (Socket)ar.AsyncState;
                    s.EndSend(ar);
                }
                catch
                {
                    return;
                }
            }

            private void ReceiveCB(IAsyncResult ar)
            {
                Socket s = (Socket)ar.AsyncState;
                try
                {
                    if (!s.Connected) { return; }

                    int received_bytes = s.EndReceive(ar);
                    if(received_bytes > 0)
                    {
                        byte[] data = new byte[received_bytes];
                        Array.Copy(buffer, data, received_bytes);
                        MyForm.Send(client, data);
                        s.BeginReceive(buffer, 0, buffer_size, SocketFlags.None, new AsyncCallback(ReceiveCB), s);
                    }
                }
                catch
                {
                    return;
                }
            }



        }



    }
}
