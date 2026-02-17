# GameMathPractice

Practical Unity implementations with custom-built game math systems, including bitboards, vectors, lines and planes, intersections, affine transformations, and quaternion rotations.

---

The actual custom game math implementations are in Coords.cs (custom vector class), HolisticMath.cs, Line.cs, Plane.cs and Matrix.cs.
The rest are supporting scripts used to demonstrate and test the math.

---

## Bitboards Practice:

Practicing the usage the bitboards and performing bitwise operations on them. In this project,
a game board is spawned with randomly generated tiles of different types. Trees also randomly spawn specifically on dirt tiles
without houses, and houses can be spawned by clicking on either dirt tiles without trees, or desert tiles. There's also a score
calculation for the houses spawned.

---

## 2DDistanceDirectionGame:

Practicing Distance and Direction with 2D vectors. This is a small game where
you have a tank and a fuel container that randomly spawns. You're given the position of the fuel container
and have to enter the amount of energy (distance) needed and the required turn angle (positive rotation being
anticlockwise). You then go forward and see if you reach the fuel container with only a fraction of energy remaining.

---

## PlayerControlledTank:

Practicing applying 2D Translation and Rotation with player input.

---

## ParametricFormLine:

Drawing a line from one cube to another, and then having a sphere travel from one end to the other with lerping.

---

## ParametricFormPlane:

Creating a plane from 3 cubes as positions with plane lerping and spawning spheres.

---

## LineIntersection:

- Line-line and line-plane intersections. Seeing if there's an intersection point and then calculating it.
- In 2D, having a sphere travel along a line/path and stopping at a wall.
- In 3D, Having a sphere travel along a path and bouncing off of a plane using reflection.

---

## Matrices:

- Affine Transformations: Translation, Scaling, Rotation, Shearing and Reflection with Euler Angles.
- Quaternions and rotations with them.
- Extracting the Rotation Axis and Angle.
- Converting a Euler Angle rotation to a Quaternion rotation.

---

## AeroRotate:

Doing the equivalent of Unity's transform.rotate(1, 1, 1).
