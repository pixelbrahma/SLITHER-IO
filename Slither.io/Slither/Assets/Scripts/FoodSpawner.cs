using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

    private float height;
    private float width;
    private Vector2 foodPosition;
    [SerializeField] private float spawnSpeedCheck;
    private int count = 0;
    [SerializeField] Transform foodPrefab;

    void Start() {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    void Update()
    {
        count++;
        if (count >= spawnSpeedCheck)
        {
            count = 0;
            foodPosition = new Vector2(Random.Range(width, -width), Random.Range(height, -height));
            Transform food = Instantiate(foodPrefab, foodPosition, Quaternion.identity);
        }
    }
}
