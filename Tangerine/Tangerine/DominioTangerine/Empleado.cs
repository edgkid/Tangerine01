﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DominioTangerine
{
  public   class Empleado
  {

      #region Atributos
      public int emp_num_ficha ;
	  public int emp_cedula ;
	  public String emp_genero ;
	  public String emp_p_nombre ;
	  public String emp_s_nombre ;
	  public String emp_p_apellido ;
	  public String emp_s_apellido ;
	  public DateTime emp_fecha_nac ;
	  public String emp_nivel_estudio ;
	  public String emp_email ;
	  public String emp_activo ;
	  public int fk_lug_dir_id ;

      private string address;
      private Cargo job;
      private List<Cargo> listJobs = new List<Cargo>();
      private List<Proyecto> listProjects = new List<Proyecto>();

      #endregion

      #region constructores
      public Empleado()
       {
           emp_num_ficha = 0;
           emp_cedula = 0;
           emp_genero = String.Empty;
           emp_p_nombre = String.Empty;
           emp_s_nombre = String.Empty;
           emp_p_apellido = String.Empty;
           emp_s_apellido = String.Empty;
           emp_fecha_nac = DateTime.Now;
           emp_nivel_estudio = String.Empty;
           emp_email = String.Empty;
           emp_activo = String.Empty;
	       fk_lug_dir_id = 0;
       }

       public Empleado(string pNombre, string sNombre, string pApellido, string sApellido,
               string email, string genero, DateTime fechaNacimiento, int ficha, int cedula,
               string nivelEstudio, string activo)
       {
           this.emp_num_ficha = ficha;
           this.emp_cedula = cedula;
           this.emp_genero = genero;
           this.emp_p_nombre = pNombre;
           this.emp_s_nombre = sNombre;
           this.emp_p_apellido = pApellido;
           this.emp_s_apellido = sApellido;
           this.emp_fecha_nac = fechaNacimiento;
           this.emp_nivel_estudio = nivelEstudio;
           this.emp_email = email;
           this.emp_activo = activo;
           this.fk_lug_dir_id = 1;
       }

       public Empleado(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                       int empCedula, DateTime empFecha, string empActivo, int empLugId)
       {
           this.emp_num_ficha = empId;
           this.emp_cedula = empCedula;
           this.emp_p_nombre = empPNombre;
           this.emp_s_nombre = empSNombre;
           this.emp_p_apellido = empPApellido;
           this.emp_s_apellido = empSApellido;
           this.emp_fecha_nac = empFecha;
           this.emp_activo = empActivo;
           this.fk_lug_dir_id = empLugId;
       }

       public Empleado(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                      string empGenero,int empCedula, DateTime empFecha, string empActivo, string empEstudio, 
                      string empEmail,int empLugId)
       {
           this.emp_num_ficha = empId;
           this.emp_cedula = empCedula;
           this.emp_p_nombre = empPNombre;
           this.emp_s_nombre = empSNombre;
           this.emp_p_apellido = empPApellido;
           this.emp_s_apellido = empSApellido;
           this.emp_genero = empGenero;
           this.emp_fecha_nac = empFecha;
           this.emp_activo = empActivo;
           this.emp_nivel_estudio = empEstudio;
           this.emp_email = empEmail;
           this.fk_lug_dir_id = empLugId;
       }

       public Empleado(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                       string empGenero, int empCedula, DateTime empFecha, string empActivo, string empEstudio,
                       string empEmail, int empLugId, string cargo, double salario, string fechaIni, string fechaFin,
                       string address)
       {
           this.emp_num_ficha = empId;
           this.emp_cedula = empCedula;
           this.emp_p_nombre = empPNombre;
           this.emp_s_nombre = empSNombre;
           this.emp_p_apellido = empPApellido;
           this.emp_s_apellido = empSApellido;
           this.emp_genero = empGenero;
           this.emp_fecha_nac = empFecha;
           this.emp_activo = empActivo;
           this.emp_nivel_estudio = empEstudio;
           this.emp_email = empEmail;
           this.fk_lug_dir_id = empLugId;
           this.job = new Cargo(cargo, salario, fechaIni, fechaFin);
           this.address = address;
       }

      #endregion

      #region Get's Set's
       public int Emp_num_ficha
       {
           get
           {
               return this.emp_num_ficha;
           }
           set
           {
               this.emp_num_ficha = value;
           }
       }

       public int Emp_cedula
       {
           get
           {
               return this.emp_cedula;
           }
           set
           {
               this.emp_cedula = value;
           }
       }

       public String Emp_genero
       {
           get
           {
               return this.emp_genero;
           }
           set
           {
               this.emp_genero = value;
           }
       }

       public String Emp_p_nombre
       {
           get
           {
               return this.emp_p_nombre;
           }
           set
           {
               this.emp_p_nombre = value;
           }
       }

       public String Emp_s_nombre
       {
           get
           {
               return this.emp_s_nombre;
           }
           set
           {
               this.emp_s_nombre = value;
           }
       }

       public String Emp_p_apellido
       {
           get
           {
               return this.emp_p_apellido;
           }
           set
           {
               this.emp_p_apellido = value;
           }
       }

       public String Emp_s_apellido
       {
           get
           {
               return this.emp_s_apellido;
           }
           set
           {
               this.emp_s_apellido = value;
           }
       }

       public DateTime Emp_fecha_nac
       {
           get
           {
               return this.emp_fecha_nac;
           }
           set
           {
               this.emp_fecha_nac = value;
           }
       }

       public String Emp_nivel_estudio
       {
           get
           {
               return this.emp_nivel_estudio;
           }
           set
           {
               this.emp_nivel_estudio = value;
           }
       }

       public String Emp_email
       {
           get
           {
               return this.emp_email;
           }
           set
           {
               this.emp_email = value;
           }
       }

       public String Emp_activo
       {
           get
           {
               return this.emp_activo;
           }
           set
           {
               this.emp_activo = value;
           }
       }

       public int Fk_lug_dir_id
       {
           get
           {
               return this.fk_lug_dir_id;
           }
           set
           {
               this.fk_lug_dir_id = value;
           }
       }

       public string Adrress 
       {
           get
           {
               return this.address;
           }
           set
           {
               this.address = value;
           }
       }

       public List<Proyecto> ListProjects
       {
           get
           {
               return this.listProjects;
           }
           set
           {
               this.listProjects = value;
           }
       }

       public Cargo Job
       {
           get
           {
               return this.job;
           }
       }

       public List<Cargo> ListJobs
       {
           get
           {
               return this.listJobs;
           }
           set
           {
               this.listJobs = value;
           }
       }
       #endregion

  }

    
}
