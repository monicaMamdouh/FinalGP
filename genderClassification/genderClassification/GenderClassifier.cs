using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class GenderClassifier
    {
        public void Classification()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");
            Dictionary<String, List<InvertedItem>> index = new Dictionary<String, List<InvertedItem>>();

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select Term,gender from genderTerms", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            List<Document> _trainCorpus = new List<Document>();

            foreach (DataRow row in dataTable.Rows)
            {
                String Term = row["Term"].ToString().ToLower();
                String gender = row["gender"].ToString().ToLower();
                var dokumen = new Document(gender, Term);
                _trainCorpus.Add(dokumen);
            }
            try
            {
                DataTable data = new DataTable();
                SqlCommand cm = new SqlCommand("select UserId,Term from genderTermsTest ", con);
                SqlDataReader read = cm.ExecuteReader();
                data.Load(read);
                foreach (DataRow rowData in data.Rows)
                {
                    String WordsClass = "";
                    String TermTest = rowData["Term"].ToString().ToLower();
                    // String TermTest = "Business compnay";
                    var c = new Classifier(_trainCorpus);
                    var male = c.IsInClassProbability("male", TermTest);
                    var female = c.IsInClassProbability("female", TermTest);
                    if(male > female)
                    { WordsClass = "male"; }
                    else { WordsClass = "female"; }
                    
                    try
                    {
                        SqlCommand com = new SqlCommand("INSERT INTO ClassifierResult (Term,ReplaceTerm) VALUES(@t,@r)", con);
                        com.Parameters.AddWithValue("@t", TermTest);
                        com.Parameters.AddWithValue("@r", WordsClass);
                        // Console.WriteLine();
                        com.ExecuteNonQuery();

                    }
                    catch { throw; }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

