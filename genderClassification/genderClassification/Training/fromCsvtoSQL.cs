using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class fromCsvtoSQL
    {

        public void readFromCsvTosql()
        {
            //Read Training Data from csv file 
            //save it in sqlServer
             SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");

              StreamReader readFile = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\genderClassification.csv");
              var csv = new CsvReader(readFile);
              con.Open();
              List<string> genders = new List<string>();
              List<string> descriptions = new List<string>();
              while (csv.Read())
              {

                  try
                  {
                      var gender = csv.GetField<string>("gender");
                      var description = csv.GetField<string>("description");

                      SqlCommand c = new SqlCommand("INSERT INTO genderclassificationTraining (gender,description) VALUES(@g,@d)", con);

                      c.Parameters.AddWithValue("@g", gender);
                      c.Parameters.AddWithValue("@d", description);

                      c.ExecuteNonQuery();

                  }
                  catch { throw; }

              }
            con.Dispose();
        }
    }
}
