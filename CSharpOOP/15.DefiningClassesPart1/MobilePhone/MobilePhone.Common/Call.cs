namespace MobilePhone.Common
{
    using System;
    using System.Text;

    public class Call
    {
        #region Fields
        private DateTime timeOfCall;
        private ulong callDuration;
        private string dialedNumber;
        #endregion

        #region Properties
        public DateTime TimeOfCall
        {
            get
            {
                return this.timeOfCall;
            }
            set
            {
                this.timeOfCall = value;
            }
        }
        public ulong CallDuration
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                this.callDuration = value;
            }
        }
        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
            set
            {
                foreach (var symbol in value)
                {
                    if (!char.IsDigit(symbol))
                    {
                        throw new ArgumentException("Dialed phone number must contain only digits!");
                    }
                }
                this.dialedNumber = value;
            }
        }
        #endregion

        #region Constructors
        public Call(DateTime timeOfCall, ulong callDuration, string dialedNumber)
        {
            this.TimeOfCall = timeOfCall;
            this.CallDuration = callDuration;
            this.DialedNumber = dialedNumber;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine("Dialed number : " + DialedNumber);
            output.AppendLine("Time of call : " + TimeOfCall);
            output.AppendLine("Call duration : " + CallDuration + " seconds");

            return output.ToString();
        }
        #endregion
    }
}
