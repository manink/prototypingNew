using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour
{
    public Camera mapCamera = null;
    public GameObject legendCanvas = null;

    public GameObject treeStickerPrefab = null;
    public GameObject mountainStickerPrefab = null;

    public bool bigMap = true;

    public string selectedSticker = string.Empty;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (bigMap == true)
            {
                bigMap = false;
                mapCamera.rect = new Rect(0.0f, 0.0f, 0.2f, 0.2f);
                legendCanvas.SetActive(false);
            }
            else
            {
                bigMap = true;
                mapCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                legendCanvas.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject instantiatedObject = null;

                if (selectedSticker == "Tree")
                {
                    instantiatedObject = (GameObject)Instantiate(treeStickerPrefab);
                }
                else if (selectedSticker == "Mountain")
                {
                    instantiatedObject = (GameObject)Instantiate(mountainStickerPrefab);
                }
                instantiatedObject.transform.position = hit.point + Vector3.up * 0.1f;
            }
        }
    }

    public void OnTreeStickerSelected()
    {
        selectedSticker = "Tree";
    }

    public void OnMountainStickerSelected()
    {
        selectedSticker = "Mountain";
    }
}