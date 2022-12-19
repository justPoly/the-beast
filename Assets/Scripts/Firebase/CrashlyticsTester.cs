using System;
using UnityEngine;

/*
* firebase crashlytics:symbols:upload --app=1:209561609170:android:00948e167051b4ea8bde0b C:\\Users\\NINJA\\Documents\\Unity-Projects\\BUILDS\\3rd_Party_Test_App_11-1.1.0-v11.symbols.zip
*/
public class CrashlyticsTester : MonoBehaviour {

    int updatesBeforeException;

    // Use this for initialization
    void Start () {
        Firebase.FirebaseApp.LogLevel = Firebase.LogLevel.Debug;
        updatesBeforeException = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Call the exception-throwing method here so that it's run
        // every frame update
        throwExceptionEvery60Updates();
    }

    // A method that tests your Crashlytics implementation by throwing an
    // exception every 60 frame updates. You should see non-fatal errors in the
    // Firebase console a few minutes after running your app with this method.
    void throwExceptionEvery60Updates()
    {
        if (updatesBeforeException > 0)
        {
            updatesBeforeException--;
        }
        else
        {
            // Set the counter to 60 updates
            updatesBeforeException = 60;

            // Throw an exception to test your Crashlytics implementation
            throw new System.Exception("test exception please ignore");
        }
    }
}

/*
* This script will cause a test crash a few seconds after you run your app.
*/