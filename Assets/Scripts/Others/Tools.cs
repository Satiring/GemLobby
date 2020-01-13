using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools 
{
    public static Quaternion LookAt(Vector3 start, Vector3 dest, float angleOffset) {
        var relativePos = start - dest;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        Quaternion rotationFinal = Quaternion.AngleAxis(angle + angleOffset, Vector3.forward);
        return rotationFinal;
    }
    
    public static Vector2 GetPointOnRing(float aMinRadius, float aMaxRadius)
    {
        var v = Random.insideUnitCircle;
        return v.normalized * aMinRadius + v*(aMaxRadius - aMinRadius);
    }
    
    public static Quaternion getRotationToTarget(Vector2 TargetPoint)
    {
        float angle = Mathf.Atan2(TargetPoint.y, TargetPoint.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    public static Vector2 GetNextStep(Vector2 direction, Vector2 actualPosition,float moveSpeed)
    {
        Vector2 nextStep = new Vector2();
        nextStep = actualPosition + (direction * moveSpeed * Time.deltaTime);
        return nextStep;
    }
    
    public static Vector2 Rotate(this Vector2 v, float degrees) {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
    
    public static IEnumerator FlashSprite(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.material.SetFloat("_FlashAmount", 0);
    }

    public static IEnumerator DestroyCountdown(int countDownValue, GameObject toDestroy)
    {
        float current = countDownValue;
        while (current > 0)
        {
            yield return new WaitForSeconds(1.0f);
            current--;
        }
        GameObject.Destroy(toDestroy);
    }
}
