using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class workerBee : MonoBehaviour
{
    public Sprite[] Sprites;
    public float WiggleDistance;
    
    public float timeToReachFlower = 2.0f;
    public float timeToReachHoneyCell = 2.0f;
    public ParticleSystem honeyTrail;
    private IEnumerator animationCoroutine;
    private GameObject[] flowers;

    private beeTrafficController hiveMind;
    private honeyCell targetCell;

    // Start is called before the first frame update
    private void Start()
    {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        hiveMind = GameObject.FindGameObjectWithTag("HiveMind").GetComponent<beeTrafficController>();
        goToFlower();
        StartCoroutine(AnimateFlight());
    }

    public void goToFlower()
    {
        var flowerPosition = flowers[Random.Range(0, flowers.Length)].transform.position;
        animationCoroutine = AnimateVector3(timeToReachFlower, transform.position, flowerPosition, pollenate);
        StartCoroutine(animationCoroutine);
    }

    private void pollenate()
    {
        hiveMind.pollinatedBees.Enqueue(this);
        honeyTrail.Play();
    }

    public void targetEmptyCell(honeyCell cell)
    {
        targetCell = cell;
        animationCoroutine = AnimateVector3(timeToReachHoneyCell, transform.position,
            targetCell.GetComponent<Transform>().position, depositHoney);
        StartCoroutine(animationCoroutine);
    }

    private void depositHoney()
    {
        targetCell.fill();
        honeyTrail.Stop();
        goToFlower();
    }

    private void setPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private IEnumerator AnimateVector3(float seconds, Vector3 start, Vector3 end, Action callback)
    {
        var forward = Vector3.Normalize(end - start);
        var right = Quaternion.AngleAxis(90, Vector3.forward) * forward;
        var remainingSeconds = seconds;
        var t = 0f;
        lookAt(end.x, end.y);
        while (t < 1)
        {
            yield return new WaitForEndOfFrame();
            setPosition(Vector3.Lerp(start, end, t) + Wiggle());
            remainingSeconds -= Time.deltaTime;
            t = 1 - remainingSeconds / seconds;
        }

        setPosition(end);
        callback.Invoke();

        Vector3 Wiggle() => math.sin(t * math.PI * 4) * right * WiggleDistance;
    }
    
    private IEnumerator AnimateFlight()
    {
        var renderer = GetComponentInChildren<SpriteRenderer>();
        while (true)
        {
            foreach (var sprite in Sprites)
            {
                yield return new WaitForSeconds(0.02f);
                renderer.sprite = sprite;
            }
        }
    }

    private void lookAt(float x, float y)
    {
        x = x - transform.position.x;
        y = y - transform.position.y;
        var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}