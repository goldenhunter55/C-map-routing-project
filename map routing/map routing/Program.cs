using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_routing
{

    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            string[] map = {   "E:/[1] Sample Cases/map1.txt",
                               "E:/[1] Sample Cases/map2.txt",
                               "E:/[1] Sample Cases/map3.txt",
                               "E:/[1] Sample Cases/map4.txt",
                               "E:/[1] Sample Cases/map5.txt",
                               "E:/[2] Medium Cases/OLMap.txt",
                               "E:/[3] Large Cases/SFMap.txt"

                                         };


            string[] Queries ={   "E:/[1] Sample Cases/queries1.txt",
                                  "E:/[1] Sample Cases/queries2.txt",
                                  "E:/[1] Sample Cases/queries3.txt",
                                  "E:/[1] Sample Cases/queries4.txt",
                                  "E:/[1] Sample Cases/queries5.txt",
                                  "E:/[2] Medium Cases/OLQueries.txt",
                                  "E:/[3] Large Cases/SFQueries.txt"

                             };
            
            while (true)
            {
                
               
                Console.WriteLine("1-SAMPLE CASE");
                Console.WriteLine("2-MEDIUM CASE");
                Console.WriteLine("3-LARGE CASE");
                Console.Write("your Choice:");
                choice = int.Parse(Console.ReadLine());
                int secondChoice;
                if (choice == 1)
                {
                    Console.WriteLine("enter number from 1 to 5 :");
                   secondChoice=int.Parse( Console.ReadLine());
                    data D1 = readingData.read(map[secondChoice-1]);

                    //D1.printGraph();
                    //Console.WriteLine();
                    //Console.WriteLine("////////////////// MAIN GRAPH ////////////////");
                    //Console.WriteLine();

                    readingData.queryReading(D1,Queries[secondChoice-1]);
     
                }
                else  if (choice == 2)
                {
                   
                    data D1 = readingData.read(map[5]);

                    //D1.printGraph();
                    //Console.WriteLine();
                    //Console.WriteLine("////////////////// MAIN GRAPH ////////////////");
                    //Console.WriteLine();

                    readingData.queryReading(D1, Queries[5]);
                }

                else if (choice == 3)
                {
                    data D1 = readingData.read(map[6]);

                    //D1.printGraph();
                    //Console.WriteLine();
                    //Console.WriteLine("////////////////// MAIN GRAPH ////////////////");
                    //Console.WriteLine();

                    readingData.queryReading(D1, Queries[6]);
                }
                else { break; }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("////////////////////////////////////////////////////////////////////////");
            }
        }
    }
}
