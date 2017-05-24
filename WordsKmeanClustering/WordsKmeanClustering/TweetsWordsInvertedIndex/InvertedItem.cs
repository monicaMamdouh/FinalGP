using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsKmeanClustering.TweetsWordsInvertedIndex
{
    class InvertedItem
    {

        public int TF;
        public double IDF;
        public double weight;

        public InvertedItem() { }
        public InvertedItem(int TF,double IDF,double Weight)
        {
            this.TF = TF;
            this.IDF = IDF;
            this.weight = Weight;
        }
    }
}
