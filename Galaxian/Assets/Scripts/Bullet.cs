using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            transform.position += new Vector3(0, bulletSpeed * Time.deltaTime, 0);
        if (transform.position.y > 15f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor" || collision.gameObject.tag == "Enemy")
        {
            int score;
            if (collision.gameObject.tag == "Meteor")
            {
                score = PlayerPrefs.GetInt("score");
                score += 5;
                PlayerPrefs.SetInt("score", score);
                
            }
            if (collision.gameObject.tag == "Enemy")
            {
                score = PlayerPrefs.GetInt("score");
                if (collision.gameObject.GetComponent<Ebemy>().isAlpha == false)
                {
                    score += 10;
                    PlayerPrefs.SetInt("score", score);
                }
                else
                {
                    score += 20;
                    PlayerPrefs.SetInt("score", score);
                }
                score += 5;
                PlayerPrefs.SetInt("score", score);
                collision.gameObject.GetComponent<Ebemy>().Death();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    /*    private void OnCollisionEnter2D(Collider2D collision)
        {

        }*/
}
