using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterestClassification
{
    class InterestTerms
    {
        public void getTerms()
        { 

         SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=UserInterestClassification ;Integrated Security=True");

         DataTable dataTable = new DataTable();
         SqlCommand cmd = new SqlCommand("select category,tweets from interestTrainingAfterCleaning", con);
         con.Open();
         SqlDataReader reader = cmd.ExecuteReader();
         dataTable.Load(reader);
         foreach (DataRow row in dataTable.Rows)
         {
                String Text = row["tweets"].ToString();
                String cat = row["category"].ToString();
             List<String> stringList = new List<string>();
             stringList = Text.Split(' ').ToList();
             foreach (string str in stringList)
             {
                 try
                 {
                     SqlCommand c = new SqlCommand("INSERT INTO InterestsTerms (category,Term) VALUES(@c,@t)", con);

                     c.Parameters.AddWithValue("@c", cat);
                     c.Parameters.AddWithValue("@t",str);

                     c.ExecuteNonQuery();

                 }
                 catch { throw; }

             }

         }
           // con.Dispose();
      }
    }
}
