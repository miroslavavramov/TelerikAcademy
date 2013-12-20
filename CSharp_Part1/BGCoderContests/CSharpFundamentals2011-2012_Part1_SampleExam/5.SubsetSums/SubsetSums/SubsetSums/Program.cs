using System;



class Program
{
    static void Main()
    {
        
            long s = long.Parse(Console.ReadLine());
            long count = long.Parse(Console.ReadLine());
            long[] numbers = new long[count];     
            long sums = 0;

            for (int i = 0; i < count; i++)
            {
                
                numbers[i] = long.Parse(Console.ReadLine());     
            }

            long sum;    

            for (int i = 1; i < Math.Pow(2, count); i++)    
            {                                               
                sum = 0;
                for (int k = 0; k < count; k++) 
                {
                    sum += numbers[k] * GetBinaryNum(i, k);    
                }                                                           
                
                if (sum == s)
                {
                    sums++;
                }
            }
            Console.WriteLine(sums);
        
    }
    static int GetBinaryNum(int number, int bit)      
    {
        int mask = 1;                                       
        return (number & (mask << bit)) >> bit;
    }
}