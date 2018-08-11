using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLooping = false;
    private List<SpriteRenderer> backgroundPart;

    public GameObject player;
    private Rigidbody2D rbPlayer;

    public float parallllllllllalalllalexDistanceFromPlayer = 1;

    void Start()
    {
        if (isLooping)
        {
            backgroundPart = new List<SpriteRenderer>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer r = child.GetComponent<SpriteRenderer>();

                if (r != null)
                    backgroundPart.Add(r);
            }

            backgroundPart = backgroundPart.OrderBy(
              t => t.transform.position.x
            ).ToList();
        }

        rbPlayer = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
      -rbPlayer.velocity.x,
      speed.y * direction.y,
      0);

        //Vector3 movement = new Vector3(
        //  speed.x * direction.x,
        //  speed.y * direction.y,
        //  0);

        movement *= Time.fixedDeltaTime / parallllllllllalalllalexDistanceFromPlayer;
        transform.Translate(movement);

        if (isLooping)
        {
            SpriteRenderer firstChild = backgroundPart.FirstOrDefault();
            SpriteRenderer lastChild = backgroundPart.LastOrDefault();

            if (rbPlayer.velocity.x >= 0)
            {
                if (firstChild != null)
                {
                    if (firstChild.transform.position.x + firstChild.sprite.rect.width < Camera.main.transform.position.x)
                    {
                        if (firstChild.isVisible == false)
                        {
                            Vector3 lastPosition = lastChild.transform.position;
                            //Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);
                            firstChild.transform.position = new Vector3(lastPosition.x + lastChild.sprite.rect.width, firstChild.transform.position.y, firstChild.transform.position.z);
                        var bounds = firstChild.gameObject.GetComponent<UnityEngine.SpriteRenderer>().bounds;
                            backgroundPart.Remove(firstChild);
                            backgroundPart.Add(firstChild);
                        
                        }
                    }
                }
            }
            else
            {
                if (lastChild != null)
                {
                    //if (lastChild.transform.position.x > Camera.main.transform.position.x +
                    //    (backgroundPart.Sum(b => (b.bounds.max - b.bounds.min).x) / backgroundPart.Count) * (backgroundPart.Count - 2))
                    //if (firstChild.transform.position.x > (Camera.main.transform.position.x - ((firstChild.bounds.max - firstChild.bounds.min).x / 2)))
                    if (firstChild.transform.position.x > Camera.main.transform.position.x)
                    {
                        if (lastChild.isVisible == false)
                        {
                            Vector3 firstPosition = firstChild.transform.position;
                            Vector3 firstSize = (firstChild.bounds.max - firstChild.bounds.min);
                            lastChild.transform.position = new Vector3(firstPosition.x - firstChild.sprite.rect.width, lastChild.transform.position.y, lastChild.transform.position.z);
                            backgroundPart.Remove(lastChild);
                            backgroundPart.Insert(0, lastChild);
                        }
                    }
                }
            }
        }
    }
}