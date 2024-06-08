using System;

namespace CCC.Utility
{
    [Serializable]
    public class IntReference
    {
        public bool UseConstant;
        public int ConstantValue;
        public IntVariable Variable;

        private IntReference() : this(0)
        {
        }

        public IntReference(int i)
        {
            UseConstant = true;
            ConstantValue = i;
        }

        public int Value => UseConstant ? ConstantValue : (Variable != null ? Variable.Value : 0);

        public static implicit operator int(IntReference reference) => reference.Value;
    }
}