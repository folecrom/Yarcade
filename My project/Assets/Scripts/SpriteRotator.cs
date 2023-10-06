using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    public float rotationSpeed = 30f;

    private void Update()
    {
        // Faites tourner le GameObject autour de son axe Z (orientation 2D)
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
