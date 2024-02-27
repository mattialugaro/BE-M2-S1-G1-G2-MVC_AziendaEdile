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
    public class DipendenteController : Controller
    {
        // GET: Dipendente
        public ActionResult Index()
        {
            List<Dipendente> listaDip = new List<Dipendente>(); 
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Dipendente";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dipendente d = new Dipendente();
                    d.Nome = reader["Nome"].ToString();
                    d.Cognome = reader["Cognome"].ToString();
                    d.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    d.Indirizzo = reader["Indirizzo"].ToString();
                    d.Coniugato = Convert.ToBoolean(reader["Coniugato"]);
                    d.NumeroFigli = Convert.ToInt32(reader["NumeroFigli"]);
                    d.Mansione = reader["Mansione"].ToString();
                    listaDip.Add(d);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View(listaDip);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Dipendente d )
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO Dipendente (Nome, Cognome, Indirizzo, CodiceFiscale, Coniugato, NumeroFigli, Mansione) VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @NumeroFigli, @Mansione)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", d.Nome);
                cmd.Parameters.AddWithValue("@Cognome", d.Cognome);
                cmd.Parameters.AddWithValue("@Indirizzo", d.Indirizzo);
                cmd.Parameters.AddWithValue("@CodiceFiscale", d.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Coniugato", d.Coniugato);
                cmd.Parameters.AddWithValue("@NumeroFigli", d.NumeroFigli);
                cmd.Parameters.AddWithValue("@Mansione", d.Mansione);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
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