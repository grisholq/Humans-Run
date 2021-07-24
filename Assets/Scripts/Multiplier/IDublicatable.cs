using UnityEngine;

public interface IDublicatable
{
    Transform CreateDublicate();
    DublicatingZone LastDublicateZone { get; set; }  
}