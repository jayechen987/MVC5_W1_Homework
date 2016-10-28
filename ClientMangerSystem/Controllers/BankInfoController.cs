using ClientMangerSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientMangerSystem.Controllers
{
    public class BankInfoController : Controller
    {
        ClientEntities db = new ClientEntities();

        // GET: BankInfo
        public ActionResult Index(int ClinetId)
        {
            var model = db.客戶銀行資訊.Where(p => p.客戶Id == ClinetId).ToList();
            return View(model);
        }

        // GET: BankInfo/Details/5
        public ActionResult Details(int id)
        {
            var model = db.客戶銀行資訊.FirstOrDefault(p => p.Id == id);
            return View(model);
        }

        // GET: BankInfo/Create
        public ActionResult Create(int clientID)
        {
            var model = new 客戶銀行資訊() { 客戶Id = clientID};
            return View(model);
        }

        // POST: BankInfo/Create
        [HttpPost]
        public ActionResult Create(客戶銀行資訊 bankInfo)
        {

            try
            {
                db.客戶銀行資訊.Add(bankInfo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException De)
            {
                foreach (var entityErrors in De.EntityValidationErrors)
                {
                    foreach (var vErrors in entityErrors.ValidationErrors)
                    {
                        ViewBag.Message = vErrors.PropertyName + " 發生錯誤：" + vErrors.ErrorMessage;
                    }
                }
                return View(bankInfo);
            }
            catch (Exception ee)
            {
                ViewBag.Message = ee.Message;
                return View(bankInfo);
            }
        }

        // GET: BankInfo/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.客戶銀行資訊.FirstOrDefault(p => p.Id == id);
            return View(data);
        }

        // POST: BankInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(客戶銀行資訊 bankInfo)
        {
            try
            {

                var oldBank = db.客戶銀行資訊.FirstOrDefault(p => p.Id == bankInfo.Id);
                if (oldBank != null)
                {
                    oldBank.銀行名稱 = bankInfo.銀行名稱;
                    oldBank.銀行代碼 = bankInfo.銀行代碼;
                    oldBank.分行代碼 = bankInfo.分行代碼;
                    oldBank.帳戶名稱 = bankInfo.帳戶名稱;
                    oldBank.帳戶號碼 = bankInfo.帳戶號碼;
                    oldBank.客戶資料 = bankInfo.客戶資料;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(bankInfo);
            }
        }

        // GET: BankInfo/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.客戶銀行資訊.FirstOrDefault(p => p.Id == id);
            //data.is刪除 = true;

            return View("Index", new { ClinetId = data.客戶Id });
        }
    }
}
