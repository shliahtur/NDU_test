using NDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDU
{
    public static class DbContextExtension
    {
        public static void EnsureDatabaseSeeded(this NDUContext context)
        {
       
                context.AddRange(new Document[]
                {
                    new Document()
                    {
                        Name = "НацБанк",
                        Type = "Заява",
                        EDPNOU = "07573169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 3, 11),
                        DocState = "створено",
                        ConsiderationDate = new DateTime(2019, 3, 6),
                        FileName = "doc.txt",
                        FilePath = "/Files/doc.txt"
                    },
                     new Document()
                    {
                        Name = "НАК «Нафтогаз України»‎",
                        Type = "Заява",
                        EDPNOU = "07573169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 11, 3),
                        DocState = "Надано відповідь",
                        ConsiderationDate = new DateTime(2019, 3, 6),
                        FileName = "doc2.txt",
                        FilePath = "/Files/doc2.txt"
                    },
                      new Document()
                    {
                        Name = "КиївВодоКанал",
                        Type = "Довідка",
                        EDPNOU = "34634636",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 11, 11),
                        DocState = "створено",
                        ConsiderationDate = new DateTime(2019, 3, 6),
                        FileName = "doc.txt",
                        FilePath = "/Files/doc.txt"
                    },
                        new Document()
                    {
                        Name = "Запоріжсталь",
                        Type = "Заява",
                        EDPNOU = "07573169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 11, 11),
                        DocState = "отримано",
                        ConsiderationDate = new DateTime(2019, 3, 6),
                        FileName = "doc3.txt",
                        FilePath = "/Files/doc3.txt"
                    },
                        new Document()
                    {
                        Name = "КиівМіськБуд",
                        Type = "Скарга",
                        EDPNOU = "66673169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 5, 11),
                        DocState = "відмовлено",
                        ConsiderationDate = new DateTime(2019, 3, 6),
                        FileName = "doc.txt",
                        FilePath = "/Files/doc.txt"
                    },
                        new Document()
                    {
                        Name = "Енергоатом‎",
                        Type = "Заява",
                        EDPNOU = "03753169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 3, 11),
                        DocState = "Надано відповідь",
                        ConsiderationDate = new DateTime(2019, 3, 6),
                        FileName = "doc.txt",
                        FilePath = "/Files/doc.txt"
                    },
                        new Document()
                    {
                        Name = "ДП Антонов",
                        Type = "Скарга",
                        EDPNOU = "07573169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 4, 1),
                        DocState = "отримано",
                        ConsiderationDate = new DateTime(2019, 7, 4),
                        FileName = "doc4.txt",
                        FilePath = "/Files/doc4.txt"
                    },
                        new Document()
                    {
                        Name = "ЗАТ УкрСпецЕлектроніка",
                        Type = "Довідка",
                        EDPNOU = "07573169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019,6, 6),
                        DocState = "Надано відповідь",
                        ConsiderationDate = new DateTime(2019, 3, 7),
                        FileName = "doc.txt",
                        FilePath = "/Files/doc.txt"
                    },
                        new Document()
                    {
                        Name = "Укрзалізниця",
                        Type = "Довідка",
                        EDPNOU = "07573169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 1, 12),
                        DocState = "Надано відповідь",
                        ConsiderationDate = new DateTime(2019, 3, 6),
                        FileName = "doc.txt",
                        FilePath = "/Files/doc.txt"
                    },
                        new Document()
                    {
                        Name = "ПриватБанк",
                        Type = "Заява",
                        EDPNOU = "07573169",
                        SenderId = "25235235",
                        SenderRegDate = new DateTime(2019, 3, 1),
                        FilingDate = new DateTime(2019, 2, 1),
                        RecipientId = "2305230523",
                        RecipientRegDate = new DateTime(2019, 4, 4),
                        DocState = "Надано відповідь",
                        ConsiderationDate = new DateTime(2019, 5, 6),
                        FileName = "doc.txt",
                        FilePath = "/Files/doc.txt"
                    }

                });
                context.SaveChanges();
            }


        
    }
}
