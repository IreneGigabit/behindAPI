using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditableListMvc.Models;

namespace EditableListMvc.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index(string viewtype) {
            using (DatabaseEntities db = new DatabaseEntities()) {
                Order o = db.Orders.Select(x => x).FirstOrDefault();
                if (o == null) {
                    Order od = new Order()
                    {
                        OrderNo = DateTime.Today.ToString("yyyyMMdd")+"001",
                        OrderDate = DateTime.Today,
                        Description = "it is a new auto Order_"+ DateTime.Today.ToString("yyyyMMdd")
                    };
                    db.Orders.Add(od);

                    od.OrderDetails.Add(new OrderDetail() { ItemName = "AA", Quantity = 3, Rate = 14, TotalAmount = 3 * 14 });
                    od.OrderDetails.Add(new OrderDetail() { ItemName = "BB", Quantity = 5, Rate = 24, TotalAmount = 5 * 24 });

                    db.SaveChanges();
                }

                Order ov = db.Orders.ToList().Select(z => new Order
                {
                    OrderID = z.OrderID,
                    OrderNo = z.OrderNo,
                    OrderDate = z.OrderDate,
                    Description = z.Description,
                    //OrderDetails = o.OrderDetails.Select(d => new OrderDetail { ItemName = d.ItemName, Quantity = d.Quantity, Rate = d.Rate, TotalAmount = d.TotalAmount }).ToList()
                    OrderDetails = z.OrderDetails
                }).FirstOrDefault();
                if (viewtype == "foreach") {
                    return View("IndexForeach", ov);
                }
                return View(ov);
            }
        }


        [HttpPost]
        /*public ActionResult Index(Order orr) {
            using (DatabaseEntities db = new DatabaseEntities()) {
                db.Orders.Add(orr);
                db.SaveChanges();

                return RedirectToAction("Index", "Order");
            }
        }*/
        public ActionResult Index(Order orr,string command) {
            if (command == "Save") {
                using (DatabaseEntities db = new DatabaseEntities()) {
                    if (orr.OrderID > 0) {
                        //Edit
                        var v = db.Orders.Where(a => a.OrderID == orr.OrderID).FirstOrDefault();
                        if (v != null) {
                            v.OrderNo = orr.OrderNo;
                            v.OrderDate = orr.OrderDate;
                            v.Description = orr.Description;
                            foreach (OrderDetail dd in orr.OrderDetails) {
                                if (dd.OrderItemsID > 0) {
                                    OrderDetail ord = v.OrderDetails.Where(z => z.OrderItemsID == dd.OrderItemsID).FirstOrDefault();
                                    if (ord != null) {
                                        ord.ItemName = dd.ItemName;
                                        ord.Quantity = dd.Quantity;
                                        ord.Rate = dd.Rate;
                                        ord.TotalAmount = dd.Quantity * dd.Rate;
                                    }
                                } else {
                                    v.OrderDetails.Add(new OrderDetail() { ItemName = dd.ItemName, Quantity = dd.Quantity, Rate = dd.Rate, TotalAmount = dd.Quantity * dd.Rate });
                                }
                            }
                        }
                    } else {
                        //New
                        //取得單號
                        string seqKey = "ORD" + DateTime.Today.ToString("yyyyMM");
                        SequenceDict sq = db.SequenceDicts.Where(q => q.SequqnceKey == seqKey).FirstOrDefault();
                        int seqno = 0;
                        if (sq == null) {
                            db.SequenceDicts.Add(new SequenceDict { SequqnceKey = seqKey, SequenceNo = 1 });
                            seqno = 1;
                        }else {
                            seqno = sq.SequenceNo + 1;
                            sq.SequenceNo = sq.SequenceNo + 1;
                        }

                        string ordNo = string.Format("{0:yyyyMM}{1:0000}", DateTime.Today, seqno);

                        Order od = new Order()
                        {
                            OrderNo = ordNo,
                            OrderDate = orr.OrderDate,
                            Description = orr.Description
                        };
                        db.Orders.Add(od);

                        foreach (OrderDetail dd in orr.OrderDetails) {
                            if (dd.ItemName != null)
                                od.OrderDetails.Add(new OrderDetail() { ItemName = dd.ItemName, Quantity = dd.Quantity, Rate = dd.Rate, TotalAmount = dd.Quantity * dd.Rate });
                        }
                    }
                    db.SaveChanges();

                }
            }

            if (command == "Delete") {
                using (DatabaseEntities db = new DatabaseEntities()) {
                    var v = db.Orders.Where(a => a.OrderID == orr.OrderID).FirstOrDefault();

                    if (v != null) {

                        db.Orders.Remove(v);

                        List<OrderDetail> dd = db.OrderDetails.Where(z => z.OrderID == v.OrderID).ToList();
                        foreach (OrderDetail zz in dd) {
                              db.OrderDetails.Remove(zz);
                        }


                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index", "Order");
        }
    }
}
