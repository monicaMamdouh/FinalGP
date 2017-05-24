using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class genderTermTest
    {
        public void getgenderTermsTest()
        { 

         SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");

         DataTable dataTable = new DataTable();
         SqlCommand cmd = new SqlCommand("select userId,description from genderTestingAfterCleaning", con);
         con.Open();
         SqlDataReader reader = cmd.ExecuteReader();
         dataTable.Load(reader);
         //dataGridView1.DataSource = dataTable;
         foreach (DataRow row in dataTable.Rows)
         {
             String Text = row["description"].ToString().ToLower();
             long userId = Int64.Parse(row["UserID"].ToString());


             List<String> stringList = new List<string>();
             stringList = Text.Split(' ').ToList();
             for (int i = 0; i < stringList.Count(); i++)
             {
                 try
                 {
                     SqlCommand c = new SqlCommand("INSERT INTO genderTermsTest (userId,Term) VALUES(@g,@t)", con);

                     c.Parameters.AddWithValue("@g", userId);
                     c.Parameters.AddWithValue("@t",stringList[i]);

                     c.ExecuteNonQuery();

                 }
                 catch { throw; }

             }

         }
            con.Dispose();
      }
    }
}
