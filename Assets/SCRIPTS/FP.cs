
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FP : MonoBehaviour
{
    [SerializeField] private float vidas;
    [SerializeField] private TMP_Text textoVidas;

    //MOVIMIENTO
    //velocidad a la que te mueves
    [SerializeField] private float velocidadMov;
    CharacterController controlador;

    //SALTO
    //gravedad que quiera
    [SerializeField] private float gravedad;
    //cuanto me muevo en altura
    private Vector3 movimientoVertical;
    //altura a la que salto
    [SerializeField] private float alturaSalto;

    //SUELO
    //radio de deteccion del suelo
    [SerializeField] private float radioDetect;
    //posicion donde tengo los pies del personaje
    [SerializeField] private Transform pies;
    //capa que indica que es el suelo
    [SerializeField] private LayerMask queEsSuelo;

    //borde que recubre al ovni
    [SerializeField] private Outline outlineOvni;

    //para contar cada vez que cojo un objeto
    [SerializeField] private int puntos;

    //alt+enter, encapsular y seguir usando, y puedes sumar puntos desde otro script
    public int Puntos { get => puntos; set => puntos = value; }

    void Start()
    {
        //coger componente controller
        controlador = GetComponent<CharacterController>();
        //esconder el cursor del raton
        Cursor.lockState = CursorLockMode.Locked;
        //poner el texto de las vidas al maximo (100)
        textoVidas.text = vidas.ToString();
    }

    void Update()
    {
        //llamar metodos, si doy control+click en lo amarillo voy directo, se hace lo que ponga dentro del metodo (mas facil de acceder y ordenado)
        MovYRotar();
        AplicarGravedad();
        //si estoy tocando el suelo
        if (Suelo() == true)
        {
            //digo que mi altura en Y es 0. Si no se pone baja raro porque la gravedad se acumula
            movimientoVertical.y = 0;
            //llamo al metodo para poder saltar
            Salto();
        }
    }
    //esto es un metodo, lo que esta dentro del void movyrotar. se sabe porque esta en amarillo y tiene () al final
    void MovYRotar()
    {
        //cojo los datos cuando pulso las teclas de donde te mueves
        float movH = Input.GetAxisRaw("Horizontal");
        float movV = Input.GetAxisRaw("Vertical");
        //asi se hace que se mueva, cojo los datos que antes he recogido, los normalizo(convertir los vectores en 1)
        Vector2 inputs = new Vector2(movH, movV).normalized;
        //saco arcotangente del mov en x entre el mov en z, convertir radianes a grados y alinear angulo de la cam con el personaje
        float anguloRot = Mathf.Atan2(inputs.x, inputs.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        //para que el cuerpo gire a la vez que la camara
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        //si la magnitud del vector que hace que me mueva es mayor a 0, es decir si te mueves
        if (inputs.magnitude > 0)
        {
            //el movimiento queda rotado con el angulo de rotacion de la camara. Es decir, tu frontal es donde la camara apunta
            Vector3 movimiento = Quaternion.Euler(0, anguloRot, 0) * Vector3.forward;
            //el controller se mueve
            controlador.Move(movimiento * velocidadMov * Time.deltaTime);
        }
    }
    private void AplicarGravedad()
    {
        //la velocidad en y (vertical), aumenta segun la gravedad a una velocidad x segundo
        movimientoVertical.y += gravedad * Time.deltaTime;
        //movimiento vertical, por segundo otra vez porque la gravedad es al cuadrado. 
        controlador.Move(movimientoVertical * Time.deltaTime);
    }
    //en vez de void es bool porque va a dar la info si toco el suelo o no
    private bool Suelo()
    {
            //esfera para comprobar si toco el suelo,(donde estan los pues de mi personaje, el radio que la esfera detectara, para saber si lo q toca la esfera de deteccion es suelo)
        bool resultado = Physics.CheckSphere(pies.position, radioDetect, queEsSuelo);
        //devuelvo el resultado si toco el suelo o no
        return resultado;
    }
    //pijada para ver la esfera de deteccion en la escena
    private void OnDrawGizmos()
    {
        //color que ves la esfera
        Gizmos.color = Color.blue;
        //dibujar la esfera en la posicion de los pies del personaje, con el radio elegido
        Gizmos.DrawWireSphere(pies.position, radioDetect);
    }
    private void Salto()
    {
        //si le doy al espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //formula para saltar la altura que quiera, se traslada al movimiento en y (vertical, salto)
            movimientoVertical.y = math.sqrt(-2 * gravedad * alturaSalto);
        }
    }
    //PUBLIC, para acceder al metodo desde donde quiera, cualquier codigo.
    //tiene un metodo de entrada, que viene de otro script para poder hacer el metodo.
    //en este caso con el daño que recibiras del enemigo recibiras daño
    public void RecibirDaño(float dañoEnemigo)
    {
        //las vidas de tu personaje bajaran segun el daño que te hagan y el trexto se actualiza
        vidas -= dañoEnemigo;
        textoVidas.text = vidas.ToString();
        //si las vidas son menores o iguales a 0 (mueres)
        if (vidas <= 0)
        {
            //cambio de escena o lo que quiera para indicar que he muerto
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    //lo mismo que el anterior, en este caso necesito objetos que recojo para sumar puntos
    public void ReceivePoints(int numeroObjetos)
    {
        //los puntos suben segun los objetos que cojo
        puntos += numeroObjetos;
        //si los puntos son mayores que 5, de 6 para arriba
        if (puntos > 5) 
        {
            //el color del borde del ovni cambia a verde (si no se mantiene en rojo)
            outlineOvni.OutlineColor = Color.green;
        }
    }
}
