﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Fabrica;
using DominioTangerine.Entidades.M4;
using DominioTangerine;
using LogicaTangerine.Fabrica;
using LogicaTangerine;
using System.Globalization;
using DominioTangerine.Entidades.M10;
using DominioTangerine.Entidades.M2;

namespace PruebasUnitarias.M10
{
    [TestFixture]
    public class PruebaLogica
    {
         #region Atributos
        private Entidad theEmpleado;
        private Entidad theEmpleado2;
        private Entidad theEmpleado3;     
     
        private Entidad theCargo;
        private string pnombre;
        private string snombre;
        private string papellido;
        private string sapellido;
        private string genero;
        private int cedula;
        private DateTime fechaNac;
        private string status;
        private string estudio;
        private string correo;
        private Entidad Pais;
        private Comando<Entidad> ComandoEntidad;
        private Comando<Boolean> ComandoBooleano;
        private Comando<List<Entidad>> ComandoLista;
        private List<Entidad> ListaEmpleado;
        private List<Entidad> listaCargo;
        private List<Entidad> ListaEstado;
        private List<Entidad> ListaPais;
        private List<DominioTangerine.Entidades.M10.LugarDireccion> Direccion;
        private Entidad ElUsuario;
        private Entidad ElUsuario2;
        private Entidad ElUsuarioActivo;
        private Entidad ElRol;
        private Double Salario;
        private string Telefono;


        #endregion

        #region Setup&TearDown

        [SetUp]
        public void setup()
        {           
            
            pnombre = "Eduardo";
            snombre = "Jose";
            papellido = "Pacheco";
            sapellido = "Aguirre";
            genero = "Masculino";
            cedula = 19563263;
            fechaNac = DateTime.ParseExact("08/10/1989","dd/MM/yyyy", CultureInfo.InvariantCulture);
            status = "Activo";
            estudio = "Bachiller";
            correo = "eddcold@mail.com";
            Salario = 60;
            Telefono = "(0212)-7935754";
            theCargo =FabricaEntidades.CrearEntidadCargo("Gerente", 
                                       DateTime.ParseExact("04/01/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                       "Tiempo completo", Salario);

            Direccion = new List<DominioTangerine.Entidades.M10.LugarDireccion>();
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Venezuela", "Pais"));
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Distrito Capital", "Estado"));
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Caracas", "Ciudad"));
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Plaza Sucre", "Direccion"));

            ElRol = (RolM2)FabricaEntidades.crearRolNombre("Administrador");
            ElUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("leojma@gmail.com", "leojma", new DateTime(2015, 2, 10),
                                                                                      "Activo", ((RolM2)ElRol) , 1);
            ElUsuarioActivo = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioConUsuarioYContrasena("leojma@gmail.com","leojma");
            //ElUsuarioInactivo = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioConUsuarioYContrasena("lenon@gmail.com", "lenito22");
                        

            theEmpleado = (EmpleadoM10)FabricaEntidades.CrearEntidadEmpleado(pnombre, snombre, papellido,
                                               sapellido, genero,
                                               cedula,
                                               fechaNac,
                                               status, estudio, correo, theCargo,Telefono,
                                               Direccion);

            theEmpleado2 = FabricaEntidades.AgregarEmpledoM10();            
                       
            //pais = "Venezuela";            

            //Se agrega un empleado
            ComandoBooleano = FabricaComandos.ComandoAgregarEmpleado(theEmpleado);
        }

        [TearDown]
        public void clean()
        {
            pnombre = null;
            snombre = null;
            papellido = null;
            sapellido = null;
            genero = null;
            cedula = 0;
            status = null;
            estudio = null;
            correo = null;
            theCargo = null;
            ElRol = null;
            ElUsuario = null;
            ElUsuario2 = null;
            theEmpleado = null;
            theEmpleado2 = null;
            ComandoEntidad=null;
            ComandoBooleano = null;
            ComandoLista = null;
        }
        #endregion

        #region Tests

        /// <summary>
        /// Prueba Comando Agregar Empleado
        /// </summary>
        [Test]
        public void TestComandoAgregarEmpleado()
        {           
            

            //El empleado ya fue insertado arriba en el setup
            ComandoLista = FabricaComandos.ConsultarEmpleados();
            ListaEmpleado = ComandoLista.Ejecutar();
            theEmpleado2 = (EmpleadoM10)ListaEmpleado[ListaEmpleado.Count - 1];

            Assert.IsTrue(ComandoBooleano.Ejecutar());
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_nombre,"Eduardo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_nombre,"Jose");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_apellido,"Pacheco");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_apellido,"Aguirre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_genero,"Maculino");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_cedula,"19563263");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_fecha_nac, "08/10/1989");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_activo,"Activo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_nivel_estudio, "Bachiller");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_email, "eddcold@mail.com");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Nombre, "Gerente");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.FechaContratacion, "04/01/2016");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Modalidad, "Tiempo completo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[0].LugNombre,"Venezuela");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[0].LugTipo,"Pais");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[1].LugNombre, "Distrito Capital");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[1].LugTipo, "Estado");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[2].LugNombre, "Caracas");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[2].LugTipo, "Ciudad");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[3].LugNombre, "Plaza Sucre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[3].LugTipo, "Direccion");
        
        
        }

        /// <summary>
        /// Prueba Comando Consultar Empleado
        /// </summary>
        [Test]
        public void TestComandoConsultarEmpleado()
        {
            ComandoLista = FabricaComandos.ConsultarEmpleados();
            ListaEmpleado = ComandoLista.Ejecutar();
            
            theEmpleado2 = (EmpleadoM10)ListaEmpleado[ListaEmpleado.Count - 1];
            
            Assert.IsNotEmpty(ComandoLista.Ejecutar());
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_nombre, "Eduardo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_nombre, "José");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_apellido, "Pacheco");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_apellido, "Aguirre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_genero, "Maculino");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_cedula, "19563263");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_fecha_nac, "08/10/1989");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_activo, "Activo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_nivel_estudio, "Bachiller");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_email, "eddcold@mail.com");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Nombre, "Gerente");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Descripcion, "Gerente de proyectos de software");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.FechaContratacion, "04/01/201");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Modalidad, "Tiempo completo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[0].LugNombre, "Venezuela");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[0].LugTipo, "Pais");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[1].LugNombre, "Distrito Capital");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[1].LugTipo, "Estado");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[2].LugNombre, "Caracas");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[2].LugTipo, "Ciudad");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[3].LugNombre, "Plaza Sucre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).ListaDireccion[3].LugTipo, "Direccion");

            
        }

        /// <summary>
        /// Prueba Comando Consultar por Id
        /// </summary>
        [Test]
        public void TestComandoConsultarPorId()
        {            
            //Consulta el Empleado por Id
            ComandoEntidad = FabricaComandos.ConsultarIdEmpleado(theEmpleado);
            theEmpleado2 = (EmpleadoM10)ListaEmpleado[ListaEmpleado.Count - 1];
            theEmpleado3 = ComandoEntidad.Ejecutar();


            Assert.AreEqual(((EmpleadoM10)theEmpleado3).emp_id, theEmpleado2.Id);
            Assert.IsNotEmpty(ComandoLista.Ejecutar());
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_p_nombre, "Eduardo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_s_nombre, "José");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_p_apellido, "Pacheco");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_s_apellido, "Aguirre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_genero, "Maculino");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_cedula, "19563263");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_fecha_nac, "08/10/1989");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_activo, "Activo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_nivel_estudio, "Bachiller");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_email, "eddcold@mail.com");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Jobs.Nombre, "Gerente");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Jobs.Descripcion, "Gerente de proyectos de software");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Jobs.FechaContratacion, "04/01/201");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Jobs.Modalidad, "Tiempo completo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[0].LugNombre, "Venezuela");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[0].LugTipo, "Pais");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[1].LugNombre, "Distrito Capital");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[1].LugTipo, "Estado");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[2].LugNombre, "Caracas");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[2].LugTipo, "Ciudad");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[3].LugNombre, "Plaza Sucre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).ListaDireccion[3].LugTipo, "Direccion");

        }

        /// <summary>
        /// Prueba Comando Cambiar estado de estatus de un empleado
        /// </summary>
        [Test]
        public void TestComandoCambiarStatus()
        {
            ComandoLista = FabricaComandos.ConsultarEmpleados();
            ListaEmpleado = ComandoLista.Ejecutar();
            //Se obtiene el último empleado insertado
            theEmpleado2 = (EmpleadoM10)ListaEmpleado[ListaEmpleado.Count - 1];
           
            //Se asigna el id del ultimo empleado
            Entidad estatusId = DominioTangerine.Fabrica.FabricaEntidades.ConsultarEmpleados();
            estatusId.Id = ((EmpleadoM10)theEmpleado2).emp_id;

            //Se envía el id del empleado para modificar el estatus
            ComandoBooleano = LogicaTangerine.Fabrica.FabricaComandos.HabilitarEmpleado(estatusId);

             
            Assert.IsTrue(ComandoBooleano.Ejecutar());
            //Verifico que efectivamente el estatus cambio a Inactivo
            Assert.AreEqual(((EmpleadoM10)theEmpleado3).Emp_activo, "Inactivo");

        }

        /// <summary>
        /// Prueba para obtener la lista de todos los cargos
        /// </summary>
        [Test]
        public void TestObtenerCargos()
        {
            ComandoLista =FabricaComandos.ObtenerFabricaCargo();
            listaCargo = ComandoLista.Ejecutar();
            Assert.IsNotEmpty(listaCargo);           
        }

        /// <summary>
        /// Prueba para obtener la lista de todos los estados
        /// </summary>
        [Test]
        public void TestObtenerEstados()
        {
            ComandoLista = FabricaComandos.ObtenerFabricaEstado(Pais);
            ListaEstado = ComandoLista.Ejecutar();
            Assert.IsNotEmpty(ListaEstado);
        }
       
        /// <summary>
        /// Prueba para obtener la lista de todos los paises
        /// </summary>
        [Test]
        public void TestObtenerPaises()
        {
            ComandoLista = FabricaComandos.ObtenerFabricaPaises();
            ListaPais = ComandoLista.Ejecutar();
            Assert.IsNotEmpty(ListaPais);
        }

        /// <summary>
        /// Prueba Comando Agregar Empleado
        /// </summary>
        [Test]
        public void TestComandoValidarUsuarioCorreo()
        {

            //Probar que el  Usuario es activo
            ComandoEntidad = FabricaComandos.ConsultarUsuarioxCorreo(ElUsuarioActivo);
            ElUsuario2=ComandoEntidad.Ejecutar();

            Assert.IsNotNull(ElUsuario2);
            Assert.AreEqual(((UsuarioM2)ElUsuario2).activo, "Inactivo");
            
            
            //Probar que el  Usuario es inactivo
            ElUsuario2 = null;
            ComandoEntidad = FabricaComandos.ConsultarUsuarioxCorreo(ElUsuarioActivo);
            ElUsuario2 = ComandoEntidad.Ejecutar();

            Assert.IsNotNull(ElUsuario2);
            Assert.AreEqual(((UsuarioM2)ElUsuario2).activo, "Activo");
        }

        #endregion

    }
}
