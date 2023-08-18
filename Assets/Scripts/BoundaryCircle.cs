using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCircle : MonoBehaviour
{
    [SerializeField]
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = GameManager.instance.rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rotateSpeed = GameManager.instance.rotateSpeed;

        if (!GameManager.instance.isGameOver)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }
}
