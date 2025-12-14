# 🎮 Tic Tac Toe Deluxe (Raylib + C#)

A polished **Tic Tac Toe game built in C# using Raylib**, featuring a clean UI, smooth interactions, and a scalable architecture designed for both single-player and future online multiplayer support.

> 🚧 **Online multiplayer is currently in progress**  
> The project already contains Client/Server game modes and UI, but **socket communication is not implemented yet**.

---

## ✨ Features

- 🎨 Custom UI styling using Raylib
- 🧠 Fully implemented **Single Player** gameplay logic
- 🧩 Multiple game states (Menu, Playing, Hosting, Joining, etc.)
- 🖱️ Interactive buttons with hover effects
- 🔄 Restart and game state reset support
- 🧱 Clean separation of UI, game logic, and modes

---

## 🕹️ Game Modes

### ✅ Single Player
- Local Tic Tac Toe gameplay
- Turn-based logic (`X` / `O`)
- Win, draw, and restart detection
- Visual grid and symbols rendered with Raylib

### 🚧 Host / Join (Online Multiplayer – In Progress)
- Separate **Client** and **Server** modes already implemented
- Dedicated UI for:
  - Hosting a game
  - Joining via IP & Port
- Networking logic **not yet connected**
- Planned async socket-based communication (no threads)


### 🎯 Design Goals
- Host acts as **authoritative server**
- Joiner acts as **client**
- Turn-based synchronization
- Minimal data transfer (moves only)
- No game logic duplication


### 📡 Networking Model
- **Protocol**: TCP
- **Implementation**: `System.Net.Sockets.Socket`
- **Concurrency**: `async / await`
- **No Threads**
- **No TcpListener**

---

## 🗂️ Project Structure

