using MobilePhone.Common;
using System;
using System.Collections.Generic;


class GSMTest
{
    static void Main()
    {
        List<GSM> mobilePhones = new List<GSM>();

        mobilePhones.Add(new GSM("Xperia SP", "Sony", 450M,
            new Battery(BatteryType.LiIon, 635, 10.25), new Display(4.6, (int)(16e+6))));
        mobilePhones.Add(new GSM("One Dual SIM", "HTC", 1050M,
            new Battery(BatteryType.LiPo, 500, 20), new Display(4.68, (int)(16e+6))));
        mobilePhones.Add(new GSM("3310", "Nokia", 10M, "Grandpa",
            new Battery(BatteryType.NiMH, 250, 4.5)));
        mobilePhones.Add(new GSM("Galaxy S4", "Samsung"));
        mobilePhones.Add(GSM.IPhone4S);

        foreach (var gsm in mobilePhones)
        {
            Console.WriteLine(gsm.ToString());
        }
    }
}

