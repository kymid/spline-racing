    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Dreamteck.Splines;
    

    public class Draw : MonoBehaviour
    {
        [SerializeField] Vector3 offset,scale;
        SplineComputer computer;
        [SerializeField] int spawnDelay, countFrame, pointsCount;
        Camera cam;
        [SerializeField]
        Vector3 pos;
        [SerializeField]
        GameObject linePrefab, line;
        [SerializeField] PLayerMovement movement;   
        bool cancreate;
        void Start()
        {
            cam = Camera.main;
            countFrame = spawnDelay;
            cancreate = true;
        }

        // Update is called once per frame
        void Update()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit)) return;

            if (hit.collider.CompareTag("Panel") & cancreate)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CreateRay(hit);
                    CreateDot(hit);
                    CreateDot(hit);
                    CreateDot(hit);
            }
            
                else if (Input.GetMouseButton(0))
                    UpdateRay(hit);
            }       
                if (Input.GetMouseButtonUp(0))
                {
                    if (GameStatement.Instance.currentState != GameStatement.State.Finish)
                        StartCoroutine(PLayerStanding());
                    else if (line != null)
                    Destroy(line);
                }

        }
        void CreateRay(RaycastHit hit)
        {
            line = Instantiate(linePrefab, UpdateRay(hit), Quaternion.identity);
            line.transform.parent = transform;
            computer = line.GetComponent<SplineComputer>();
        }
        Vector3 UpdateRay(RaycastHit hit)
        {
                if (line != null)
                {
                    line.transform.position = hit.point;
                    if (countFrame % spawnDelay == 0)
                    {
                        CreateDot(hit);
                    }
                }
                countFrame++;
                return hit.point;
        }

        void CreateDot(RaycastHit hit)
        {
            Vector3 finalPos = Vector3.Scale(hit.point, scale);
            
            computer.SetPointPosition(pointsCount, new Vector3(finalPos.x + offset.x,
                                      offset.y, finalPos.y + offset.z), SplineComputer.Space.World);
            pointsCount++;
        }
        
        IEnumerator PLayerStanding()
        {
            if(GameStatement.Instance.currentState == GameStatement.State.PrePlay)
            {
                GameStatement.Instance.FromPrePlayToPlay();
                foreach (GameObject p in movement.players)
                {
                    p.GetComponent<Animator>().SetBool("isRun", true);
                }
            }
 
            cancreate = false;
            movement.SetPosition(computer);
            yield return new WaitForSeconds(.1f);
            cancreate = true;
            Destroy(line);
            countFrame = spawnDelay;
            pointsCount = 0;
    }
    }