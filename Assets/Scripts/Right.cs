using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    [SerializeField] GameObject[] styles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "End")
            if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Instantiate(styles[Random.Range(0, styles.Length)], other.transform.position, other.transform.rotation);
            }
        else
            {
            Instantiate(other.transform.parent.gameObject, other.transform.position, other.transform.rotation);
        }
    }
    }
