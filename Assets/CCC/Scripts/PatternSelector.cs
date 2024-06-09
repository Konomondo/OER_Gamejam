using System;
using UnityEngine;

namespace CCC
{
    public class PatternSelector : MonoBehaviour
    {
        public event Action SelectPattern;

        public void ClickedPattern()
        {
            SelectPattern?.Invoke();
        }
    }
}