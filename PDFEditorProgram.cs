using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Security.Principal;

namespace PiyushApps.PDFEditor
{
    class PDFEditorProgram
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            string file = @"C:\Users\Pyuish\OneDrive\Documents\Personal\Finance\NSDL\NSDLe-CAS_110424803_2018_07.PDF";
            string password = "BQPPP3943R";

            //Console.WriteLine("Enter Document Path: ");
            //file = Console.ReadLine();            
            //Console.WriteLine("Enter Document Password:");
            //password = Console.ReadLine();
            
            try
            {
                PDFBoxEditor pdfEditor = new PDFBoxEditor(file, password);
                string pdfText = pdfEditor.PdfToText();
                pdfEditor.PdfFields();
                Logger.Info(pdfText);
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
            }
            
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            
        }
    }
}
