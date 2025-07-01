using UnityEngine;


public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 10f;
    public GameObject Astronaut;
    public bool isInCar;

    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(0, 0, v) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0) * rotSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F) && isInCar)
            ExitCar();


        Debug.Log(isInCar);

        isInCar = true;
    }

    public void ExitCar()
    {

        Instantiate(Astronaut, new Vector3(transform.position.x + 5, transform.position.y, transform.position.z), Quaternion.identity);
        GetComponent<CarController>().enabled = false;


    }
    void OnDisable()
    {
        isInCar = false;
    }
}