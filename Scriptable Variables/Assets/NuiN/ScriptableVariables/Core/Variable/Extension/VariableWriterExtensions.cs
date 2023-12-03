using System;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.References
{
    public static class VariableWriterExtensions
    {
        #region Add
        
        public static void Add(this VariableWriter<float> reference, float value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<double> reference, double value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<decimal> reference, decimal value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<int> reference, int value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<long> reference, long value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<string> reference, string value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<Vector2> reference, Vector2 value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<Vector3> reference, Vector3 value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<Vector2Int> reference, Vector2Int value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<Vector3Int> reference, Vector3Int value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<Vector4> reference, Vector4 value) 
            => reference.Set(reference.Val + value);
        public static void Add(this VariableWriter<Color> reference, Color value) 
            => reference.Set(reference.Val + value);
        
        #endregion
        
        #region AddClamped
        
        public static void AddClamped(this VariableWriter<float> reference, float value, float? min = null, float? max = null)
        {
            float newVal = reference.Val + value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void AddClamped(this VariableWriter<double> reference, double value, double? min = null, double? max = null)
        {
            double newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void AddClamped(this VariableWriter<decimal> reference, decimal value, decimal? min = null, decimal? max = null)
        {
            decimal newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void AddClamped(this VariableWriter<int> reference, int value, int? min = null, int? max = null)
        {
            int newVal = reference.Val + value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void AddClamped(this VariableWriter<long> reference, long value, long? min = null, long? max = null)
        {
            long newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void AddClamped(this VariableWriter<Vector2> reference, Vector2 value, float max)
        {
            Vector2 newVal = reference.Val + value;
            reference.Set(Vector2.ClampMagnitude(newVal, max));
        }
        public static void AddClamped(this VariableWriter<Vector3> reference, Vector3 value, float max)
        {
            Vector3 newVal = reference.Val + value;
            reference.Set(Vector3.ClampMagnitude(newVal, max));
        }
        public static void AddClamped(this VariableWriter<Vector2Int> reference, Vector2Int value, Vector2Int? min = null, Vector2Int? max = null)
        {
            Vector2Int newVal = reference.Val + value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }
        public static void AddClamped(this VariableWriter<Vector3Int> reference, Vector3Int value, Vector3Int? min = null, Vector3Int? max = null)
        {
            Vector3Int newVal = reference.Val + value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }

        #endregion
        
        #region Subtract

        public static void Subtract(this VariableWriter<float> reference, float value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<double> reference, double value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<decimal> reference, decimal value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<int> reference, int value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<long> reference, long value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<Vector2> reference, Vector2 value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<Vector3> reference, Vector3 value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<Vector2Int> reference, Vector2Int value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<Vector3Int> reference, Vector3Int value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<Vector4> reference, Vector4 value) 
            => reference.Set(reference.Val - value);
        public static void Subtract(this VariableWriter<Color> reference, Color value) 
            => reference.Set(reference.Val - value);
        
        #endregion
        
        #region SubtractClamped
        
        public static void SubtractClamped(this VariableWriter<float> reference, float value, float? min = null, float? max = null)
        {
            float newVal = reference.Val - value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void SubtractClamped(this VariableWriter<double> reference, double value, double? min = null, double? max = null)
        {
            double newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void SubtractClamped(this VariableWriter<decimal> reference, decimal value, decimal? min = null, decimal? max = null)
        {
            decimal newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void SubtractClamped(this VariableWriter<int> reference, int value, int? min = null, int? max = null)
        {
            int newVal = reference.Val - value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void SubtractClamped(this VariableWriter<long> reference, long value, long? min = null, long? max = null)
        {
            long newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void SubtractClamped(this VariableWriter<Vector2> reference, Vector2 value, float maxLength)
        {
            Vector2 newVal = reference.Val - value;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength));
        }
        public static void SubtractClamped(this VariableWriter<Vector3> reference, Vector3 value, float maxLength)
        {
            Vector3 newVal = reference.Val - value;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength));
        }
        public static void SubtractClamped(this VariableWriter<Vector2Int> reference, Vector2Int value, Vector2Int? min = null, Vector2Int? max = null)
        {
            Vector2Int newVal = reference.Val - value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }
        public static void SubtractClamped(this VariableWriter<Vector3Int> reference, Vector3Int value, Vector3Int? min = null, Vector3Int? max = null)
        {
            Vector3Int newVal = reference.Val - value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }

        #endregion
        
        #region Multiply

        public static void Multiply(this VariableWriter<float> reference, float factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<double> reference, double factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<decimal> reference, decimal factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<int> reference, int factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<long> reference, long factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector2> reference, Vector2 factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector2> reference, float factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector3> reference, Vector3 factor) 
            => reference.Set(Vector3.Scale(reference.Val, factor));
        public static void Multiply(this VariableWriter<Vector3> reference, float factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector2Int> reference, Vector2Int factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector2Int> reference, int factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector3Int> reference, Vector3Int factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector3Int> reference, int factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Vector4> reference, float factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Color> reference, Color factor) 
            => reference.Set(reference.Val * factor);
        public static void Multiply(this VariableWriter<Color> reference, float factor) 
            => reference.Set(reference.Val * factor);
        
        #endregion
        
        #region MultiplyClamped
        
        public static void MultiplyClamped(this VariableWriter<float> reference, float factor, float? min = null, float? max = null)
        {
            float newVal = reference.Val * factor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void MultiplyClamped(this VariableWriter<double> reference, double factor, double? min = null, double? max = null)
        {
            double newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void MultiplyClamped(this VariableWriter<decimal> reference, decimal factor, decimal? min = null, decimal? max = null)
        {
            decimal newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void MultiplyClamped(this VariableWriter<int> reference, int factor, int? min = null, int? max = null)
        {
            int newVal = reference.Val * factor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void MultiplyClamped(this VariableWriter<long> reference, long factor, long? min = null, long? max = null)
        {
            long newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void MultiplyClamped(this VariableWriter<Vector2> reference, Vector2 factor, float maxLength)
        {
            Vector2 newVal = reference.Val * factor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength));
        }
        public static void MultiplyClamped(this VariableWriter<Vector2> reference, float factor, float maxLength)
        {
            Vector2 newVal = reference.Val * factor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength));
        }
        public static void MultiplyClamped(this VariableWriter<Vector3> reference, Vector3 factor, float maxLength)
        {
            Vector3 newVal = Vector3.Scale(reference.Val, factor);
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength));
        }
        public static void MultiplyClamped(this VariableWriter<Vector3> reference, float factor, float maxLength)
        {
            Vector3 newVal = reference.Val * factor;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength));
        }
        public static void MultiplyClamped(this VariableWriter<Vector2Int> reference, Vector2Int factor, Vector2Int? min = null, Vector2Int? max = null)
        {
            Vector2Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }
        public static void MultiplyClamped(this VariableWriter<Vector3Int> reference, Vector3Int factor, Vector3Int? min = null, Vector3Int? max = null)
        {
            Vector3Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }
        public static void MultiplyClamped(this VariableWriter<Vector2Int> reference, int factor, Vector2Int? min = null, Vector2Int? max = null)
        {
            Vector2Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }
        public static void MultiplyClamped(this VariableWriter<Vector3Int> reference, int factor, Vector3Int? min = null, Vector3Int? max = null)
        {
            Vector3Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }

        #endregion
        
        #region Divide

        public static void Divide(this VariableWriter<float> reference, float divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<double> reference, double divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<decimal> reference, decimal divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<int> reference, int divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<long> reference, long divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<Vector2> reference, Vector2 divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<Vector2> reference, float divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<Vector3> reference, Vector3 divisor) 
            => reference.Set(Vector3.Scale(reference.Val, divisor));
        public static void Divide(this VariableWriter<Vector3> reference, float divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<Vector2Int> reference, int divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<Vector3Int> reference, int divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<Vector4> reference, float divisor) 
            => reference.Set(reference.Val / divisor);
        public static void Divide(this VariableWriter<Color> reference, float divisor) 
            => reference.Set(reference.Val / divisor);
        
        #endregion
        
        #region DivideClamped
        
        public static void DivideClamped(this VariableWriter<float> reference, float divisor, float? min = null, float? max = null)
        {
            float newVal = reference.Val / divisor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void DivideClamped(this VariableWriter<double> reference, double divisor, double? min = null, double? max = null)
        {
            double newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void DivideClamped(this VariableWriter<decimal> reference, decimal divisor, decimal? min = null, decimal? max = null)
        {
            decimal newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void DivideClamped(this VariableWriter<int> reference, int divisor, int? min = null, int? max = null)
        {
            int newVal = reference.Val / divisor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void DivideClamped(this VariableWriter<long> reference, long divisor, long? min = null, long? max = null)
        {
            long newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal));
        }
        public static void DivideClamped(this VariableWriter<Vector2> reference, Vector2 divisor, float maxLength)
        {
            Vector2 newVal = reference.Val / divisor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength));
        }
        public static void DivideClamped(this VariableWriter<Vector2> reference, float divisor, float maxLength)
        {
            Vector2 newVal = reference.Val / divisor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength));
        }
        public static void DivideClamped(this VariableWriter<Vector3> reference, Vector3 divisor, float maxLength)
        {
            Vector3 newVal = Vector3.Scale(reference.Val, divisor);
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength));
        }
        public static void DivideClamped(this VariableWriter<Vector3> reference, float divisor, float maxLength)
        {
            Vector3 newVal = reference.Val / divisor;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength));
        }
        public static void DivideClamped(this VariableWriter<Vector2Int> reference, int divisor, Vector2Int? min = null, Vector2Int? max = null)
        {
            Vector2Int newVal = reference.Val / divisor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }
        public static void DivideClamped(this VariableWriter<Vector3Int> reference, int divisor, Vector3Int? min = null, Vector3Int? max = null)
        {
            Vector3Int newVal = reference.Val / divisor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal);
        }

        #endregion
    }
}


