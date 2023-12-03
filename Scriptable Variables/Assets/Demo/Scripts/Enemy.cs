using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;

    public void SetColor(Color color) => sr.color = color;
}
