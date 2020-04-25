using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    [SerializeField] TextMeshProUGUI scoreUI;
    [HideInInspector] public float timeElapsed;

    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();

        timeElapsed += Time.deltaTime;
    }
}
