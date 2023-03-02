# HollowKnight

2023-02-14 / v0.0.1 / SetUp TitleScene
2023-02-15 / v0.0.2 / PlayerController
2023-02-17 / v0.0.3 / PlayerAnimation
2023-02-17 / v0.0.3.1 / PlayerAnimationModify

1. 오프닝 / 인트로
    Video Player를 사용해서 적용
    Render Mode를 이용해서 Camera에 Main Camera를 삽입
    Loop를 해제하여 영상이 반복으로 재생되지 않도록 한다.
    스크립트를 적용해서 오프닝영상이 끝나면 인트로 영상을 재생하도록 할 수 있을것으로 생각된다. -> 혹은 시간으로 판단 
    ex) 오프닝 영상의 길이가 10s일 경우 10s 이후에 오프닝 영상은 false가 되며, 인트로 영상은 true가 된다.
    또한, 어떠한 입력이 있을 경우 Skip 텍스트가 출력되도록 한다. -> ex) 3s
    설정된 시간(ex 3s)안에 다시 어떠한 입력이 있을 경우 영상을 Skip하는 기능을 추가할 수 있을것으로 생각된다.
    인트로 영상이 끝나면 다음 Scene으로 이동한다.

2. 타이틀(메인메뉴)
    타이틀 / 선택지(게임시작, 설정, 게임종료) 등
    마우스 커서 -> Project Settings -> Default Cursor에서 변경이 가능하다.
    게임시작 -> 프로필창
    Json을 활용해서 저장 불러오기
    DataManager 싱글톤으로 스크립트를 작성
    DontDestroyOnLoad를 사용하여 오브젝트가 파괴되지 않고 유지되도록 한다.

3. Level01 - 튜토리얼 / 보스(거대 붕붕이)
4. Level02 - 마을
5. Level03 - 보스(거짓된 기사)