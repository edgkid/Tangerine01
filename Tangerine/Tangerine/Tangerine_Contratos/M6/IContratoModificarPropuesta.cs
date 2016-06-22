﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M6
{
    public interface IContratoModificarPropuesta
    {

        Literal Requerimientos
        {
            get;
            set;
        }
        string ContenedorCompania
        {
            get;
            set;
        }
        string IdCompania
        {
            get;
        }
        string Descripcion
        {
            get;
            set;
        }
        DropDownList ComboDuracion
        {
            get;
            set;
        }
        string TextoDuracion
        {
            get;
            set;
        }
        string DatePickerUno
        {
            get;
            set;
        }
        string DatePickerDos
        {
            get;
            set;
        }
        DropDownList TipoCosto
        {
            get;
            set;
        }

        string TextoCosto
        {
            get;
            set;
        }
        DropDownList FormaPago
        {
            get;
            set;
        }
        DropDownList ComboCuota
        {
            get;
            set;
        }
        DropDownList ComboStatus
        {
            get;
            set;
        }


    }
}
