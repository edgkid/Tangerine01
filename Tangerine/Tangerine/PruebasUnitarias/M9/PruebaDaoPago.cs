﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M9;
using DatosTangerine.InterfazDAO.M9;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M9;
using LogicaTangerine;



namespace PruebasUnitarias.M9
{
    [TestFixture]
    public class PruebaDaoPago
    {
        #region Atributos

        public bool answer;
        public Entidad elPago;
        public Entidad elPago1;
        public Entidad factura;
        public Entidad compania;
        public IDAOPago daoPago;
        public List<Entidad> listaPagos;
        #endregion


        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de DAOPago
        /// </summary>
        [SetUp]
        public void init()
        {
            daoPago = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPago();
            elPago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(123456, 12000, "EUR", "Deposito", 1);
            compania = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaVacia();

        }

        /// <summary>
        /// TearDown para las pruebas de DAOPago
        /// </summary>
        [TearDown]
        public void clean()
        {
            elPago = null;
            factura = null;
            compania = null;
            daoPago = null;
        }

        #endregion
        /// <summary>
        /// Método que permite verificar el agregar un pago en la base de datos
        /// </summary>
        [Test]
        public void TestAgregar()
        {

            answer = daoPago.Agregar(elPago);
            listaPagos = daoPago.ConsultarTodos();
            elPago = (Pago)listaPagos[listaPagos.Count - 1];

            Assert.IsTrue(answer);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).codPago == 123456);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).montoPago == 12000);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).monedaPago == "EUR");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).formaPago == "Deposito");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).idFactura == 1);

            answer = daoPago.EliminarPago(elPago);
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Método que permite verificar el cambio de status de una factura
        /// </summary>
        [Test]
        public void TestCambiarStatus()
        {

            answer = daoPago.CargarStatus(1, 1);

            Assert.IsTrue(answer);

            answer = daoPago.CargarStatus(1, 0);
        }

        [Test]
        public void TestPagosCompania()
        {
            
            ((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id= 1;
           Assert.IsNotNull(daoPago.ConsultarPagosCompania(compania));

        }
    }

}