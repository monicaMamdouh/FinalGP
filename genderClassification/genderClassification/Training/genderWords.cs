using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class genderWords
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");

        public void getEachGenderWords()
        {
            Dictionary<String, List<String>> index = new Dictionary<String, List<String>>();

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select Term,gender from genderTerms", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            //dataGridView1.DataSource = dataTable;
           
            foreach (DataRow row in dataTable.Rows)
            {
                String Term = row["Term"].ToString().ToLower();
                String gender = row["gender"].ToString().ToLower();
                List<String> words = new List<String>();

                if (!index.ContainsKey(gender))    //check if the dictionary Not contain the same term 
                {

                    words.Add(Term);
                    index.Add(gender, words);

                }
                else
                {
                    List<String> t = new List<String>();
                    t = index[gender];
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
                    SqlCommand c = new SqlCommand("INSERT INTO genderWords (gender,genderWords) VALUES(@g,@w)", con);
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
