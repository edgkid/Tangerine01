﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M6;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M6
{
    public interface IDAORequerimiento : IDao
    {

        List<Entidad> ConsultarRequerimientosXPropuesta(String id);
        int ConsultarNumeroRequerimientos();
        bool EliminarRequerimiento(Entidad elRequerimiento);


    }
}
