using System;


namespace UserInterestClassification
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

