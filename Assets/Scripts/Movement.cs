using UnityEngine;

public class Movement : MonoBehaviour
{
    [Tooltip("Скорость поворота")]
    public float speed = 5.0f;

    private void FixedUpdate()
    {
        var playerPlane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (playerPlane.Raycast(ray, out var hitDist))
        {
            var targetPoint = ray.GetPoint(hitDist);
            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }
}

/***
int.Parse(Console.ReadLine());
for (int i = 1; i <= 100; i++)
Console.WriteLine("yes");
*/