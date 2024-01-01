using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<ArrowCollide>())
        {
            _scoreText.text = (Convert.ToInt32(_scoreText.text) + 1).ToString();
        }
    }
}
