using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class CleaningData
    {
        public void cleanTrainingDescription()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select gender,description from genderclassificationTraining", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            //dataGridView1.DataSource = dataTable;
            foreach (DataRow row in dataTable.Rows)
            {
                String Text = row["description"].ToString().ToLower();
                String gender = row["gender"].ToString().ToLower();
                Tokenizer token = new Tokenizer();
                String afterToken = token.token(Text);

                Normalization norm = new Normalization();
                String afterNormal = norm.normal(afterToken);

               stopWords1 stop1 = new stopWords1();
               String afterStop1 = stop1.stopWordFunction1(afterNormal);

              stopWords2 stop2 = new stopWords2();
              String afterStop2 = stop2.stopWordFunction2(afterStop1);

              stemmingFunction sf = new stemmingFunction();
              string afterStem = sf.stemFunction(afterStop2);
                try
                {
                    SqlCommand c = new SqlCommand("INSERT INTO genderTrainingAfterCleaning (gender,description) VALUES(@g,@d)", con);

                    c.Parameters.AddWithValue("@g", gender);
                    c.Parameters.AddWithValue("@d", afterStem);

                    c.ExecuteNonQuery();

                }
                catch { throw; }
            }
            con.Dispose();
        }
        
    }
}
