using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace Todo_Mascota.Models.ejecuta
{
    public class ConexionOracle : Conexion
    {
        OracleConnection conexion;
        OracleCommand comando;
        OracleDataAdapter adaptador;

        // metodo que instancia los objetos de conexion
        protected void conectar()
        {
            try
            {
                conexion = new OracleConnection(cadena_conexion);
                comando = new OracleCommand();
                comando.Connection = conexion;
                adaptador = new OracleDataAdapter();
            }
            catch { }
        }

        // consulta basica select, update o delete
        public string EjecutaQuery(string consulta)
        {
            try
            {

                string sentencia = consulta.Split(' ').First().ToUpper().Trim();

                conectar();
                comando.CommandText = consulta;
                comando.CommandTimeout = timeout;
                conexion.Open();

                Object reader = "";

                switch (sentencia)
                {
                    case "SELECT":
                        reader = comando.ExecuteScalar();
                        break;
                    case "EXECUTE":
                        comando.CommandType = CommandType.StoredProcedure;
                        //reader = comando.ExecuteNonQuery();
                        var dr = comando.ExecuteReader();
                        break;
                    default:
                        reader = comando.ExecuteNonQuery();
                        break;

                }

                if (reader != null)
                {
                    conexion.Close();
                    conexion.Dispose();
                    if (reader.ToString() == "1") return "OK";
                    else return "ERROR";
                }
                else
                {
                    conexion.Close();
                    conexion.Dispose();
                    return "ERROR CONEXION";
                }
            }
            catch (Exception exp)
            {
                string error= exp.ToString();
                return null;
            }
        }

        public string EjecutaQuery_Execute(string idsubclase, string precioproducto, string costoproducto, string idcolor, string largotamano, string anchotamano, string altotamano, string nombretamano, string idmaterial, string idmascotas, string unidadpesosproducto, string cantpesoproducto)
        {
            try
            {
                conectar();
                comando.CommandTimeout = timeout;
                conexion.Open();
                //comando.CommandType = CommandType.StoredProcedure;
                Object reader = "";

                comando.CommandText = "ADDPRODUCTO";
                comando.Parameters.Add(new OracleParameter("IDSUBCLASE", OracleType.Number)).Value = idsubclase;
                comando.Parameters.Add(new OracleParameter("PRECIOPRODUCTO", OracleType.Number)).Value = precioproducto;
                comando.Parameters.Add(new OracleParameter("COSTOPRODUCTO", OracleType.Number)).Value = costoproducto;
                if (idmaterial == "")
                {
                    comando.Parameters.Add(new OracleParameter("IDCOLOR", OracleType.Number)).Value = DBNull.Value;
                }
                else { comando.Parameters.Add(new OracleParameter("IDCOLOR", OracleType.Number)).Value = idcolor; }
               
                comando.Parameters.Add(new OracleParameter("LARGOTAMANO", OracleType.Number)).Value = largotamano;
                comando.Parameters.Add(new OracleParameter("ANCHOTAMANO", OracleType.Number)).Value = anchotamano;
                comando.Parameters.Add(new OracleParameter("ALTOTAMANO", OracleType.Number)).Value = altotamano;
                comando.Parameters.Add(new OracleParameter("NOMBRETAMANO", OracleType.VarChar)).Value = nombretamano;
                if (idmaterial == "")
                {
                    comando.Parameters.Add(new OracleParameter("IDMATERIAL", OracleType.Number)).Value = DBNull.Value;
                }
                else { comando.Parameters.Add(new OracleParameter("IDMATERIAL", OracleType.Number)).Value = idmaterial; }
                if (idmaterial == "")
                {
                    comando.Parameters.Add(new OracleParameter("IDMASCOTAS", OracleType.Number)).Value = DBNull.Value;
                }
                else { comando.Parameters.Add(new OracleParameter("IDMASCOTAS", OracleType.Number)).Value = idmascotas; }

                
                comando.Parameters.Add(new OracleParameter("UNIDADPESOSPRODUCTO", OracleType.VarChar)).Value = unidadpesosproducto;
                comando.Parameters.Add(new OracleParameter("CANTPESOPRODUCTO", OracleType.Number)).Value = cantpesoproducto;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                reader = comando.ExecuteNonQuery();

                if (reader != null)
                {
                    conexion.Close();
                    conexion.Dispose();
                    if (reader.ToString() == "1") return "OK";
                    else return "ERROR";
                }
                else
                {
                    conexion.Close();
                    conexion.Dispose();
                    return "ERROR CONEXION";
                }
            }
            catch (Exception exp)
            {
                string error = exp.ToString();
                return null;
            }
        }

        // retorna un select en forma de datatable
        public DataTable EjecutaQuery_DT(string sql)
        {
            try
            {
                conectar();
               
                /*
                comando.CommandText = sql;
                comando.CommandTimeout = timeout;
                conexion.Open();
                
                OracleDataReader dataReader = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataReader.Dispose();
                dataReader.Close();
                conexion.Close();
                comando.Dispose();
                */
                
                DataTable dt = new DataTable();
                comando.CommandText = sql;
                comando.CommandTimeout = timeout;
                conexion.Open();

                adaptador.SelectCommand = comando;
                adaptador.Fill(dt);
                conexion.Close();
                comando.Dispose();
                
                return dt;
            }
            catch { return null; }
        }
        /*
        //public List<List<String>> GetTagList(string sql)
        //public IEnumerable<string> GetTagList(string sql)
        public List<Tuple<string, string>> GetTagList(string sql)
        {
            //var tagsList = new List<Tuple<string, string>>();
            //List<List<String>> tagsList = new List<List<String>>(); //Creates new nested List
            List<Tuple<string, string>> tagsList = new List<Tuple<string, string>>(); //Creates new nested List
          
            conectar();
            comando.CommandText = sql;
            comando.CommandTimeout = timeout;
            conexion.Open();

            using (OracleDataReader reader = comando.ExecuteReader())
            {
                
                int indice = 0;
                while (reader.Read())
                {
                    tagsList.Add(new Tuple<string, string>()); //Adds new sub List
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string v_colname = reader.GetName(i).ToString();


                        //tagsList[v_colname].Add(reader.GetName(i));
                        //tagsList[v_colname].Add(reader.GetValue(i).ToString());
                        //tagsList.Add(new Tuple<string, string>(reader.GetName(i), reader.GetValue(i).ToString()));
                        tagsList[indice].Add(Tuple.Create(reader.GetName(i), reader.GetValue(i).ToString()));
                    }
                    indice++;
                }
                
                reader.Close();
            }
            
            conexion.Close();

            return tagsList;
        }
         */
    }
}