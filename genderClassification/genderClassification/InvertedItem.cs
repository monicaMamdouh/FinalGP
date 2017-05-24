using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBayesianModelTrends
{
    class InvertedItem
    {

            public string gender;
            public int position;
            public int frequency;

            public InvertedItem() { }
            public InvertedItem(String gender, int position, int frquency)
            {
                this.gender = gender;
                this.position = position;
                this.frequency = frquency;
            }
        }
    }

