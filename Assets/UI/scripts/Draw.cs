    using System.Collections;
    using UnityEngine;
    using Dreamteck.Splines;
    
    public class Draw : MonoBehaviour
    {
        [SerializeField] Vector3 offset,scale;
        [SerializeField] int spawnDelay, countFrame, pointsCount;
        
        [SerializeField] GameObject linePrefab, line;
        [SerializeField] PlayerMovement movement;

        Camera cam;
        SplineComputer computer;
        bool canCreate;
        void Start()
        {
            cam = Camera.main;
            countFrame = spawnDelay;
            canCreate = true;
        }

        void Update()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit)) return;

            if (hit.collider.CompareTag("Panel") & canCreate)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CreateRay(hit);
                    CreateDot(hit);
                    CreateDot(hit);
            }
            
                else if (Input.GetMouseButton(0))
                    UpdateRay(hit);
            }       
                if (Input.GetMouseButtonUp(0))
                {
                    if (GameStatement.Instance.currentState != GameStatement.State.Finish)
                        StartCoroutine(StartRunning());
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
        
        IEnumerator StartRunning()
        {
            if(GameStatement.Instance.currentState == GameStatement.State.PrePlay)
            {
                GameStatement.Instance.FromPrePlayToPlay();
                foreach (GameObject p in movement.players)
                {
                    p.GetComponent<Animator>().SetBool("isRun", true);
                }
            }
 
            canCreate = false;
            movement.SetPosition(computer);

            yield return new WaitForSeconds(.1f);

            canCreate = true;
            Destroy(line);
            countFrame = spawnDelay;
            pointsCount = 0;
    }
    }