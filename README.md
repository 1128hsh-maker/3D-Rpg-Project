3D RPG Project


프로젝트 실행 화면 예시

소개 (Introduction)

3D Unity 엔진 기반의 간단한 RPG 프로젝트입니다.
플레이어 캐릭터가 적 몬스터와 전투를 벌이고, 레벨업 및 퀘스트 진행, 강화 시스템 등이 구현되어 있습니다.

주요 기능 (Features)

플레이어 이동 및 자동 공격 AI

몬스터 AI 및 공격 기능

체력, 마나, 경험치, 골드, 다이아 UI 표시

스탯 강화 (데미지, 체력, 방어력) 시스템

버프 시스템 (데미지, 체력, 방어력 일시적 증가)

몬스터 스폰 및 리셋 포인트 기능

퀘스트 진행 및 완료 UI 업데이트

설치 및 실행 방법 (Installation & Run)

Unity 2022.3.62f2 이상 버전 설치

GitHub 저장소에서 프로젝트를 클론하거나 ZIP 다운로드

Unity Hub로 프로젝트 폴더 열기

SampleScene 씬 실행

플레이 버튼 클릭하여 게임 실행

사용법 (Usage)

플레이어 캐릭터는 자동으로 앞으로 이동합니다.

적 몬스터가 사정거리 내에 들어오면 자동으로 공격을 시작합니다.

화면 좌측 상단에 HP, MP, EXP, Dia, Gold가 표시됩니다.

UI 버튼을 눌러 스탯을 강화할 수 있습니다.

퀘스트 진행 상황이 우측 상단에 표시됩니다.

프로젝트 구조 (Project Structure)
Assets/
├── EnemyData/             # 몬스터 스탯 ScriptableObject
├── Material/Enemy/        # 몬스터 관련 머티리얼
├── Prefabs/               # 몬스터 프리팹
├── Scenes/                # 씬 파일
├── Scripts/
│   ├── Character/         # Player, Enemy 관련 스크립트
│   ├── Spawner/           # 몬스터, 플레이어 스폰 관련 스크립트
│   └── UI/                # UI 관리 및 퀘스트, 버프, 상태창 스크립트
└── TextMesh Pro/          # 텍스트 렌더링 관련 패키지

기여 방법 (Contributing)

버그 리포트 및 기능 제안은 Issue로 남겨주세요.

직접 수정 후 Pull Request를 보내주시면 검토 후 병합합니다.

코드 스타일은 기존 스타일에 맞춰 주세요.

라이선스 (License)
MIT License

이메일: hshansh@naver.com
