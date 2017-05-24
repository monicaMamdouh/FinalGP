using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterestClassification
{
    class Program
    {
        static void Main(string[] args)
        {
            //read csv to sql
            // fromCsvtoSQL c = new fromCsvtoSQL();
            // c.readFromCsvTosql();

            //clean Data
            // CleaningData clean = new CleaningData();
            // clean.cleanTrainingDescription();

            //getEachInterestTerms
            //InterestTerms i = new InterestTerms();
            // i.getTerms();


            //get Each Interest set of Words
            //InterestWords words = new InterestWords();
            //words.getEachInterestWords();


            //Build Gender Inverted index
            //InterestInvertedIndex invert = new InterestInvertedIndex();
            //invert.buildInvertedIndex();

            //our Tweets Cleaning Process
            //CleaningDataTest cTest = new CleaningDataTest();
            //cTest.cleanTestingDescription();

            // save each Term of our tweet Individual
            //genderTermTest g = new genderTermTest();
            //g.getgenderTermsTest();

            //get each Term Genders
            //eachTermGenders each = new eachTermGenders();
            //each.calculateEachTermGenders();

            //Finally Classification
            //UserInterestClassifier u = new UserInterestClassifier();
            //u.Classification();


            //TO DO
            //count each category
            // SqlCommand command = new SqlCommand("SELECT count(distinct TweetId) FROM InvertedTerm", con);
            // Int32 count = (Int32)command.ExecuteScalar();





        }
    }
}
