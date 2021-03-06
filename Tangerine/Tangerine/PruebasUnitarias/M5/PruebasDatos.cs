﻿using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using DominioTangerine.Entidades.M5;
using DominioTangerine.Fabrica;
using ExcepcionesTangerine.M5;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PruebasUnitarias.M5
{
    [TestFixture]
    public class PruebasDatos
    {
        #region Atributos
        private Entidad _contacto;
        private List<Entidad> _listaContactos;
        private IDAOContacto _daoContacto;
        private bool _respuesta;
        private int _contadorContactos;
        #endregion

        #region SetUp and TearDown
        /// <summary>
        /// Método para inicializar atributos
        /// </summary>
        [SetUp]
        public void init()
        {
            _contacto = FabricaEntidades.crearContactoSinId( "pruebaNombre", "pruebaApellido",
                                                             "pruebaDepartamento", "pruebaCargo",
                                                             "pruebaTelefono", "pruebaCorreo", 1, 1 );
            _listaContactos = new List<Entidad>();

            _daoContacto = FabricaDAOSqlServer.crearDAOContacto();

            _respuesta = false;

            _contadorContactos = 0;
        }

        /// <summary>
        /// Método para reiniciar atributos
        /// </summary>
        [TearDown]
        public void clean()
        {
            _contacto = null;
            _listaContactos = null;
            _daoContacto = null;
        }
        #endregion

        #region Pruebas Unitarias

        /// <summary>
        /// Método para probar el método Agregar() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoAgregar()
        {
            _respuesta = _daoContacto.Agregar( _contacto );
            Assert.True( _respuesta );

            _listaContactos = _daoContacto.ConsultarTodos();
            _contadorContactos = _listaContactos.Count;
            Assert.AreEqual( _contadorContactos, 5 );

            ContactoM5 contacto = ( ContactoM5 ) _contacto;
            bool verificar = false;

            foreach ( Entidad e in _listaContactos )
            {
                ContactoM5 c = ( ContactoM5 ) e;

                if ( c.Nombre.Equals( contacto.Nombre ) && c.Apellido.Equals( contacto.Apellido )
                     && c.Telefono.Equals( contacto.Telefono ) && c.Correo.Equals( contacto.Correo )
                     && c.Departamento.Equals( contacto.Departamento ) && c.Cargo.Equals( contacto.Cargo )
                     && c.TipoCompañia.Equals( contacto.TipoCompañia ) && c.IdCompañia.Equals( contacto.IdCompañia ) )
                {
                    verificar = true;
                }
            }
            Assert.IsTrue( verificar );
        }

        /// <summary>
        /// Método para probar el método Eliminar() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOConactoEliminar()
        {
            _contacto.Id = 2;

            _respuesta = _daoContacto.Eliminar( _contacto );
            Assert.True( _respuesta );

            _listaContactos = _daoContacto.ConsultarTodos();
            _contadorContactos = _listaContactos.Count;
            Assert.AreEqual( _contadorContactos, 4 );
        }

        /// <summary>
        /// Método para probar el método Modificar() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoModificar()
        {
            Entidad _contactoModificar;
            _contactoModificar = FabricaEntidades.crearContactoSinId( "nombre modificado", "igual",
                                                                      "igual", "igual",
                                                                      "igual", "igual", 1, 1 );
            _contactoModificar.Id = 3;

            Entidad contactoConsulta = _daoContacto.ConsultarXId( _contactoModificar );
            ContactoM5 nuevo = ( ContactoM5 ) contactoConsulta;
            Assert.AreEqual( nuevo.Nombre, "Maria" );

            _respuesta = _daoContacto.Modificar( _contactoModificar );
            Assert.True( _respuesta );

            contactoConsulta = _daoContacto.ConsultarXId( _contactoModificar );
            nuevo = ( ContactoM5 ) contactoConsulta;
            Assert.AreEqual( nuevo.Nombre, "nombre modificado" );
        }

        /// <summary>
        /// Método para probar el método ConsultarXId() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoConsultarXId()
        {
            Entidad contacto = FabricaEntidades.crearContactoVacio();
            contacto.Id = 3;

            contacto = _daoContacto.ConsultarXId( contacto );
            ContactoM5 nuevo = ( ContactoM5 ) contacto;
            Assert.AreEqual( nuevo.Nombre, "Maria" );
        }

        /// <summary>
        /// Método para probar el método ConsultarTodos() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoConsultarTodos()
        {
            _listaContactos = _daoContacto.ConsultarTodos();
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 5 );
        }

        /// <summary>
        /// Método para probar el método ContactosPorCompania() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoContactosPorCompania()
        {
            _listaContactos = _daoContacto.ContactosPorCompania( 1, 1 );
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 5 );
        }

        /// <summary>
        /// Método para probar el método AgregarContactoAProyecto() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoAgregarContactoAProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;
            _contacto.Id = 3;

            _respuesta = _daoContacto.AgregarContactoAProyecto( _contacto, proyecto );
            Assert.True( _respuesta );

            _listaContactos = _daoContacto.ContactosPorProyecto( proyecto );
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 3 );
        }

        /// <summary>
        /// Método para probar el método ContactosPorProyecto() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoContactosPorProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;

            _listaContactos = _daoContacto.ContactosPorProyecto( proyecto );
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 3 );
        }

        /// <summary>
        /// Método para probar el método EliminarContactoDeProyecto() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoEliminarContactoDeProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;
            _contacto.Id = 3;

            _respuesta = _daoContacto.EliminarContactoDeProyecto( _contacto, proyecto );
            Assert.True( _respuesta );

            _listaContactos = _daoContacto.ContactosPorProyecto( proyecto );
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 1 );
        }

        /// <summary>
        /// Método para probar el método ContactosNoPertenecenAProyecto() de DAOContacto
        /// </summary>
        [Test]
        public void PruebaDAOContactoContactosNoPertenecenAProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;

            _listaContactos = _daoContacto.ContactosNoPertenecenAProyecto( proyecto );
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 3 );
        }

        // Pruebas de Excepciones 

        /// <summary>
        /// Metodo para probar NullReferenceException en el método Agregar() de DAOContacto
        /// </summary>
        [Test]
        [ ExpectedException( typeof( AgregarContactoException ), 
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOContactoAgregarNull()
        {
            Entidad contacto = null;
            _respuesta = _daoContacto.Agregar( contacto );
        }

        /// <summary>
        /// Método para probar NullReferenceException en el método Eliminar() de DAOContacto
        /// </summary>
        [Test]
        [ ExpectedException( typeof( EliminarContactoException ), 
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOConactoEliminarNull()
        {
            Entidad contacto = null;
            _respuesta = _daoContacto.Eliminar( contacto );

        }
        /// <summary>
        /// Método para probar NullReferenceException en el método Modificar() de DAOContacto
        /// </summary>
        /// 
        [Test]
        [ ExpectedException( typeof( ModificarContactoException ), 
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOContactoModificarNull()
        {
            Entidad contacto = null;
            _respuesta = _daoContacto.Modificar( contacto );

        }

        /// <summary>
        /// Método para probar NullReferenceException en el método ConsultarXId() de DAOContacto
        /// </summary>
        /// 
        [Test]
        [ ExpectedException( typeof( ConsultarContactoException ), 
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOContactoConsultarXIdNull()
        {
            Entidad contacto = null;
            Entidad contactoxid = _daoContacto.ConsultarXId( contacto );

        }

        /// <summary>
        /// Método para probar NullReferenceExcepcion en el método AgregarContactoAProyecto() de DAOContacto
        /// </summary>
        [Test]
        [ ExpectedException( typeof( AgregarContactoException ), 
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOContactoAgregarContactoAProyectoNull()
        {
            Entidad contacto = null;
            Entidad proyecto = null;
            _respuesta = _daoContacto.AgregarContactoAProyecto( contacto, proyecto );
        }

        /// <summary>
        /// Método para probar NullReferenceExcepcion en el método ContactosPorProyecto() de DAOContacto
        /// </summary>
        [Test]
        [ ExpectedException( typeof( ConsultarContactoException ), 
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOContactoContactosPorProyectoNull()
        {
            Entidad proyecto = null;
            _listaContactos = _daoContacto.ContactosPorProyecto( proyecto );

        }

        /// <summary>
        /// Método para probar el método EliminarContactoDeProyecto() de DAOContacto
        /// </summary>
        [Test]
        [ ExpectedException( typeof( EliminarContactoException ),
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOContactoEliminarContactoDeProyectoNull()
        {
            Entidad contacto = null;
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;

            _respuesta = _daoContacto.EliminarContactoDeProyecto( contacto, proyecto );

        }
        /// <summary>
        /// Método para probar el método ContactosNoPertenecenAProyecto() de DAOContacto
        /// </summary>
        [Test]
        [ ExpectedException( typeof( ConsultarContactoException ), 
                             ExpectedMessage = "Ingreso de un argumento con valor invalido" ) ]
        public void PruebaDAOContactoContactosNoPertenecenAProyectoNull()

        {
            Entidad proyecto = null;
            _listaContactos = _daoContacto.ContactosNoPertenecenAProyecto( proyecto );

        }

        #endregion

    }


}


