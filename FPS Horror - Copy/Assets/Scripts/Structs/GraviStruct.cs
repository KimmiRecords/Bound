using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GraviStruct
{
    //este struct es un combo de 2 vector3, y en el futuro, de quaternions tambien
    //por valentino roman y diego katabian

    public Vector3 normalGrav;
    public Vector3 alteredGrav;
}
