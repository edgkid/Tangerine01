﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M2
{
    public interface IDAOUsuarios : IDao<Entidad, bool, Entidad>
    {

        /// <summary>
        /// Encabezado de verificar si el usuario por su ficha
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Devuelve true si existe, si no, false</returns>
        bool VerificarUsuarioPorFichaEmpleado( int fichaEmpleado );

        /// <summary>
        /// Encabezado de metodo para devolver todos los empleados sin usuario
        /// </summary>
        /// <returns>Retorna la lista de empleados</returns>
        List<Empleado> ConsultarListaDeEmpleados();

        /// <summary>
        /// Encabezado de metodo usado para verificar si el usuario existe en el sistema
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>Retorna una valor booleano indicando la disponibilidad del usuario</returns>
        bool VerificarExistenciaUsuario( string nombreUsuario );

        /// <summary>
        /// Encabezado de metodo que retorna el usuario y rol de un empleado
        /// </summary>
        /// <param name="theEmpleado"></param>
        /// <returns>Retorna el usuario de un empleado</returns>
        Entidad ObtenerUsuarioDeEmpleado( Entidad theEmpleado );

    }
}
