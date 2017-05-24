using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsKmeanClustering.VectorSpaceModel
{
    class calculateTFIDF
    {
        public void CalculateDocumentScore()
        {
            // Some example documents.
            string[] documents = new string[3000];

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=WordsClustering ;Integrated Security=True");
            con.Open();

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select CleanedTweets from TestTweets ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            List<string> stemmedDoc = new List<string>();

            for (int i = 0; i < 3000; i++)
            {
                DataRow myRow = dataTable.Rows[i];
                String Tweet = myRow["CleanedTweets"].ToString().ToLower();
                documents[i] = Tweet;
            }



            // Apply TF*IDF to the documents and get the resulting vectors.
            double[][] inputs = TFIDF.Transform(documents, 0);
            inputs = TFIDF.Normalize(inputs);
            double totalTweetWeight;
            int k = 1;
            // Display the output.
            for (int index = 0; index < inputs.Length; index++)
            {
                // Console.WriteLine(documents[index]);
                totalTweetWeight = 0.0;
                foreach (double value in inputs[index])
                {
                    totalTweetWeight += value;
                }

                //Console.WriteLine("\n");
                //string query = string.Format("UPDATE CleanedDocumentForInvertedIndex SET Weight = '{0}' WHERE DocumentID = " + k, totalTweetWeight);
               // SqlCommand c = new SqlCommand(query, con);
               // c.ExecuteNonQuery();
               // Console.WriteLine(totalTweetWeight);
               // k++;
            }
            con.Dispose();

        }
    }
}

