using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfo
{
    static int level = 0;
    static int objective = 0;
    public static bool pov = false;
    public static Vector3 gPosition;
    public static Vector3 gRotation;

    public static int GetLevel()
    {
        return level;
    }

    public static int GetObjective()
    {
        return objective;
    }

    public static void SetLevel(int lvl)
    {
        level = lvl;
    }

    public static void SetObjective(int obj)
    {
        objective = obj;
    }





}
