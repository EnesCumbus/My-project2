using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraSwitch : MonoBehaviour
{
    // Tüm kameralarý saklayacaðýmýz bir liste oluþturuyoruz
    private List<Camera> cameras = new List<Camera>();

    void Start()
    {
        // Sahnedeki tüm kameralarý bul ve isimlerine göre sýralayarak listeye ekle
        cameras = FindObjectsOfType<Camera>().OrderBy(cam => cam.name).ToList();

        // Ýlk kamerayý etkinleþtir, diðerlerini devre dýþý býrak
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(i == 0);
        }
    }

    void Update()
    {
        // 1 ile 9 arasýndaki tuþlara basýldýðýný kontrol ediyoruz
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
            // Tüm kameralarý devre dýþý býrakýyoruz
            foreach (var cam in cameras)
            {
                cam.gameObject.SetActive(false);
            }
            // Ýlgili kamerayý aktif hale getiriyoruz
            cameras[index].gameObject.SetActive(true);
        }
    }
}