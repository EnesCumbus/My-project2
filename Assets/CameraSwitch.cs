using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraSwitch : MonoBehaviour
{
    // T�m kameralar� saklayaca��m�z bir liste olu�turuyoruz
    private List<Camera> cameras = new List<Camera>();

    void Start()
    {
        // Sahnedeki t�m kameralar� bul ve isimlerine g�re s�ralayarak listeye ekle
        cameras = FindObjectsOfType<Camera>().OrderBy(cam => cam.name).ToList();

        // �lk kameray� etkinle�tir, di�erlerini devre d��� b�rak
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(i == 0);
        }
    }

    void Update()
    {
        // 1 ile 9 aras�ndaki tu�lara bas�ld���n� kontrol ediyoruz
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                SwitchCamera(i - 1);
            }
        }
    }

    void SwitchCamera(int index)
    {
        if (index >= 0 && index < cameras.Count)
        {
            // T�m kameralar� devre d��� b�rak�yoruz
            foreach (var cam in cameras)
            {
                cam.gameObject.SetActive(false);
            }
            // �lgili kameray� aktif hale getiriyoruz
            cameras[index].gameObject.SetActive(true);
        }
    }
}