using UnityEngine;
using System;

public class Matrix
{
    float[] values;
    int rows;
    int cols;

    public Matrix (int rows, int cols, float[] values) {
        this.rows = rows;
        this.cols = cols;
        this.values = new float[rows * cols];
        Array.Copy(values, this.values, rows * cols);
    }

    public Coords AsCoords() {
        if(rows != 4 || cols != 1) {
            return null;
        }
        return new Coords(values[0], values[1], values[2], values[3]);
    }

    public float GetValue(int row, int col) {
        return values[row * cols + col]; 
    }

    static public Matrix operator+(Matrix lhs, Matrix rhs) {
        if (lhs.rows != rhs.rows || lhs.cols != rhs.cols) {
            return null;
        }
        Matrix result = new Matrix(lhs.rows, lhs.cols, rhs.values);
        for (int i = 0; i < lhs.rows * lhs.cols; i++) {
            result.values[i] += rhs.values[i];
        }

        return result;
    }

    static public Matrix operator -(Matrix lhs, Matrix rhs) {
        if (lhs.rows != rhs.rows || lhs.cols != rhs.cols) {
            return null;
        }
        Matrix result = new Matrix(lhs.rows, lhs.cols, rhs.values);
        for (int i = 0; i < lhs.rows * lhs.cols; i++) {
            result.values[i] -= rhs.values[i];
        }

        return result;
    }

    static public Matrix operator *(Matrix lhs, Matrix rhs) {
        if (lhs.cols != rhs.rows) {
            return null;
        }
        float[] vals = new float[lhs.rows * rhs.cols];
        Matrix result = new Matrix(lhs.rows, rhs.cols, vals);
        for (int r = 0; r < lhs.rows; r++) {
            for (int c = 0; c < rhs.cols; c++) {
                for (int cr = 0; cr < rhs.rows; cr++) {
                    result.values[r * rhs.cols + c] += lhs.values[r * lhs.cols + cr] * rhs.values[cr * rhs.cols + c];
                }
            }
        }
        return result;
    }

    public override string ToString() {
        string matrix = "";

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                matrix += values[r * cols + c] + " ";
            }
            matrix += "\n";
        }

        return matrix;
    }
}
