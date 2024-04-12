using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Alteruna;

public class BallController : AttributesSync
{
    public float maxPower;
     public float changeAngleSpeed;
 public float lineLength;
     public Slider powerSlider;
 public TextMeshProUGUI puttCountLabel;
    public float minHoleTime;
     public Transform startPosition;
     public Transform startTransform;
  public LevelManager levelManager;

     private LineRenderer line;
    private Rigidbody ball;
     private float angle;
     private float powerUpTime;
     private float power;
    private int Putts;
    private float holeTime;
     private Vector3 lastPosition;
     public Alteruna.Avatar _avatar;

    void Awake()
    {
          _avatar = GetComponent<Alteruna.Avatar>();

          if (_avatar.IsMe)
         {
              enabled = false;
        }

        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
        startTransform.GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
          if (_avatar.IsMe)
          {
              enabled = false;
          }

        if (ball.velocity.magnitude < 0.09f)
        {
            if (Input.GetKey(KeyCode.A))
            {
                ChangeAngle(-1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                ChangeAngle(1);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Putt();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                PowerUp();
            }
            UpdateLinePositions();
        }
        else
        {
            line.enabled = false;
        }
    }

    private void ChangeAngle(int direction)
    {
        angle += changeAngleSpeed * Time.deltaTime * direction;
    }

    private void UpdateLinePositions()
    {
        if (holeTime == 0)
        {
            line.enabled = true;
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * lineLength);
    }

    private void Putt()
    {
        lastPosition = transform.position;
        ball.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * maxPower * power, ForceMode.Impulse);
        power = 0;
        powerSlider.value = 0;
        powerUpTime = 0;
        Putts++;
        puttCountLabel.text = Putts.ToString();
    }

    private void PowerUp()
    {
        powerUpTime += Time.deltaTime;
        power = Mathf.PingPong(powerUpTime, 1);
        powerSlider.value = power;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hole")
        {
            CountHoleTime();
        }
    }

    private void CountHoleTime()
    {
        holeTime = Time.deltaTime;
        if (holeTime >= minHoleTime)
        {
            levelManager.NextPlayer(Putts);
            holeTime = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hole")
        {
            LeftHole();
        }
    }

    private void LeftHole()
    {
        holeTime = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Out Of Bounds")
        {
            transform.position = lastPosition;
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;
        }
    }

    public void SetUpBall(Color color)
    {
        transform.position = startTransform.position;
        angle = startTransform.rotation.eulerAngles.y;
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;
        GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        line.material.SetColor("_Color", color);
        line.enabled = true;
        Putts = 0;
        puttCountLabel.text = "0";
    }
}





