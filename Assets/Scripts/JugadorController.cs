using UnityEngine;

public class JugadorController : MonoBehaviour
{
    public float velocidad = 5;
    public float inputHorizontal;
    public float inputVertical;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


        transform.Translate(Vector3.right * inputHorizontal * Time.deltaTime * velocidad);
        transform.Translate(Vector3.up * inputVertical * Time.deltaTime * velocidad);


    }
}
