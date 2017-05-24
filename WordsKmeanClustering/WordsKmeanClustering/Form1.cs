
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordsKmeanClustering.HelperClasses;
using Sparc.TagCloud;
using System.IO;
using WordCloudGen = WordCloud.WordCloud;
using WordsKmeanClustering.TweetsWordsInvertedIndex;
using WordsKmeanClustering.VectorSpaceModel;

namespace WordsKmeanClustering
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=WordsClustering ;Integrated Security=True");



        private bool isFinished;

        /// <summary>
        /// Number of iteration
        /// </summary>
        private int iterationNumber;




        /// <summary>
        /// List of DataPoint objects
        /// </summary>
        private List<DataPoint> listDataPoint;

        /// <summary>
        /// List of Cluster objects
        /// </summary>
        private List<Cluster> listCluster;

        /// <summary>
        /// Color list for cluster repsresenting color
        /// </summary>
        private List<Color> listColor;

        /// <summary>
        /// Number of DataPoints
        /// </summary>
        private long numberOfDataPoints;

        /// <summary>
        /// Number of Clusters
        /// </summary>
        private long numberOfClusters;

        /// <summary>
        /// enum Random Type of Generation DataPoints
        /// </summary>
        List<string> WordsList = new List<string>();
        List<int> FrequencyList = new List<int>();


        public Form1()
        {
            con.Open();
            InitializeComponent();
            InitializeVariables();
            // Reset();
            // InitializeCluster();
            // AssignDataPointsToCloserCluster();
            // CalculateCenterOfEachCluster();
            // FintTheResult();
            drawCloudWords();



        }
        private void CreateDataPoints()
        {

            try
            {
                DataTable t = new DataTable();
                SqlCommand m = new SqlCommand("select  Id,Term,IDF,TF,Weight from InvertedIndex", con);
                SqlDataReader r = m.ExecuteReader();
                t.Load(r);
                listDataPoint = new List<DataPoint>();
                listCluster = new List<Cluster>();

                int i = 0;
                foreach (DataRow dataRow in t.Rows)
                {
                    int frequency = Int32.Parse(dataRow["TF"].ToString());
                    int pointID = Int32.Parse(dataRow["Id"].ToString());
                    double IDF = double.Parse(dataRow["IDF"].ToString());
                    double weight = double.Parse(dataRow["Weight"].ToString());
                    string Term = dataRow["Term"].ToString();

                    int xPoint = frequency;
                    double yPoint = IDF;
                    double zPoint = weight;

                    DataPoint dataPoint = new DataPoint(pointID, Term, xPoint, yPoint, zPoint, null);
                    listDataPoint.Add(dataPoint);
                    i++;

                }
            }
            catch { return; }


        }


        /// <summary>
        /// Initilaize the initial variables for program
        /// </summary>
        private void InitializeVariables()
        {
            // Set number of DataPoints
            numberOfDataPoints = 100;

            // Set number of Clusters
            numberOfClusters = 3;


            // Create lists
            listCluster = new List<Cluster>();
            listDataPoint = new List<DataPoint>();

            // Create list of color and add colors to it
            listColor = new List<Color>();
            listColor.Add(System.Drawing.Color.Yellow);
            listColor.Add(System.Drawing.Color.Red);
            listColor.Add(System.Drawing.Color.Black);
            listColor.Add(System.Drawing.Color.Blue);
            listColor.Add(System.Drawing.Color.Gray);
            listColor.Add(System.Drawing.Color.Orange);
            listColor.Add(System.Drawing.Color.Navy);
            listColor.Add(System.Drawing.Color.Pink);
            listColor.Add(System.Drawing.Color.Azure);
            listColor.Add(System.Drawing.Color.Chocolate);
            listColor.Add(System.Drawing.Color.SteelBlue);

            // Create DataPoints
            CreateDataPoints();
        }



        /// <summary>
        /// Create clusters with improving
        /// </summary>
        private void CreateClustersWithImproving()
        {
            // Recreate list of cluster for reset
            listCluster = new List<Cluster>();

            // Starting point of space
            int XCenter = 0;
            int YCenter = 0;
            int ZCenter = 0;

            // Calculate distance of each datapoint and keep
            foreach (DataPoint dataPoint in listDataPoint)
            {
                int xdis = (dataPoint.XPoint - XCenter);
                double ydis = (dataPoint.YPoint - YCenter);
                double zdis = (dataPoint.ZPoint - ZCenter);
                double tot = (xdis * xdis + ydis * ydis + zdis * zdis);
                double distance = Math.Sqrt(tot);
                dataPoint.Distace = distance;
            }

            // Sort datapoints using distance
            for (int i = 0; i < listDataPoint.Count; i++)
            {
                for (int j = 0; j < listDataPoint.Count - 1; j++)
                {
                    if (listDataPoint[j].Distace > listDataPoint[j + 1].Distace)
                    {
                        DataPoint tempDP = listDataPoint[j];
                        listDataPoint[j] = listDataPoint[j + 1];
                        listDataPoint[j + 1] = tempDP;
                    }
                }
            }


            // Create clusters for dividing cluster number to datapoint list
            // and choose middle datapoint x,y coordinates for ecah cluster center
            for (int i = 0; i < numberOfClusters; i++)
            {
                int index = Convert.ToInt16(listDataPoint.Count / (numberOfClusters * 2) * (2 * i + 1));
                int xPoint = listDataPoint[index].XPoint;
                double yPoint = listDataPoint[index].YPoint;
                double zPoint = listDataPoint[index].ZPoint;

                // Create cluster and add to list
                Cluster cluster = new Cluster(i + 1, xPoint, yPoint, zPoint, listColor[i]);
                listCluster.Add(cluster);
            }
        }




        /// <summary>
        /// Reset datapoints and remove clusters
        /// </summary>
        private void Reset()
        {
            numberOfDataPoints = Convert.ToInt64(10);

            CreateDataPoints();

        }

        /// <summary>
        /// Initialize clusters
        /// </summary>
        private void InitializeCluster()
        {
            // Set iteration number to 0
            iterationNumber = 0;
            //number of cluster
            numberOfClusters = Convert.ToInt64(3);

            // Create clusters
            CreateClustersWithImproving();

            //Assigns datapoints to clusters randomly
            SetClustersOfDataPointsRandomly();


        }

        /// <summary>
        /// Assigns datapoints to clusters randomly
        /// </summary>
        private void SetClustersOfDataPointsRandomly()
        {
            // Set clusters of datapoints randomly
            Random rand = new Random();
            foreach (DataPoint dataPoint in listDataPoint)
            {
                dataPoint.Cluster = listCluster[rand.Next((int)numberOfClusters)];
            }
        }

        /// <summary>
        /// Initializes clusters with improving
        /// </summary>
        private void InitializeClusterWithImproving()
        {
            numberOfClusters = Convert.ToInt64(3);

            CreateClustersWithImproving();

            SetClustersOfDataPointsRandomly();
        }

        /// <summary>
        /// Assigns datapoints to closest clusters
        /// </summary>
        private void AssignDataPointsToCloserCluster()
        {
            iterationNumber++;
            foreach (DataPoint dataPoint in listDataPoint)
            {
                Cluster nearestCluster = null;
                double distance = 999999999999;
                foreach (Cluster cluster in listCluster)
                {
                    double tempDistance = GetDistance(dataPoint, cluster);
                    if (tempDistance < distance)
                    {
                        nearestCluster = cluster;
                        distance = tempDistance;
                    }
                }
                dataPoint.Cluster = nearestCluster;
            }


        }

        /// <summary>
        /// Calculates center of clusters
        /// </summary>
        private void CalculateCenterOfEachCluster()
        {
            foreach (DataPoint dataPoint in listDataPoint)
            {
                dataPoint.Cluster.XTotal += dataPoint.XPoint;
                dataPoint.Cluster.YTotal += dataPoint.YPoint;

                dataPoint.Cluster.TotalDataPoints++;
            }

            bool isSame = true;
            foreach (Cluster cluster in listCluster)
            {
                if (cluster.TotalDataPoints > 0)
                {
                    cluster.setXPoint(Convert.ToInt16(cluster.XTotal / cluster.TotalDataPoints));
                    cluster.setYPoint(Convert.ToInt16(cluster.YTotal / cluster.TotalDataPoints));
                    cluster.setZPoint(Convert.ToInt16(cluster.ZTotal / cluster.TotalDataPoints));

                    if (!(cluster.XPoint == cluster.OldXPoint &&
                        cluster.YPoint == cluster.OldYPoint &&
                        cluster.ZPoint == cluster.OldZPoint &&
                        cluster.OldTotalDataPoints == cluster.OldTotalDataPoints))
                    {
                        isSame = false;
                    }

                    cluster.SetToDefaultTotal();
                }
            }

            if (isSame)
            {
                isFinished = true;
                string msg = "Finished" + Environment.NewLine;

                foreach (DataPoint point in listDataPoint)
                {
                    string Term = point.pointString;
                    int id = point.PointID;
                    int clusterNumber = point.Cluster.Number;

                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO  WordsClustersTable(Id,Term,ClusterNumber) VALUES(@id,@Term,@cluster)", con);
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@Term", Term);
                        command.Parameters.AddWithValue("@cluster", clusterNumber);
                        command.ExecuteNonQuery();
                    }
                    catch { throw; }

                }

                //msg += "Iteration Number : " + iterationNumber.ToString();
                MessageBox.Show(msg);
            }


        }

        /// <summary>
        /// Returns distance of datapoint and cluster
        /// </summary>
        /// <param name="dataPoint">datapoint</param>
        /// <param name="cluster">cluster</param>
        /// <returns></returns>
        private double GetDistance(DataPoint dataPoint, Cluster cluster)
        {
            int xdis = (dataPoint.XPoint - cluster.XPoint);
            double ydis = (dataPoint.YPoint - cluster.YPoint);
            double zdis = (dataPoint.ZPoint - cluster.ZPoint);
            double tot = (xdis * xdis + ydis * ydis + zdis * zdis);
            double distance = Math.Sqrt(tot);

            return distance;
        }

        /// <summary>
        /// Find the result by iteration all iteration
        /// </summary>
        private void FintTheResult()
        {
            isFinished = false;
            while (!isFinished)
            {
                AssignDataPointsToCloserCluster();
                CalculateCenterOfEachCluster();
            }
        }





        private void drawCloudWords()
        {

            try
            {
                DataTable table = new DataTable();
                SqlCommand c = new SqlCommand("select  id,clusterNumber,Term from WordsClustersTable order by clusterNumber desc", con);
                SqlDataReader r = c.ExecuteReader();
                table.Load(r);


                foreach (DataRow DR in table.Rows)
                {
                    int pointID = Int32.Parse(DR["id"].ToString());

                    string Term = DR["Term"].ToString().ToUpper();
                    int custer = Int32.Parse(DR["clusterNumber"].ToString());
                    WordsList.Add(Term);
                    if (custer >= 3)
                    {
                        FrequencyList.Add(3);
                    }
                    if (custer < 3 && custer >= 2)
                    {
                        FrequencyList.Add(2);
                    }
                    if (custer < 2)
                    {
                        FrequencyList.Add(1);
                    }




                }

            }
            catch { return; }



        }


        private void button3_Click(object sender, EventArgs e)
        {
            var wc = new WordCloudGen(1000, 1000);
            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            Image i = wc.Draw(WordsList, FrequencyList);

            pictureBox1.Image = i;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            //calculate tf idf weight for each word
             // calculateTFIDF cal = new calculateTFIDF();
             //  cal.CalculateDocumentScore();

            //InvertedIndex
             // InvertedIndex c = new InvertedIndex();
             // c.buildInvertedIndex();

        }
    }
}


