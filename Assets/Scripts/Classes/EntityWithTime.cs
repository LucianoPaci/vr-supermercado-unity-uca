using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityWithTime
{
    public string elaspedTime { get; private set; }
    public Entity entity { get; private set; }
    public EntityWithTime(string time, Entity e)
    {
        this.elaspedTime = time;
        this.entity = e;
    }

}