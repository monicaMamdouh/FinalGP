using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsKmeanClustering.TweetsWordsInvertedIndex
{
    class InvertedIndex
    {
       
        public void buildInvertedIndex()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=WordsClustering ;Integrated Security=True");
            Dictionary<String, List<InvertedItem>> index = new Dictionary<String, List<InvertedItem>>();

            con.Open();

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select Term,TF,IDF,Weight from WordsWeight", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            //dataGridView1.DataSource = dataTable;
            long currentId = 1;
            int pos = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                
                String Term = row["Term"].ToString().ToLower();
                int TF= Int32.Parse(row["TF"].ToString());
                double IDF = double.Parse(row["IDF"].ToString());
                double Weight = double.Parse(row["Weight"].ToString());

                List<String> answer = new List<String>();
                List<InvertedItem> idx = new List<InvertedItem>();
                double totalWeight = 0.0;

                if (!index.ContainsKey(Term))    //check if the dictionary Not contain the same term 
                {
                    totalWeight += Weight;
                    idx.Add(new InvertedItem(TF,IDF, totalWeight));
                    index.Add(Term, idx);

                }
                else
                {
                    totalWeight += Weight;
                    List<InvertedItem> t = new List<InvertedItem>();
                    t = index[Term];
                    t.Add(new InvertedItem(TF, IDF, totalWeight));
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
                        SqlCommand c = new SqlCommand("INSERT INTO InvertedIndex (Term,TF,IDF,Weight) VALUES(@a,@b,@c,@d)", con);
                        c.Parameters.AddWithValue("@a", key);
                        c.Parameters.AddWithValue("@c", t[0].IDF);

                         double totalWeight = 0.0;
                         int totalTF = 0;
                         for (int k = 0; k < t.Count(); k++)
                         {
                            totalWeight += t[k].weight;
                            totalTF += t[k].TF;
                         }
                    

                           c.Parameters.AddWithValue("@d", totalWeight);
                          c.Parameters.AddWithValue("@b", totalTF);
                    // Console.WriteLine();  
                    c.ExecuteNonQuery();

                    }
                    catch { throw; }
                }

            con.Dispose();
        }
          

        }
    }

