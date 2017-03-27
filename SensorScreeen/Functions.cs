using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SensorScreeen
{
    public static class Functions
    {

        public const string sqlDB = "Data Source=np:SERVIDORSQL;Password=Class1!;User ID=sa;Initial Catalog=ElectroAD;Connect Timeout=150";
        public static bool IsNumeric(this string s) //Para saber si una string es convertible a float
        {
            float output;
            return float.TryParse(s, out output);
        }
        public static string QuitarR(this string s) //Quita la R del inicio de una String (p.ej SeriePedido)
        {
            if (s.StartsWith("R")) return (s.Substring(1));
            else return s;
        }
        public static string GetLocalIPAddress() //Nos da la IP local del terminal
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
        public static string Rellenar0s(long NS)
        {
            String ret = NS.ToString();
            while (ret.Length < 7)
            {
                ret = "0" + ret;
            }
            return (ret);
        }
        public static string Rellenar0s(string NS)
        {
            String ret = NS.ToString();
            while (ret.Length < 7)
            {
                ret = "0" + ret;
            }
            return (ret);
        }
        public static void GetNumTrabajo(ref int EjTra, ref int NumTra, string SPed, int NumPed, short orden) {
            var sql = new System.Data.SqlClient.SqlConnection(sqlDB);
            string sqlStr = @"SELECT      OrdenesTrabajo.EjercicioTrabajo, OrdenesTrabajo.NumeroTrabajo
                        FROM EstadoPedidosClientes INNER JOIN
                        OrdenesFabricacion ON EstadoPedidosClientes.CodigoEmpresa = OrdenesFabricacion.CodigoEmpresa AND
                        EstadoPedidosClientes.IdOFabricacion = OrdenesFabricacion.Identificador INNER JOIN
                        OrdenesTrabajo ON OrdenesFabricacion.CodigoArticulo = OrdenesTrabajo.CodigoArticulo AND
                        OrdenesFabricacion.EjercicioFabricacion = OrdenesTrabajo.EjercicioFabricacion AND OrdenesFabricacion.SerieFabricacion = OrdenesTrabajo.SerieFabricacion AND
                        OrdenesFabricacion.NumeroFabricacion = OrdenesTrabajo.NumeroFabricacion
                        WHERE (EstadoPedidosClientes.SeriePedido = '" + SPed + "') AND (EstadoPedidosClientes.NumeroPedido = "+NumPed +  ") AND (EstadoPedidosClientes.OrdenLineas = "+ orden + ")";
            var cmd = new System.Data.SqlClient.SqlCommand(sqlStr, sql);
            sql.Open();
            System.Data.SqlClient.SqlDataReader resp = cmd.ExecuteReader();
            if (resp.HasRows){
                while (resp.Read()) {
                    //var aux = resp["EjercicioTrabajo"];
                    EjTra = (Int16)(resp["EjercicioTrabajo"]);
                    NumTra = (Int32)(resp["NumeroTrabajo"]);
                }
            }
            sql.Close();
        }
    }
}
