using Repaso.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.Persistencia
{
    public class EmpleadoRepository
    {
        public List<Empleado> GetAll()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT EmpleadoId, Nombre, Direccion, Email, Telefono FROM Empleados";
                    var entity = new List<Empleado>();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var e = new Empleado()
                            {
                                EmpleadoId = Convert.ToInt32(reader["EmpleadoId"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                Direccion = Convert.ToString(reader["Direccion"]),
                                Email = Convert.ToString(reader["Email"]),
                                Telefono = Convert.ToString(reader["Telefono"])
                            };
                            entity.Add(e);
                        }
                    }
                    return entity;
                }
            }
        }

        public void Create(Empleado entity)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Empleados(Nombre, Direccion, Email, Telefono)" +
                                     " VALUES(@Nombre, @Direccion, @Email, @Telefono)";
                    cmd.Parameters.AddWithValue("@Nombre", (object)entity.Nombre ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", (object)entity.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)entity.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object)entity.Telefono ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Empleado entity)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Empleados SET Nombre = @Nombre, Direccion = @Direccion, Email = @Email, Telefono = @Telefono" +
                                     " WHERE EmpleadoId = @EmpleadoId";
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@Nombre", (object)entity.Nombre ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", (object)entity.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)entity.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object)entity.Telefono ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public Empleado Single(int id)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT EmpleadoId, Nombre, Direccion, Email, Telefono FROM Empleados" +
                                     " WHERE EmpleadoId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var entity = new Empleado();
                            if (reader.Read())
                            {
                                entity.EmpleadoId = Convert.ToInt32(reader["EmpleadoId"]);
                                entity.Nombre = Convert.ToString(reader["Nombre"]);
                                entity.Direccion = Convert.ToString(reader["Direccion"]);
                                entity.Email = Convert.ToString(reader["Email"]);
                                entity.Telefono = Convert.ToString(reader["Telefono"]);
                            }
                            return entity;
                        }
                        else
                            return null;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Empleados WHERE EmpleadoId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
