using System;
using UnityEngine;

namespace CCC.Utility
{
    [CreateAssetMenu(menuName = "Scriptable Objects/GameEvent", fileName = "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        public event Action Event;

        public void Raise()
        {
            if (Event != null)
            {
                Event.Invoke();
                return;
            }

            Debug.LogWarning($"Event '{name}' had no subscribers!");
        }
    }
}