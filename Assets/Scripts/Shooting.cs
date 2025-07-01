using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    public int attackDamage = 10;


    void Update()
    {
        Shoot();
    }

    private void Shoot()
{
    if (Input.GetMouseButtonDown(0))
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
    }
}

}
