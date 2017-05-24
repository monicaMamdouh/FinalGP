using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterestClassification
{
    class eachTermGenders 
    {
        public void calculateEachTermGenders()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=UserInterestClassification ;Integrated Security=True");
            con.Open();
            //gender Test Table
            DataTable dataTable = new DataTable();
            SqlCommand cm = new SqlCommand("select TweetId,Term from InterestTermsTest ", con);
            SqlDataReader reader = cm.ExecuteReader();
            dataTable.Load(reader);

            //gender Training Table
            DataTable table = new DataTable();
            SqlCommand c = new SqlCommand("select Term,category from InterestInvertedIndex", con);
            SqlDataReader read = c.ExecuteReader();
            table.Load(read);
            foreach (DataRow row in dataTable.Rows)
            {
                String TermTest = row["Term"].ToString().ToLower();
                long TweetId = Int64.Parse(row["TweetId"].ToString());

                foreach (DataRow rowData in table.Rows)
                {
                    String categoryTraining = rowData["category"].ToString();
                    String TermTraining = rowData["Term"].ToString().ToLower();
                    List<String> TermsTrain = TermTraining.Split(' ').ToList();
                    foreach (string Term in TermsTrain)
                    {
                        SqlCommand com = new SqlCommand("insert into InterestTestFinal (TweetId,Term,ReplcaeTerm) values(@user,@Te,@re)", con);

                        if (TermTest.ToLower().Equals(Term))
                        {

                            try
                            {
                                com.Parameters.AddWithValue("@user", TweetId);
                                com.Parameters.AddWithValue("@te", TermTest);
                                com.Parameters.AddWithValue("@re", categoryTraining);

                                com.ExecuteNonQuery();

                            }
                            catch { throw; }

                        }


                    }
                }
            }
            con.Dispose();
        }
    }
}
