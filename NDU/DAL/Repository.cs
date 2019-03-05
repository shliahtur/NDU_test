using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NDU.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NDU.DAL
{
    public class Repository : IRepository
    {
        private readonly NDUContext _context;
        IHostingEnvironment _appEnvironment;

        public Repository(NDUContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _appEnvironment = hostingEnvironment;
        }

        public Document GetDocument(int id)
        {
            return _context.Documents.Find(id);
        }

        public IList<Document> GetDocuments()
        {
           return _context.Documents.ToList();
        }


        public void AddNewDocument(Document document, IFormFile uploadedFile)
        {

            _context.Documents.Add(document);

            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                   uploadedFile.CopyToAsync(fileStream);
                }
               
            }
            Save();
        }
        public void EditDocument(Document document, IFormFile uploadedFile)
        {

            if (uploadedFile != null)
            {
                document.FileName = uploadedFile.FileName;
                document.FilePath = "/Files/" + uploadedFile.FileName;
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyToAsync(fileStream);
                }

            }
           
            _context.Entry(document).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteDocumentAndFile(int id)
        {
            var doc = _context.Documents.Find(id);
            _context.Documents.Remove(doc);

            if(doc.FileName != null)
            {
                string path = _appEnvironment.WebRootPath + "/Files/" + doc.FileName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

            }
            Save();
        }

        public (MemoryStream content, string contentType, string fileName) ExportToExcel()
        {
            var docs = GetDocuments();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Назва відправника документа";
            ws.Cells["B1"].Value = "Тип документа";
            ws.Cells["C1"].Value = "ЄДРПОУ";
            ws.Cells["D1"].Value = "Реєстраційний номер відправника";
            ws.Cells["E1"].Value = "Реєстраційна дата відправника";
            ws.Cells["F1"].Value = "Дата подання документа";
            ws.Cells["G1"].Value = "Реєстраційний номер отримувача";
            ws.Cells["H1"].Value = "Реєстраційна дата отримувача";
            ws.Cells["I1"].Value = "Стан документа";
            ws.Cells["J1"].Value = "Дата розгляду документа";
            ws.Cells["K1"].Value = "Доданий файл";

            int rowStart = 2;
            foreach (var doc in docs)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = doc.Name;
                ws.Cells[string.Format("B{0}", rowStart)].Value = doc.Type;
                ws.Cells[string.Format("C{0}", rowStart)].Value = doc.EDPNOU;
                ws.Cells[string.Format("D{0}", rowStart)].Value = doc.SenderId;
                ws.Cells[string.Format("E{0}", rowStart)].Value = doc.SenderRegDate;
                ws.Cells[string.Format("F{0}", rowStart)].Value = doc.FilingDate;
                ws.Cells[string.Format("G{0}", rowStart)].Value = doc.RecipientId;
                ws.Cells[string.Format("H{0}", rowStart)].Value = doc.RecipientRegDate;
                ws.Cells[string.Format("I{0}", rowStart)].Value = doc.DocState;
                ws.Cells[string.Format("J{0}", rowStart)].Value = doc.ConsiderationDate;
                ws.Cells[string.Format("K{0}", rowStart)].Value = doc.FileName;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var content = new MemoryStream(pck.GetAsByteArray());
            var fileName = "ExcelReport.xlsx";
            return (content, contentType, fileName);
        
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        #region dispose
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    #endregion
}
