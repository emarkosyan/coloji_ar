using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetection : MonoBehaviour {
	
	const int diceSize = 3;
	const int cubeSize = 6;
	public Color color;
    public List<GameObject> emo1;
    public List<GameObject> emo2;
    public List<GameObject> emo3;

    public List <GameObject> emojis;
	public GameObject[] cube=new GameObject[diceSize];
	public Mesh mf;
	public List<GameObject>[] cubeFaces=new List<GameObject>[diceSize];
	public GameObject[] childTargets=new GameObject[diceSize];
	public int[] index=new int[diceSize];


	public int emot;
    // Use this for initialization
    void Start () {
		for (int j = 0;j< diceSize; j++)
		{
			childTargets[j] = cube[j].transform.Find("ChildTargets").gameObject;
			int childCount = childTargets[j].transform.childCount;
			cubeFaces[j] = new List<GameObject>();
			for (int i = 0; i < childCount; i++) 
			{
				cubeFaces[j].Add(childTargets[j].transform.GetChild(i).gameObject);
			}

		}

	}

	// Update is called once per frame
	void Update () {

		float[] min = new float[cube.Length];
		for (int j = 0; j < cube.Length; j++)
		{
			min[j] = Vector3.Distance(cubeFaces[j][0].transform.position, transform.position);
			index[j] = 0;
			for (int i = 1; i < cubeSize; i++)
			{
				if (min[j] > Vector3.Distance(cubeFaces[j][i].transform.position, transform.position))
				{
					index[j] = i;
					min[j] = Vector3.Distance(cubeFaces[j][i].transform.position, transform.position);
				}

			}

		}

		emot = (index [0] + index [1] + index [2])/3;

        color = new Color((float)index[0]/6, (float)index[1] / 6,(float)index[2] / 6);

        foreach (GameObject obj in emo1) {
			obj.SetActive (false);
		}	
		emo1 [index [0]].SetActive (true);
		mf = emojis [emot].GetComponent<MeshFilter> ().sharedMesh;
		emo1 [index [0]].GetComponent<MeshFilter> ().sharedMesh = mf;

        foreach (GameObject obj in emo2)
        {
            obj.SetActive(false);
        }
        emo2[index[1]].SetActive(true);
        mf = emojis[emot].GetComponent<MeshFilter>().sharedMesh;
        emo2[index[1]].GetComponent<MeshFilter>().sharedMesh = mf;

        foreach (GameObject obj in emo3)
        {
            obj.SetActive(false);
        }
        emo3[index[2]].SetActive(true);
        mf = emojis[emot].GetComponent<MeshFilter>().sharedMesh;
        emo3[index[2]].GetComponent<MeshFilter>().sharedMesh = mf;

        Renderer rend = emojis[emot].GetComponent<Renderer>();
        Material mat = rend.sharedMaterial;
        mat.color = Color.yellow;

        //rend.sharedMaterials[0].shader = Shader.Find("_MainTex");
        //rend.sharedMaterials[0].SetColor("_MainTex", Color.yellow);

        //rend.sharedMaterials[0].color = color;



//        switch (emot)
//        {
//            case 0:
//                emojis[emot].SetActive(true);
//                break;
//            case 1:
//                emojis[emot].SetActive(true);
//                break;
//            case 2:
//                emojis[emot].SetActive(true);
//                break;
//            case 3:
//                emojis[emot].SetActive(true);
//                break;
//            case 4:
//                emojis[emot].SetActive(true);
//                break;
//            case 5:
//                emojis[emot].SetActive(true);
//                break;
//            default:
//                break;
//        }
    }
}