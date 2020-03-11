using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCube : Prop
{
    public BreakItem[] cubes;
    private int id = 0;
    public override void Function()
    {
        StartCoroutine("Break");
    }

    IEnumerator Break()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[id++].Break();
            yield return new WaitForSeconds(1);
        }
    }
}
