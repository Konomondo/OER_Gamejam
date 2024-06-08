using UnityEngine;

namespace CCC.Utility
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Variables/Int SO Variable", fileName = "IntVariable",
        order = 0)]
    public class IntVariable : DescriptionBaseSO
    {
        public int Value;

        public void Set(int iVal)
        {
            Value = iVal;
        }

        public void Set(IntVariable iVar)
        {
            Value = iVar.Value;
        }

        public void ApplyChange(int iAmount)
        {
            Value += iAmount;
        }

        public void ApplyChange(IntVariable iVarAmount)
        {
            Value += iVarAmount.Value;
        }
    }
}