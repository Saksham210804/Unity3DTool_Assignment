# Unity 3D Tool Development Assignment

## 📌 Overview

I am grateful for the opportunity to work on this assignment. It was a **valuable learning experience** that allowed me to strengthen my understanding of **Unity editor-style tool development**, **camera systems**, **UI-driven object manipulation**, and **performance-oriented coding practices**.

This project implements a **basic 3D scene interaction tool** in Unity that allows users to **spawn**, **select**, and **manipulate 3D objects** while providing smooth **camera navigation** and an **interactive property panel**, exactly as described in the assignment document.

The project is developed using **Unity 2022.3.44f1 LTS** and follows clean, modular, and scalable design principles.

---

## 🎯 Assignment Objectives Covered

This project fulfills **all requirements** mentioned in the assignment PDF, including:

- Object spawning through UI
- Object selection with visual feedback
- Property panel (Object Inspector)
- Camera navigation and focus system
- Optimized and modular code structure
- Performance-friendly architecture using object pooling

---

## 🧱 Core Features

### 1️⃣ Object Spawning System

- A dedicated **UI panel** lists basic Unity 3D primitives:
  - Cube  
  - Sphere  
  - Capsule  
  - Cylinder
  - Plane
  - Quad  
- Clicking on any object:
  - Spawns it at the **center of the world**
  - Does **not override** previously spawned objects
- Supports spawning **multiple objects simultaneously**

---

### 2️⃣ Object Selection & Manipulation

- Objects can be **selected using Left Click**
- Selected object is clearly **highlighted** for visual feedback
- Only **one object is active at a time**, ensuring clean interaction
- Selected object data is reflected instantly in the **Property Panel**

---

### 3️⃣ Property Panel (Object Inspector)

- Displays **Position values (X, Y, Z)** of the selected object
- Values are **editable in real time**
- Any change in the panel:
  - Immediately updates the object in the scene
- Mimics a simplified version of Unity’s Inspector for usability

---

### 4️⃣ Camera Navigation System

The camera system is designed to feel **smooth, intuitive, and editor-like**.

#### 🎮 Controls

| Input | Action |
|------|-------|
| **Right Click + Mouse Move** | Rotate camera |
| **Middle Mouse Button + Move** | Pan camera |
| **Scroll Wheel** | Zoom In / Zoom Out |
| **L Key** | Focus camera on selected object |
| **Left Click** | Select object |

The **focus feature** ensures fast navigation in scenes with multiple objects.

---

### 5️⃣ Dynamic Object Pooling (Performance Focus)

- Implemented a **dynamic object pooling system**
- A **single Object Pool class** is used for **all object types**
- Benefits:
  - Avoids unnecessary instantiation & destruction
  - Improves runtime performance
  - Scales efficiently with many objects in the scene
- Designed in a reusable and extensible way for future additions

---

## 🧠 Code Quality & Architecture

- Fully **modular and maintainable codebase**
- Each system is separated logically:
  - Camera Controller
  - Selection System
  - UI & Property Panel
  - Object Pooling
- **Best coding practices** followed:
  - Minimal Update calls
  - Clear separation of responsibilities
  - Efficient selection handling
- The project structure is clean and easy to navigate

---

## 📚 XML Documentation

- **Every script includes XML documentation**
- Each class and method explains:
  - Purpose
  - Parameters
  - Functional behavior
- This ensures:
  - Readability
  - Maintainability
  - Easy onboarding for future developers



The structure is designed to scale and remain understandable even as features grow.

---

## ▶️ Build & Demo Links

### 🔹 Game Build
👉 https://drive.google.com/file/d/1v5kXUiYXLaxIrfwGw8_-4f3x15Aa2lGa/view?usp=sharing

### 🔹 Gameplay Video
👉 https://drive.google.com/file/d/1S1yHbyI4EIDEEyI32m9zmw_zJ6EK1gOi/view?usp=sharing

### 🔹 Documentation
👉 https://assignment-documentation.netlify.app/

---

## 🧪 Unity Version

- **Unity 2022.3.44f1 LTS**

---

## 🙏 Final Notes

This assignment was a **great hands-on learning experience** that helped me improve my understanding of:

- Tool-based development in Unity  
- Camera mechanics similar to editor tools  
- Clean UI-driven workflows  
- Performance optimization using object pooling  

I have implemented everything **strictly according to the assignment PDF**, while also applying **industry-level coding standards** wherever possible.

I would genuinely appreciate any **feedback or suggestions for improvement**, as they would help me grow further as a Unity developer.

Thank you for the opportunity.

---


