using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDialogBox : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMesh;

    void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
