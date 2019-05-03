using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeController : MonoBehaviour {

    [SerializeField] private Transform tailPrefab;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private List<Transform> tails;
    private bool ate = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Move", 0.3f, 0.1f);
        tails = new List<Transform>();
	}

	void Update ()
    {
       
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        ate = true;
        Destroy(other.gameObject);
    }

    private void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction = direction.normalized;
        Vector2 headPosition = transform.position;
        rb.velocity = direction * moveSpeed;
        if(ate)
        {
            Transform tail = Instantiate(tailPrefab, headPosition, Quaternion.identity);
            tails.Insert(0, tail);
            ate = false;
        }
        else if(tails.Count>0)
        {
            tails.Last().position = headPosition;
            tails.Insert(0, tails.Last());
            tails.RemoveAt(tails.Count - 1);
        }
    }
}
