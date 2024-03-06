using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Storage;
using Hope.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoSingleton<VariableManager>
{
    public Dictionary<ObscuredString, object> Variables = new Dictionary<ObscuredString, object>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddVariable<T>(string variableName, T variableValue) where T : IObscuredType
    {
        if (Variables.ContainsKey(variableName))
        {
            Variables[variableName] = variableValue;
        }
        else
        {
            Variables.Add(variableName, variableValue);
        }
    }

    public T GetVaraiable<T>(string variableName) where T : IObscuredType
    {
        if (Variables.ContainsKey(variableName))
        {
            return (T)Variables[variableName];
        }
        else
        {
            return default;
        }
    }

    public void DeleteVariable(string variableName)
    {
        if (Variables.ContainsKey(variableName))
        {
            Variables.Remove(variableName);
        }
    }

    public bool VariableExists(string variableName)
    {
        return Variables.ContainsKey(variableName);
    }

    public void ResetAllVariables()
    {
        Variables.Clear();
    }

    public void AddLocalVariable(string localKey, string localValue)
    {
        ObscuredPrefs.Set(localKey, localValue);
    }

    public string GetLocalVariable(string localKey)
    {
        return ObscuredPrefs.Get(localKey, "");
    }
    public bool LocalVariableExists(string localKey)
    {
        return ObscuredPrefs.HasKey(localKey);
    }
    public void DeleteLocalVariable(string localKey)
    {
        ObscuredPrefs.DeleteKey(localKey);
    }
    public void ResetAllLocalVariables()
    {
        ObscuredPrefs.DeleteAll();
    }
}
