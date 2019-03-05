using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDU.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Type { get; set; }                  // Тип документа(Заява, Скарга, Розпорядження, Довідка) *
        public string Name { get; set; }                  // Назва відправника документа *
        public string EDPNOU { get; set; }                // Код за ЄДРПОУ відправника документа *
        public string SenderId { get; set; }              // Реєстраційний номер відправника *
        public DateTime SenderRegDate { get; set; }       // Реєстраційна дата відправника *
        public DateTime FilingDate { get; set; }          // Дата подання документа *
        public string RecipientId { get; set; }           // Реєстраційний номер отримувача *
        public DateTime RecipientRegDate { get; set; }    // Реєстраційна дата отримувача *
        public string DocState { get; set; }              // Стан документа(створено, відправлено, отримано, на розгляді, узгоджено, відмовлено, надано відповідь) *
        public DateTime ConsiderationDate  { get; set; }  // Дата розгляду документа
        public string FileName { get; set; }                    // Доданий файл
        public string FilePath { get; set; }
    }


}



