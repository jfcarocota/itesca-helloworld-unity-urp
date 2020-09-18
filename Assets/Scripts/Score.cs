using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    TextMeshProUGUI textMesh;

    int score = 0;
    
    void Awake() 
    {
        textMesh = GetComponent<TextMeshProUGUI>();    
    }

    public void AddPoints(int points)
    {
        score += points;
        textMesh.text = $"Score: {score}";
    }
}
