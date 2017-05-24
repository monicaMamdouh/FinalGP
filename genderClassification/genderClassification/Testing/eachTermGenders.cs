using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class eachTermGenders 
    {
        public void calculateEachTermGenders()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");
            con.Open();
            //gender Test Table
            DataTable dataTable = new DataTable();
            SqlCommand cm = new SqlCommand("select userId,Term from genderTermsTest ", con);
            SqlDataReader reader = cm.ExecuteReader();
            dataTable.Load(reader);

            //gender Training Table
            DataTable table = new DataTable();
            SqlCommand c = new SqlCommand("select Term,gender from genderInvertedIndex", con);
            SqlDataReader read = c.ExecuteReader();
            table.Load(read);
            foreach (DataRow row in dataTable.Rows)
            {
                String TermTest = row["Term"].ToString().ToLower();
                long userId = Int64.Parse(row["userId"].ToString());

                foreach (DataRow rowData in table.Rows)
                {
                    String genderTraining = rowData["gender"].ToString();
                    String TermTraining = rowData["Term"].ToString().ToLower();
                    List<String> TermsTrain = TermTraining.Split(' ').ToList();
                    foreach (string Term in TermsTrain)
                    {
                        SqlCommand com = new SqlCommand("insert into genderTestFinal (userId,Term,ReplcaeTerm) values(@user,@Te,@re)", con);

                        if (TermTest.ToLower().Equals(Term))
                        {

                            try
                            {
                                com.Parameters.AddWithValue("@user", userId);
                                com.Parameters.AddWithValue("@te", TermTest);
                                com.Parameters.AddWithValue("@re", genderTraining);

                                com.ExecuteNonQuery();

                            }
                            catch { }

                        }


                    }
                }
            }
            con.Dispose();
        }
    }
}
