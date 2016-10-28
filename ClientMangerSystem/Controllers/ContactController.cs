using ClientMangerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientMangerSystem.Controllers
{
    public class ContactController : Controller
    {
        ClientEntities db = new ClientEntities();
        // GET: Contact
        public ActionResult Index(int ClinetId)
        {
            var model = db.客戶聯絡人.Where(p => p.客戶Id == ClinetId).ToList();
            return View(model);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            var model = db.客戶聯絡人.FirstOrDefault(p => p.Id == id);
            return View(model);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            var model = new 客戶聯絡人();
            return View(model);
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(客戶聯絡人 contact)
        {
            try
            {
                db.客戶聯絡人.Add(contact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(contact);
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.客戶聯絡人.FirstOrDefault(p => p.Id == id);
            return View(data);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(客戶聯絡人 contact)
        {
            try
            {

                var oldContact = db.客戶聯絡人.FirstOrDefault(p => p.Id == contact.Id);
                if (oldContact != null)
                {
                    oldContact.姓名 = contact.姓名;
                    oldContact.手機 = contact.手機;
                    oldContact.電話 = contact.電話;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(contact);
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.客戶聯絡人.FirstOrDefault(p => p.Id == id);
            data.is刪除 = true;
            
            return View();
        }

        
    }
}
