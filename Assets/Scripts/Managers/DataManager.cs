using Hope.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public DatabaseInfoStracture databaseInfoStracture = DatabaseInfoStracture.Firebase;

    DataProvider dataProvider;

    void Start()
    {
        switch (databaseInfoStracture)
        {
            case DatabaseInfoStracture.Firebase:
                dataProvider = gameObject.AddComponent<DataProviderFirebase>();
                break;
            case DatabaseInfoStracture.MySQL:
                dataProvider = gameObject.AddComponent<DataProviderMySQL>();
                break;
            default:
                break;
        }

        if (dataProvider != null)
        {
            dataProvider.Initialize(null, (parameter) =>
            {
                if (parameter)
                {
                    Debug.Log("DataManager Initialized");
                }
                else
                {
                    Debug.LogError("DataManager Initialization Failed");
                }
            });
        }
    }

    public DataProvider GetProvider()
    {
        return dataProvider;
    }
}
