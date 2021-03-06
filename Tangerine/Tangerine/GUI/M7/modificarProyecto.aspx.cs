﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using Tangerine_Presentador.M7;
using Tangerine_Contratos.M7;
using LogicaTangerine.M10;
using System.Web.Security.AntiXss;
using System.Web.UI.HtmlControls;


namespace Tangerine.GUI.M7
{
    public partial class modificarProyecto : System.Web.UI.Page, IContratoModificarProyecto
    {

        PresentadorModificarProyecto presentador;
        int Proyectoid;

        public modificarProyecto()
        {
            this.presentador = new PresentadorModificarProyecto(this);
        }

        #region Contrato
        

        TextBox IContratoModificarProyecto.realizacion
        {
            get
            {
                return realizacion;
            }
            set
            {
                realizacion = value;
            }
        }

        TextBox IContratoModificarProyecto.gteAct
        {
            get
            {
                return gteAct;
            }
            set
            {
                gteAct = value;
            }
        }

        TextBox IContratoModificarProyecto.inputPropuesta
        {
            get
            {
                return inputPropuesta;
            }
            set
            {
                inputPropuesta = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputNombreProyecto
        {
            get
            {
                return textInputNombreProyecto;
            }
            set
            {
                textInputNombreProyecto = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputCodigo
        {
            get
            {
                return textInputCodigo;
            }
            set
            {
                textInputCodigo = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputFechaInicio
        {
            get
            {
                return textInputFechaInicio;
            }
            set
            {
                textInputFechaInicio = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputCosto
        {
            get
            {
                return textInputCosto;
            }
            set
            {
                textInputCosto = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputPorcentaje
        {
            get
            {
                return textInputPorcentaje;
            }
            set
            {
                textInputPorcentaje = value;
            }
        }

        DropDownList IContratoModificarProyecto.inputGerente
        {
            get
            {
                return inputGerente;
            }
            set
            {
                inputGerente = value;
            }
        }

        DropDownList IContratoModificarProyecto.inputEstatus
        {
            get 
            {
                return inputEstatus;
            }
            set
            {
                inputEstatus = value;
            }
        }

        TextBox IContratoModificarProyecto.text10
        {
            get
            {
                return text10;
            }
            set
            {
                text10 = value;
            }
        }

        ListBox IContratoModificarProyecto.imputEncargado
        {
            get
            {
                return inputEncargado;
            }
            set
            {
                inputEncargado = value;
            }
        }

        ListBox IContratoModificarProyecto.inputPersonal
        {
            get
            {
                return this.inputPersonal;
            }
            set
            {
                inputPersonal = value;
            }
        }

        TextBox IContratoModificarProyecto.idPropuesta
        {
            get
            {
                return idPropuesta;
            }
            set
            {
                idPropuesta = value;
            }
        }

        TextBox IContratoModificarProyecto.idProyecto
        {
            get
            {
                return idProyecto;
            }
            set
            {
                idProyecto = value;
            }
       }

        ListBox IContratoModificarProyecto.GerentesPasados
        {
            get
            {
                return GerentesPasados;
            }
            set
            {
                GerentesPasados = value;
            }
        }

        ListBox IContratoModificarProyecto.inputPersonalNoActivo
        {
            get
            {
                return this.inputPersonalNoActivo;
            }
            set
            {
                inputPersonalNoActivo = value;
            }
        }

        TextBox IContratoModificarProyecto.acuerdoPago
        {
            get
            {
                return acuerdoPago;
            }
            set
            {
                acuerdoPago = value;

            }
        }

        TextBox IContratoModificarProyecto.idCompania
        {
            get
            {
                return idCompania;
            }
            set
            {
                idCompania = value;
            }
        }

        TextBox IContratoModificarProyecto.descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }

        public string alertaClase
        {
            set { alert.Attributes["class"] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes["role"] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }

        public string FechaFin
        {
            get
            {
                return datepicker1.Value;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Proyectoid = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idCont"], false));
                if (!IsPostBack)
                {
                     presentador.CargarProyecto(Proyectoid);
                }
            }
            catch
            {
                Response.Redirect("ConsultaProyecto.aspx");
            }

         }

        protected void Modificar_Datos(object sender, EventArgs e)
        {
            bool resultado = presentador.EventoClick_Modificar();
            try
            {
                if (resultado.Equals(true))
                {
                    Server.Transfer("ConsultaProyecto.aspx?estado=3", true);
                }

            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                Server.Transfer("ConsultaProyecto.aspx?estado=2", true);
            }
        }

        protected void bIzquierdo_Click(object sender, EventArgs e)
        {
            presentador.MoverIzquierda();
        }

        protected void bDerecho_Click(object sender, EventArgs e)
        {
            presentador.MoverDerecha();
        }

    }
}