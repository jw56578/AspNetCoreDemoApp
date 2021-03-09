using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine(Request.GetDisplayUrl());
            Console.WriteLine(Request.GetEncodedUrl());

            return GetData();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        public static List<string> GetData()
        {
            List<string> items = new List<string>();
            string connStr = "server=den1.mysql1.gear.host;user=aca311week3day1;database=aca311week3day1;port=3306;password=Wq87E!7mUF~7";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = "SELECT * from customers";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    items.Add(rdr[1].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return items;
        }
    }
}