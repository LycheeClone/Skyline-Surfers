using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basda : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float movementSpeed;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        print(Time.time);
        ConstMovement();
    }

    private void ConstMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 z1 = new Vector3(x * (movementSpeed * Time.deltaTime), 0, z * (movementSpeed * Time.deltaTime));
        transform.Translate(z1, Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {
        throw new NotImplementedException();
    }


    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Height"))
    //     {
    //         // Küpü kendi altına almak için onu çocuk obje yap
    //         collision.transform.SetParent(transform);
    //
    //         // Küpün pozisyonunu düzeltmek için yerel pozisyonunu sıfırla
    //         collision.transform.localPosition = Vector3.zero;
    //
    //         // Küpün rotasyonunu düzeltmek için yerel rotasyonunu sıfırla
    //         collision.transform.localRotation = Quaternion.identity;
    //
    //         // Küpün ölçeğini düzeltmek için yerel ölçeğini sıfırla
    //         collision.transform.localScale = Vector3.one;
    //
    //         // Oyuncu, küpe dokunduğunda kendini bir blok yükselt
    //         Vector3 newPosition = transform.position;
    //         newPosition.y += 1f;
    //         transform.position = newPosition;
    //     }
    // }



    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Height")) // Eğer çarpışma küp ile gerçekleşirse
    //     {
    //         Rigidbody playerRigidbody = GetComponent<Rigidbody>(); // Oyuncunun Rigidbody bileşenini al
    //         Rigidbody cubeRigidbody = collision.gameObject.GetComponent<Rigidbody>(); // Küpün Rigidbody bileşenini al
    //
    //         if (cubeRigidbody != null &&
    //             playerRigidbody != null) // Eğer hem oyuncunun hem de küpün Rigidbody bileşenleri varsa
    //         {
    //             playerRigidbody.isKinematic = true; // Oyuncunun fizik etkileşimlerini kapat
    //             playerRigidbody.transform.SetParent(collision.gameObject.transform,
    //                 true); // Oyuncuyu küpün altına yerleştir ve hiyerarşide bağlı kalmasını sağla
    //         }
    //     }
    // }
}