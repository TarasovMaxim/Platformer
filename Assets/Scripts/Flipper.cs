using UnityEngine;

public class Flipper : MonoBehaviour
{
    public void Flip( bool isFaceRight)
    {
        Vector2 scale = transform.localScale;

        if (isFaceRight)
            scale.x = Mathf.Abs(scale.x);   
        else
            scale.x = -Mathf.Abs(scale.x); 

        transform.localScale = scale;
    }
}