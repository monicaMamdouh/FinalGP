using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterestClassification
{
    class genderTermTest
    {
        public void getgenderTermsTest()
        { 

         SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=UserInterestClassification ;Integrated Security=True");

         DataTable dataTable = new DataTable();
         SqlCommand cmd = new SqlCommand("select TweetId,Tweet from InterestTestingAfterCleaning", con);
         con.Open();
         SqlDataReader reader = cmd.ExecuteReader();
         dataTable.Load(reader);
         //dataGridView1.DataSource = dataTable;
         foreach (DataRow row in dataTable.Rows)
         {
             String Text = row["Tweet"].ToString().ToLower();
             long TweetId = Int64.Parse(row["TweetId"].ToString());


             List<String> stringList = new List<string>();
             stringList = Text.Split(' ').ToList();
             for (int i = 0; i < stringList.Count(); i++)
             {
                 try
                 {
                     SqlCommand c = new SqlCommand("INSERT INTO InterestTermsTest (TweetId,Term) VALUES(@g,@t)", con);

                     c.Parameters.AddWithValue("@g", TweetId);
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
