using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AirlineReservationSystem
{
    internal static class ErrorHandling
    {
        /// <summary>
        /// Handel the errro
        /// </summary>
        /// <param name="SClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        public static void handelError(string SClass, string sMethod, string sMessage)
        {
            MessageBox.Show(SClass + "." + sMethod + "->" + sMessage);
            try
            {
                System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\Resources\Error\Error.txt",
                Environment.NewLine + "HandleError Exception: " + SClass + "." + sMethod + "->" + sMessage);
            }
            catch(Exception ex)
            {
                ; // If we could not write to the text file do nothing
            }
        }

        public static void throwError(string declaringType, string name, string message)
        {
            if(declaringType == null)
            {
                declaringType = String.Empty;
            }
            if(name == null)
            {
                name = String.Empty;
            }
            if(message == null)
            {
                message = String.Empty;
            }

            throw new Exception(declaringType + "." + name + "->" + Environment.NewLine + message);
            //throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name.ToString() + "." +
            //    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
        }
    }
}
