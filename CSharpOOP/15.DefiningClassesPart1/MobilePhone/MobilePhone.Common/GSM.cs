using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhone.Common
{
    public class GSM
    {
        #region Fields
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;

        private const decimal RATE = 0.37M;
        private List<Call> callHistory = new List<Call>();

        private static readonly GSM iPhone4S = new GSM("iPhone 4S", "Apple", 700M, "Nemo Nobody",
            new Battery(BatteryType.LiPo, 200, 14), new Display(3.5,(int)(16e+6)));
        #endregion
        
        #region Properties
        public string Model
        {
            get 
            { 
                return this.model;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("Device's model name can't be empty!");
                }
                this.model = value; 
            }
        }
        public string Manufacturer
        {
            get 
            { 
                return this.manufacturer;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("Device's manufacturer name can't be empty!");
                }
                this.manufacturer = value; 
            }
        }
        public string Owner
        {
            get 
            {
                return this.owner;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("Device's owner name can't be empty!");
                }
                this.owner = value; 
            }
        }
        public decimal? Price
        {
            get 
            { 
                return this.price;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price can't be negative!");
                }
                this.price = value; 
            }
        }
        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }
        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
        #endregion

        #region Constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {

        }
        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null)
        {

        }
        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price, owner, null)
        {

        }
        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, null)
        {

        }
        public GSM(string model, string manufacturer, decimal? price, Battery battery, Display display)
            : this(model, manufacturer, price, null, battery, display)
        {

        }
        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            var output = new StringBuilder();

            if (!string.IsNullOrEmpty(Model))
            {
                output.AppendLine("Device Model : " + Model);
            }
            if (!string.IsNullOrEmpty(Manufacturer))
            {
                output.AppendLine("Device Manufacturer : " + Manufacturer);
            }
            if (Price.HasValue)
            {
                output.AppendLine(string.Format("Price : {0:C2}", Price));
            }
            if (!string.IsNullOrEmpty(Owner))
            {
                output.AppendLine("Owner : " + Owner);
            }
            if(Battery != null)
            {
                output.AppendLine("Battery Type : " + Battery.Type);
                
                if (!string.IsNullOrEmpty(Battery.Model))
                {
                    output.AppendLine("Battery Model : " + Battery.Model);
                }
                if (Battery.HoursIdle.HasValue)
                {
                    output.AppendLine("Battery Stand By : " + Battery.HoursIdle + " hours");
                }
                if (Battery.HoursTalk.HasValue)
                {
                    output.AppendLine("Battery Talk Time : " + Battery.HoursTalk + " hours");
                }
            }
            if (Display != null)
            {
                if (Display.Size.HasValue)
                {
                    output.AppendLine("Display Size : " + Display.Size);
                }
                if (Display.Colors.HasValue)
                {
                    output.AppendLine("Display Colors : " + Display.Colors);
                }
            }
            
            return output.ToString();
        }
        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }
        public void DeleteCall(Call call)
        {
            this.CallHistory.Remove(call);
        }
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }
        public decimal CalculateBill()
        {
            decimal total = 0;

            foreach (var call in this.CallHistory)
            {
                total += ((call.CallDuration / 60M) * RATE);
            }

            return Math.Round(total,2);
        }
        public void ShowCallHistory()
        {
            if (this.CallHistory.Count == 0)
            {
                Console.WriteLine("No call history to show.");
            }
            else
            {
                foreach (var call in this.CallHistory)
                {
                    Console.WriteLine(call.ToString());
                }
            }
            Console.WriteLine();
        }
        #endregion
    }
}
