using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver;
    public GameObject gameoverText;
    public GameObject gameoverBtn;
    public GameObject gameoverImg;
    public TextMeshProUGUI scoreText;

    [SerializeField]
    private int score = 0;
    public int phase;

    [SerializeField]
    public int numOfTarget;

    [SerializeField]
    public float rotateSpeed;

    // 게임시작과 동시에 싱글턴을 구성 
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 GameManager가 존재!");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        phase = 1;
        isGameOver = false;
        rotateSpeed = -80f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int newScore)
    {
        numOfTarget--;
        score += newScore;
        scoreText.text = score.ToString();
    }

    public void setGameover()
    {
        isGameOver = true;
        gameoverText.SetActive(true);
        gameoverBtn.SetActive(true);
        gameoverImg.SetActive(true);
    }

    public void setNextPhase()
    {
        phase++;
        rotateSpeed = Random.Range(-100f, 200f);
    }
}
