# OpenDSSAT.NET

**OpenDSSAT.NET**은 레거시 포트란 기반의 작물 시뮬레이션 엔진인 **DSSAT (Decision Support System for Agrotechnology Transfer)**을 현대적인 **C# .NET Core** 환경으로 통합하고 확장하기 위한 오픈 소스 프로젝트입니다.

이 프로젝트는 복잡한 파일 기반의 입출력 시스템을 **객체 지향 모델(POCO)**로 추상화하고, 향후 **웹 기반 스마트팜 플랫폼** 및 **IoT 데이터 통합**을 목표로 합니다.

## 🚀 Project Roadmap

현재 **[2단계: 모듈별 점진적 변환]**을 진행 중입니다.

### ✅ Phase 1: Engine Encapsulation & I/O Pipeline (Completed)
- [x] **Native Process Control:** `DSCSM048.EXE` 프로세스 래핑 및 제어 구현
- [x] **Sandbox Environment:** 독립적인 시뮬레이션 실행 환경 구축 (`C:\Temp\DssatRun`)
- [x] **Hybrid Path System:** 원본 데이터(날씨/토양) 참조 및 결과 파일 분리 구조 확립
- [x] **Exit Code Verification:** 시뮬레이션 정상 종료 검증 (Exit Code 0)

### 🔄 Phase 2: Incremental Rewrite (In Progress)
- [ ] **Data Modeling:** 실험 설계(.SBX), 기상(.WTH) 등 주요 파일 포맷의 C# Class(POCO) 설계
- [ ] **Input Generator:** C# 객체 데이터를 기반으로 DSSAT 입력 파일 자동 생성기 개발
- [ ] **Output Parser:** `OVERVIEW.OUT` 등 결과 파일을 분석하여 구조화된 데이터로 변환
- [ ] **DB Integration:** 시뮬레이션 결과를 데이터베이스에 저장

### 📅 Phase 3: Web UX & Data Integration (Planned)
- [ ] **ASP.NET Core MVC:** 웹 기반 시뮬레이션 대시보드 구축
- [ ] **Interactive Charts:** 생육 시뮬레이션 결과 시각화
- [ ] **IoT/API Connection:** 현장 센서 데이터 및 공공 기상 API 실시간 연동

### 🔮 Phase 4: Native Algorithm Rewrite (Future)
- [ ] **Scientific Specification:** 작물 생육 알고리즘(수식) 명세화
- [ ] **C# Native Engine:** 포트란 의존성을 제거한 순수 .NET 엔진 구현
- [ ] **Parallel Verification:** 기존 EXE 결과값과 C# 엔진 결과값의 정밀도 비교 검증

---

## 🛠 Prerequisites

이 프로젝트를 실행하기 위해서는 다음 환경이 필요합니다.

* **OS:** Windows 10/11 (DSSAT 엔진 호환성)
* **.NET SDK:** .NET 8.0 이상
* **DSSAT Engine:** 공식 DSSAT v4.8.x 설치 필요 (`C:\DSSAT48` 경로 권장)
    * *Note: 이 리포지토리는 DSSAT 실행 파일(`DSCSM048.EXE`)을 포함하지 않습니다.*

## 📥 Installation & Setup

1.  이 저장소를 클론합니다.
    ```bash
    git clone [https://github.com/hanhead/OpenDSSAT.NET.git](https://github.com/hanhead/OpenDSSAT.NET.git)
    ```
2.  `C:\DSSAT48` 경로에 공식 DSSAT이 설치되어 있는지 확인합니다.
3.  프로젝트를 빌드하고 실행하면, 자동으로 샌드박스 환경을 구성하고 엔진을 테스트합니다.

---

## ⚖️ License

이 프로젝트의 소스 코드는 **BSD 3-Clause License** 하에 배포됩니다. 자세한 내용은 `LICENSE` 파일을 참고하세요.

> **Disclaimer:**
> 이 프로젝트는 DSSAT 엔진을 제어하는 래퍼(Wrapper) 및 미들웨어입니다.
> **DSSAT 엔진(`DSCSM048.EXE`) 및 관련 바이너리**의 저작권은 **DSSAT Foundation**에 있으며, 이 리포지토리에 포함되거나 배포되지 않습니다. 사용자는 별도로 적법한 라이선스를 보유해야 합니다.

---

## 🤝 Contribution

기여는 언제나 환영합니다! 버그 제보, 기능 제안, PR(Pull Request)은 Issue 탭을 이용해 주세요.
