using System.Collections;
using System.Collections.Generic;
using NuiN.ScriptableHarmony.Events;
using NuiN.ScriptableHarmony.ListVariable.Base;
using NuiN.ScriptableHarmony.References;
using NuiN.ScriptableHarmony.Variable.Base;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

internal class ScriptableVariableSOTests
{
    [Test]
    public void ResetValue_ShouldResetValue()
    {
        var variableObj = ScriptableObject.CreateInstance<TestVariableSO>();
        var setVariable = new TestSetVariable(variableObj);
        setVariable.Set(25f);
        setVariable.ResetValue();
        
        Assert.AreEqual(variableObj.value, variableObj.DefaultValue);
    }
    
    [Test]
    public void ResetAllVariableObjectsEvent_ShouldResetValue()
    {
        var variableObj = ScriptableObject.CreateInstance<TestVariableSO>();
        var setVariable = new TestSetVariable(variableObj);
        setVariable.Set(25f);
        VariableEvents.ResetAllVariableObjects();
        
        Assert.AreEqual(variableObj.value, variableObj.DefaultValue);
    }
    
    [Test]
    public void SetEvent_ShouldSetValue()
    {
        var variableObj = ScriptableObject.CreateInstance<TestVariableSO>();
        var setVariable = new TestSetVariable(variableObj);
        
        TestVariableSOEvents testEventValue = new(setVariable);
        
        setVariable.Set(25f);
        Assert.AreEqual(testEventValue.testValue, variableObj.value);
        setVariable.Set(Mathf.Epsilon);
        Assert.AreEqual(testEventValue.testValue, variableObj.value);
        setVariable.Set(344.324234f);
        Assert.AreEqual(testEventValue.testValue, variableObj.value);
    }
}
internal class ScriptableListVariableSOTests
{
    [Test]
    public void ResetValues_ShouldResetList()
    {
        var variableObj = ScriptableObject.CreateInstance<TestListVariableSO>();
        var setVariable = new TestSetListVariable(variableObj);
        setVariable.Replace(new List<float> {1f, 2f, 3f, 4f, 5f});
        setVariable.ResetValues();
        
        Assert.AreEqual(variableObj.values, variableObj.DefaultValues);
    }
    
    [Test]
    public void ResetAllVariableObjectsEvent_ShouldResetList()
    {
        var variableObj = ScriptableObject.CreateInstance<TestListVariableSO>();
        var setVariable = new TestSetListVariable(variableObj);
        setVariable.Replace(new List<float> {1f, 2f, 3f, 4f, 5f});
        VariableEvents.ResetAllVariableObjects();
        
        Assert.AreEqual(variableObj.values, variableObj.DefaultValues);
    }
    
    [Test]
    public void AddEvent_ShouldAddValueToList()
    {
        var variableObj = ScriptableObject.CreateInstance<TestListVariableSO>();
        var setVariable = new TestSetListVariable(variableObj);
        
        TestListVariableSOEvents testEventValue = new(setVariable);
        
        setVariable.Add(25f);
        Assert.AreEqual(testEventValue.testList, variableObj.values);
        setVariable.Add(Mathf.Epsilon);
        Assert.AreEqual(testEventValue.testList, variableObj.values);
        setVariable.Add(344.324234f);
        Assert.AreEqual(testEventValue.testList, variableObj.values);
    }
}

internal class TestVariableSO : ScriptableVariableBaseSO<float> { }

internal class TestSetVariable : SetVariable<float>
{
    public TestSetVariable(TestVariableSO variable) { this.variable = variable; }
}
internal class TestListVariableSO : ScriptableListVariableBaseSO<float> { }

internal class TestSetListVariable : SetListVariable<float>
{
    public TestSetListVariable(TestListVariableSO list) { this.list = list; }
}

internal class TestVariableSOEvents
{
    public float testValue;
    public TestVariableSOEvents(TestSetVariable variable) { variable.SubOnChange(SetTestValue); }
    void SetTestValue(float newValue) => testValue = newValue;
}

internal class TestListVariableSOEvents
{
    public readonly List<float> testList = new();
    public TestListVariableSOEvents(TestSetListVariable variable) { variable.SubOnAdd(AddTestValue); }
    void AddTestValue(float newValue) => testList.Add(newValue);
}


