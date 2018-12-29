using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_routing
{
    class Dijkstra
    {

        public static int getSmallestUnVistiedVertx(double [] dest , bool[] Vistied)
        {
            double smallest = double.MaxValue;
            int index=0;
           // int alltrue = 0;
            for (int i = 0; i < dest.Length; i++)
            {
                 if (smallest > dest[i] && Vistied[i]==false)
                {
                    smallest = dest[i];
                    index = i;
                }
            }
          
                return index;
        }

        public static void Dijkstraa(int V, List<List<int>> edges , List<List<double>> weight,List<double>Xpoints , List<double> Ypoints)
        {
            int source = V - 2;
            double[] dest = new double[V];
            dest[V - 2] = 0;
            bool[] Vistied = new bool[V];
           int [] previousVertex = new int[V];
            for (int i = 0; i < V; i++)
            {
                
                    dest[i] = double.MaxValue;
                    Vistied [i]= false;
            }
            dest[V - 2] = 0;

            for (int i = 0; i < V; i++)
            {
                int index = getSmallestUnVistiedVertx(dest, Vistied);

               // Console.WriteLine(index);
                    for (int j = 0; j < edges[index].Count; j++)
                    {
                     int Next=edges[index][j];
                        double W=weight[index][j];
                        if (dest[index] + W < dest[Next])
                        {
                           dest[Next]=dest[index] +W;
                            previousVertex[Next] = index;
                        }
                    }

                    Vistied[index] = true;
             }
               
            
        
            Console.WriteLine("shortest path is " +Math.Round( dest[V - 1] * 60 ,2));
           PrintPathandCalculateTotalDistance(previousVertex, V, Xpoints,Ypoints);

        }
        public static void PrintPathandCalculateTotalDistance( int [] previousVertex, int V,List<double>Xpoints,List<double>Ypoints)
        {
            List<int> route = new List<int>();
            double totalDistance = 0;
            double carDistance = 0;
            double walkedDistance = 0;
            int source = V - 2;
            int destination = V - 1;
            route.Add(destination);
            int nextdest = destination;
            while (true)
            {
                int index = previousVertex[nextdest];
                route.Add(index);
                totalDistance = totalDistance + Caluclations.distance(Xpoints[index], Ypoints[index],Xpoints[nextdest], Ypoints[nextdest]);
                nextdest = index;
                if (index == source) { break; }
            }
            walkedDistance = walkedDistance + Caluclations.distance(Xpoints[V - 2], Ypoints[V - 2], Xpoints[route[route.Count - 2]], Ypoints[route[route.Count - 2]]);
            walkedDistance = walkedDistance + Caluclations.distance(Xpoints[V - 1], Ypoints[V - 1], Xpoints[route[1]], Ypoints[route[1]]);
            carDistance = totalDistance - walkedDistance;
            Console.WriteLine("WALKED DISTANCE : " + Math.Round(walkedDistance,2));
            Console.WriteLine("CAR DISTANCE : " + Math.Round(carDistance,2));
            Console.WriteLine("TOTAL DISTANCE : " + Math.Round(totalDistance,2));
            Console.Write("routes is :");
            foreach (int x in route) { Console.Write(x + " "); }
            Console.WriteLine();

        }
    }
}
