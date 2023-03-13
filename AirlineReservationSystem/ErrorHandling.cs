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
        /// Handel Errors
        /// </summary>
        /// <param name="method">MethodInfo.GetCurrentMethod()</param>
        /// <param name="ex"></param>
        public static void handleError(MethodBase method, Exception ex)
        {
            string message = getString(method, ex);
            MessageBox.Show(message);
            try
            {
                System.IO.File.AppendAllText(Environment.CurrentDirectory + @"\Resources\Error\Error.txt",
                "HandleError Exception: " + Environment.NewLine  + message);
            }
            catch(Exception execption)
            {
                ; // If we could not write to the text file do nothing
            }
        }

        /// <summary>
        /// Throw a new error
        /// </summary>
        /// <param name="method">MethodInfo.GetCurrentMethod()</param>
        /// <param name="ex"></param>
        /// <exception cref="Exception"></exception>
        public static void throwError(MethodBase method, Exception ex)
        {
            //throw new Exception(declaringType + "." + name + "->" + Environment.NewLine + message);
            throw new Exception(getString(method, ex));
        }

        private static string getString(MethodBase method, Exception ex)
        {
            return method.DeclaringType.Name.ToString() + "." + method.Name + "->" + Environment.NewLine + ex.Message;
        }
    }
}
