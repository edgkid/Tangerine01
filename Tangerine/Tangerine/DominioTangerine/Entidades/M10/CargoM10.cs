﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DominioTangerine.Entidades.M10
{
    public class CargoM10:Entidad
    {
        #region Atributos
        private string nombre;
        private string descripcion;
        private DateTime fechaContratacion;
        private DateTime fechaFinContrato;
        private string modalidad;
        private double sueldo;

        private string fechaIni;
        private string fechaFin;

        private int fk_car_id;
        private int fk_emp_num_ficha;
        private int car_id;

        private List<EmpleadoM10> listEmployees;
        #endregion

        #region constructores
        public CargoM10() { }

         //Constructor que uso en el presentador para agregar un empleado
        public CargoM10(string name,DateTime dateJob, string jobMode, double salario )
        {
            this.nombre = name;
            this.fechaContratacion = dateJob;
            this.modalidad = jobMode;
            this.sueldo = salario; 
        }

        public CargoM10(string nombre, string descripcion, DateTime fecha)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaContratacion = fecha;
            
        }
        
        public CargoM10(string cargo, double salary, string dateIni, string dateFin)
        {
            this.nombre=cargo;
            this.fechaIni = dateIni;
            this.fechaFin = dateFin;
            this.sueldo = salary;
        }          
    
               

        /*cargo de creacion con empleado*/
        public CargoM10(string name, string summaryJob, DateTime dateJob, string jobMode, Double Salary)
        {
            this.nombre = name;
            this.descripcion = summaryJob;
            this.fechaContratacion = dateJob;
            this.modalidad = jobMode;
            this.sueldo = Salary;
        }
        #endregion

        # region Get's Set's
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public DateTime FechaContratacion
        {
            get
            {
                return this.fechaContratacion;
            }
            set
            {
                this.fechaContratacion = value;
            }
        }

        public DateTime FechaFinContrato
        {
            get
            {
                return this.fechaFinContrato;
            }
            set 
            {
                this.fechaFinContrato = value;
            }
        }

        public string Modalidad
        {
            get
            {
                return this.modalidad;
            }
            set 
            {
                this.modalidad = value;
            }
        }

        public double Sueldo
        {
            get
            {
                return this.sueldo;
            }
            set
            {
                this.sueldo = value;
            }
        }

        public int Fk_car_id
        {
            get 
            {
                return this.fk_car_id;
            }
            set 
            {
                this.fk_car_id = value;
            }
        }

        public int Fk_emp_num_ficha
        {
            get 
            {
                return this.fk_emp_num_ficha;
            }
            set
            {
                this.fk_emp_num_ficha = value;
            }
        }

        public int Car_id
        {
            get 
            {
                return this.car_id;
            }
            set
            {
                this.car_id = value;
            }
        }

        public string FechaIni
        {
            get
            {
                return this.fechaIni;
            }
            set
            {
                this.fechaIni = value;
            }
        }

        public string FechaFin
        {
            get
            {
                return this.fechaFin;
            }
            set
            {
                this.fechaFin = value;
            }
        }

       public List<EmpleadoM10> ListEmployees
        {
            get 
            {
                return this.listEmployees;
            }
            set 
            {
                this.listEmployees = value;
            }
        }
        #endregion
    }
}
