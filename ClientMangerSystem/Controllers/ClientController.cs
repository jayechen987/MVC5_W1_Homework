using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientMangerSystem.Models;
using System.Data.Entity.Validation;

namespace ClientMangerSystem.Controllers
{
    public class ClientController : Controller
    {
        ClientEntities db = new ClientEntities();

        public ActionResult Index(string search)
        {

            var client = db.客戶資料.Where(p=>p.is刪除==false).OrderByDescending(p => p.Id).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                client = client.Where(p => p.客戶名稱.Contains(search)).ToList();
            }

            return View(client);
        }

        public ActionResult Create()
        {
            var model = new 客戶資料();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(客戶資料 client)
        {
            db.客戶資料.Add(client);

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
            return View("Index");
        }

        public ActionResult Detail(int id)
        {
            //ClientViewModel model = new ClientViewModel()
            //{
            //    Client = db.客戶資料.FirstOrDefault(p => p.Id == id),
            //    ClientContact = new 客戶聯絡人(),
            //    ClientBank = new 客戶銀行資訊()
            //};

            //if (db.客戶聯絡人.FirstOrDefault(p => p.客戶Id == id) != null)
            //{
            //    model.ClientContact = db.客戶聯絡人.FirstOrDefault(p => p.客戶Id == id);
            //    model.ClientBank = db.客戶銀行資訊.FirstOrDefault(p => p.客戶Id == id);
            //}

            var model = db.客戶資料.FirstOrDefault(p => p.Id == id);

            return View(model);
        }

        public ActionResult Update(int id)
        {
            ////宣告
            //ClientViewModel data = new ClientViewModel()
            //{
            //    ClientContact = new 客戶聯絡人(),
            //    ClientBank = new 客戶銀行資訊()
            //};
            //#region ReadData
            //data.Client = db.客戶資料.FirstOrDefault(p => p.Id == id);
            //if (db.客戶聯絡人.FirstOrDefault(p => p.Id == id) != null)
            //{
            //    data.ClientContact = db.客戶聯絡人.FirstOrDefault(p => p.Id == id);
            //}
            //if (db.客戶銀行資訊.FirstOrDefault(p => p.Id == id) != null)
            //{
            //    data.ClientBank = db.客戶銀行資訊.FirstOrDefault(p => p.Id == id);
            //}

            //#endregion
            var model = db.客戶資料.FirstOrDefault(p => p.Id == id);

            return View(model);

        }

        [HttpPost]
        public ActionResult UPdate(客戶資料 client)
        {

            var oldClient = db.客戶資料.FirstOrDefault(p => p.Id == client.Id);

            oldClient.客戶名稱 = client.客戶名稱;
            oldClient.統一編號 = client.統一編號;
            oldClient.電話 = client.電話;
            oldClient.傳真 = client.傳真;
            oldClient.Email = client.Email;


            //#region 客戶聯絡人
            //var oldContact = db.客戶聯絡人.FirstOrDefault(p => p.Id == clientVM.Client.Id);
            //if (oldContact != null)
            //{
            //    oldContact.姓名 = clientVM.ClientContact.姓名;
            //    oldContact.手機 = clientVM.ClientContact.手機;
            //    oldContact.電話 = clientVM.ClientContact.電話;
            //}
            //else
            //{
            //    //新增紀錄
            //    db.客戶聯絡人.Add(new 客戶聯絡人()
            //    {
            //        客戶Id = clientVM.Client.Id,
            //        姓名 = clientVM.ClientContact.姓名,
            //        手機 = clientVM.ClientContact.手機,
            //        電話 = clientVM.ClientContact.電話
            //    });
            //}
            //#endregion


            //var oldBank = db.客戶銀行資訊.FirstOrDefault(p => p.客戶Id == clientVM.Client.Id);
            //if (oldBank != null)
            //{
            //    oldBank.銀行名稱 = clientVM.ClientBank.銀行名稱;
            //    oldBank.銀行代碼 = clientVM.ClientBank.銀行代碼;
            //    oldBank.分行代碼 = clientVM.ClientBank.分行代碼;
            //    oldBank.帳戶名稱 = clientVM.ClientBank.帳戶名稱;
            //    oldBank.帳戶號碼 = clientVM.ClientBank.帳戶號碼;
            //    oldBank.客戶資料 = clientVM.ClientBank.客戶資料;
            //}
            //else
            //{
            //    db.客戶銀行資訊.Add(new 客戶銀行資訊()
            //    {
            //        客戶Id = clientVM.Client.Id,
            //        銀行代碼 = clientVM.ClientBank.銀行代碼,
            //        分行代碼 = clientVM.ClientBank.分行代碼,
            //        帳戶名稱 = clientVM.ClientBank.帳戶名稱,
            //        帳戶號碼 = clientVM.ClientBank.帳戶號碼,
            //        客戶資料 = clientVM.ClientBank.客戶資料
            //    });
            //}

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ee)
            {
                foreach (var entityErrors in ee.EntityValidationErrors)
                {
                    foreach (var vErrors in entityErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vErrors.PropertyName + " 發生錯誤：" + vErrors.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Dele(int id)
        {
            var data = db.客戶資料.FirstOrDefault(p => p.Id == id);
            //if (data.客戶聯絡人 != null)
            //{
            //    data.客戶聯絡人.Remove(data.客戶聯絡人.FirstOrDefault(p=>p.客戶Id==id));
            //    data.客戶銀行資訊.Remove(data.客戶銀行資訊.FirstOrDefault(p=>p.客戶Id==id));
            //    db.SaveChanges();
            //}
            //db.客戶資料.Remove(data);

            if (data != null)
            {
                data.is刪除 = true;
            }

            db.SaveChanges();
            return View();
        }

    }
}