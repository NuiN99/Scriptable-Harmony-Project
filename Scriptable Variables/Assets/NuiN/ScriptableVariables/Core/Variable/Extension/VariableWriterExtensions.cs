using System;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.References
{
    public static class VariableWriterExtensions
    {
        #region Add
        
        public static void Add(this VariableWriter<float> reference, float value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<double> reference, double value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<decimal> reference, decimal value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<int> reference, int value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<long> reference, long value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<string> reference, string value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<Vector2> reference, Vector2 value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<Vector3> reference, Vector3 value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<Vector2Int> reference, Vector2Int value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<Vector3Int> reference, Vector3Int value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<Vector4> reference, Vector4 value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this VariableWriter<Color> reference, Color value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        
        #endregion
        
        #region AddClamped
        
        public static void AddClamped(this VariableWriter<float> reference, float value, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val + value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this VariableWriter<double> reference, double value, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this VariableWriter<decimal> reference, decimal value, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this VariableWriter<int> reference, int value, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val + value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this VariableWriter<long> reference, long value, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this VariableWriter<Vector2> reference, Vector2 value, float max, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val + value;
            reference.Set(Vector2.ClampMagnitude(newVal, max), invokeActions);
        }
        public static void AddClamped(this VariableWriter<Vector3> reference, Vector3 value, float max, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val + value;
            reference.Set(Vector3.ClampMagnitude(newVal, max), invokeActions);
        }
        public static void AddClamped(this VariableWriter<Vector2Int> reference, Vector2Int value, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val + value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void AddClamped(this VariableWriter<Vector3Int> reference, Vector3Int value, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val + value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
        
        #region Subtract

        public static void Subtract(this VariableWriter<float> reference, float value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<double> reference, double value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<decimal> reference, decimal value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<int> reference, int value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<long> reference, long value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<Vector2> reference, Vector2 value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<Vector3> reference, Vector3 value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<Vector2Int> reference, Vector2Int value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<Vector3Int> reference, Vector3Int value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<Vector4> reference, Vector4 value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this VariableWriter<Color> reference, Color value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        
        #endregion
        
        #region SubtractClamped
        
        public static void SubtractClamped(this VariableWriter<float> reference, float value, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val - value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<double> reference, double value, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<decimal> reference, decimal value, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<int> reference, int value, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val - value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<long> reference, long value, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<Vector2> reference, Vector2 value, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val - value;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<Vector3> reference, Vector3 value, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val - value;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<Vector2Int> reference, Vector2Int value, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val - value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void SubtractClamped(this VariableWriter<Vector3Int> reference, Vector3Int value, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val - value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
        
        #region Multiply

        public static void Multiply(this VariableWriter<float> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<double> reference, double factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<decimal> reference, decimal factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<int> reference, int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<long> reference, long factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector2> reference, Vector2 factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector2> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector3> reference, Vector3 factor, bool invokeActions = true) 
            => reference.Set(Vector3.Scale(reference.Val, factor), invokeActions);
        public static void Multiply(this VariableWriter<Vector3> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector2Int> reference, Vector2Int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector2Int> reference, int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector3Int> reference, Vector3Int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector3Int> reference, int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Vector4> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Color> reference, Color factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this VariableWriter<Color> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        
        #endregion
        
        #region MultiplyClamped
        
        public static void MultiplyClamped(this VariableWriter<float> reference, float factor, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val * factor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<double> reference, double factor, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<decimal> reference, decimal factor, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<int> reference, int factor, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val * factor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<long> reference, long factor, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector2> reference, Vector2 factor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val * factor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector2> reference, float factor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val * factor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector3> reference, Vector3 factor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = Vector3.Scale(reference.Val, factor);
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector3> reference, float factor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val * factor;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector2Int> reference, Vector2Int factor, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector3Int> reference, Vector3Int factor, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector2Int> reference, int factor, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void MultiplyClamped(this VariableWriter<Vector3Int> reference, int factor, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
        
        #region Divide

        public static void Divide(this VariableWriter<float> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<double> reference, double divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<decimal> reference, decimal divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<int> reference, int divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<long> reference, long divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<Vector2> reference, Vector2 divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<Vector2> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<Vector3> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<Vector2Int> reference, int divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<Vector3Int> reference, int divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<Vector4> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this VariableWriter<Color> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        
        #endregion
        
        #region DivideClamped
        
        public static void DivideClamped(this VariableWriter<float> reference, float divisor, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val / divisor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<double> reference, double divisor, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<decimal> reference, decimal divisor, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<int> reference, int divisor, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val / divisor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<long> reference, long divisor, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<Vector2> reference, Vector2 divisor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val / divisor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<Vector2> reference, float divisor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val / divisor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<Vector3> reference, Vector3 divisor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = Vector3.Scale(reference.Val, divisor);
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<Vector3> reference, float divisor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val / divisor;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this VariableWriter<Vector2Int> reference, int divisor, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val / divisor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void DivideClamped(this VariableWriter<Vector3Int> reference, int divisor, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val / divisor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
    }
}


