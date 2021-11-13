using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using proyectoAnalisis.modelos;
using proyectoAnalisis.Conexion;

namespace proyectoAnalisis.data
{
    public class datosMarca
    {
        
          public static bool addMarcas(marcasMod marcasmod)
        {
            using (SqlConnection oConexion = new SqlConnection(rutaConexion.conexionBD))
            {
                SqlCommand cmd = new SqlCommand("sp_marcas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_operacion", 1);

                cmd.Parameters.AddWithValue("@i_estado", marcasmod.estado);
                cmd.Parameters.AddWithValue("@i_nombre", marcasmod.nombre);
                

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
        
        
        
          public static bool editMarcas(marcasMod marcasmod)
        {
            using (SqlConnection oConexion = new SqlConnection(rutaConexion.conexionBD))
            {
                SqlCommand cmd = new SqlCommand("sp_marcas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_operacion", 2);
                cmd.Parameters.AddWithValue("@i_id", marcasmod.id);
                cmd.Parameters.AddWithValue("@i_nombre", marcasmod.nombre);
                

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
        
        
        
        
          public static bool deleteMarcas(marcasMod marcasmod)
        {
            using (SqlConnection oConexion = new SqlConnection(rutaConexion.conexionBD))
            {
                SqlCommand cmd = new SqlCommand("sp_marcas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_operacion", 3);

                cmd.Parameters.AddWithValue("@i_estado", marcasmod.estado);
                cmd.Parameters.AddWithValue("@i_id", marcasmod.id);
                

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



        public static List<marcasMod> listarMarcas()
        {
            List<marcasMod> oListaDatos = new List<marcasMod>();
            using (SqlConnection oConexion = new SqlConnection(rutaConexion.conexionBD))
            {
                SqlCommand cmd = new SqlCommand("sp_marcas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_operacion", 4);
                cmd.Parameters.AddWithValue("@i_estado", 1);

              

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaDatos.Add(new marcasMod()
                            {
                                id = Convert.ToInt32(dr["01"]),
                                nombre = dr["02"].ToString(),
                                
                                estado = Convert.ToInt32(dr["03"])


                            });
                        }
                        return oListaDatos;
                    }


                }
                catch (Exception ex)
                {
                    return oListaDatos;
                }
                finally
                {
                    oConexion.Close();
                }

            }
        }


    }
}
