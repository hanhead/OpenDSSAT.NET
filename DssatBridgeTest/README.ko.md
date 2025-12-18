# DssatBridgeTest (Phase 1 Implementation)

이 프로젝트는 **OpenDSSAT.NET**의 **Phase 1(엔진 캡슐화)** 단계를 구현한 콘솔 애플리케이션(Console App)입니다.

포트란 기반의 DSSAT 엔진(`DSCSM048.EXE`)을 C# 프로세스로 래핑(Wrapping)하여 제어하고, 샌드박스 환경에서 안전하게 시뮬레이션을 수행하는 기술 검증(Proof of Concept) 코드가 포함되어 있습니다.

## 🎯 Key Features

1.  **Process Wrapping (V22)**
    * `System.Diagnostics.Process`를 사용하여 외부 EXE를 실행합니다.
    * Command Line Arguments (`C UFGA7801.SBX 1`)를 통해 배치 파일 없이 엔진을 직접 제어합니다.
2.  **Sandbox Isolation**
    * 실행 시마다 `C:\Temp\DssatRun` 폴더를 초기화하여, 이전 실행 결과가 남지 않는 깨끗한 환경을 보장합니다.
3.  **Hybrid Path Configuration**
    * `DSSATPRO.v48` 설정 파일을 조작하여, 무거운 데이터(Weather, Soil)는 원본 설치 경로(`C:\DSSAT48`)를 참조하고, 결과 파일(.OUT)만 샌드박스에 생성합니다.

## ⚙️ How to Run

이 프로젝트는 독립적인 실행이 가능합니다.

1.  **필수 조건:** `C:\DSSAT48` 경로에 DSSAT v4.8이 설치되어 있어야 합니다.
2.  Visual Studio에서 `OpenDSSAT.NET.sln`을 엽니다.
3.  `DssatBridgeTest` 프로젝트를 **Set as Startup Project**로 설정합니다.
4.  **Debug/Run (F5)**를 실행합니다.

## 📂 Project Structure

* **Program.cs:** 메인 실행 로직. 샌드박스 생성, 설정 파일 복사, 프로세스 실행, 결과 확인 등 전체 워크플로우를 담당합니다.
* **Models/** (Planned): Phase 2에서 추가될 실험 설계 파일(.SBX) 데이터 모델이 위치할 예정입니다.

## 🔍 Verification

정상적으로 실행되면 콘솔 창에 다음 로그가 출력되어야 합니다.

```text
[Action] Running DSSAT...
[Command] DSCSM048.EXE C UFGA7801.SBX 1
[Exit Code] 0
[SUCCESS] OVERVIEW.OUT created!
```
