using UnityEngine;
using System;
using UnityEngine.TextCore.LowLevel;

public class HexCodeGenoratorScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2;
    public float localRotation;
    public Color value;

    public float redMin = 120f;
    public float redMax = 250f;
    public float blueMin = 300f;
    public float blueMax = 180f;
    public float greenMin = 250f;
    public float greenMax = 0f;
    public Vector3 hexCode;
    void Start()
    {
        
    }

    void Update()
    {
        localRotation = rigidbody2.rotation;
        
        hexCode = GenorateHexValues(localRotation);

        value.r = GenorateHexValues(localRotation).x;
        value.g = GenorateHexValues(localRotation).y;
        value.b = GenorateHexValues(localRotation).z;
    }

    public Vector3 GenorateHexValues(float normRotation)
    {
        while (normRotation < 0)
        {
            normRotation += 360;
        }
        while (normRotation > 360)
        {
            normRotation -= 360;
        }

        float perOfRed = 0f;
        float perOfGreen = 0f;
        float perOfBlue = 0f;

        // if (normRotation <= redMin && normRotation >= 0 || normRotation <= 360 && normRotation >= redMax)
        // {
            if (normRotation <= redMin - 60 && normRotation >= 0 || normRotation >= redMax + 60 && normRotation <= 360)
            {
                perOfRed = 1f;
            }
            else if (normRotation <= redMin && normRotation >= redMin - 60)
            {
                perOfRed = ((redMin + 60) - normRotation) / 60 - 1;
            }
            else if (normRotation >= redMax && normRotation <= redMax + 60)
            {
                perOfRed = (normRotation - (redMax - 60)) / 60 - 1;
            }

        // }

        // if (normRotation >= blueMin && normRotation <= 360 || normRotation >= 0 && normRotation <= blueMax)
        // {
            if (normRotation >= blueMax && normRotation <= blueMin)
            {
                perOfBlue = 1f;
            }
            else if (normRotation <= blueMax && normRotation >= blueMax - 60)
            {
                perOfBlue = (normRotation - (blueMax - 60)) / 60;
            }
            else if (normRotation >= blueMin && normRotation <= 360)
            {
                perOfBlue = ((blueMin + 60) - normRotation) / 60;
            }
        // }

        // if (normRotation >= greenMax && normRotation <= greenMin)
        // {
            if (normRotation >= greenMax + 60 && normRotation <= greenMin - 60)
            {
                perOfGreen = 1f;
            }
            else if (normRotation >= greenMin - 60 && normRotation <= greenMin)
            {
                perOfGreen = (greenMin - normRotation) / 60;
            }
            else if (normRotation <= greenMax + 60 && normRotation >= greenMax)
            {
                perOfGreen = (normRotation - greenMax) / 60;
            }
        // }

        return Vector3.zero + (Vector3.right * perOfRed) + (Vector3.up * perOfGreen) + (Vector3.forward * perOfBlue);
    }
}
