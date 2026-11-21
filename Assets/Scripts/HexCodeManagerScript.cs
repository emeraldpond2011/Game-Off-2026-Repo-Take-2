using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class HexCodeManagerScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color value;
    public HexCodeGenoratorScript hexCode;
    public float colorOffSet;
    public float localRotation;
    public float normRotation;
    public PlayerManagerScript solidRange;

    void Update()
    {
        GetColor();
        SolidCheck();
    }

    public void GetColor()
    {
        localRotation = hexCode.localRotation + colorOffSet;
        normRotation = NormalizeRotation(localRotation);

        value = sprite.color;
        value.r = hexCode.GenorateHexValues(localRotation).x;
        value.g = hexCode.GenorateHexValues(localRotation).y;
        value.b = hexCode.GenorateHexValues(localRotation).z;

        sprite.color = value;
    }

    public void SolidCheck()
    {
        if (solidRange.colorMin > solidRange.colorMax)
        {
            if (normRotation >= solidRange.colorMin && normRotation <= 360 || normRotation <= solidRange.colorMax && normRotation >= 0)
            {
                gameObject.layer = 3;
                sprite.sortingOrder = 2;
            }
            else
            {
                gameObject.layer = 6;
                sprite.sortingOrder = 0;
            }
        }
        else
        {
            if (normRotation >= solidRange.colorMin && normRotation <= solidRange.colorMax)
            {
                gameObject.layer = 3;
                sprite.sortingOrder = 2;
            }
            else
            {
                gameObject.layer = 6;
                sprite.sortingOrder = 0;
            }
        }
    }

    public float NormalizeRotation(float baseRotation)
    {
        float rotationing = baseRotation;
        
        while (rotationing < 0)
        {
            rotationing += 360;
        }
        while (rotationing > 360)
        {
            rotationing -= 360;
        }
        return rotationing;
    }
}
