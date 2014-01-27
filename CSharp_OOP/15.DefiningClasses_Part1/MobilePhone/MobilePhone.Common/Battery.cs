using System;

namespace MobilePhone.Common
{
    public class Battery
    {
        #region Fields
        private BatteryType type;
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;
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
                    throw new ArgumentOutOfRangeException("Battery model can't be empty!");
                }
                this.model = value;
            }
        }
        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value <= 0 || !value.HasValue)
                {
                    throw new ArgumentOutOfRangeException("Invalid battery idle hours!");
                }
                this.hoursIdle = value;
            }
        }
        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0 || !value.HasValue)
                {
                    throw new ArgumentOutOfRangeException("Invalid battery talk hours!");
                }
                this.hoursTalk = value;
            }
        }
        public BatteryType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        #endregion

        #region Constructors
        public Battery(BatteryType type)
            : this(type, null, null)
        {

        }
        public Battery(BatteryType type, double? hoursIdle, double? hoursTalk)
            : this(type, null, hoursIdle, hoursTalk)
        {

        }
        public Battery(BatteryType type, string model, double? hoursIdle, double? hoursTalk)
        {
            this.Type = type;
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }
        #endregion
    }
}
