using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            System.IO.File.AppendAllText("C:\\" + Directory.GetCurrentDirectory() + @"\Resources\Error\Error.txt", Environment.NewLine +
                             "HandleError Exception: " + SClass + "." + sMethod + "->" + sMessage);
        }

        public static void throwError()
        {

        }
    }
}
