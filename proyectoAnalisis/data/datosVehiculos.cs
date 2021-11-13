using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendVehiculos.modelos;
namespace BackendVehiculos.data
{
    public class datosVehiculos
    {

        public static bool addVehiculos(vehiculosMod vehiculosmod)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_vehiculos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_operacion", 1);

                cmd.Parameters.AddWithValue("@i_estado", vehiculosmod.estado);
                cmd.Parameters.AddWithValue("@i_idModelo", vehiculosmod.idModelo);
                cmd.Parameters.AddWithValue("@i_placa", vehiculosmod.placa);
                cmd.Parameters.AddWithValue("@i_kilometraje", vehiculosmod.kilometraje);
                cmd.Parameters.AddWithValue("@i_anio", vehiculosmod.anio);
                

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally { oConexion.Close(); }

            }

        }


        public static bool updateVehiculos(vehiculosMod vehiculosmod)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_vehiculos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_operacion", 2);
                
                cmd.Parameters.AddWithValue("@i_idModelo", vehiculosmod.idModelo);
                cmd.Parameters.AddWithValue("@i_placa", vehiculosmod.placa);
                cmd.Parameters.AddWithValue("@i_kilometraje", vehiculosmod.kilometraje);
                cmd.Parameters.AddWithValue("@i_anio", vehiculosmod.anio);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally { oConexion.Close(); }

            }

        }


        public static bool deleteVehiculos(vehiculosMod vehiculosmod)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_vehiculos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_operacion", 3);

                cmd.Parameters.AddWithValue("@i_estado", vehiculosmod.estado);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally { oConexion.Close(); }

            }

        }

    }
}
