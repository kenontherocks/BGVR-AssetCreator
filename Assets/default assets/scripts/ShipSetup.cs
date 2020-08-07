using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSetup : MonoBehaviour {

    [Tooltip("Ship type unique identifier. Ex: heavycruiser")]
    public string shipClass;

    [Tooltip("Ship proper display name. Ex: Constitution Class Heavy Cruiser")]
    public string shipClassName;

    [TextArea(10, 10)]
    [Tooltip("Description text about this ship.")]
    public string shipBio;

    [Tooltip("Value used to judge how powerful this ship is. Example smallest ship = 100, battleship = 1000")]
    public int powerValue = 500;

    [Tooltip("Resource cost to buy the ship.")]
    public int cost = 30000;

    [Tooltip("Max scanning range in meters.")]
    public float scanRange = 10000;

    [Tooltip("Distance to target to begin firing or use abilties in meters.")]
    public float weapRange = 8000;

    [Tooltip("Preferred engagement range relative to weapon range, (0)close = 25% weaprange, (1)medium = 50%, (2)far = 100%.")]
    public int range = 1;

    [Tooltip("Distance beyond scan range to show unknown blip. Can be negative for within scan range but still unknown.")]
    public float signature = 1000;

    [Tooltip("Size of the ship in meters, order is: width, height, length.")]
    public Vector3 size;

    [Tooltip("Arc setting to keep the target within, (0)front0 = always face enemy, (1)front90, (2)front180, (3)front270, (4)frontback90, (5)leftright90, (6)full360 = target can be anywhere.")]
    public int weaponArc = 3;

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

}
