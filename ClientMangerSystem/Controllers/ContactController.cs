using ClientMangerSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        public ActionResult Create(int clientID)
        {
            var model = new 客戶聯絡人() {客戶Id = clientID };
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
            }
            catch (Exception ee)
            {
                ViewBag.Message = ee.Message;
                return View(contact);
            }
            return RedirectToAction("Index");
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
            catch (Exception ee)
            {
                ViewBag.Message = ee.Message;
                return View(contact);
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.客戶聯絡人.FirstOrDefault(p => p.Id == id);
            data.is刪除 = true;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException De)
            {
                foreach (var entityErrors in De.EntityValidationErrors)
                {
                    foreach (var vErrors in entityErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vErrors.PropertyName + " 發生錯誤：" + vErrors.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return View("Index",new { ClinetId  = data.客戶Id});
        }

        
    }
}
