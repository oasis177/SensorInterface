using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace SensorScreeen
{
    public class SocketClient
    {
        public string IPdest;
        public string IPsrc;
        public int portD;
        public int portS;
        private Socket s;
        public SocketClient(int PuertoOrigen,string IPDestino,int puertoDestino)
        {
            portD = puertoDestino;
            portS = PuertoOrigen;
            IPdest = IPDestino;
            IPsrc = Functions.GetLocalIPAddress();
        }
        public int InitConnection(ref Prueba CurrProv)
        {
            //TRAMA INICI
            // Opcode (1byte) / Ej.Trab (2byte) / NumTra (2byte) / AC/DC (1byte) / Voltage(2byte) / num.Sensors (1byte) / [ nomSensor(6byte) / idSensor(1byte) ... ]
            byte[] buff = new byte[(CurrProv.Sensors.Count * 7) + 9];
            byte[] BConv = new byte[2];
            byte[] SensB = new byte[6];
            Buffer.SetByte(buff, 0, (byte)CurrProv.Cabezales);
            BConv = BitConverter.GetBytes(CurrProv.EjTra);
            Buffer.BlockCopy(BConv, 0, buff, 1, 2);
            BConv = BitConverter.GetBytes(CurrProv.NumTra);
            Buffer.BlockCopy(BConv, 0, buff, 3, 2);
            Buffer.SetByte(buff, 5, (byte)CurrProv.VoltageType);
            BConv = BitConverter.GetBytes(CurrProv.Voltage);
            Buffer.BlockCopy(BConv, 0, buff, 6, 2);
            Buffer.SetByte(buff, 8, (byte)CurrProv.Sensors.Count);
            
            for (int i = 0; i < CurrProv.Sensors.Count; i++)
            {
                SensB = Encoding.ASCII.GetBytes(CurrProv.Sensors[i].name);
                Buffer.BlockCopy(SensB,0,buff, 9 + (i * 7), 6);
                Buffer.SetByte(buff, 15+(i*7), (byte)CurrProv.Sensors[i].index);
            }
           
            //CREAMOS SOCKET
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IPsrc ), portS);
            s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                s.Connect(IPAddress.Parse(IPdest ), portD);
                int sensc = s.Send(buff);
                //s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int newBomb(ref Prueba CurrProv,string numser)
        {
            byte[] buff = new byte[11];
            byte[] BLong = new byte[4];
            byte[] BShort = new byte[2];
            long NS = long.Parse(numser);
            Buffer.SetByte(buff, 0, 11);
            BLong = BitConverter.GetBytes(NS);
            Buffer.BlockCopy(BLong, 0, buff, 1, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(CurrProv.Numeros[numser][0].TimeVacMax), 0, buff, 5, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(CurrProv.Numeros[numser][0].TimeEst), 0, buff, 7, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(CurrProv.Numeros[numser][0].TimePerdida), 0, buff, 9, 2);
            return (s.Send(buff));
        }
        public void Listen(ref int OpC, ref long NSerie, ref float Value)
        {
            byte[] buff = new byte[9];
            int Lis = s.Receive(buff);

            if (Lis > 0)
            {
                OpC = Buffer.GetByte(buff, 0);
                NSerie = BitConverter.ToInt32(buff, 1);
                if (OpC != 150)
                {
                    Value = BitConverter.ToSingle(buff, 5);
                }             
            }
            //System.IO.StreamWriter f1 = new System.IO.StreamWriter(@"\\servidorsql\Datos\Informatica\Buffer.txt", true);
            //f1.WriteLine(OpC.ToString() + "\t" + NSerie.ToString() + "\t" + Value.ToString());
            //f1.Close();
          
        }
        public void StopConnection()
        {
            byte[] buff = new byte[1];
            Buffer.SetByte(buff, 0, 151);
            s.Send(buff);
        }
    }
}
