using RobertMaxim.DataModel;
using System;
using System.Collections.Generic;

namespace RobertMaxim
{
    class Printer
    {
        public static void PrintCollections<T>(ICollection<T> collection){
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintDictionary<T,S>(Dictionary<T,List<S>> dictionary)
        {
            foreach (T key in dictionary.Keys)
            {
                Console.WriteLine($"Key: {key}");
                foreach(S value in dictionary[key])
                {
                    Console.WriteLine($"Value: {string.Join("\n", value)}");
                }
                Console.WriteLine();
            }
        }

        public static void PrintDrugRequest(IEnumerable<DrugUnit> requestedDrugs)
        {
            foreach (DrugUnit drugUnit in requestedDrugs)
            {
                Console.WriteLine(drugUnit);
            }
        }
    }
}
