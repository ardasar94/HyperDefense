using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range (0f, 5f)] float speed;
    List<Waypoint> path;
    PlayerInfo playerInfo;
    void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        path = transform.parent.gameObject.GetComponent<Wave>().GetPath();
        transform.LookAt(path[1].transform.position);
        StartCoroutine(FallowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator FallowPath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = path[i].transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        playerInfo.DecreaseHealth();
        Destroy(gameObject);
        //gameObject.SetActive(false);
        
    }

    public void SetPath(List<Waypoint> WavePath)
    {
        path = WavePath;
    }
}
