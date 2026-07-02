using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float growthSpeed = 0.8f;
    Vector3 startScale, startPosition;
    // Odniesienie do skryptu PlayerRespawn
 
    bool isRising = false;
    void Start()
    {
        startScale = transform.localScale;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRising)
        {
            // Aktualizacja skali
            transform.localScale += new Vector3(0f, growthSpeed * Time.deltaTime, 0f);
            // Przesuwanie obiektu o pó³ wartoœci zmiany wysokoœci tak,
            // aby dó³ pozosta³ w jednej pozycji
            transform.position += new Vector3(0f, growthSpeed * Time.deltaTime / 2f, 0f);
        }
    }
    public void StartLava()
    {
        isRising = true;
    }

    public void StopLava()
    {
        isRising = false;
        transform.localScale = startScale;
        transform.position = startPosition;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var respawn = collision.gameObject.GetComponent<PlayerRespawn>();
            respawn.Respawn();
            StopLava();
        }
    }
}
