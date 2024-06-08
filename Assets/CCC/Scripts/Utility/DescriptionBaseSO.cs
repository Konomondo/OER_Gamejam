using UnityEngine;

namespace CCC.Utility
{
    public abstract class DescriptionBaseSO : ScriptableObject
    {
#if UNITY_EDITOR
        [field: TextArea]
        [field: SerializeField]
        public string Description { get; private set; } = "Add description here.";
#endif
    }
}