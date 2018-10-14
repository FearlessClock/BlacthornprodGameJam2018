﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleGenerator : ShapeAbstractGenerator
{
    public override void GenerateShape(Vector3 spellLocation)
    {
        this.transform.position = new Vector3(shapeSettings.posX, shapeSettings.posY, 0) + spellLocation;
        switch (shapeSettings.elementalType)
        {
            case "fire":
                elementalType = ElementalType.fire;
                break;
            case "water":
                elementalType = ElementalType.water;
                break;
            default:
                elementalType = ElementalType.normal;
                break;
        }
    }
}
