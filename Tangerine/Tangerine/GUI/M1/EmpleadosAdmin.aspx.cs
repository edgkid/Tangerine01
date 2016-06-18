﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;
using System.Globalization;
using Tangerine_Contratos.M10;
using Tangerine_Presentador.M10;


namespace Tangerine.GUI.M1
{
    public partial class EmpleadosAdmin : System.Web.UI.Page, IContratoConsultaEmpleados
    {
        private PresentadorConsultaEmpleado presentador;

        public string empleado
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }

        public Literal Tabla
        {
            get
            {
                return tabla;
            }
            set
            {
                tabla = value;
            }
        }

        public string button
        {
            get
            {
                return this.nuevoempleado.Text;
            }
            set
            {
                this.nuevoempleado.Text = value;
            }
        }

         public EmpleadosAdmin()
        {
            this.presentador = new PresentadorConsultaEmpleado(this); 
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                presentador.cargarConsultarEmpleados();
                
            }

        }






       
    }
}