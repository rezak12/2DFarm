using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public float maxStamina;
    public float[] position;
    public int XP;
    public int Level;

    public SceneData (Player ply, ExperinceSystem xp)
    {
        maxStamina = ply.maxStamina;
        position = new float[3];
        position[0] = ply.transform.position.x;
        position[1] = ply.transform.position.y;
        position[2] = ply.transform.position.z;
        XP = xp.CurrentXP;
        Level = xp.CurrentLevel;
    }
}

    
