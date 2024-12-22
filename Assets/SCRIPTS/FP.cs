
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FP : MonoBehaviour
{
    [SerializeField] private float vidas;

    [SerializeField] private float velocidadMov;
    CharacterController controlador;
    [SerializeField] private float gravedad;
    private Vector3 movimientoVertical;
    [SerializeField] private float alturaSalto;

    [SerializeField] private float radioDetect;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private Outline outlineOvni;

    [SerializeField] private int puntos;

    public int Puntos { get => puntos; set => puntos = value; }

    void Start()
    {
        controlador = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovYRotar();
        AplicarGravedad();
        if (Suelo() == true)
        {
            movimientoVertical.y = 0;
            Salto();
        }
    }
    void MovYRotar()
    {
        float movH = Input.GetAxisRaw("Horizontal");
        float movV = Input.GetAxisRaw("Vertical");

        Vector2 inputs = new Vector2(movH, movV).normalized;

        float anguloRot = Mathf.Atan2(inputs.x, inputs.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        if (inputs.magnitude > 0)
        {
            Vector3 movimiento = Quaternion.Euler(0, anguloRot, 0) * Vector3.forward;

            controlador.Move(movimiento * velocidadMov * Time.deltaTime);
        }
    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += gravedad * Time.deltaTime;
        controlador.Move(movimientoVertical * Time.deltaTime);
    }
    private bool Suelo()
    {
        bool resultado = Physics.CheckSphere(pies.position, radioDetect, queEsSuelo);
        return resultado;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pies.position, radioDetect);
    }
    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = math.sqrt(-2 * gravedad * alturaSalto);
        }
    }
    public void RecibirDaño(float dañoEnemigo)
    {
        vidas -= dañoEnemigo;

        if (vidas <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void ReceivePoints(int numeroObjetos)
    {
        puntos += numeroObjetos;

        if(puntos > 5)
        {
            outlineOvni.OutlineColor = Color.green;
        }
    }
}
