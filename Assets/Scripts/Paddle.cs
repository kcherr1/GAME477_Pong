using UnityEngine;

public class Paddle : MonoBehaviour {
  [SerializeField]
  private float speed = 0.01f;

  private InputActionsPaddles inputActions;

  void Start() {
    if (transform.CompareTag("PaddleRight")) {

    }
    else {
      GetComponent<SpriteRenderer>().color = new Color(1, 0, 1);
    }
    inputActions = new InputActionsPaddles();
    inputActions.Enable();
  }

  void Update() {
    if (!Game.isPlaying) {
      return;
    }
    if (transform.CompareTag("PaddleRight")) {
      GetComponent<SpriteRenderer>().color = new Color(0, 0, Mathf.Abs(Mathf.Sin(Time.time)));
      float move = inputActions.Default.RightPaddleMove.ReadValue<float>();
      transform.Translate((Vector3.up * move) * speed * Time.deltaTime);
    }
    else if (transform.CompareTag("PaddleLeft")) {
      GetComponent<SpriteRenderer>().color = new Color(Mathf.Abs(Mathf.Sin(Time.time)), 0, Mathf.Abs(Mathf.Sin(Time.time)));
      float move = inputActions.Default.LeftPaddleMove.ReadValue<float>();
      transform.Translate((Vector3.up * move) * speed * Time.deltaTime);
    }
  }
}
