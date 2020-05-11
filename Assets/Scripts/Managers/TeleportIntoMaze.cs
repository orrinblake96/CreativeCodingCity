using System;
using UnityEngine;

namespace Managers
{
    public class TeleportIntoMaze : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<AudioManager>().Play("Teleport");
                other.gameObject.transform.position = GameObject.Find("InsideMazeTeleporter(Clone)").GetComponent<Transform>().position;
                gameObject.SetActive(false);
            }
        }
    }
}
