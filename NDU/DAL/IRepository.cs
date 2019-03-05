using Microsoft.AspNetCore.Http;
using NDU.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace NDU.DAL
{
    public interface IRepository : IDisposable
    {
        Document GetDocument(int id);
        IList<Document> GetDocuments();
        void AddNewDocument(Document document, IFormFile uploadedFile);
        void EditDocument(Document document, IFormFile uploadedFile);
        void DeleteDocumentAndFile(int id);
        (MemoryStream content, string contentType, string fileName) ExportToExcel();
        void Save();
    }
}
