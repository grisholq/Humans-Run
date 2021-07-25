using UnityEngine;
using System.Collections.Generic;

public class DublicatingZonesGroup : MonoBehaviour
{
    [SerializeField] private List<DublicatingZone> _dublicatingZones;

    public void DisableAllZonesExcept(DublicatingZone zone)
    {
        foreach (var dublicatingZone in _dublicatingZones)
        {
            if(dublicatingZone != zone)
            {
                dublicatingZone.Disable();
            }
        }
    }
}