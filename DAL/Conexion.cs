using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using BLL;
using System.Data;
using CapaComun;

namespace DAL
{
    public class Conexion
    {
        private SqlConnection conection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private SqlDataReader dataReader;

        //contenedor de datos
        private DataSet dataSet;

        //variable para almacenar el string de conexion
        private string strConexion;

        //constructor de la clase
        public Conexion(string strCnx)
        {
            this.strConexion = strCnx;
        }

        public void AgregarEmpleado(Empleados empleados)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Ins_Empleado]";

                //se asignan los valores a cada parametro
                this.command.Parameters.AddWithValue("@Cedula", empleados.cedula);
                this.command.Parameters.AddWithValue("@NombreCompleto", empleados.nombreCompleto);
                this.command.Parameters.AddWithValue("@FechaNacimiento", empleados.fechaNaciemiento);
                this.command.Parameters.AddWithValue("@Direccion", empleados.direccion);
                this.command.Parameters.AddWithValue("@Telefono", empleados.telefono);
                this.command.Parameters.AddWithValue("@Email", empleados.email);
                this.command.Parameters.AddWithValue("@Cargo", empleados.cargo);
                // this.command.Parameters.AddWithValue("@Foto", empleados.foto);
                //aqui asiganamos al parametro la foto de usuario
                this.command.Parameters.Add(new SqlParameter("@Foto", SqlDbType.Image)).Value = empleados.foto;

                this.command.ExecuteNonQuery();
                this.conection.Close();

                this.conection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo agregar empleados

        public void AgregarUsuario(Usuarios usuarios)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Ins_Usuario]";

                //se asignan los valores a cada parametro
                this.command.Parameters.AddWithValue("@IdEmpleado", usuarios.idEmpleado);
                this.command.Parameters.AddWithValue("@Login", usuarios.login);
                this.command.Parameters.AddWithValue("@Password", usuarios.password);
                this.command.Parameters.AddWithValue("@Email", usuarios.email);
                this.command.Parameters.AddWithValue("@Rol", usuarios.rol);

                //aqui asiganamos al parametro la foto de usuario
                //this.command.Parameters.Add(new SqlParameter("@Foto", SqlDbType.Image)).Value = pUser.Foto;

                this.command.ExecuteNonQuery();
                this.conection.Close();

                this.conection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo agregar usuario
        public DataSet BuscarIdEmpleadoFrmUsuario(string pnombreCompleto)
        {
            try
            {
                //se instancia una conexion
                this.conection = new SqlConnection(this.strConexion);
                //se intenta abrir
                this.conection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //se asigna la conexion al comando
                this.command.Connection = this.conection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento almacenado 
                this.command.CommandText = "[Sp_Cns_idEmpleadoFrmUsuarios]";
                //asignamos el valor al parametro del procedimiento
                this.command.Parameters.AddWithValue("@nombreCompleto", pnombreCompleto);
                //se instancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia el comando al adaptador
                this.dataAdapter.SelectCommand = this.command;
                //se instancia un dataset con los datos del comando
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.conection.Close();
                //se liberan los recursosr
                this.conection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();

                //se retorna el DataSet
                return this.dataSet;

            }

            catch (Exception ex)
            {

                throw;
            }
        }//fin de metodo buscar empleado por ID

        public DataSet BuscarEmpleados(string pNombreCompleto)
        {
            try
            {
                //se instancia una conexion
                this.conection = new SqlConnection(this.strConexion);
                //se intenta abrir
                this.conection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //se asigna la conexion al comando
                this.command.Connection = this.conection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento almacenado 
                this.command.CommandText = "[Sp_Cns_Empleados]";
                //asignamos el valor al parametro del procedimiento
                this.command.Parameters.AddWithValue("@Nombrecompleto", pNombreCompleto);
                //se instancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia el comando al adaptador
                this.dataAdapter.SelectCommand = this.command;
                //se instancia un dataset con los datos del comando
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.conection.Close();
                //se liberan los recursosr
                this.conection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();

                //se retorna el DataSet
                return this.dataSet;

            }

            catch (Exception ex)
            {

                throw;
            }
        }//fin de metodo buscar empleados

        public void eliminarEmpleado(int idEmpleado)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Del_Empleado]";

                this.command.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                this.command.ExecuteNonQuery();
                this.conection.Close();
                this.command.Dispose();
                this.conection.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }//fin de metodo eliminarEmpleado
        public Empleados consultarEmpleado(string nombreCompleto)
        {
            try
            {
                //variabl para almacenar los datos del usuario dentro del obj
                Empleados temp = null;

                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Datos_Empleado]";
                //se asigna el valor al parametro
                this.command.Parameters.AddWithValue("@nombreCompleto ", nombreCompleto);

                //muy importe el comando es de lectura ExecuteReader
                this.dataReader = this.command.ExecuteReader();

                //se pregunta si el lector tiene datos
                if (this.dataReader.Read())
                {
                    //se crea una instancia del obj usuario
                    temp = new Empleados();

                    //rellenamos el obj con los datos que nos retorna el proce almacenado
                    temp.cedula = Int32.Parse(this.dataReader.GetValue(1).ToString());
                    temp.nombreCompleto = this.dataReader.GetValue(2).ToString();
                    temp.fechaNaciemiento = DateTime.Parse(this.dataReader.GetValue(3).ToString());
                    temp.direccion = this.dataReader.GetValue(4).ToString();
                    temp.telefono = this.dataReader.GetValue(5).ToString();
                    temp.email = this.dataReader.GetValue(6).ToString();
                    temp.cargo = this.dataReader.GetValue(7).ToString();

                    //se pregunta si existe una foto
                    if (!Convert.IsDBNull(this.dataReader.GetValue(8)))
                    {
                        //importante realizar un parse del varbinary a un vector de byte[]
                        temp.foto = (byte[])this.dataReader.GetValue(8);
                    }
                    else
                    {
                        temp.foto = null;
                    }
                }
                //cerrar la conexion
                this.conection.Close();

                //liberacion de recursos
                this.conection.Dispose();
                this.command.Dispose();
                this.dataReader = null;

                //se retorna el obj usuario con los datos facilitados por el stored procedure
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo consultar empleados

        public void modificarEmpleado(Empleados empleado)
        {
            try
            {
                //se instancia la conex
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_upd_Empleado]";

                this.command.Parameters.AddWithValue("@Cedula", empleado.cedula);
                this.command.Parameters.AddWithValue("@NombreCompleto", empleado.nombreCompleto);
                this.command.Parameters.AddWithValue("@FechaNacimiento", empleado.fechaNaciemiento);
                this.command.Parameters.AddWithValue("@Direccion", empleado.direccion);
                this.command.Parameters.AddWithValue("@Telefono", empleado.telefono);
                this.command.Parameters.AddWithValue("@Email", empleado.email);
                this.command.Parameters.AddWithValue("@Cargo", empleado.cargo);
                this.command.Parameters.AddWithValue("@Foto", empleado.foto);

                this.command.ExecuteNonQuery();
                this.conection.Close();
                this.command.Dispose();
                this.conection.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo modificar usuario

        public bool autenticacion(Usuarios pUser)
        {
            try
            {
                 
                bool autorizado = false;
                //se crea una instancia de la conexion
                this.conection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexion
                this.conection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //se asigna la conexion
                this.command.Connection = this.conection;
                //se indica el tipo de comando
                this.command.CommandType = System.Data.CommandType.StoredProcedure;
                //s asigna el nombre del procedimiento almacenado
                this.command.CommandText = "[Sp_Cns_Usuario]";
                //asignacion de valores a cada parametro
                this.command.Parameters.AddWithValue("@login", pUser.login);
                this.command.Parameters.AddWithValue("@Password", pUser.password);

                //realizar lectura de los datos del usuario
                this.dataReader = this.command.ExecuteReader(); 

                //se pregunta si existen los datos
                if (this.dataReader.Read())
                {
                    autorizado = true;

                    UserLogin.password = this.dataReader.GetString(0);
                    UserLogin.login = this.dataReader.GetString(3);
                    UserLogin.rol = this.dataReader.GetString(1);

                    if (!Convert.IsDBNull(this.dataReader.GetValue(4)))
                    {
                        //importante realizar un parse del varbinary a un vector de byte[]
                        UserLogin.foto = (byte[])this.dataReader.GetValue(4);
                    }
                    else
                    {
                        UserLogin.foto = null;
                    }

                }



                return autorizado;
                

                // return autorizado;
            }
            
            catch (Exception)
            {

                throw;
            }
            
        }//fin de metodo autenticacion

        public DataSet BuscarUsuarios(string pLogin)
        {
            try
            {
                //se instancia una conexion
                this.conection = new SqlConnection(this.strConexion);
                //se intenta abrir
                this.conection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //se asigna la conexion al comando
                this.command.Connection = this.conection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento almacenado 
                this.command.CommandText = "[Sp_Cns_DatosUsuario]";
                //asignamos el valor al parametro del procedimiento
                this.command.Parameters.AddWithValue("@login", pLogin);
                //se instancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia el comando al adaptador
                this.dataAdapter.SelectCommand = this.command;
                //se instancia un dataset con los datos del comando
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.conection.Close();
                //se liberan los recursosr
                this.conection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();

                //se retorna el DataSet
                return this.dataSet;
            }

            catch (Exception ex)
            {

                throw;
            }
        }//fin de buscarUsuario

        public void eliminarUsuario(string login)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Del_Usuario]";

                this.command.Parameters.AddWithValue("@login", login);

                this.command.ExecuteNonQuery();
                this.conection.Close();
                this.command.Dispose();
                this.conection.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }//fin de metodo eliminarUsuario

        public Usuarios consultarUsuario(string login)
        {
            try
            {
                //variabl para almacenar los datos del usuario dentro del obj
                Usuarios temp = null;

                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_DatosTablaUsuario]";
                //se asigna el valor al parametro
                this.command.Parameters.AddWithValue("@login", login);

                //muy importe el comando es de lectura ExecuteReader
                this.dataReader = this.command.ExecuteReader();

                //se pregunta si el lector tiene datos
                if (this.dataReader.Read())
                {
                    //se crea una instancia del obj usuario
                    temp = new Usuarios();

                    //rellenamos el obj con los datos que nos retorna el proce almacenado
                    temp.idEmpleado = Int32.Parse(this.dataReader.GetValue(0).ToString());
                    temp.login = this.dataReader.GetValue(1).ToString();
                    temp.email = this.dataReader.GetValue(2).ToString();
                    temp.rol = this.dataReader.GetValue(3).ToString();

                }
                //cerrar la conexion
                this.conection.Close();

                //liberacion de recursos
                this.conection.Dispose();
                this.command.Dispose();
                this.dataReader = null;

                //se retorna el obj usuario con los datos facilitados por el stored procedure
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo consultarUsuario

        public void modificarUsuario(Usuarios usuarios)
        {
            try
            {
                //se instancia la conex
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_upd_Usuario]";

                this.command.Parameters.AddWithValue("@IdEmpleado", usuarios.idEmpleado);
                this.command.Parameters.AddWithValue("@Login", usuarios.login);
                this.command.Parameters.AddWithValue("@Password", usuarios.password);
                this.command.Parameters.AddWithValue("@Email", usuarios.email);
                this.command.Parameters.AddWithValue("@Rol", usuarios.rol); 

                this.command.ExecuteNonQuery();
                this.conection.Close();
                this.command.Dispose();
                this.conection.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo modificar usuario

        public void AgregarEntrevista(Entrevista entrevista)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Ins_Entrevista]";

                //se asignan los valores a cada parametro
                this.command.Parameters.AddWithValue("@Login", entrevista.login);
                this.command.Parameters.AddWithValue("@NombreCompleto", entrevista.nombreCompleto);
                this.command.Parameters.AddWithValue("@Cedula", entrevista.cedula);
                this.command.Parameters.AddWithValue("@Telefono", entrevista.telefono);
                this.command.Parameters.AddWithValue("@Email", entrevista.email);
                this.command.Parameters.AddWithValue("@Direccion", entrevista.direccion);
                this.command.Parameters.AddWithValue("@RubroPresentacion", entrevista.rubroPresentacion);
                this.command.Parameters.AddWithValue("@RubroHabilidadesBlandas", entrevista.rubroHabilidadesBlandas);
                this.command.Parameters.AddWithValue("@RubroHabilidadesComportamiento", entrevista.rubroHabilidadesComportamiento);
                this.command.Parameters.AddWithValue("@RubroHabilidadesSituacionales", entrevista.rubroHabilidadesSituacionales);
                this.command.Parameters.AddWithValue("@RubroHabilidadesDuras", entrevista.rubroHabilidadesDuras);
                this.command.Parameters.AddWithValue("@CalificacionFinal", entrevista.calificacionFinal);

                this.command.ExecuteNonQuery();
                this.conection.Close();

                this.conection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo agregar empleados

        public void modificarEntrevista(Entrevista entrevista)
        {
            try
            {
                //se instancia la conex
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_upd_Candidato]";

                this.command.Parameters.AddWithValue("@Login", entrevista.login);
                this.command.Parameters.AddWithValue("@NombreCompleto", entrevista.nombreCompleto);
                this.command.Parameters.AddWithValue("@Cedula", entrevista.cedula);
                this.command.Parameters.AddWithValue("@Telefono", entrevista.telefono);
                this.command.Parameters.AddWithValue("@Email", entrevista.email);
                this.command.Parameters.AddWithValue("@Direccion", entrevista.direccion);
                this.command.Parameters.AddWithValue("@RubroPresentacion", entrevista.rubroPresentacion);
                this.command.Parameters.AddWithValue("@RubroHabilidadesBlandas", entrevista.rubroHabilidadesBlandas);
                this.command.Parameters.AddWithValue("@RubroHabilidadesComportamiento", entrevista.rubroHabilidadesComportamiento);
                this.command.Parameters.AddWithValue("@RubroHabilidadesSituacionales", entrevista.rubroHabilidadesSituacionales);
                this.command.Parameters.AddWithValue("@RubroHabilidadesDuras", entrevista.rubroHabilidadesDuras);
                this.command.Parameters.AddWithValue("@CalificacionFinal", entrevista.calificacionFinal);

                this.command.ExecuteNonQuery();
                this.conection.Close();
                this.command.Dispose();
                this.conection.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet buscarCandidatos(string pNombre)
        {
            try
            {
                //se instancia una conexion
                this.conection = new SqlConnection(this.strConexion);
                //se intenta abrir
                this.conection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //se asigna la conexion al comando
                this.command.Connection = this.conection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento almacenado 
                this.command.CommandText = "[Sp_Cns_DatosTablaCandidato]";
                //asignamos el valor al parametro del procedimiento
                this.command.Parameters.AddWithValue("@nombreCompleto", pNombre);
                //se instancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia el comando al adaptador
                this.dataAdapter.SelectCommand = this.command;
                //se instancia un dataset con los datos del comando
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.conection.Close();
                //se liberan los recursosr
                this.conection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();

                //se retorna el DataSet
                return this.dataSet;
            }

            catch (Exception ex)
            {

                throw;
            }
        }//fin de buscarCandidato

        public Entrevista consultarCandidato(int cedula)
        {
            try
            {
                //variabl para almacenar los datos del usuario dentro del obj
                Entrevista temp = null;

                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Datos_Candidato]";
                //se asigna el valor al parametro
                this.command.Parameters.AddWithValue("@cedula", cedula);

                //muy importe el comando es de lectura ExecuteReader
                this.dataReader = this.command.ExecuteReader();

                //se pregunta si el lector tiene datos
                if (this.dataReader.Read())
                {
                    //se crea una instancia del obj usuario
                    temp = new Entrevista();

                    //rellenamos el obj con los datos que nos retorna el proce almacenado
                    temp.login = this.dataReader.GetValue(1).ToString();
                    temp.nombreCompleto = this.dataReader.GetValue(2).ToString();
                    temp.cedula = Int32.Parse(this.dataReader.GetValue(3).ToString());
                    temp.telefono = this.dataReader.GetValue(4).ToString();
                    temp.email = this.dataReader.GetValue(5).ToString();
                    temp.direccion = this.dataReader.GetValue(6).ToString();
                    temp.rubroPresentacion = Int32.Parse(this.dataReader.GetValue(7).ToString());
                    temp.rubroHabilidadesBlandas = Int32.Parse(this.dataReader.GetValue(8).ToString());
                    temp.rubroHabilidadesComportamiento = Int32.Parse(this.dataReader.GetValue(9).ToString());
                    temp.rubroHabilidadesSituacionales = Int32.Parse(this.dataReader.GetValue(10).ToString());
                    temp.rubroHabilidadesDuras = Int32.Parse(this.dataReader.GetValue(11).ToString());
                }
                //cerrar la conexion
                this.conection.Close();

                //liberacion de recursos
                this.conection.Dispose();
                this.command.Dispose();
                this.dataReader = null;

                //se retorna el obj usuario con los datos facilitados por el stored procedure
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de consultar candidato

        public void eliminarCandidato(int cedula)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Del_Candidato]";

                this.command.Parameters.AddWithValue("@cedula", cedula);

                this.command.ExecuteNonQuery();
                this.conection.Close();
                this.command.Dispose();
                this.conection.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }//fin de metodo eliminarCandidato

        public void agregarEvaluacion(Evaluacion evaluacion)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Ins_Evaluacion]";

                //se asignan los valores a cada parametro
                this.command.Parameters.AddWithValue("@Login", evaluacion.login);
                this.command.Parameters.AddWithValue("@NombreEmpleado", evaluacion.nombreEmpleado);
                this.command.Parameters.AddWithValue("@Cedula", evaluacion.cedula);
                this.command.Parameters.AddWithValue("@Puntualidad", evaluacion.puntualidad);
                this.command.Parameters.AddWithValue("@Logros", evaluacion.logros);
                this.command.Parameters.AddWithValue("@TrabajoEnEquipo", evaluacion.trabajoEnEquipo);
                this.command.Parameters.AddWithValue("@DesempenoIndividual", evaluacion.desempenoIndividual);
                this.command.Parameters.AddWithValue("@HabilidadesTecnicas", evaluacion.habilidadesTecnicas);
                this.command.Parameters.AddWithValue("@CalificacionFinal", evaluacion.calificacionFinal);

                this.command.ExecuteNonQuery();
                this.conection.Close();

                this.conection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo agregar evaluacion

        public Evaluacion consultarEvaluacion(int cedula)
        {
            try
            {
                //variabl para almacenar los datos del usuario dentro del obj
                Evaluacion temp = null;

                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_Datos_Evaluacion]";
                //se asigna el valor al parametro
                this.command.Parameters.AddWithValue("@cedula", cedula);

                //muy importe el comando es de lectura ExecuteReader
                this.dataReader = this.command.ExecuteReader();

                //se pregunta si el lector tiene datos
                if (this.dataReader.Read())
                {
                    //se crea una instancia del obj usuario
                    temp = new Evaluacion();

                    //rellenamos el obj con los datos que nos retorna el proce almacenado
                    //temp.login = this.dataReader.GetValue(0).ToString();
                    temp.nombreEmpleado = this.dataReader.GetValue(1).ToString();
                    temp.cedula = Int32.Parse(this.dataReader.GetValue(2).ToString());
                    temp.puntualidad = Int32.Parse(this.dataReader.GetValue(3).ToString());
                    temp.logros = Int32.Parse(this.dataReader.GetValue(4).ToString());
                    temp.trabajoEnEquipo = Int32.Parse(this.dataReader.GetValue(5).ToString());
                    temp.desempenoIndividual = Int32.Parse(this.dataReader.GetValue(6).ToString());
                    temp.habilidadesTecnicas = Int32.Parse(this.dataReader.GetValue(7).ToString());
                }
                //cerrar la conexion
                this.conection.Close();

                //liberacion de recursos
                this.conection.Dispose();
                this.command.Dispose();
                this.dataReader = null;

                //se retorna el obj usuario con los datos facilitados por el stored procedure
                return temp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de consultar evaluacion

        public void modificarEvaluacion(Evaluacion evaluacion)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_upd_Evaluacion]";

                //se asignan los valores a cada parametro
                this.command.Parameters.AddWithValue("@Login", evaluacion.login);
                this.command.Parameters.AddWithValue("@NombreEmpleado", evaluacion.nombreEmpleado);
                this.command.Parameters.AddWithValue("@Cedula", evaluacion.cedula);
                this.command.Parameters.AddWithValue("@Puntualidad", evaluacion.puntualidad);
                this.command.Parameters.AddWithValue("@Logros", evaluacion.logros);
                this.command.Parameters.AddWithValue("@TrabajoEnEquipo", evaluacion.trabajoEnEquipo);
                this.command.Parameters.AddWithValue("@DesempenoIndividual", evaluacion.desempenoIndividual);
                this.command.Parameters.AddWithValue("@HabilidadesTecnicas", evaluacion.habilidadesTecnicas);
                this.command.Parameters.AddWithValue("@CalificacionFinal", evaluacion.calificacionFinal);

                this.command.ExecuteNonQuery();
                this.conection.Close();

                this.conection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin de metodo modificar evaluacion

        public DataSet BuscarEvaluacion(string nombreEmpleado)
        {
            try
            {
                //se instancia una conexion
                this.conection = new SqlConnection(this.strConexion);
                //se intenta abrir
                this.conection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //se asigna la conexion al comando
                this.command.Connection = this.conection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento almacenado 
                this.command.CommandText = "[Sp_Cns_DatosTablaEvaluacion]";
                //asignamos el valor al parametro del procedimiento
                this.command.Parameters.AddWithValue("@nombreEmpleado", nombreEmpleado);
                //se instancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia el comando al adaptador
                this.dataAdapter.SelectCommand = this.command;
                //se instancia un dataset con los datos del comando
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.conection.Close();
                //se liberan los recursosr
                this.conection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();

                //se retorna el DataSet
                return this.dataSet;

            }

            catch (Exception ex)
            {

                throw;
            }
        }//fin de metodo buscar evaluaciones

        public void eliminarEvaluacion(int cedula)
        {
            try
            {
                this.conection = new SqlConnection(this.strConexion);
                this.conection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.conection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Del_Evaluacion]";

                this.command.Parameters.AddWithValue("@cedula", cedula);

                this.command.ExecuteNonQuery();
                this.conection.Close();
                this.command.Dispose();
                this.conection.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }//fin eliminar evaluacion


    }//fin de public class
}//fin de namespace
