using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAtoms : MonoBehaviour
{
    public GameObject hydrogen;
    public GameObject oxygen;
    GameObject atom;
    Rigidbody2D rb;

    [SerializeField, Range(0f, 1f)]
    public float slowness;

    public Slot slot;

    public void Emit(string Item, Vector3 pos, float x, float y)
    {
        switch(Item)
        {
            case "Hydrogen":
                if (slot.hydrogen_n == 0)
                    break;
                else
                {
                    PlayerPrefs.SetInt("Hydrogen", PlayerPrefs.GetInt("Hydrogen") - 1);
                    atom = (GameObject)Instantiate(hydrogen, pos, Quaternion.identity);
                }
                break;
            case "Oxygen":
                if (slot.oxygen_n == 0)
                    break;
                else
                {
                    PlayerPrefs.SetInt("Oxygen", PlayerPrefs.GetInt("Oxygen") - 1);
                    atom = (GameObject)Instantiate(oxygen, pos, Quaternion.identity);
                }
                break;
            // case 3:
            //     break;
            // case 4:
            //     break;
            // case 5:
            //     break;
            default:
                break;
        }
        
        rb = atom.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(x, y) * slowness);
    }
}
