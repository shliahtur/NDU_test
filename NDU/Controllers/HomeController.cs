using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDU.DAL;
using NDU.Models;

namespace NDU.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public static List<Document> documentList = new List<Document>();


        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(int? page)
        {
            var docs = _repo.GetDocuments();
            return View(docs);
        }

        public IActionResult Document(int id)
        {
            var document = _repo.GetDocument(id);
            return PartialView("_Document", document);
        }

        [HttpGet]
        public ActionResult AddNewDocument()
        {
            return PartialView("_AddNewDocument", new Document());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewDocument(Document document, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                document.FileName = uploadedFile.FileName;
                document.FilePath = "/Files/" + uploadedFile.FileName;
            }

            _repo.AddNewDocument(document, uploadedFile);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditDocument/{id}")]
        public IActionResult EditDocument(int id)
        {
            var document = _repo.GetDocument(id);
            return PartialView("_EditDocument", document);
        }

        [HttpPost]
        [Route("EditDocument/{id?}")]
        public IActionResult EditDocument(int? id, Document document, IFormFile uploadedFile)
        {
            _repo.EditDocument(document, uploadedFile);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("DeleteDocument/{id}")]
        public IActionResult DeleteDocument(int id)
        {
            _repo.DeleteDocumentAndFile(id);
            return RedirectToAction("Index");
        }

        public IActionResult ExportToExcel()
        {
            var obj = _repo.ExportToExcel();
            return File(obj.content, obj.contentType, obj.fileName);
        }
    }

}
