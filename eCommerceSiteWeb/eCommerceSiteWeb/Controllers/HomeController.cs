using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerceSiteWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.Configuration;
using System.IO;

namespace eCommerceSiteWeb.Controllers
{
    public class HomeController : Controller
    {
        public eCommerceDBEntitie _db = new eCommerceDBEntitie();
        private List<Products> listChart;
        Products prodChart;
        int productQuantity;
        
        ChartClass ctr;
        List<ChartClass> listQuantityProduct;
        
        ChartClass quantityProdChart;
        Dictionary<int, Products> _dbAddChart = new Dictionary<int, Products>();
        Products valueAdd = new Products();
        int i = 0;
        private string valueID;
        public string TestVariable = "Test";


        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View(_db.Products.ToList());
        }

        [HttpPost]
        public ActionResult Index(List<string> IDProduct, List<string> Quantity)
        {
          int i=0;
          int j = 0;
          string IDPrtChoose=null;
          string QuantityPrtChoose=null;
            foreach (string quantityProduct in Quantity)
            {
                
                if (quantityProduct != "")
                {
                    foreach (string IDPrd in IDProduct)
                    {
                        if (i == j)
                        {
                            IDPrtChoose = IDPrd;
                            QuantityPrtChoose = quantityProduct;
                            break;
                        }
                        j++;
                    }
                }
                i++;
            }


            // ho considerato id numerico, l' avrei potuto anche definire tipo string
         
            
                var moveToChart = (from m in _db.Products where m.ID == IDPrtChoose select m).First();
                var AddToChart = (from m in _db.Products where m.ID == moveToChart.ID select m).First();


                if (Session["ListChart"] == null)
                {
                    listChart = new List<Products>();
                    prodChart = (Products)AddToChart;
                   
                    listChart.Add(prodChart);

                    Session["ListChart"] = listChart;

                }

                else
                {
                    listChart = (List<Products>)Session["ListChart"];
                    Products addProduct = (Products)AddToChart;

                    listChart.Add(addProduct);
                    Session["ListChart"] = listChart;
                }

                quantityProdChart = new ChartClass();

                int qntProd = Int32.Parse(QuantityPrtChoose);
                quantityProdChart.Title = moveToChart.Title;
                quantityProdChart.IDProduct = moveToChart.ID;
                if (Session["PriceProduct"] == null)
                {
                    listQuantityProduct = new List<ChartClass>();
                    quantityProdChart.Quantity = qntProd;


                    quantityProdChart.PriceSingProduct = moveToChart.Price.Value;
                    quantityProdChart.TotPriceAllProduct += quantityProdChart.PriceSingProduct * quantityProdChart.Quantity;

                    listQuantityProduct.Add(quantityProdChart);
                    Session["PriceProduct"] = listQuantityProduct;

                }

                else
                {

                    listQuantityProduct = (List<ChartClass>)Session["PriceProduct"];

                    quantityProdChart.Quantity = qntProd;

                    bool boolVerif = false;
                    foreach (var item in listQuantityProduct)
                    {
                        if (item.IDProduct == moveToChart.ID)
                        {
                            item.Quantity += qntProd;
                            item.PriceSingProduct = moveToChart.Price.Value;
                            item.TotPriceAllProduct += (Double)moveToChart.Price * quantityProdChart.Quantity;
                            boolVerif = true;
                        }
                    }
                    if (boolVerif == false)
                    {

                        quantityProdChart.Title = moveToChart.Title;
                        quantityProdChart.PriceSingProduct = moveToChart.Price.Value;
                        //quantityProdChart.TotPriceSingProduct = (Double)moveToChart.Price * quantityProdChart.PriceSingProduct;
                        quantityProdChart.TotPriceAllProduct += (Double)moveToChart.Price * quantityProdChart.Quantity;

                        listQuantityProduct.Add(quantityProdChart);

                    }



                }


                Session["PriceProduct"] = listQuantityProduct;
            

            return View(_db.Products.ToList());
        }



        public ActionResult About()
        {
            return View();
        }
        // GET: /Home/Chart/1

        public ActionResult Chart()
        {
            return View(Session["PriceProduct"]);
         } 
  
    }
  }

       

