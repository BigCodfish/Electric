using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : Prop
{
    public Transform[] trans;
    public override void Function()
    {
        trans[0].DOMoveY(trans[0].position.y + 1, 1);
        trans[1].DOMoveY(trans[0].position.y - 1, 1);
    }
}
