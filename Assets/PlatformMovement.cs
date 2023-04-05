using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformMovement : MonoBehaviour
{
    public Text score;
    public Text endText;
    int scoreAmt = 0;
    float constant = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.z < 15)
        {
            transform.Translate(Vector3.forward * constant * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -2)
        {
            transform.Translate(Vector3.back * constant * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -75)
        {
            transform.Translate(Vector3.left * constant * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < -25)
        {
            transform.Translate(Vector3.right * constant * Time.deltaTime);
        }

        if(scoreAmt>=10)
        {
            endText.text = "You Won! Press Space to Exit";
            if(Input.GetKey(KeyCode.Space))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject != null)
        {
            Destroy(collision.collider.gameObject);
            scoreAmt++;
            score.text = "Score: "+scoreAmt.ToString();
        }

        GameObject particles = collision.collider.gameObject.transform.GetChild(0).gameObject;
        particles.transform.parent = null;

        ParticleSystem particleSys = particles.GetComponent<ParticleSystem>();
        particleSys.Stop();

        Destroy(collision.collider.gameObject);
        Destroy(particles, 5.5f);
    }

}
