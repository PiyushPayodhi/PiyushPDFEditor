using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using org.apache.pdfbox.pdfparser;
using java.io;
using org.apache.pdfbox.pdmodel.encryption;
using org.apache.pdfbox.pdmodel.interactive.form;

namespace PiyushApps.PDFEditor
{
    class PDFBoxEditor
    {
        public string PdfFile { get; set; }
        public string PdfPassword { get; set; }


        public PDFBoxEditor(string pdfFile, string pdfPassword)
        {
            PdfFile = pdfFile;
            PdfPassword = pdfPassword;
        }

        public string PdfToText()
        {
            string pdfText = String.Empty;
            PDFParser parser = new PDFParser(new BufferedInputStream(new FileInputStream(PdfFile)));
            parser.parse();
            PDDocument originialPdfDoc = parser.getPDDocument();

            bool isOriginalDocEncrypted = originialPdfDoc.isEncrypted();
            if (isOriginalDocEncrypted)
            {
                originialPdfDoc.openProtection(new StandardDecryptionMaterial(PdfPassword));
            }
            PDFTextStripper stripper = new PDFTextStripper();
            try
            {
                pdfText = stripper.getText(originialPdfDoc);

            }
            catch (java.io.IOException ex)
            {
                throw ex;
            }
            return pdfText;
        }

        public string PdfFields()
        {
            string pdfText = String.Empty;
            PDFParser parser = new PDFParser(new BufferedInputStream(new FileInputStream(PdfFile)));
            parser.parse();
            PDDocument originialPdfDoc = parser.getPDDocument();

            bool isOriginalDocEncrypted = originialPdfDoc.isEncrypted();
            if (isOriginalDocEncrypted)
            {
                originialPdfDoc.openProtection(new StandardDecryptionMaterial(PdfPassword));
            }
            
            try
            {
                PDDocumentCatalog docCatalog = originialPdfDoc.getDocumentCatalog();
                PDAcroForm acroForm = docCatalog.getAcroForm();
                PDField field = acroForm.getField("Name");
                if (field != null)
                {
                    field.setValue("name");
                }
            }
            catch (java.io.IOException ex)
            {
                throw ex;
            }
            return pdfText;
        }

    }
}
