using System;
using NuiN.ScriptableVariables.Variable.References;
using UnityEngine;

namespace NuiN.ScriptableVariables.Variable.References
{
    public static class VariableWriterExtensions
    {
        #region Add
        
        public static void Add(this SetVariable<float> reference, float value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<double> reference, double value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<decimal> reference, decimal value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<int> reference, int value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<long> reference, long value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<string> reference, string value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<Vector2> reference, Vector2 value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<Vector3> reference, Vector3 value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<Vector2Int> reference, Vector2Int value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<Vector3Int> reference, Vector3Int value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<Vector4> reference, Vector4 value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        public static void Add(this SetVariable<Color> reference, Color value, bool invokeActions = true) 
            => reference.Set(reference.Val + value, invokeActions);
        
        #endregion
        
        #region AddClamped
        
        public static void AddClamped(this SetVariable<float> reference, float value, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val + value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this SetVariable<double> reference, double value, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this SetVariable<decimal> reference, decimal value, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this SetVariable<int> reference, int value, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val + value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this SetVariable<long> reference, long value, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val + value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void AddClamped(this SetVariable<Vector2> reference, Vector2 value, float max, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val + value;
            reference.Set(Vector2.ClampMagnitude(newVal, max), invokeActions);
        }
        public static void AddClamped(this SetVariable<Vector3> reference, Vector3 value, float max, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val + value;
            reference.Set(Vector3.ClampMagnitude(newVal, max), invokeActions);
        }
        public static void AddClamped(this SetVariable<Vector2Int> reference, Vector2Int value, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val + value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void AddClamped(this SetVariable<Vector3Int> reference, Vector3Int value, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val + value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
        
        #region Subtract

        public static void Subtract(this SetVariable<float> reference, float value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<double> reference, double value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<decimal> reference, decimal value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<int> reference, int value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<long> reference, long value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<Vector2> reference, Vector2 value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<Vector3> reference, Vector3 value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<Vector2Int> reference, Vector2Int value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<Vector3Int> reference, Vector3Int value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<Vector4> reference, Vector4 value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        public static void Subtract(this SetVariable<Color> reference, Color value, bool invokeActions = true) 
            => reference.Set(reference.Val - value, invokeActions);
        
        #endregion
        
        #region SubtractClamped
        
        public static void SubtractClamped(this SetVariable<float> reference, float value, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val - value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this SetVariable<double> reference, double value, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this SetVariable<decimal> reference, decimal value, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this SetVariable<int> reference, int value, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val - value;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this SetVariable<long> reference, long value, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val - value;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void SubtractClamped(this SetVariable<Vector2> reference, Vector2 value, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val - value;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void SubtractClamped(this SetVariable<Vector3> reference, Vector3 value, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val - value;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void SubtractClamped(this SetVariable<Vector2Int> reference, Vector2Int value, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val - value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void SubtractClamped(this SetVariable<Vector3Int> reference, Vector3Int value, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val - value;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
        
        #region Multiply

        public static void Multiply(this SetVariable<float> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<double> reference, double factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<decimal> reference, decimal factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<int> reference, int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<long> reference, long factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector2> reference, Vector2 factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector2> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector3> reference, Vector3 factor, bool invokeActions = true) 
            => reference.Set(Vector3.Scale(reference.Val, factor), invokeActions);
        public static void Multiply(this SetVariable<Vector3> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector2Int> reference, Vector2Int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector2Int> reference, int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector3Int> reference, Vector3Int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector3Int> reference, int factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Vector4> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Color> reference, Color factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        public static void Multiply(this SetVariable<Color> reference, float factor, bool invokeActions = true) 
            => reference.Set(reference.Val * factor, invokeActions);
        
        #endregion
        
        #region MultiplyClamped
        
        public static void MultiplyClamped(this SetVariable<float> reference, float factor, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val * factor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<double> reference, double factor, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<decimal> reference, decimal factor, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<int> reference, int factor, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val * factor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<long> reference, long factor, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val * factor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector2> reference, Vector2 factor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val * factor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector2> reference, float factor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val * factor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector3> reference, Vector3 factor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = Vector3.Scale(reference.Val, factor);
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector3> reference, float factor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val * factor;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector2Int> reference, Vector2Int factor, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector3Int> reference, Vector3Int factor, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector2Int> reference, int factor, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void MultiplyClamped(this SetVariable<Vector3Int> reference, int factor, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val * factor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
        
        #region Divide

        public static void Divide(this SetVariable<float> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<double> reference, double divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<decimal> reference, decimal divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<int> reference, int divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<long> reference, long divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<Vector2> reference, Vector2 divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<Vector2> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<Vector3> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<Vector2Int> reference, int divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<Vector3Int> reference, int divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<Vector4> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        public static void Divide(this SetVariable<Color> reference, float divisor, bool invokeActions = true) 
            => reference.Set(reference.Val / divisor, invokeActions);
        
        #endregion
        
        #region DivideClamped
        
        public static void DivideClamped(this SetVariable<float> reference, float divisor, float? min = null, float? max = null, bool invokeActions = true)
        {
            float newVal = reference.Val / divisor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this SetVariable<double> reference, double divisor, double? min = null, double? max = null, bool invokeActions = true)
        {
            double newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this SetVariable<decimal> reference, decimal divisor, decimal? min = null, decimal? max = null, bool invokeActions = true)
        {
            decimal newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this SetVariable<int> reference, int divisor, int? min = null, int? max = null, bool invokeActions = true)
        {
            int newVal = reference.Val / divisor;
            reference.Set(Mathf.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this SetVariable<long> reference, long divisor, long? min = null, long? max = null, bool invokeActions = true)
        {
            long newVal = reference.Val / divisor;
            reference.Set(Math.Clamp(newVal, min ?? newVal, max ?? newVal), invokeActions);
        }
        public static void DivideClamped(this SetVariable<Vector2> reference, Vector2 divisor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val / divisor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this SetVariable<Vector2> reference, float divisor, float maxLength, bool invokeActions = true)
        {
            Vector2 newVal = reference.Val / divisor;
            reference.Set(Vector2.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this SetVariable<Vector3> reference, Vector3 divisor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = Vector3.Scale(reference.Val, divisor);
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this SetVariable<Vector3> reference, float divisor, float maxLength, bool invokeActions = true)
        {
            Vector3 newVal = reference.Val / divisor;
            reference.Set(Vector3.ClampMagnitude(newVal, maxLength), invokeActions);
        }
        public static void DivideClamped(this SetVariable<Vector2Int> reference, int divisor, Vector2Int? min = null, Vector2Int? max = null, bool invokeActions = true)
        {
            Vector2Int newVal = reference.Val / divisor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }
        public static void DivideClamped(this SetVariable<Vector3Int> reference, int divisor, Vector3Int? min = null, Vector3Int? max = null, bool invokeActions = true)
        {
            Vector3Int newVal = reference.Val / divisor;
            newVal.Clamp(min ?? newVal, max ?? newVal);
            reference.Set(newVal, invokeActions);
        }

        #endregion
    }
}


