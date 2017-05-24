using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace UserInterestClassification
{
    class InterestWords
    {
        public void getEachInterestWords()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=UserInterestClassification ;Integrated Security=True");
            Dictionary<String, List<String>> index = new Dictionary<String, List<String>>();

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select Term,category from InterestsTerms", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            //dataGridView1.DataSource = dataTable;
           
            foreach (DataRow row in dataTable.Rows)
            {
                String Term = row["Term"].ToString().ToLower();
                String category = row["category"].ToString().ToLower();
                List<String> words = new List<String>();

                if (!index.ContainsKey(category))    //check if the dictionary Not contain the same term 
                {

                    words.Add(Term);
                    index.Add(category, words);

                }
                else
                {
                    List<String> t = new List<String>();
                    t = index[category];
                    t.Add(Term);
                    words.AddRange(t);


                }
            }
            List<string> keyList = new List<string>(index.Keys);

            foreach (String key in keyList)
            {
                List<string> t = new List<string>();
                t = index[key];

                try
                {
                    SqlCommand c = new SqlCommand("INSERT INTO InterestsWords (category,categoryWords) VALUES(@g,@w)", con);
                    c.Parameters.AddWithValue("@g", key);

                    //Console.Write("word: " + key + "    ");

                    String wordString;
                    String fullWords = null;

                    for (int k = 0; k < t.Count(); k++)
                    {
                        wordString = t[k].ToString() + " ";
                        fullWords += wordString;

                        //  Console.Write(t[k].position + " ");
                    }
                    c.Parameters.AddWithValue("@w", fullWords);

                    // Console.WriteLine();
                    c.ExecuteNonQuery();

                }
                catch { throw; }
            }
            con.Dispose();
        }
  
    }
}
