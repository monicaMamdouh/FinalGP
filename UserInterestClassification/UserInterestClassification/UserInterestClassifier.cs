using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterestClassification
{
    class UserInterestClassifier
    {

        public void Classification()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=UserInterestClassification ;Integrated Security=True");
            Dictionary<String, List<InvertedItem>> index = new Dictionary<String, List<InvertedItem>>();

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select Term,category from InterestsTerms", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            List<Document> _trainCorpus = new List<Document>();

            foreach (DataRow row in dataTable.Rows)
            {
                String Term = row["Term"].ToString().ToLower();
                String category = row["category"].ToString().ToLower();
                var dokumen = new Document(category, Term);
                _trainCorpus.Add(dokumen);
            }
            try
            {
                DataTable data = new DataTable();
                SqlCommand cm = new SqlCommand("select TweetId,Term from InterestTermsTest ", con);
                SqlDataReader read = cm.ExecuteReader();
                data.Load(read);
                foreach(DataRow rowData in data.Rows)
                {
                    String WordsClass = "";
                     String TermTest =rowData["Term"].ToString().ToLower();
                   // String TermTest = "Business compnay";
                    var c = new Classifier(_trainCorpus);
                    var education = c.IsInClassProbability("education", TermTest);
                    var politics = c.IsInClassProbability("politics", TermTest);
                    var fashion = c.IsInClassProbability("fashion", TermTest);
                    var food = c.IsInClassProbability("food", TermTest);
                    var news = c.IsInClassProbability("news", TermTest);
                    var arts = c.IsInClassProbability("arts", TermTest);
                    var business = c.IsInClassProbability("business", TermTest);
                    var sports = c.IsInClassProbability("sports", TermTest);
                    var music = c.IsInClassProbability("music", TermTest);
                    var technology = c.IsInClassProbability("technology", TermTest);
                    //calculate maximum value
                    //if condition
                    if ( education > politics && education>fashion && education > food && education > news  && education > arts && education > business && education > sports && education > music &&education>technology)
                    {
                        WordsClass = "education";
                    }

                    if (politics > education && politics > fashion && politics > food && politics > news && politics > arts && politics > business && politics > sports && politics > music && politics> technology)
                    {
                        WordsClass = "politics";
                    }

                    if (fashion > politics && fashion > education && fashion > food && fashion > news && fashion > arts && fashion > business && fashion > sports && fashion > music && fashion > technology)
                    {
                        WordsClass = "fashion";
                    }


                    if (food > politics && food > fashion && food >education && food > news && food > arts && food > business && food > sports && food > music && food >technology)
                    {
                        WordsClass = "food";
                    }


                    if (news > politics && news > fashion && news > food && news > education && news > arts && news > business && news > sports && news > music && news> technology)
                    {
                        WordsClass = "news";
                    }


                    if (arts > politics && arts > fashion && arts > food && arts > news && arts > education && arts > business && arts > sports && arts > music && arts > technology)
                    {
                        WordsClass = "arts";
                    }


                    if (sports > politics && sports > fashion && sports > food && sports > news && sports > arts && sports > business && sports > education && sports > music && sports> technology)
                    {
                        WordsClass = "sports";
                    }

                    if (business > politics && business > fashion && business > food && business > news && business > arts && business > education && business > sports && business > music && business>technology)
                    {
                        WordsClass = "business";
                    }


                    if (music > politics && music > fashion && music > food && music > news && music > arts && music > business && music > sports && music > education && music >technology)
                    {
                        WordsClass = "music";
                    }
                    if (technology > politics && technology > fashion && technology > food && technology > news && technology > arts && technology > business && technology > sports && technology > education && technology > music)
                    {
                        WordsClass = "technology";
                    }
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
