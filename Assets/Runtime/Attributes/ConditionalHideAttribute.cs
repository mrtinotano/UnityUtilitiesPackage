using UnityEngine;
using System;

namespace Utilities
{
    [AttributeUsage(
        AttributeTargets.Field | 
        AttributeTargets.Property |
        AttributeTargets.Class | 
        AttributeTargets.Struct, 
        Inherited = true)]
    public class ConditionalHideAttribute : PropertyAttribute
    {
        public string ConditionalName;

        public ConditionalHideAttribute(string conditionalName)
        {
            ConditionalName = conditionalName;
        }
    }
}
