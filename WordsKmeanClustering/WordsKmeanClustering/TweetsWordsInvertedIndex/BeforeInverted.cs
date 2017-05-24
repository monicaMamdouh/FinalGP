using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsKmeanClustering.TweetsWordsInvertedIndex
{
    class BeforeIverted
    {
        public void call()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=WordsClustering ;Integrated Security=True");

            con.Open();
            

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select CleanedTweets from TestTweets", con);
            
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            //dataGridView1.DataSource = dataTable;
            foreach (DataRow row in dataTable.Rows)
            {
                String Text = row["CleanedTweets"].ToString().ToLower();
               
             

                List<String> stringList = new List<string>();
                stringList = Text.Split(' ').ToList();
                for (int i = 0; i < stringList.Count(); i++)
                {
                    try
                    {
                        SqlCommand c = new SqlCommand("INSERT INTO InvertedTerm (Term) VALUES(@term)", con);

                        c.Parameters.AddWithValue("@term",stringList[i]);
                       c.ExecuteNonQuery();

                    }
                    catch { return; }

                }
                
            }

            con.Dispose();
        }





    }
} 
