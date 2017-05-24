using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class genderTerms
    {
        public void getgenderTerms()
        { 

         SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");

         DataTable dataTable = new DataTable();
         SqlCommand cmd = new SqlCommand("select gender,description from genderTrainingAfterCleaning", con);
         con.Open();
         SqlDataReader reader = cmd.ExecuteReader();
         dataTable.Load(reader);
         //dataGridView1.DataSource = dataTable;
         foreach (DataRow row in dataTable.Rows)
         {
             String Text = row["description"].ToString().ToLower();
             String gender = row["gender"].ToString().ToLower();


             List<String> stringList = new List<string>();
             stringList = Text.Split(' ').ToList();
             for (int i = 0; i < stringList.Count(); i++)
             {
                    SqlCommand c = new SqlCommand("INSERT INTO genderTerms (gender,Term) VALUES(@gender,@te)", con);

                    try
                    {

                     c.Parameters.AddWithValue("@gender", gender);
                     c.Parameters.AddWithValue("@te",stringList[i]);
                        c.ExecuteNonQuery();



                    }
                    catch { throw; }
                    
                }

            }
            con.Dispose();
        }
       
    }
}
