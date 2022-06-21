using UnityEngine;

public class GlassLine : MonoBehaviour
{
    public int hitCount;
    public GameObject GameEndCanvas;
    Manager Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<Manager>();
        GameEndCanvas.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            collision.tag = "WaterInGlass";
            collision.GetComponent<Rigidbody2D>().gravityScale = .3f;
            collision.GetComponent<Rigidbody2D>().velocity =
                collision.GetComponent<Rigidbody2D>().velocity / 4;
            hitCount++;
            if (hitCount > 40)
            {
                //change the sprite to happy
                GetComponentInParent<Glass>().ChnageSpriteToHappy();
                if (Manager == null) return;

                Manager.gameCleared = true;


                if (hitCount > 50)
                {
                    //Star 3
                    Manager.StarCount = 3;
                    GameEndCanvas.SetActive(true);
                    // Manager.StartEndScreed();
                }
                else if (hitCount > 45)
                {
                    //Star 2
                    Manager.StarCount = 2;
                    GameEndCanvas.SetActive(true);
                    //Manager.StartEndScreed();
                }
                else
                {
                    Manager.StarCount = 1;
                    GameEndCanvas.SetActive(true);
                    //  Manager.StartEndScreed();
                }

            }
            else
            {
                //chnage the sprite to sad
                GetComponentInParent<Glass>().ChnageSpriteToSad();
                if (Manager == null) return;

                Manager.gameCleared = false;

            }
        }
    }
}
