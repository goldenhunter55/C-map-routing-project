using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_routing
{
    class  data:ICloneable
    {
        public int V;//number of Vertcies 
      // public Dictionary<double, double> points;
       public List<double> XPoints;
       public List<double> YPoints;

      public List<List<int>> neighbours;
      public List<List<double>> weights;
        //constructor 
        public data(List<double> Xpts , List<double> ypts, List<List<int>>edges ,  List<List<double>> w,int V)
        {
            XPoints = Xpts;
            YPoints = ypts;
            neighbours = edges;
            weights = w;
            this.V = V;
        }
        
        
        public void printGraph()
        {
            Console.WriteLine("number of vertcies is : " + this.V);
            for (int i = 0; i <neighbours.Count; i++)
            {

                foreach(int X in neighbours[i])
                {
                    Console.Write(X + " ");
                }
                    Console.WriteLine();
            }
            Console.WriteLine("...................................................");
            for (int i = 0; i < weights.Count; i++)
            {

                foreach (double X in weights[i])
                {
                    Console.Write(X + "+++");
                }
                Console.WriteLine();
            }

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
   

}
