using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    
    public void TakeScreenshot() {

        GameObject subject = FindObjectOfType<ShipSetup>().gameObject;

        string folderPath = Directory.GetCurrentDirectory() + "/AssetBundles/Windows/";


        string subjectname = "";
        if (subject) {
            subjectname = subject.name;
        }

        var screenshotName = "preview-" + subjectname + ".png";
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
        Debug.Log(folderPath + screenshotName);

        #if UNITY_EDITOR
        EditorUtility.RevealInFinder(folderPath);
        #endif
    }

    public void AutoPosition() {
        GameObject subject = FindObjectOfType<ShipSetup>().gameObject;
        ShipSetup ss = subject.GetComponent<ShipSetup>();
        if (ss) {            
            transform.position = new Vector3(ss.size.z/2, ss.size.z/2, ss.size.z/2);
            transform.LookAt(Vector3.zero);
        }
    }

    

}

#if UNITY_EDITOR
[CustomEditor(typeof(Screenshot))]
class Screenshotbtns : Editor {
    public override void OnInspectorGUI() {
        Screenshot thisscript = (Screenshot)target;
        if (GUILayout.Button("Auto Position")) {
            thisscript.AutoPosition();
        }

        if (GUILayout.Button("Take Screenshot")) {
            thisscript.TakeScreenshot();
        }
    }
}
#endif