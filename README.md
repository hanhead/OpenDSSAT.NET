# OpenDSSAT.NET

**OpenDSSAT.NET** is an open-source initiative designed to modernize and extend the legacy Fortran-based **DSSAT (Decision Support System for Agrotechnology Transfer)** crop simulation engine using **C# .NET Core**.

This project abstracts the complex, file-based I/O system of DSSAT into **Object-Oriented Models (POCO)** and aims to build a scalable **Web-based Smart Farm Platform** with **IoT Data Integration**.

## 🚀 Project Roadmap

We are currently in **[Phase 2: Incremental Rewrite]**.

### ✅ Phase 1: Engine Encapsulation & I/O Pipeline (Completed)

* [x] **Native Process Control:** implemented `DSCSM048.EXE` process wrapping and execution control.
* [x] **Sandbox Environment:** Established an isolated simulation environment (`C:\Temp\DssatRun`) to prevent system conflicts.
* [x] **Hybrid Path System:** Configured a structure that references original static data (Weather/Soil) while isolating output files.
* [x] **Exit Code Verification:** Verified successful simulation termination (Exit Code 0).

### 🔄 Phase 2: Incremental Rewrite (In Progress)

* [ ] **Data Modeling:** Designing C# Classes (POCO) for major file formats like Experiment (.SBX) and Weather (.WTH).
* [ ] **Input Generator:** Developing a module to automatically generate DSSAT input text files from C# objects.
* [ ] **Output Parser:** Parsing result files (e.g., `OVERVIEW.OUT`) into structured data.
* [ ] **DB Integration:** Storing simulation results into a relational database.

### 📅 Phase 3: Web UX & Data Integration (Planned)

* [ ] **ASP.NET Core MVC:** Building a web-based simulation dashboard.
* [ ] **Interactive Charts:** Visualizing crop growth simulation results using Chart.js.
* [ ] **IoT/API Connection:** Real-time integration with on-site sensor data and public weather APIs.

### 🔮 Phase 4: Native Algorithm Rewrite (Future)

* [ ] **Scientific Specification:** Documenting crop growth algorithms and formulas.
* [ ] **C# Native Engine:** Implementing a pure .NET engine, removing the dependency on Fortran binaries.
* [ ] **Parallel Verification:** Cross-validating precision between the original EXE results and the new C# engine.

---

## 🛠 Prerequisites

To run this project, the following environment is required:

* **OS:** Windows 10/11 (Required for DSSAT Engine compatibility)
* **.NET SDK:** .NET 8.0 or higher
* **DSSAT Engine:** Official DSSAT v4.8.x installed (Recommended path: `C:\DSSAT48`)
* *Note: This repository does **not** include the DSSAT executable (`DSCSM048.EXE`).*



## 📥 Installation & Setup

1. Clone this repository:
```bash
git clone https://github.com/hanhead/OpenDSSAT.NET.git

```


2. Ensure that the official DSSAT software is installed at `C:\DSSAT48`.
3. Build and run the project. It will automatically configure the sandbox environment and test the engine connection.

---

## ⚖️ License

The source code for this project is distributed under the **BSD 3-Clause License**. See the `LICENSE` file for details.

> **Disclaimer:**
> This project serves as a wrapper and middleware for controlling the DSSAT engine.
> The **DSSAT Engine (`DSCSM048.EXE`) and related binaries** are the property of the **DSSAT Foundation** and are **not** included or distributed in this repository. Users must obtain a valid license for DSSAT separately.

---

## 🤝 Contribution

Contributions are always welcome! Please use the **Issues** tab for bug reports, feature requests, or Pull Requests (PRs).
