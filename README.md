# LaddrEditor

## 개요
* PLC 레더를 작성/배포/모니터링 할 수 있는 개발툴
* Devinno.PLC의 LadderEngine 과 연동하여 PLC 기능 수행

<br />
<br />  

## 목차
 * 사용법
   * [화면 구성](#화면-구성)
   * [에디터 편집](#에디터-편집)
   * [프로젝트 정보](#프로젝트-정보)
   * [심볼](#심볼)
   * [통신](#통신)
   * [라이브러리](#라이브러리)
 * 명령어
   * [특수 릴레이](#특수-릴레이)
   * [데이터 표현형](#데이터-표현형)
   * [연산자](#연산자)
   * [함수](#함수)


<br />
<br />  


## 사용법

### 화면 구성
![](./imgs/화면구성.png)

* **도구바**

|아이콘|명칭|설명|
|:---:|:---:|:---:|
|![](./imgs/새파일.png)|새 파일|파일을 새로 생성합니다|
|![](./imgs/열기.png)|열기|기존 파일을 불러옵니다|
|![](./imgs/저장.png)|저장|작업중인 파일을 저장합니다|
|![](./imgs/다른이름저장.png)|다른 이름으로 저장|작업중인 파일을 새로운 이름으로 저장합니다|
|![](./imgs/체크.png)|유효성 체크|작업중인 레더 로직의 유효성을 체크합니다|
|![](./imgs/정보.png)|프로젝트 정보|프로젝트 정보를 입력합니다|
|![](./imgs/심볼.png)|심볼|장치 영역 크기를 지정하거나 심볼을 등록합니다|
|![](./imgs/통신.png)|통신|통신을 등록합니다|
|![](./imgs/라이브러리.png)|라이브러리|라이브러리를 등록하고 인스턴스를 생성합니다|
|![](./imgs/다운로드.png)|다운로드|연결된 장비의 작업중인 레더문서를 다운로드합니다|
|![](./imgs/업로드.png)|업로드|연결된 장비의 동작중인 레더문서를 업로드합니다|
|![](./imgs/모니터링.png)|모니터링|연결된 장비를 모니터링합니다|

|항목|설명|
|:---:|:---:|
|![](./imgs/연결.png)|장비 연결 / 해지|

* **레더도구**

|아이콘|단축키|명칭|설명|
|:---:|:---:|:---:|:---:|
|![](./imgs/Space.png)|Space|삭제|커서 위치의 항목 삭제|
|![](./imgs/F3.png)|F3|A 접점|입력이 참인 경우 참인 접점 지정|
|![](./imgs/F4.png)|F4|B 접점|입력이 참인 경우 참인 접점 지정|
|![](./imgs/F5.png)|F5|H 라인|레더 연결을 위한 수평 라인 지정|
|![](./imgs/F6.png)|F6|V 라인|레더 연결을 위한 수직 라인 지정|
|![](./imgs/F7.png)|F7|출력|입력 상태가 참인 경우 접점 출력|
|![](./imgs/F8.png)|F8|함수|입력 상태가 참인 경우 함수 호출|
|![](./imgs/F9.png)|F9|반전|입력이 반전 되는 접점|
|![](./imgs/F11.png)|F11|상승 엣지|입력이 상승 시 연결되는 접점|
|![](./imgs/F12.png)|F12|하강 엣지|입력이 하강 시 연결되는 접점|

* **작업영역**

|단축키|설명|
|:---:|:---:|
|Del|커서 위치의 항목 삭제|
|Shift + Del|커서 위치의 행 삭제|
|Insert|커서 위치의 빈 항목 삭입|
|Shift + Insert|커서 위치의 빈 행 삽입|
|Left|커서 위치를 좌측으로 이동|
|Right|커서 위치를 우측으로 이동|
|Up|커서 위치를 위로 이동|
|Down|커서 위치를 아래로 이동|
|PageUp|커서 위치를 이전 페이지로 이동|
|PageDown|커서 위치를 다음 페이지로 이동|
|Home|커서 위치를 행의 처음으로 이동|
|End|커서 위치를 행의 끝으로 이동|
|Ctrl + Left|커서 위치를 행의 처음으로 이동|
|Ctrl + Right|커서 위치를 행의 끝으로 이동|
|Ctrl + Up|커서 위치를 문서 최상단으로 이동|
|Ctrl + Down|커서 위치를 문서 최하단으로 이동|
|Enter|항목에 내용 입력|
|Ctrl + Z|실행 취소|
|Ctrl + Y|다시 실행|
|Ctrl + C|선택 영역 복사|
|Ctrl + X|선택 영역 잘라내기|
|Ctrl + V|복사된 항목 붙여넣기|
|Shift + Left|선택 영역을 좌측으로 확장|
|Shift + Right|선택 영역을 우측으로 확장|
|Shift + Up|선택 영역을 위쪽으로 확장|
|Shift + Down|선택 영역을 아래쪽으로 확장|
|Shift + PageUp|선택 영역을 위쪽으로 한 페이지 만큼 확장|
|Shift + PageDown|선택 영역을 아래쪽으로 한 페이지 만큼 확장|
|Shift + Home|선택 영역을 행 처음까지 확장|
|Shift + End|선택 영역을 행 끝까지 확장|
|Escape|복사된 항목 초기화|


* **결과표시**

유효성 체크 결과 문제가 되는 내역 표시

|항목|설명|
|:---:|:---:|
|행|문제가 발생한 셀의 행 표시|
|열|문제가 발생한 셀의 열 표시|
|메시지|문제 항목의 내용 표시|

* **상태표시줄**

|아이콘|설명|
|:---:|:---:|
|![](./imgs/커서상태.png)|작업 영역의 커서 위치 표시|
|![](./imgs/장치상태.png)|연결된 장치 상태 표시|

### 프로젝트 정보
![](./imgs/프로젝트정보.png)

|항목|설명|
|:---:|:---:|
|제목|프로젝트 제목|
|버전|프로젝트 버전|
|설명|프로젝트 설명|

### 심볼
```
```
### 통신
```
```
### 라이브러리
```
```

<br />
<br />  

## 명령어

### 특수 릴레이
```
```
### 데이터 표현형
```
```
### 연산자
```
```
### 함수
```
```