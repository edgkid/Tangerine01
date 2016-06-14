﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M9;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M9
{
   public interface IDAOPago 
    {

        bool CargarPago (Entidad pagoParam);

        bool CargarStatus(int factura, int status);
    
    
    }
}