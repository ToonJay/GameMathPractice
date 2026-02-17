using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateBoard : MonoBehaviour {
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public GameObject treePrefab;
    public Text score;
    GameObject[] tiles;
    long dirtBB = 0;
    long treeBB = 0;
    long desertBB = 0;
    long playerBB = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        tiles = new GameObject[64];
        for (int r = 0; r < 8; r++) {
            for (int c = 0; c < 8; c++) {
                int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                Vector3 pos = new Vector3(c, 0, r);
                GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                tile.name = tile.tag + "_" + r + "_" + c;
                tiles[r * 8 + c] = tile;
                if (tile.tag == "Dirt") {
                    dirtBB = SetCellState(dirtBB, r, c);
                } else if (tile.tag == "Desert") {
                    desertBB = SetCellState(desertBB, r, c);
                }
            }
        }
        Debug.Log("Dirt cells = " + CellCount(dirtBB));
        InvokeRepeating("PlantTree", 1, 0.2f);
    }

    void PlantTree() {
        int rr = UnityEngine.Random.Range(0, 8);
        int rc = UnityEngine.Random.Range(0, 8);
        if (GetCellState(dirtBB & ~playerBB & ~treeBB, rr, rc)) {
            Debug.Log("Planted tree: " + rr + "," + rc);
            GameObject tree = Instantiate(treePrefab);
            tree.transform.parent = tiles[rr * 8 + rc].transform;
            tree.transform.localPosition = Vector3.zero;
            treeBB = SetCellState(treeBB, rr, rc);
        }
    }

    void PrintBB(string name, long BB) {
        Debug.Log(name + ": " + Convert.ToString(BB, 2).PadLeft(64, '0'));
    }

    long SetCellState(long bitboard, int row, int col) {
        long newBit = 1L << (row * 8 + col); // row * width + col
        return bitboard |= newBit;
    }

    bool GetCellState(long bitboard, int row, int col) {
        long mask = 1L << (row * 8 + col);
        return ((bitboard & mask) != 0);
    }

    int CellCount(long bitboard) {
        int count = 0;
        long bb = bitboard;
        while (bb != 0) {
            bb &= bb - 1;
            count++;
        }
        return count;
    }

    void CalculateScore() {
        score.text = "Score: " + (CellCount(playerBB & dirtBB) * 10 + CellCount(playerBB & desertBB) * 2);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                int hitRow = (int)hit.collider.gameObject.transform.position.z;
                int hitCol = (int)hit.collider.gameObject.transform.position.x;
                if (GetCellState((dirtBB | desertBB) & ~treeBB & ~playerBB, hitRow, hitCol)) {
                    Debug.Log("Constructed house: " + hitRow + "," + hitCol);
                    GameObject house = Instantiate(housePrefab);
                    house.transform.parent = hit.collider.gameObject.transform;
                    house.transform.localPosition = Vector3.zero;
                    playerBB = SetCellState(playerBB, hitRow, hitCol);
                    CalculateScore();
                }
            }
        }
    }
}
