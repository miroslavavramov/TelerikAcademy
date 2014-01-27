using MobilePhone.Common;
using System;
using System.Collections.Generic;

class CallHistoryTest
{
    static void Main()
    {
        GSM myPhone = new GSM("Galaxy S3", "Samsung");

        myPhone.AddCall(new Call(DateTime.Parse("30.1.2014 10:22:15"), 300, "0881311296"));
        myPhone.AddCall(new Call(DateTime.Parse("1.2.2014 7:29:00"), 45, "0899992224"));
        myPhone.AddCall(new Call(DateTime.Parse("5.2.2014 17:00:55"), 91, "0871773217"));
        myPhone.AddCall(new Call(DateTime.Parse("6.2.2014 22:10:31"), 152, "0871773217"));

        Console.WriteLine("|* Call History *|\r\n");
        myPhone.ShowCallHistory();

        Console.WriteLine("Bill : {0:C2} ", myPhone.CalculateBill());

        Call longestCall = myPhone.CallHistory[0];

        foreach (var call in myPhone.CallHistory)
        {
            if (call.CallDuration > longestCall.CallDuration)
            {
                longestCall = call;
            }
        }

        myPhone.DeleteCall(longestCall);

        Console.WriteLine("\r\n|* After deleting the longest call from the call history *|\r\n");
        Console.WriteLine("Bill : {0:C2} ", myPhone.CalculateBill());

        myPhone.ClearCallHistory();

        Console.WriteLine("\r\n|* After clearing the call history *|\r\n");
        Console.WriteLine("|* Call History *|\r\n");

        myPhone.ShowCallHistory();
    }
}

