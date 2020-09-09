using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipSetup : MonoBehaviour {

    [Tooltip("Ship type unique identifier. Ex: heavycruiser")]
    public string shipClass;

    [Tooltip("Ship proper display name. Ex: Constitution Class Heavy Cruiser")]
    public string shipClassName;

    [TextArea(10, 10)]
    [Tooltip("Description text about this ship.")]
    public string shipBio;

    [Tooltip("Max scanning range in meters.")]
    public float scanRange = 10000;

    [Tooltip("Distance to target to begin firing or use abilties in meters.")]
    public float weapRange = 8000;

    [Tooltip("Preferred engagement range relative to weapon range, close = 25% weaprange, medium = 50%, far = 100%.")]
    public prefrange range = prefrange.close;
    public enum prefrange { close = 0, medium = 1, far = 2 }

    [Tooltip("Distance beyond scan range to show unknown blip. Can be negative for within scan range but still unknown.")]
    public float signature = 1000;

    [Tooltip("Size of the ship in meters, order is: width, height, length.")]
    public Vector3 size;

    [Tooltip("Degrees for the ship to keep the target within, front0 = always face enemy, front90 = target 90degress in front, front180, front270, frontback90, leftright90 = 90d left or right, full360 = target can be anywhere.")]
    public weaponarc weaponArc = weaponarc.front90;
    public enum weaponarc {front0 = 0, front90 = 1, front180 = 2, front270 = 3, frontback90 = 4, leftright90 = 5, full360 = 6 }

    [Tooltip("Max speed per second in meters.")]
    public float maxSpeed = 125;

    [Tooltip("How fast a ships speeds up per second in meters.")]
    public float accelleration = 0.8f;

    [Tooltip("Maximum turning per second in degrees.")]
    public float maxTurn = 9;

    [Tooltip("Hull hit points. Example: corvette = 600, battleship = 3200")]
    public float hitPoints = 1500;

    [Tooltip("How much supply this ship starts with for abilities. Average active ability costs 25-50 supply. ")]
    public float maxsupply = 250;

    [Header("Shields")]
    [Tooltip("Maximum hitpoints for left shield.")]
    public float maxleft = 1000;

    [Tooltip("Maximum hitpoints for right shield.")]
    public float maxright = 1000;

    [Tooltip("Maximum hitpoints for front shield.")]
    public float maxfront = 1500;

    [Tooltip("Maximum hitpoints for rear shield.")]
    public float maxback = 500;

    [Header("Links")]
    [Tooltip("Link/point to the main body object.")]
    public GameObject body;

    [Tooltip("Link/point to the bridge placeholder object.")]
    public GameObject bridgepos;

    [Tooltip("Link/point to the engine flares container object.")]
    public GameObject engineflare;

    [Tooltip("Link/point to the equipment slot and weapons container object.")]
    public GameObject weaponsetup;

    [Tooltip("Size of the bridge cabin to load.")]    
    public bridgesize bridgeSize;
    public enum bridgesize { small = 0, medium = 1, large = 2}
    public GameObject customBridgeSetup;

    [Tooltip("Enter your STEAMID to bind this asset to your account, only this STEAM account can upload to workshop. Use AUTOSIGN button to generate.")]
    public ulong bindSteamid;

    public void AutoPopulate() {
        float hppervol = 0.06f;
        float shieldpervol = 0.14f;
        float speedpervol = 0.125f;
        float accelerationpervol = 0.001f;
        float turnpervol = 0.009f;

        //get vol
        float volume = size.x * size.y * size.z;
        float scaledvol = volume / 1000f;

        //set stats based on scaled vol
        hitPoints = hppervol * scaledvol;

        float totalshields = shieldpervol * scaledvol;
        maxleft = totalshields / 4;
        maxright = totalshields / 4;
        maxfront = totalshields / 4;
        maxback = totalshields / 4;

        maxSpeed = 250 * (speedpervol * scaledvol);
        accelleration = accelleration * scaledvol;
        maxTurn = turnpervol * scaledvol;
    }


    public void AutoSign() {
        bool connected = false;
        if (!Steamworks.SteamClient.IsValid) {
            try {
                //starting up steam
                Debug.Log("connecting to steam...");
                Steamworks.SteamClient.Init(1178780);
                connected = true;
            } catch (System.Exception e) {
                // Something went wrong
                Debug.LogError("Could not connect to STEAM, are you signed in? "+e);
            }
        } else {
            connected = true;
        }

        if (connected) {
            string steamname = Steamworks.SteamClient.Name;
            ulong steamid = Steamworks.SteamClient.SteamId;
            bindSteamid = steamid;
            Debug.Log($"Ship bound to {steamid} ({steamname})"); // Your SteamId
        }

    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(ShipSetup), true)]
public class AutoCalcStats : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        ShipSetup thisscript = (ShipSetup)target;

        if (GUILayout.Button("AUTOSIGN")) {
            thisscript.AutoSign();
        }

        /*if (GUILayout.Button("Auto Calc Stats Based on Volume")) {
            thisscript.AutoPopulate();
            Debug.Log("stats populated based on volumn");
        }*/
    }
}
#endif