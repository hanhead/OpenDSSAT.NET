[![Korean](https://img.shields.io/badge/Language-Korean-blue.svg)](./README.ko.md)

# DssatBridgeTest (Phase 1 Implementation)

This project is a **Console Application** that implements **Phase 1 (Engine Encapsulation)** of the OpenDSSAT.NET roadmap.

It serves as a technical Proof of Concept (PoC) to validate the **Native Process Control** and **Sandbox Isolation** logic required to run the Fortran-based DSSAT engine (`DSCSM048.EXE`) safely from a C# environment.

## 🎯 Key Features

1.  **Process Wrapping (V22)**
    * Wraps the native executable using `System.Diagnostics.Process`.
    * Utilizes **Command Line Mode ('C')** to bypass fragile batch file dependencies.
    * Executes logic equivalent to: `DSCSM048.EXE C UFGA7801.SBX 1`.
2.  **Sandbox Isolation**
    * Automatically initializes an isolated workspace at `C:\Temp\DssatRun` for every run.
    * Ensures no file conflicts occur during concurrent simulations.
3.  **Hybrid Path Configuration**
    * Dynamically configures `DSSATPRO.v48` to reference **Original Static Data** (Weather, Soil, Genotypes) from the installation directory (`C:\DSSAT48`).
    * Redirects all **Simulation Outputs** (`.OUT`) to the local sandbox folder.

## ⚙️ How to Run

This project runs independently as a standalone console app.

### Prerequisites
* **DSSAT v4.8** must be installed at `C:\DSSAT48` (Default path).
* **.NET 8.0 SDK** or higher.

### Steps
1.  Open `OpenDSSAT.NET.sln` in Visual Studio.
2.  Right-click the `DssatBridgeTest` project and select **"Set as Startup Project"**.
3.  Press **F5** or click **Debug** to run the application.

## 📂 Project Structure

* **Program.cs:** Contains the core logic for sandbox creation, file copying, process execution, and output verification.
* **Models/** *(Planned)*: Will contain C# POCO models for `.SBX` file generation in Phase 2.

## 🔍 Verification

Upon successful execution, the console should display the following logs indicating a successful simulation run:

```text
[Info] Engine copied: DSCSM048.EXE
[Info] Sample copied: UFGA7801.SBX
[Action] Running DSSAT...
[Command] DSCSM048.EXE C UFGA7801.SBX 1
[Exit Code] 0
[SUCCESS] OVERVIEW.OUT created!
Phase 1 Complete. You are ready for Phase 2.
```
