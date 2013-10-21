using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_Datos;
using System.Text.RegularExpressions;
using System.Data;

namespace Capa_Negocio
{
   public class Logica
   {
       #region Obtener Clientes
       public int GetClientes(Entidades ENTI)
        {
           
            if (!Regex.IsMatch(ENTI.Cedula, "^[0-9]+[0-9]+[0-9]-[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]-[0-9]$"))
            {
                throw new Control("La cedula no cumple con el formato correcto");
            }
            if (string.IsNullOrEmpty(ENTI.Nombre))
            {
                throw new Control("El Nombre esta Vacio!!");
            }
            if (string.IsNullOrEmpty(ENTI.Apellido))
            {
                throw new Control("El Apellido esta Vacio!!");
            }
            if (string.IsNullOrEmpty(ENTI.Telefono))
            {
                throw new Control("El Telefono esta Vacio!!");
            }
            if (string.IsNullOrEmpty(ENTI.Direccion))
            {
                throw new Control("El Direccion esta Vacio!!");
               
            }

           
                return new Datos().InsertarCli(ENTI);

        }
       #endregion

       #region llenarDataGrid
       public DataTable llenarDataGrid() 
       {
           return new Datos().GetFillGrid();
       }
       #endregion

       public Entidades Editar(int ID) 
       {
         return new Datos().EditarCli(ID);

       }

       public int actualizar(int ID,Entidades ENTI)
       {
         return  new Datos().Update(ID,ENTI);
       }

       public int Borrar(int ID)
       {
           return new Datos().Delete(ID);
       }
   }
  }
