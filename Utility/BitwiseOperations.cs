	static int CheckBitAtPosition(int number, int position)
        {
           int bit = (number & ((int)1 << position)) >> position;
           return bit;

        }
	static int ReplaceBitAtPosition(int number, int position, int value)
        {
            if (value == 1)
            {
                number = number | (1 << position);
            }
            else if (value == 0)
            {
                number = number & (~(1 << position));
            }
            return number;
        }
		
	static int CountBits(int b)
		{
			int count = 0;
			for (int i = 0; i < 32; i++)
			{
				if (((b >> i) & 1) == 1)
				{
					count++;
				}
			}
			return count;
		}
		
	static int ReverseBits(int number)
        {

            //int number = int.Parse(Console.ReadLine());
            char[] bits = Convert.ToString(number, 2).ToCharArray();

            //foreach (char symbol in bits)
            //{
            //    Console.Write(symbol);
            //}
            //Console.WriteLine();

            Array.Reverse(bits);

            //foreach (char symbol in bits)
            //{
            //    Console.Write(symbol);
            //}
            //Console.WriteLine();

            int reversedNumber = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                reversedNumber += (int)char.GetNumericValue(bits[bits.Length - 1 - i]) * (int)Math.Pow(2, i);
            }
            return reversedNumber;
        }
		
		