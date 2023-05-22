using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basda : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float movementSpeed;

    public Transform playerTransform;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
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
    private List<Transform> collectedObjects = new List<Transform>(); // Toplanan nesnelerin listesi
    private bool isColliding = false; // Çarpışma durumunu izlemek için bir bayrak

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pickable") && !isColliding)
        {
            Transform pickableObject = other.gameObject.transform;

            // Nesneyi toplamış mı kontrol et
            if (!collectedObjects.Contains(pickableObject))
            {
                Vector3 newPosition = playerTransform.position + Vector3.up; // Y ekseninde 1 birim yukarı hareket
                playerTransform.position = newPosition;

                collectedObjects.Add(pickableObject);
                pickableObject.SetParent(playerTransform);

                Vector3 decreasePosition = newPosition - Vector3.up * collectedObjects.Count; // Her bir toplanan nesne için Y ekseninde 1 birim aşağıya hareket
                pickableObject.position = decreasePosition;

                StartCoroutine(DisableCollisionCoroutine());
            }
        }
    }

    private IEnumerator DisableCollisionCoroutine()
    {
        isColliding = true;
        yield return new WaitForSeconds(0.1f); // Çarpışma devre dışı bırakma süresi
        isColliding = false;
    }


    
    
    
    // public Vector3 decrease = new Vector3(0, -1, 0);
    // private void OnCollisionEnter(Collision other)
    // {
    //     Vector3 newPosition = playerTransform.position;
    //     if (other.gameObject.CompareTag("Pickable"))
    //     {
    //         newPosition.y += 1f;
    //         playerTransform.position = newPosition;
    //         other.gameObject.transform.SetParent(playerTransform);
    //         Vector3 decreasePosition = newPosition + decrease;
    //         other.gameObject.transform.position = decreasePosition;
    //
    //         decrease.y--;
    //         decreasePosition.y += decrease.y;
    //         
    //         // other.gameObject.transform.position = newPosition+decrease;
    //         // decrease.y--;
    //         // newPosition.y += decrease.y;
    //     }
    // }

    // var transformPosition = gameObject.transform.position;
    // newPosition.y -= 1f; // Hatanın olduğu satırı bu şekilde güncelleyin
    //
    // other.gameObject.transform.localPosition = newPosition;


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