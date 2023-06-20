using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>

public class Player : MonoBehaviour {
  public float speed; // �ƶ��ٶ�

  public float turnSpeed; // ת���ٶ�

  public GameObject camera; // ��ͷ

  public bool movable = true;

  public GameObject bag;
  public GameObject pause_canvas;

  private bool isOpen;

  private void Start() {
    Transform iniPos = transform.Find("iniPos");

    transform.position = iniPos.position;

    transform.rotation = iniPos.rotation;

    camera.transform.localPosition = new Vector3(0, 0, 0);
    camera.transform.rotation = iniPos.rotation;

    isOpen = false;
  }

  private void Update() {
    move();
    touch();
    OpenBag();
    Pause();
  }

  private void OpenBag() {
    if (Input.GetKeyDown(KeyCode.Tab)) {
      isOpen = !isOpen;
      bag.SetActive(isOpen);
      if (isOpen)
        movable = false;
      else
        movable = true;
    }
  }

  private void move() {
    if (!movable)
      return;

    float key_x = Input.GetAxis("Horizontal");
    float key_z = Input.GetAxis("Vertical");
    float mouse_x = -Input.GetAxis("Mouse Y");
    float mouse_z = Input.GetAxis("Mouse X");

    Vector3 input = new Vector3(key_x, 0.0f, key_z);		// ����������������m

    input.Normalize();  // �ѿ�������������һ����ֻҪ���������Ͳ���б���ٶ�ƫ����

    Vector3 u = input * speed * Time.deltaTime; // ����ÿ֡�ƶ���������С

    transform.Translate(u);

    transform.Rotate(0, mouse_z * turnSpeed, 0);

    camera.transform.Rotate(mouse_x * turnSpeed, 0, 0);
  }

  private void touch() {
    RaycastHit hitInfo;
    if (Input.GetKeyDown(KeyCode.E)) {
      if (Physics.Raycast(transform.position, camera.transform.forward, out hitInfo, 10.0f)) {
        GameObject gameObject = hitInfo.collider.gameObject;
        if (gameObject.name.Equals("ChineseChess")) {
          movable = false;
          ChessBoard chessBoard = gameObject.GetComponent<ChessBoard>();
          chessBoard.OpenBoardCanvas();
          return;
        }
        if (gameObject.name.Equals("Slot1")) {
          Slot slot = gameObject.GetComponent<Slot>();
          slot.Increment();
          return;
        }
        if (gameObject.name.Equals("Slot2")) {
          Slot slot = gameObject.GetComponent<Slot>();
          slot.Increment();
          return;
        }
        if (gameObject.name.Equals("Slot3")) {
          Slot slot = gameObject.GetComponent<Slot>();
          slot.Increment();
          return;
        }
        if (gameObject.name.Equals("Slot4")) {
          Slot slot = gameObject.GetComponent<Slot>();
          slot.Increment();
          return;
        }
        if (gameObject.name.Equals("Slot5")) {
          Slot slot = gameObject.GetComponent<Slot>();
          slot.Increment();
          return;
        }
        if (gameObject.name.Equals("Slot6")) {
          Slot slot = gameObject.GetComponent<Slot>();
          slot.Increment();
          return;
        }
        if (gameObject.name.Equals("PuzzleBox")) {
          PuzzleBox puzzleBox = gameObject.GetComponent<PuzzleBox>();
          puzzleBox.OpenPuzzleCanvas();
          movable = false;
          return;
        }
        if (gameObject.name.Contains("puzzle")) {
          ItemScript itemScript = gameObject.GetComponent<ItemScript>();
          itemScript.Picked();
          return;
        }
        if (gameObject.name.Equals("rock")) {
          Rock rock = gameObject.GetComponent<Rock>();
          rock.OpenCanvas();
          return;
        }

      }
    }
  }

  private void Pause()
  {
    if (Input.GetKeyDown(KeyCode.P)){
      pause_canvas.gameObject.SetActive(true);
    }
    
  }
}
