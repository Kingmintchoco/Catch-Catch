using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        setTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.numOfTarget == 0)
        {
            GameManager.instance.setNextPhase();
            setTarget();
        }
    }

    public Vector3 GetRandomPosition()
    {
        float radius = 1.75f;

        playerPos = player.transform.position;
        float px = playerPos.x;

        // player 위치에서는 나오지 않게함 
        float x = Random.Range(-radius, radius);
        while (true)
        {
            float val;
            if (px > x) val = px - x;
            else val = x - px;

            if (val < 1) x = Random.Range(-radius, radius);
            else break;
        }
        float y = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x, 2));
        y *= Random.Range(0, 2) == 0 ? -1 : 1;

        Vector3 randomPos = new Vector3(x, y, 0);
        return randomPos;
    }

    public void setTarget()
    {
        int p = GameManager.instance.phase;
        GameManager.instance.numOfTarget = Random.Range(1, p + 3);
        int len = GameManager.instance.numOfTarget;
        for(int i = 0; i < len; ++i)
        {
            Instantiate(target, GetRandomPosition(), Quaternion.identity);
        }
    }
}
