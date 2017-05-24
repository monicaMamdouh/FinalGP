using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;

namespace genderClassification
{
    class Program
    {
        static void Main(string[] args)
        {
            //read csv to sql
            //  fromCsvtoSQL c = new fromCsvtoSQL();
            //  c.readFromCsvTosql();

            //clean Data
            // CleaningData clean = new CleaningData();
            // clean.cleanTrainingDescription();

            //getEachGenderTerms
            //genderTerms g = new genderTerms();
            //g.getgenderTerms();


            //get Each gender set of Words
            //genderWords words = new genderWords();
            //words.getEachGenderWords();

            //Build Gender Inverted index
            // genderInvertedIndex invert = new genderInvertedIndex();
            // invert.buildInvertedIndex();

            //our Tweets Cleaning Process
            //CleaningDataTest cTest = new CleaningDataTest();
            //cTest.cleanTestingDescription();

            // save each Term of our tweet Individual
            // genderTermTest g = new genderTermTest();
            // g.getgenderTermsTest();

            //get each Term Genders
            //eachTermGenders each = new eachTermGenders();
            //each.calculateEachTermGenders();

            //Final Step : Classification :)
            //GenderClassifier u = new GenderClassifier();
            //u.Classification();

            // SqlCommand command = new SqlCommand("SELECT count(distinct TweetId) FROM InvertedTerm", con);
           // Int32 count = (Int32)command.ExecuteScalar();


        }
    }
}
