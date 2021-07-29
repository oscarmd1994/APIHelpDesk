using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using API_RESTFULL_HELPDESK_APP.Controllers.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace API_RESTFULL_HELPDESK_APP.Models
{
    public class Daos
    {
    }

    public class TipoServicioDao : Conexion
    {
        public List<string> sp_CTipoServicio_Insert(int IdTipoServicio, string Nombre, int Cancelado)
        {
            List<string> res = new List<string>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_CTipoServicio_Insert", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlId", IdTipoServicio));
            cmd.Parameters.Add(new SqlParameter("@ctrlNombre", Nombre));
            cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", Cancelado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    res.Add(data["iFlag"].ToString());
                    res.Add(data["sRespuesta"].ToString());
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return res;
        }
    }
    public class TTicketsDao : Conexion
    {
        public List<vw_TTickets> sp_Tickets_getTickets()
        {
            List<vw_TTickets> tickets = new List<vw_TTickets>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Tickets_getTickets", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            //cmd.Parameters.Add(new SqlParameter("@ctrlId", IdTipoServicio));
            //cmd.Parameters.Add(new SqlParameter("@ctrlNombre", Nombre));
            //cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", Cancelado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    vw_TTickets list = new vw_TTickets
                    {
                        IdTicket = int.Parse(data["IdTicket"].ToString()),
                        Empresa_id = int.Parse(data["Empresa_id"].ToString()),
                        Descripcion_problema = data["Descripcion_problema"].ToString(),
                        Fecha_creacion = DateTime.Parse(data["Fecha_creacion"].ToString()),
                        Modalidad_id = int.Parse(data["Modalidad_id"].ToString()),
                        NombreModalidad = data["NombreModalidad"].ToString(),
                        Status = data["Status"].ToString(),
                        Status_id = int.Parse(data["Status_id"].ToString()),
                        Usuario_asignado = data["Usuario_asignado"].ToString(),
                        Usuario_asignado_id = int.Parse(data["Usuario_asignado_id"].ToString()),
                        Prioridad_id = int.Parse(data["Prioridad_id"].ToString())
                    };

                    tickets.Add(list);
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return tickets;
        }

        public List<vw_TTickets> sp_Tickets_getTicketsEnProceso()
        {
            List<vw_TTickets> tickets = new List<vw_TTickets>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Tickets_getTicketsEnProceso", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            //cmd.Parameters.Add(new SqlParameter("@ctrlId", IdTipoServicio));
            //cmd.Parameters.Add(new SqlParameter("@ctrlNombre", Nombre));
            //cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", Cancelado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    vw_TTickets list = new vw_TTickets
                    {
                        IdTicket = int.Parse(data["IdTicket"].ToString()),
                        Empresa_id = int.Parse(data["Empresa_id"].ToString()),
                        Descripcion_problema = data["Descripcion_problema"].ToString(),
                        Fecha_creacion = DateTime.Parse(data["Fecha_creacion"].ToString()),
                        Modalidad_id = int.Parse(data["Modalidad_id"].ToString()),
                        NombreModalidad = data["NombreModalidad"].ToString(),
                        Status = data["Status"].ToString(),
                        Status_id = int.Parse(data["Status_id"].ToString()),
                        Usuario_asignado = data["Usuario_asignado"].ToString(),
                        Usuario_asignado_id = int.Parse(data["Usuario_asignado_id"].ToString()),
                        Prioridad_id = int.Parse(data["Prioridad_id"].ToString())
                    };

                    tickets.Add(list);
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return tickets;
        }

        public List<DetalleTickets> sp_Tickets_getTicketsByStatus(string Status_id)
        {
            List<DetalleTickets> tickets = new List<DetalleTickets>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Tickets_getTicketsByStatus", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlStatus_id", Status_id));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    DetalleTickets list = new DetalleTickets
                    {
                        idTicket = data["IdTicket"].ToString(),
                        empresaId = data["Empresa_id"].ToString(),
                        nombreEmpresa = data["NombreEmpresa"].ToString(),
                        descripcionProblema = data["Descripcion_problema"].ToString(),
                        modalidadId = data["Modalidad_id"].ToString(),
                        nombreModalidad = data["NombreModalidad"].ToString(),
                        status = data["Status"].ToString(),
                        statusId = data["Status_id"].ToString(),
                        usuarioAsignado = data["Usuario_asignado"].ToString(),
                        usuarioAsignadoId = data["Usuario_asignado_id"].ToString(),
                        usuarioSolicitanteId = data["Usuario_solicitante_id"].ToString(),
                        usuarioSolicitante = data["Usuario_solicitante"].ToString(),
                        prioridad = data["Prioridad"].ToString(),
                        prioridadId = data["Prioridad_id"].ToString(),
                        fechaCreacion = data["Fecha_creacion"].ToString(),
                        fechaAsignacion = data["Fecha_asignacion"].ToString(),
                        fechaProcesamiento = data["Fecha_procesamiento"].ToString(),
                        fechaTermino = data["Fecha_termino"].ToString()
                        
                    };

                    tickets.Add(list);
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return tickets;
        }
        public Respuestas sp_TTickets_insertTickets(TicketData ticket)
        {
            Respuestas respuestas = new Respuestas();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TTickets_insertTickets", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlUser_id", ticket.User_solicitante_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", ticket.Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlModalidad_id", ticket.Modalidad_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlDescripcion_problema", ticket.Descripcion_problema));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    respuestas.iFlag = data["iFlag"].ToString();
                    respuestas.sMessage = data["sMessage"].ToString();
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return respuestas;
        }


    }
    public class ModalidadesDao : Conexion
    {
        public List<CModalidades> sp_CModalidades_getModalidades(int IdTipoServicio)
        {
            List<CModalidades> modalidades = new List<CModalidades>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_CModalidades_getModalidades", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlTipoServicio_id", IdTipoServicio));
            //cmd.Parameters.Add(new SqlParameter("@ctrlNombre", Nombre));
            //cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", Cancelado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    CModalidades list = new CModalidades
                    {
                        Id = int.Parse(data["Id"].ToString()),
                        NombreModalidad = data["NombreModalidad"].ToString(),
                        TipoServicio_id = int.Parse(data["TipoServicio_id"].ToString()),
                        TiempoRespuesta = data["TiempoRespuesta"].ToString(),
                        Cancelado = int.Parse(data["Cancelado"].ToString()),
                        Prioridad_id = int.Parse(data["Prioridad_id"].ToString())
                    };

                    modalidades.Add(list);
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return modalidades;
        }

        public Respuestas sp_CModalidades_insertModalidades(CModalidades modalidades)
        {
            Respuestas respuesta = new Respuestas();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_CModalidades_insertModalidades", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlIdModalidad", modalidades.Id));
            cmd.Parameters.Add(new SqlParameter("@ctrlNombreModalidad", modalidades.NombreModalidad));
            cmd.Parameters.Add(new SqlParameter("@ctrlTipoServicio_id", modalidades.TipoServicio_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlPrioridad_id", modalidades.Prioridad_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlTiempoRespuesta", modalidades.TiempoRespuesta));
            cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", modalidades.Cancelado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    respuesta.iFlag = data["iFlag"].ToString();
                    respuesta.sMessage = data["sMessage"].ToString();
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return respuesta;
        }

    }
    public class UsuariosDao : Conexion
    {
        public List<TUsuarios> sp_TUsuarios_getUsuarios(int IdUser)
        {
            List<TUsuarios> usuarios = new List<TUsuarios>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TUsuarios_getUsuarios", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlIdUsuario", IdUser));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    TUsuarios list = new TUsuarios
                    {
                        IdUsuario = int.Parse(data["IdUsuario"].ToString()),
                        TipoUser_id = int.Parse(data["TipoUser_id"].ToString()),
                        Nombre = data["Nombre"].ToString(),
                        Paterno = data["Paterno"].ToString(),
                        Materno = data["Materno"].ToString(),
                        Usuario = data["Usuario"].ToString(),
                        Email = data["Email"].ToString(),
                        Passw = data["Passw"].ToString(),
                        Cancelado = int.Parse(data["Cancelado"].ToString())

                    };

                    usuarios.Add(list);
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return usuarios;
        }

        public Respuestas sp_TUsuarios_getValidaUser(string user, string pass)
        {
            Respuestas respuesta = new Respuestas();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TUsuarios_getValidaUser", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", user));
            cmd.Parameters.Add(new SqlParameter("@ctrlPassword", pass));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    respuesta.iFlag = data["iFlag"].ToString();
                    respuesta.sMessage = data["sMessage"].ToString();
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();
            return respuesta;
        }

        public UserData sp_TUsuarios_getUserData(VUser user)
        {
            UserData userData = new UserData();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TUsuarios_getUserData", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", user.user));
            cmd.Parameters.Add(new SqlParameter("@ctrlPassword", user.pass));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    userData.IdUsuario = data["IdUsuario"].ToString();
                    userData.Nombre = data["Nombre"].ToString();
                    userData.Paterno = data["Paterno"].ToString();
                    userData.Materno = data["Materno"].ToString();
                    userData.Email = data["Email"].ToString();
                    userData.TipoUser = data["TipoUser"].ToString();
                    userData.TipoUser_id = data["TipoUser_id"].ToString();
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();
            return userData;
        }

        public Respuestas sp_TUsuarios_insertUsuarios(CModalidades modalidades)
        {
            Respuestas respuesta = new Respuestas();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_CModalidades_insertModalidades", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlIdModalidad", modalidades.Id));
            cmd.Parameters.Add(new SqlParameter("@ctrlNombreModalidad", modalidades.NombreModalidad));
            cmd.Parameters.Add(new SqlParameter("@ctrlTipoServicio_id", modalidades.TipoServicio_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlPrioridad_id", modalidades.Prioridad_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlTiempoRespuesta", modalidades.TiempoRespuesta));
            cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", modalidades.Cancelado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    respuesta.iFlag = data["iFlag"].ToString();
                    respuesta.sMessage = data["sMessage"].ToString();
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return respuesta;
        }

        public Respuestas sp_TUsuarios_SaveToken(NewToken token)
        {
            Respuestas respuesta = new Respuestas();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("TUsuarios_saveToken", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlUser", token.User));
            cmd.Parameters.Add(new SqlParameter("@ctrlToken", token.token));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    respuesta.iFlag = data["iFlag"].ToString();
                    respuesta.sMessage = data["sMessage"].ToString();
                }
            }

            data.Close();
            this.conexion.Close(); this.Conectar().Close();

            return respuesta;
        }

    }
}
