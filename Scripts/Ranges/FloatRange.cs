#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RichUnity.Scripts.Ranges
{
    public class MinMaxFloatRangeAttribute : Attribute
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        
        public MinMaxFloatRangeAttribute(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
    
    /// <summary>
    ///   <para>Class for creating float ranges. Should be used alongside with MinMaxFloatRange Attribute otherwise your range will be limited by [0, 1] values.</para>
    /// </summary>
    [Serializable]
    public struct FloatRange
    {
        public float MinValue;
        public float MaxValue;

        public float RandomValue
        {
            get
            {
                return Random.Range(MinValue, MaxValue);
            }
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(FloatRange), true)]
    public class FloatRangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            SerializedProperty minProperty = property.FindPropertyRelative("MinValue");
            SerializedProperty maxProperty = property.FindPropertyRelative("MaxValue");

            float minValue = minProperty.floatValue;
            float maxValue = maxProperty.floatValue;

            float rangeMin = 0.0f;
            float rangeMax = 1.0f;

            var ranges = (MinMaxFloatRangeAttribute[]) fieldInfo.GetCustomAttributes(typeof(MinMaxFloatRangeAttribute), true);
            if (ranges.Length > 0)
            {
                rangeMin = ranges[0].Min;
                rangeMax = ranges[0].Max;
            }

            const float rangeBoundsLabelWidth = 40f;

            var rangeBoundsLabelRect = new Rect(position) {width = rangeBoundsLabelWidth};
            GUI.Label(rangeBoundsLabelRect, new GUIContent(minValue.ToString("F2")));
            position.xMin += rangeBoundsLabelWidth;

            var rangeBoundsLabel2Rect = new Rect(position);
            rangeBoundsLabel2Rect.xMin = rangeBoundsLabel2Rect.xMax - rangeBoundsLabelWidth;
            GUI.Label(rangeBoundsLabel2Rect, new GUIContent(maxValue.ToString("F2")));
            position.xMax -= rangeBoundsLabelWidth;

            EditorGUI.BeginChangeCheck();
            EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, rangeMin, rangeMax);
            if (EditorGUI.EndChangeCheck())
            {
                minProperty.floatValue = minValue;
                maxProperty.floatValue = maxValue;
            }

            EditorGUI.EndProperty();
        }
    }
#endif
}