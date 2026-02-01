using UnityEngine;

public class MovimientoP : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [Header("Movimiento")]

    private float movientoHorizontal = 0f;
    [SerializeField] private float velocidadMovimiento;
    [Range(0, 0.3f)][SerializeField] private float suavizadoMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = false;
    [SerializeField] private Transform SpritePersonaje;
    

    private shooting angulo;
    [Header("Salto")]
    [SerializeField] private float FuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool estaEnSuelo;
    private bool salto = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        angulo = FindAnyObjectByType<shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        movientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }
    void FixedUpdate()
    {
        estaEnSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        mover(angulo.getGrados(),movientoHorizontal * Time.fixedDeltaTime, salto);
        salto = false;
    }
    private void mover(float angulo,float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2d.linearVelocity.y);
        rb2d.linearVelocity = Vector3.SmoothDamp(rb2d.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);
        if (angulo>270 && angulo<360 && !mirandoDerecha || angulo>1 && angulo <90 && !mirandoDerecha)
        {
            girar();
        }
        else if (angulo>90 && angulo<=270 && mirandoDerecha)
        {
            girar();
        }
        if (estaEnSuelo && saltar)
        {
            estaEnSuelo = false;
            rb2d.AddForce(new Vector2(0f, FuerzaSalto));
        }
    }
    public void girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = SpritePersonaje.transform.localScale;
        escala.x *= -1;
        SpritePersonaje.transform.localScale = escala;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
