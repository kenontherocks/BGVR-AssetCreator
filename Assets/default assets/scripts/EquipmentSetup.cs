using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSetup : MonoBehaviour
{

    public enum slottype { cannon = 0, laser = 1, turret = 2, launcher = 3, weapomni = 4, offensive = 5, defensive = 6, support = 7, compomni = 8, engine = 9, bay = 10, special = 11 }
    public enum slotsize { small = 0, medium = 1, large = 2 }
    public enum weaponarc { none = 0, F90 = 1, F180 = 2, F270 = 3, F360 = 4 }

    [Tooltip("Type of component slot.")]
    public slottype type;

    [Tooltip("Weapons only, determines the max size of weapon that can fit into this slot.")]
    public slotsize size;

    [Tooltip("If turret, turning arc.")]    
    public weaponarc weparc;
    
    [Tooltip("Full exact name of equipment to be spawned into this slot by default")]
    public string defaultcomponent;

    [Tooltip("Custom sound FX when activated.")]
    public AudioClip[] replacementsound;

    [Tooltip("Misc information. Example: tall, wide, or onedir for fighter bays")]
    public string miscinfo;

    [Tooltip("Hide the body of the component, useful for weapons that come directly from the ship, thus no turret.")]
    public bool hidebody = false;

}
