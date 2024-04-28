using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> myNumList = new List<int>();
        int listNum = -1;

        while (listNum != 0)
        {
            Console.WriteLine("Enter a number (type 0 to exit): ");
           
            string strUserNum = Console.ReadLine();

            listNum = int.Parse(strUserNum);

            if (listNum != 0)
            {
                myNumList.Add(listNum);
            }

        }

        //sum of list
        int sumMyNumList = myNumList.Sum();
        Console.WriteLine(sumMyNumList);

        //average of list
        float numItemsInList = myNumList.Count();
        float aveMyNumList = sumMyNumList/numItemsInList;
        Console.WriteLine(aveMyNumList);

        //maximum of list
        int maxMyNumList = myNumList.Max();
        Console.WriteLine(maxMyNumList);
    }
}