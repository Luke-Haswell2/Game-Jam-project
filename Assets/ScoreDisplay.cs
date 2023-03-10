using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    TMPro.TextMeshProUGUI tmpro;
    void Start()
    {
        tmpro = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpro.text = "Score: " + Score.score;
    }
}
