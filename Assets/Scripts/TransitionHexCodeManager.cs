using UnityEngine;
using UnityEngine.U2D;

public class TransitionHexCodeManager : MonoBehaviour
{
    public float perOfRed;
    public float perOfGreen;
    public float perOfBlue;
    public SpriteRenderer firstPlatform;
    public SpriteRenderer secondPlatform;
    public Color firstColor;
    public Color secondColor;
    public SpriteRenderer currentPlatform;
    public Color currentColor;
    public PlayerManagerScript playerScript;
    public Vector2 redMinAndMax;
    public Vector2 greenMinAndMax;
    public Vector2 blueMinAndMax;

    void Update()
    {
        GenorateColor();
        SolidCheck();
    }

    public void GenorateColor()
    {
        firstColor = firstPlatform.color;
        secondColor = secondPlatform.color;

        // The equation works but doesn't produce the correct color
        // Try looking at how colors mix/ color theory :,(

        perOfRed = (firstColor.r + secondColor.r) / 2;
        perOfGreen = (firstColor.g + secondColor.g) / 2;
        perOfBlue = (firstColor.b + secondColor.b) / 2;

        currentColor = currentPlatform.color;

        currentColor.r = perOfRed;
        currentColor.g = perOfGreen;
        currentColor.b = perOfBlue;
        currentColor.a = 1f;

        currentPlatform.color = currentColor;
    }

    public void SolidCheck()
    {
        redMinAndMax = (Vector2.right * (playerScript.transColorMid.x - playerScript.transColorRange)) + (Vector2.up * (playerScript.transColorMid.x + playerScript.transColorRange));
        greenMinAndMax = (Vector2.right * (playerScript.transColorMid.y - playerScript.transColorRange)) + (Vector2.up * (playerScript.transColorMid.y + playerScript.transColorRange));
        blueMinAndMax = (Vector2.right * (playerScript.transColorMid.z - playerScript.transColorRange)) + (Vector2.up * (playerScript.transColorMid.z + playerScript.transColorRange));

        if (perOfRed >= playerScript.transColorMid.x - playerScript.transColorRange && perOfRed <= playerScript.transColorMid.x + playerScript.transColorRange)
        {
            if (perOfGreen >= playerScript.transColorMid.y - playerScript.transColorRange && perOfGreen <= playerScript.transColorMid.y + playerScript.transColorRange)
            {
                if (perOfBlue >= playerScript.transColorMid.z - playerScript.transColorRange && perOfBlue <= playerScript.transColorMid.z + playerScript.transColorRange)
                {
                    gameObject.layer = 3;
                    currentPlatform.sortingOrder = 5;
                }
            }
        }
        else
        {
            gameObject.layer = 6;
            currentPlatform.sortingOrder = 3;
        }
    }
}
