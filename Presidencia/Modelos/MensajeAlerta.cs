using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Presidencia.Modelos
{
    public class MensajeAlerta
    {

        public static void AlertaValidacion(Page page, string msj)
        {

            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "SweetAlert", "swal.fire({title:'Verifica los siguientes campos:', html:'" + msj + "', icon:'warning', confirmButtonText: 'Aceptar', width: 600,});", true);
        }

        public static void AlertaAviso(Page page, string titulo, string msj)
        {
            // page.ClientScript.RegisterStartupScript(page.GetType(), "SweetAlert", $"  Swal.fire( '{titulo}','{msj}', 'error')", true);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "SweetAlert", $"  Swal.fire( '{titulo}','{msj}', 'error')", true);
        }

        public static void AlertaSatisfactorio(Page page, string msj)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "SweetAlert", $"  Swal.fire( '{msj}', '--' , 'success')", true);
        }

    }
}