using System;

namespace MobilePhone.Common
{
    public class Display
    {
        #region Fields
        private double? size;
        private int? colors;
        #endregion

        #region Properties
        public double? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid display size!");
                }
                this.size = value;
            }
        }

        public int? Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid display colors!");
                }
                this.colors = value;
            }
        }
        #endregion

        #region Constructors
        public Display(double? size)
            : this(size, null)
        {

        }
        public Display(int? colors)
            : this(null, colors)
        {

        }
        public Display(double? size, int? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
        #endregion
    }
}
