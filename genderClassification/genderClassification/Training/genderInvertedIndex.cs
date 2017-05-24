using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class genderInvertedIndex
    {
        public void buildInvertedIndex()
        {
              SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");
               Dictionary<String, List<InvertedItem>> index = new Dictionary<String, List<InvertedItem>>();

               DataTable dataTable = new DataTable();
               SqlCommand cmd = new SqlCommand("select Term,gender from genderTerms", con);
               con.Open();
               SqlDataReader reader = cmd.ExecuteReader();
               dataTable.Load(reader);
               //dataGridView1.DataSource = dataTable;
               int pos = 1;
               foreach (DataRow row in dataTable.Rows)
               {
                   String Term = row["Term"].ToString().ToLower();
                   String gender = row["gender"].ToString().ToLower();
                   List<String> answer = new List<String>();
                   List<InvertedItem> idx = new List<InvertedItem>();
                   int freq = 0;

                   if (!index.ContainsKey(Term))    //check if the dictionary Not contain the same term 
                   {

                       idx.Add(new InvertedItem(gender, pos, freq));
                       index.Add(Term, idx);

                   }
                   else
                   {
                       List<InvertedItem> t = new List<InvertedItem>();
                       t = index[Term];
                       t.Add(new InvertedItem(gender, pos, freq));
                       idx.AddRange(t);


                   }
                   pos++;
               }
               List<string> keyList = new List<string>(index.Keys);

               foreach (String key in keyList)
               {
                   List<InvertedItem> t = new List<InvertedItem>();
                   t = index[key];

                   try
                   {
                       SqlCommand c = new SqlCommand("INSERT INTO genderInvertedIndex (Term,gender,frequency,position) VALUES(@t,@g,@f,@p)", con);
                       c.Parameters.AddWithValue("@t", key);

                       //Console.Write("word: " + key + "    ");

                       String postionString;
                       String fullPosition = null;
                       String documentId;
                       String documentfullIds = null;
                       for (int k = 0; k < t.Count(); k++)
                       {
                           postionString = t[k].position.ToString() + " ";                     
                           fullPosition += postionString;
                           documentId = t[k].gender.ToString() + " ";
                           documentfullIds += documentId;
                           //  Console.Write(t[k].position + " ");
                       }
                       c.Parameters.AddWithValue("@p", fullPosition);
                       c.Parameters.AddWithValue("@g", documentfullIds);
                       List<string> frquency = fullPosition.Split(' ').ToList();
                       c.Parameters.AddWithValue("@f", frquency.Count()-1);

                       // Console.WriteLine();
                       c.ExecuteNonQuery();

                   }
                   catch { throw; }
          }
            con.Dispose();

        }
    }
}
