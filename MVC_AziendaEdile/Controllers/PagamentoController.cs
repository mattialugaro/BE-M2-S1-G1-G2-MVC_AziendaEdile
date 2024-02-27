using MVC_AziendaEdile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AziendaEdile.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        public ActionResult Index()
        {
            List<Pagamento> listaPag = new List<Pagamento>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Pagamento";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pagamento p = new Pagamento();
                    p.PeriodoPagamento = Convert.ToDateTime(reader["PeriodoPagamento"]);
                    p.AmmontarePagamento = Convert.ToDecimal(reader["AmmontarePagamento"]);
                    p.AccontoStipendio = reader["AccontoStipendio"].ToString();
                    p.IDDipendente = Convert.ToInt32(reader["IDDipendente"]);

                    listaPag.Add(p);
                }

            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View(listaPag);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Pagamento p )
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO Pagamento (PeriodoPagamento, AmmontarePagamento, AccontoStipendio, IDDipendente) VALUES (@PeriodoPagamento, @AmmontarePagamento, @AccontoStipendio, @IDDipendente)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PeriodoPagamento", p.PeriodoPagamento);
                cmd.Parameters.AddWithValue("@AmmontarePagamento", p.AmmontarePagamento);
                cmd.Parameters.AddWithValue("@AccontoStipendio", p.AccontoStipendio);
                cmd.Parameters.AddWithValue("@IDDipendente", p.IDDipendente);
                cmd.ExecuteNonQuery();
            
            }
            catch(Exception ex) 
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View();
        }
    }
}