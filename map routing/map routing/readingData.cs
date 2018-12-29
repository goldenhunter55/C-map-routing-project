using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace map_routing
{
   
    class readingData
    {

        public static data read (string Path){

            using (StreamReader sr = new StreamReader(Path)) {
          
                List<double> XPoints = new List<double>();
                List<double> YPoints = new List<double>();
                int V = int.Parse(sr.ReadLine());
                for (int i = 0; i < V; i++)
                {
                    string[] line = new string[3];
                    line = sr.ReadLine().Split(' ');
                     
                
                    XPoints.Add(double.Parse(line[1]));
                    YPoints.Add(double.Parse(line[2]));
                   

                }
                
                int E = int.Parse(sr.ReadLine());
              
               
               List<List<int>> neighbours=new List<List<int>>();
               List<List<double>> weights = new List<List<double>>();
              
           
               for (int i = 0; i < V + 2 ; i++)
               {
                   neighbours.Add(new List<int>());
                   weights.Add(new List<double>());
               }

                   for (int i = 0; i < E; i++)
                   {
                       string[] line = new string[4];
                       line = sr.ReadLine().Split(' ');
                       int index1 = int.Parse(line[0]);
                       int index2 = int.Parse(line[1]);
                       double distance = double.Parse(line[2]);
                       double speed = double.Parse(line[3]);
                       double time = distance / speed;

                      neighbours[index1].Add(index2);
                      weights[index1].Add(time);

                      neighbours[index2].Add(index1);
                      weights[index2].Add(time);

                   }
                data D1 = new data(XPoints,YPoints, neighbours,weights,V);
                return D1;
            }
           
        }

        public static void queryReading(data D,string Path)
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                int T = int.Parse(sr.ReadLine());
                while (T > 0)
                {
                    string[] line = new string[5];
                    line = sr.ReadLine().Split(' ');
                    double standingX = double.Parse(line[0]);
                    double standingY = double.Parse(line[1]);

                    double destinationX = double.Parse(line[2]);
                    double destinationY = double.Parse(line[3]);
                    double R = double.Parse(line[4]);
                    R = R / 1000;
                    Dictionary<int, double> ValidpointsSource = new Dictionary<int, double>();
                    Dictionary<int, double> ValidpointsDest = new Dictionary<int, double>();
                    
                    ValidpointsSource = Caluclations.calcDistance(standingX,standingY,D.XPoints,D.YPoints,R);
                    List<List<int>> NN = D.neighbours.GetRange(0,D.neighbours.Count);
                    List<List<double>> WW = D.weights.GetRange(0,D.weights.Count);
                    List<double> XX = D.XPoints.GetRange(0, D.XPoints.Count);
                    List<double> YY = D.YPoints.GetRange(0, D.YPoints.Count);
                   // Dictionary<double, double> pointz = D.points.ToDictionary(entry => entry.Key, entry => entry.Value);
                    int VV = D.V;
                    data DIO = new data(ObjectCopier.Clone(XX), ObjectCopier.Clone(YY),ObjectCopier.Clone( NN),ObjectCopier.Clone(WW), VV);
                    DIO.V++;
                   // DIO.points.Add(standingX, standingY);
                    DIO.XPoints.Add(standingX);
                    DIO.YPoints.Add(standingY);
                    for (int i = 0; i < ValidpointsSource.Count; i++)
                    {
                        double distance=ValidpointsSource.Values.ElementAt(i);
                        int index = DIO.V-1;
                        int index1=ValidpointsSource.Keys.ElementAt(i);
                        double speed = 5;
                        double time = distance / speed;

                        DIO.neighbours[index].Add(index1);
                        DIO.weights[index].Add(time);

                        DIO.neighbours[index1].Add(index);
                        DIO.weights[index1].Add(time);

                    }
                    //Console.WriteLine();
                    //Console.WriteLine("//////////////////after first update ////////////////");
                    //Console.WriteLine();

                    //DIO.printGraph();

                    ValidpointsDest = Caluclations.calcDistance(destinationX, destinationY,DIO.XPoints,DIO.YPoints, R);
                    DIO.V++;
                   // DIO.points.Add(destinationX, destinationY);
                    DIO.XPoints.Add(destinationX);
                    DIO.YPoints.Add(destinationY);

                    for (int i = 0; i < ValidpointsDest.Count; i++)
                    {
                        double distance = ValidpointsDest.Values.ElementAt(i);
                        int index = DIO.V - 1;
                        int index1 = ValidpointsDest.Keys.ElementAt(i);
                        double speed = 5;
                        double time = distance / speed;

                        DIO.neighbours[index].Add(index1);
                        DIO.weights[index].Add(time);

                        DIO.neighbours[index1].Add(index);
                        DIO.weights[index1].Add(time);
                       
                    }
                    
                    Dijkstra.Dijkstraa(DIO.V,DIO.neighbours, DIO.weights,DIO.XPoints,DIO.YPoints);
                        T--;
                }
               
            }

           
        }

    }
}
