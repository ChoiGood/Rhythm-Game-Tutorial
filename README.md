# Rhythm-Game-Tutorial

Unity 6 기반 리듬 게임 튜토리얼 프로젝트입니다.  
기본적인 리듬 게임 구조 구현과 함께  
Git-flow 변형 브랜치 전략과 CI 기반 워크플로우를 학습하는 것을 목표로 합니다.

## 🎮 게임 소개

이 프로젝트는 Unity 6을 사용하여 제작한  
**간단한 3D 리듬 게임 프로토타입**입니다.

플레이어는 음악의 BPM에 맞춰 생성되는 노트를  
정해진 타이밍에 입력하여 점수를 획득합니다.

본 프로젝트는 다음 요소 구현을 목표로 합니다:

- BPM 기반 노트 생성
- 입력 타이밍 판정 (Perfect / Good / Miss)
- 기본적인 점수 시스템
- 리듬 게임 구조에 대한 이해

## 🕹️ 조작 방법

- `A / S / D / F` : 노트 입력
- `Space` : 시작 / 재시작
- `ESC` : 일시 정지

## 📷 실행 화면

> 추후 Docs/images 경로에 플레이 영상 또는 스크린샷 추가 예정

## 🛠️ 개발 환경

- Engine: Unity 6
- Render Pipeline: URP (Universal Render Pipeline)
- Language: C#
- CI: GitHub Actions (Test Only)
- Version Control: Git + GitHub

---

## 🌿 브랜치 전략

Git-flow 경량 변형 구조를 사용합니다.
(Main / Dev / Feature)

main
└─ dev
   └─ feature/*

### 브랜치 역할

- **`main`**
  - 항상 릴리즈 가능한 안정 상태 유지
  - 직접 커밋 금지
  - `dev` 브랜치에서만 병합

- **`dev`**
  - 통합 개발 브랜치
  - 기능 검증 및 테스트 진행
  - 직접 커밋 금지 (권장)

- **`feature/*`**
  - 개별 기능 개발 브랜치
  - 모든 개발 작업은 해당 브랜치에서 진행

---

### 📏 브랜치 규칙

- `main`, `dev` 브랜치 직접 커밋 금지
- 모든 변경 사항은 `feature/*` 브랜치에서 작업
- Pull Request + CI 통과 후 병합
- 빌드 실패 상태로 병합 금지

---

### 🔁 작업 흐름

1. `dev` 브랜치를 기준으로 `feature/*` 브랜치 생성
2. 기능 개발
3. `feature/*` → `dev` Pull Request 생성
4. CI 빌드 통과 확인
5. `dev` 브랜치로 병합
6. 릴리즈 시 `dev` → `main` 병합

> ⚠️ merge = deploy ❌  
> ✔️ merge = 안정 상태 유지

---

## 🤖 CI 정책

Unity 6 환경에서 발생하는 CI 빌드 이슈로 인해  
현재 CI는 **EditMode / PlayMode Test 단계까지만 수행**합니다.

- 컴파일 및 테스트 오류 조기 발견 목적
- 빌드(Build) 단계는 수행하지 않음
- `main` 브랜치로의 Pull Request에서만 CI 실행

CI는 **코드 검증 도구**이며  
배포 및 실행 파일 생성을 대신하지 않습니다.

> 추후 Unity 6 CI 빌드 환경이 안정화되면  
> Build 단계를 CI에 추가할 예정입니다.

### CI 실행 조건 (GitHub Actions)

- `main` 브랜치로 향하는 Pull Request에서만 CI 실행
- `dev`, `feature/*` 브랜치에서는 CI 미실행
- CI 통과 후에만 `main` 브랜치 병합 가능

### CI 전략 선택 이유

- Unity 6 CI 환경에서 발생하는 빌드 안정성 이슈 회피
- 테스트 기반 검증으로 코드 안정성 확보
- 불필요한 빌드 시간 및 리소스 사용 방지
- 릴리즈 빌드는 로컬 환경에서 직접 수행

---

## 🚫 Git Ignore

Unity 프로젝트 특성상  
다음 폴더는 Git에 포함하지 않습니다.

- Library
- Temp
- Obj
- Build / Builds
- Logs

---

## Git Commit Convention

- feat: 기능 추가
- fix: 버그 수정
- asset: 에셋 변경
- prefab: 프리팹 수정
- scene: 씬 변경
- anim: 애니메이션 작업
- ui: UI 작업
- balance: 밸런스 조정
- refactor: 구조 개선
- chore: 환경 설정

## 🔍 Pull Request

- 모든 변경 사항은 Pull Request를 통해 병합합니다.
- PR 작성 시 템플릿을 기준으로 변경 내용과 빌드 상태를 확인합니다.

---


## 📚 참고 자료

- Rhythm Game Tutorial (YouTube)  
  https://www.youtube.com/watch?v=eLdiOCWPfPc&list=PLUZ5gNInsv_MCnum4bOQRI72LdGkIY3tY