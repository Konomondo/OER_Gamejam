using System;

namespace CCC
{
    [Serializable]
    public class CropCircle
    {
        public int Area { get; private set; }

        private CropCircle() : this(1)
        {
        }

        public CropCircle(int area)
        {
            Area = area;
        }
    }
}