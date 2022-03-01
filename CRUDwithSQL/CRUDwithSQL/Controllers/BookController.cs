using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDwithSQL.Data;
using CRUDwithSQL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDwithSQL.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration _configuration;

        public BookController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Book
        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("BookViewAll", sqlConnection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.Fill(dataTable);
            }
            return View(dataTable);
        }


        // GET: Book/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            BookViewModel bookViewModel = new BookViewModel();

            if (id>0)
            {
                bookViewModel = FetchBookById(id);
            }
         
            return View(bookViewModel);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("BookID,Title,Author,Price")] BookViewModel bookViewModel)
        {
           

            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("BookAddOrEdit", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.AddWithValue("BookID", bookViewModel.BookID);
                    sqlCmd.Parameters.AddWithValue("Title", bookViewModel.Title);
                    sqlCmd.Parameters.AddWithValue("Author", bookViewModel.Author);
                    sqlCmd.Parameters.AddWithValue("Price", bookViewModel.Price);
                    sqlCmd.ExecuteNonQuery();
                }
             
                return RedirectToAction(nameof(Index));
            }
            return View(bookViewModel);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
           

            return View();
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {    
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public BookViewModel FetchBookById(int? id)
        {
          BookViewModel bookViewModel = new BookViewModel();

           using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                DataTable dataTable = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("BookViewByID", sqlConnection);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("BookID", id);
                sqlData.Fill(dataTable);
                if (dataTable.Rows.Count==1)
                {
                    bookViewModel.BookID = Convert.ToInt32(dataTable.Rows[0]["BookID"].ToString());
                    bookViewModel.Title = dataTable.Rows[0]["Title"].ToString();
                    bookViewModel.Author = dataTable.Rows[0]["Author"].ToString();
                    bookViewModel.Price = Convert.ToInt32(dataTable.Rows[0]["Price"].ToString());
                }
            }
            return bookViewModel;
        }

       
    }
}
