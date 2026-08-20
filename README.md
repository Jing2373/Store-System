<div align="center">

# 🎮 Store System 

![Unity](https://img.shields.io/badge/Unity-6000.0-black.svg?style=flat-square&logo=unity)
![C#](https://img.shields.io/badge/C%23-10.0-green.svg?style=flat-square)
![Architecture](https://img.shields.io/badge/Architecture-MVVM-blue.svg?style=flat-square)

A game shop and item system made for Unity. It uses the MVVM architecture and VContainer to completely separate the UI from the game logic.

</div>

## 📝 About

> **⚠️ Please note:** This repository only has pure code and does not include any Unity scenes or UI Prefabs.

I am currently developing this project with a team, and I own the rights to the code. I extracted the "Shop System" and its main code to show in my personal portfolio.

For the design, I use the **MVVM architecture** to keep the data and UI separate. I also use **VContainer** for Dependency Injection (DI) and interfaces. This makes the system easy to manage, update, and test.

Also, I follow two main rules for this project:
* **Keep inheritance simple:** I only let classes inherit up to three levels deep. This stops base classes from breaking easily (avoiding the "Fragile Base Class" problem). It keeps the code flexible and easy to change.
* **Load things dynamically:** I use the **Addressables** system to load objects instead of the normal `Resources` folder. This saves memory and makes the game's file size much smaller when you first download it.


## 🛠️ Built With
* **Engine:** Unity 6000.0.74f1
* **Framework:** VContainer, UniTask
* **Architecture:** MVVM
