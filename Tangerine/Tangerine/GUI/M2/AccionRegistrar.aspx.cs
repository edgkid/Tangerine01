﻿using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M2;
using Tangerine_Presentador.M2;

namespace Tangerine.GUI.M2
{
    public partial class AccionRegistrar : System.Web.UI.Page, IContratoAccionRegistrar
    {
        private PresentadorAccionRegistrar presentador;

        #region Contrato

        /// <summary>
        /// comboBox de seleccion de rol
        /// </summary>
        public string comboRol
        {
            get { return textRol_M2.Value; }
            set { textRol_M2.Value = value; }
        }

        /// <summary>
        /// textBox de la contraseña
        /// </summary>
        public string contrasena
        {
            get { return passwordDefault.Value; }
            set { passwordDefault.Value = value; }
        }

        /// <summary>
        /// Encabezado del textBox del nombre de usuario
        /// </summary>
        public string usuario
        {
            get { return userDefault.Value; }
            set { userDefault.Value = value; }
        }

        public string ficha
        {
            get { return textFicha_M2.Value; }
            set { textFicha_M2.Value = value; }
        }

        #endregion

        /// <summary>
        /// Carga la ventana Accion Registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorAccionRegistrar(this, int.Parse(Request.QueryString["idFicha"]), 
                                                         Request.QueryString["Nombre"], Request.QueryString["Apellido"]);
            if (!IsPostBack)
            {
                presentador.inicioVista();
            }
        }

        /// <summary>
        /// Crear el usuario de un empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            presentador.registrar();
            Response.Redirect("../M2/RegistroUsuario.aspx");
        }

        #region Web Methods

        /// <summary>
        /// Método para validar si el usuario escrito existe o no.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [WebMethod]
        public static string validarUsuario(string usuario)
        {
            string nombreUsuario = usuario;
            bool respuesta = false;
            respuesta = LogicaAgregarUsuario.ExisteUsuario(nombreUsuario);

            string retorno = "Disponible";

            if (respuesta)
            {
                retorno = "Usuario Existe!";
            }

            return retorno;
        }

        #endregion
    }
}