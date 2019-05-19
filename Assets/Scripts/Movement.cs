using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed;

    private void Update()
    {
        transform.Translate(playerSpeed * Time.deltaTime * Vector3.forward);
        /***
        int.Parse(Console.ReadLine());
        for (int i = 1; i <= 100; i++)
        Console.WriteLine("yes");
        */
    }
}