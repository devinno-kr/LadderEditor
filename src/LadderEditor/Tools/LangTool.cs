using Devinno.PLC.Ladder;
using LadderEditor.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadderEditor.Tools
{
    public class LangTool
    {
        static Lang lang => Program.DataMgr?.Language ?? Lang.KO;
        
        #region SaveQuestion
        public static string SaveQuestion
        {
            get
            {
                if (lang == Lang.KO) return "저장 하시겠습니까?";
                else if (lang == Lang.EN) return "Would you like me to save it?";
                else return "";
            }
        }
        #endregion
        #region SavePermissions
        public static string SavePermissions
        {
            get
            {
                if (lang == Lang.KO) return "권한 부족으로 저장할 수 없습니다.";
                else if (lang == Lang.EN) return "Insufficient permissions to save.";
                else return "";
            }
        }
        #endregion

        #region Row
        public static string Row
        {
            get
            {
                if (lang == Lang.KO) return "행";
                else if (lang == Lang.EN) return "Row";
                else return "";
            }
        }
        #endregion
        #region Col
        public static string Col
        {
            get
            {
                if (lang == Lang.KO) return "열";
                else if (lang == Lang.EN) return "Col";
                else return "";
            }
        }
        #endregion
        
        #region ValidationOK
        public static string ValidationOK
        {
            get
            {
                if (lang == Lang.KO) return "유효성 체크 결과 정상입니다.";
                else if (lang == Lang.EN) return "The validity check results are normal.";
                else return "";
            }
        }
        #endregion
        #region ValidationFail
        public static string ValidationFail
        {
            get
            {
                if (lang == Lang.KO) return "유효성 체크 결과 문제가 확인 되었습니다.";
                else if (lang == Lang.EN) return "The validity check results have identified an issue.";
                else return "";
            }
        }
        #endregion

        #region NewFile
        public static string NewFile
        {
            get
            {
                if (lang == Lang.KO) return "새 파일";
                else if (lang == Lang.EN) return "New File";
                else return "";
            }
        }
        #endregion
        #region Save
        public static string Save
        {
            get
            {
                if (lang == Lang.KO) return "저장";
                else if (lang == Lang.EN) return "Save";
                else return "";
            }
        }
        #endregion
        #region SaveAs
        public static string SaveAs
        {
            get
            {
                if (lang == Lang.KO) return "다른 이름으로 저장";
                else if (lang == Lang.EN) return "Save As";
                else return "";
            }
        }
        #endregion
        #region Open
        public static string Open
        {
            get
            {
                if (lang == Lang.KO) return "열기";
                else if (lang == Lang.EN) return "Open";
                else return "";
            }
        }
        #endregion
        #region Monitoring
        public static string Monitoring
        {
            get
            {
                if (lang == Lang.KO) return "모니터링";
                else if (lang == Lang.EN) return "Monitoring";
                else return "";
            }
        }
        #endregion
        #region Download
        public static string Download
        {
            get
            {
                if (lang == Lang.KO) return "다운로드";
                else if (lang == Lang.EN) return "Download";
                else return "";
            }
        }
        #endregion
        #region ProjectDescription
        public static string ProjectDescription
        {
            get
            {
                if (lang == Lang.KO) return "프로젝트 설명";
                else if (lang == Lang.EN) return "Project Description";
                else return "";
            }
        }
        #endregion
        #region Communication
        public static string Communication
        {
            get
            {
                if (lang == Lang.KO) return "통신 설정";
                else if (lang == Lang.EN) return "Communication";
                else return "";
            }
        }
        #endregion
        #region ValidationCheck
        public static string ValidationCheck
        {
            get
            {
                if (lang == Lang.KO) return "유효성 체크";
                else if (lang == Lang.EN) return "Validation Check";
                else return "";
            }
        }
        #endregion
        #region Symbol
        public static string Symbol
        {
            get
            {
                if (lang == Lang.KO) return "심볼";
                else if (lang == Lang.EN) return "Symbol";
                else return "";
            }
        }
        #endregion
        #region Upload
        public static string Upload
        {
            get
            {
                if (lang == Lang.KO) return "업로드";
                else if (lang == Lang.EN) return "Upload";
                else return "";
            }
        }
        #endregion
        #region Library
        public static string Library
        {
            get
            {
                if (lang == Lang.KO) return "라이브러리";
                else if (lang == Lang.EN) return "Library";
                else return "";
            }
        }
        #endregion

        #region Device
        public static string Device
        {
            get
            {
                if (lang == Lang.KO) return "장치";
                else if (lang == Lang.EN) return "Device";
                else return "";
            }
        }
        #endregion
        #region DeviceState
        public static string DeviceState
        {
            get
            {
                if (lang == Lang.KO) return "장치 상태";
                else if (lang == Lang.EN) return "Device State";
                else return "";
            }
        }
        #endregion

        #region Connect
        public static string Connect
        {
            get
            {
                if (lang == Lang.KO) return "연결";
                else if (lang == Lang.EN) return "Conn";
                else return "";
            }
        }
        #endregion
        #region Disconnect
        public static string Disconnect
        {
            get
            {
                if (lang == Lang.KO) return "해지";
                else if (lang == Lang.EN) return "Disconn";
                else return "";
            }
        }
        #endregion
        #region DownloadComplete
        public static string DownloadComplete
        {
            get
            {
                if (lang == Lang.KO) return "다운로드를 완료하였습니다.";
                else if (lang == Lang.EN) return "The download has been completed.";
                else return "";
            }
        }
        #endregion
        #region DownloadFail
        public static string DownloadFail
        {
            get
            {
                if (lang == Lang.KO) return "다운로드에 실패하였습니다.";
                else if (lang == Lang.EN) return "The download has failed.";
                else return "";
            }
        }
        #endregion
        #region UploadComplete
        public static string UploadComplete
        {
            get
            {
                if (lang == Lang.KO) return "업로드를 완료하였습니다.";
                else if (lang == Lang.EN) return "The upload has been completed.";
                else return "";
            }
        }
        #endregion
        #region UploadFail
        public static string UploadFail
        {
            get
            {
                if (lang == Lang.KO) return "업로드에 실패하였습니다.";
                else if (lang == Lang.EN) return "The upload has failed.";
                else return "";
            }
        }
        #endregion

        #region AppTitle
        public static string AppTitle
        {
            get
            {
                if (lang == Lang.KO) return "레더 에디터";
                else if (lang == Lang.EN) return "Ladder Editor";
                else return "";
            }
        }
        #endregion
        #region StateDisconnected
        public static string StateDisconnected
        {
            get
            {
                if (lang == Lang.KO) return "미연결";
                else if (lang == Lang.EN) return "Disconnected";
                else return "";
            }
        }
        #endregion
        #region StateStandby
        public static string StateStandby
        {
            get
            {
                if (lang == Lang.KO) return "대기";
                else if (lang == Lang.EN) return "Standby";
                else return "";
            }
        }
        #endregion
        #region StateRun
        public static string StateRun
        {
            get
            {
                if (lang == Lang.KO) return "실행";
                else if (lang == Lang.EN) return "Run";
                else return "";
            }
        }
        #endregion
        #region StateDownloading
        public static string StateDownloading
        {
            get
            {
                if (lang == Lang.KO) return "다운로딩..";
                else if (lang == Lang.EN) return "Downloading..";
                else return "";
            }
        }
        #endregion
        #region StateError
        public static string StateError
        {
            get
            {
                if (lang == Lang.KO) return "에러";
                else if (lang == Lang.EN) return "Error";
                else return "";
            }
        }
        #endregion

        #region CommunicationList
        public static string CommunicationList
        {
            get
            {
                if (lang == Lang.KO) return "통신 목록";
                else if (lang == Lang.EN) return "Commnication List";
                else return "";
            }
        }
        #endregion
        #region CommunicationItem
        public static string CommunicationItem
        {
            get
            {
                if (lang == Lang.KO) return "통신 항목";
                else if (lang == Lang.EN) return "Commnication Item";
                else return "";
            }
        }
        #endregion
        #region CommunicationType
        public static string CommunicationType
        {
            get
            {
                if (lang == Lang.KO) return "통신 유형";
                else if (lang == Lang.EN) return "Commnication Type";
                else return "";
            }
        }
        #endregion
        #region CommunicationAdd
        public static string CommunicationAdd
        {
            get
            {
                if (lang == Lang.KO) return "통신 추가";
                else if (lang == Lang.EN) return "Commnication Add";
                else return "";
            }
        }
        #endregion
        #region CommunicationModify
        public static string CommunicationModify
        {
            get
            {
                if (lang == Lang.KO) return "통신 수정";
                else if (lang == Lang.EN) return "Commnication Modify";
                else return "";
            }
        }
        #endregion
        #region Information
        public static string Information
        {
            get
            {
                if (lang == Lang.KO) return "정보";
                else if (lang == Lang.EN) return "Information";
                else return "";
            }
        }
        #endregion

        #region Name
        public static string Name
        {
            get
            {
                if (lang == Lang.KO) return "명칭";
                else if (lang == Lang.EN) return "Name";
                else return "";
            }
        }
        #endregion
        #region Slave
        public const string SlaveK = "국번";
        public const string SlaveE = "Slave";
        public static string Slave
        {
            get
            {
                if (lang == Lang.KO) return SlaveK;
                else if (lang == Lang.EN) return SlaveE;
                else return "";
            }
        }
        #endregion
        #region Port
        public static string Port
        {
            get
            {
                if (lang == Lang.KO) return "통신 포트";
                else if (lang == Lang.EN) return "Port";
                else return "";
            }
        }
        #endregion
        #region PortNo
        public static string PortNo
        {
            get
            {
                if (lang == Lang.KO) return "포트 번호";
                else if (lang == Lang.EN) return "Port Number";
                else return "";
            }
        }
        #endregion

        #region Baudrate
        public static string Baudrate
        {
            get
            {
                if (lang == Lang.KO) return "통신 속도";
                else if (lang == Lang.EN) return "Baudrate";
                else return "";
            }
        }
        #endregion
        #region Interval
        public static string Interval
        {
            get
            {
                if (lang == Lang.KO) return "인터벌";
                else if (lang == Lang.EN) return "Interval";
                else return "";
            }
        }
        #endregion
        #region Timeout
        public static string Timeout
        {
            get
            {
                if (lang == Lang.KO) return "타임아웃";
                else if (lang == Lang.EN) return "Timeout";
                else return "";
            }
        }
        #endregion
        #region Property
        public static string Property
        {
            get
            {
                if (lang == Lang.KO) return "속성";
                else if (lang == Lang.EN) return "Property";
                else return "";
            }
        }
        #endregion
        #region FuncCode
        public static string FuncCode
        {
            get
            {
                if (lang == Lang.KO) return "코드";
                else if (lang == Lang.EN) return "Code";
                else return "";
            }
        }
        #endregion
        #region InputError
        public static string InputError
        {
            get
            {
                if (lang == Lang.KO) return "입력 오류";
                else if (lang == Lang.EN) return "Input Error";
                else return "";
            }
        }
        #endregion
        #region Area
        public static string Area
        {
            get
            {
                if (lang == Lang.KO) return "영역";
                else if (lang == Lang.EN) return "Area";
                else return "";
            }
        }
        #endregion
        #region StartAddress
        public static string StartAddress
        {
            get
            {
                if (lang == Lang.KO) return "시작 주소";
                else if (lang == Lang.EN) return "Start Address";
                else return "";
            }
        }
        #endregion
        #region Length
        public static string Length
        {
            get
            {
                if (lang == Lang.KO) return "길이";
                else if (lang == Lang.EN) return "Length";
                else return "";
            }
        }
        #endregion
        #region Bind
        public static string Bind
        {
            get
            {
                if (lang == Lang.KO) return "바인딩";
                else if (lang == Lang.EN) return "Bind";
                else return "";
            }
        }
        #endregion
        #region Subscribe
        public static string Subscribe
        {
            get
            {
                if (lang == Lang.KO) return "구독";
                else if (lang == Lang.EN) return "Subscribe";
                else return "";
            }
        }
        #endregion
        #region Publish
        public static string Publish
        {
            get
            {
                if (lang == Lang.KO) return "발행";
                else if (lang == Lang.EN) return "Publish";
                else return "";
            }
        }
        #endregion
        #region Topic
        public static string Topic
        {
            get
            {
                if (lang == Lang.KO) return "토픽";
                else if (lang == Lang.EN) return "Topic";
                else return "";
            }
        }
        #endregion
        #region Address
        public static string Address
        {
            get
            {
                if (lang == Lang.KO) return "주소";
                else if (lang == Lang.EN) return "Address";
                else return "";
            }
        }
        #endregion
        #region AddressBook
        public static string AddressBook
        {
            get
            {
                if (lang == Lang.KO) return "주소록";
                else if (lang == Lang.EN) return "Address Book";
                else return "";
            }
        }
        #endregion
        #region AreaStartAddress
        public static string AreaStartAddress
        {
            get
            {
                if (lang == Lang.KO) return "영역 시작주소";
                else if (lang == Lang.EN) return "Start Address";
                else return "";
            }
        }
        #endregion
        #region MemoryBind
        public static string MemoryBind
        {
            get
            {
                if (lang == Lang.KO) return "메모리 바인딩";
                else if (lang == Lang.EN) return "Memory Bind";
                else return "";
            }
        }
        #endregion
        #region MemoryAddress
        public static string MemoryAddress
        {
            get
            {
                if (lang == Lang.KO) return "메모리 주소";
                else if (lang == Lang.EN) return "Memory Address";
                else return "";
            }
        }
        #endregion
        #region MemoryMap
        public static string MemoryMap
        {
            get
            {
                if (lang == Lang.KO) return "메모리 맵";
                else if (lang == Lang.EN) return "Memory Map";
                else return "";
            }
        }
        #endregion
        #region RemoteIP
        public static string RemoteIP
        {
            get
            {
                if (lang == Lang.KO) return "원격 주소";
                else if (lang == Lang.EN) return "Remote IP";
                else return "";
            }
        }
        #endregion
        #region ConnectionName
        public static string ConnectionName
        {
            get
            {
                if (lang == Lang.KO) return "연결명";
                else if (lang == Lang.EN) return "Connection Name";
                else return "";
            }
        }
        #endregion
        #region ProjectInformation
        public static string ProjectInformation
        {
            get
            {
                if (lang == Lang.KO) return "프로젝트 정보";
                else if (lang == Lang.EN) return "Project Information";
                else return "";
            }
        }
        #endregion
        #region Title
        public static string Title
        {
            get
            {
                if (lang == Lang.KO) return "제목";
                else if (lang == Lang.EN) return "Title";
                else return "";
            }
        }
        #endregion
        #region Version
        public static string Version
        {
            get
            {
                if (lang == Lang.KO) return "버전";
                else if (lang == Lang.EN) return "Version";
                else return "";
            }
        }
        #endregion
        #region Description
        public static string Description
        {
            get
            {
                if (lang == Lang.KO) return "설명";
                else if (lang == Lang.EN) return "Description";
                else return "";
            }
        }
        #endregion
        #region VariableName
        public static string VariableName
        {
            get
            {
                if (lang == Lang.KO) return "변수명";
                else if (lang == Lang.EN) return "Variable Name";
                else return "";
            }
        }
        #endregion
        #region LibraryList
        public static string LibraryList
        {
            get
            {
                if (lang == Lang.KO) return "라이브러리 목록";
                else if (lang == Lang.EN) return "Library List";
                else return "";
            }
        }
        #endregion
        #region LibraryReference
        public static string LibraryReference
        {
            get
            {
                if (lang == Lang.KO) return "라이브러리 참조";
                else if (lang == Lang.EN) return "Library Reference";
                else return "";
            }
        }
        #endregion
        #region Message
        public static string Message
        {
            get
            {
                if (lang == Lang.KO) return "메시지";
                else if (lang == Lang.EN) return "Message";
                else return "";
            }
        }
        #endregion
        #region Search
        public static string Search
        {
            get
            {
                if (lang == Lang.KO) return "찾기";
                else if (lang == Lang.EN) return "Search";
                else return "";
            }
        }
        #endregion
        #region SearchWord
        public static string SearchWord
        {
            get
            {
                if (lang == Lang.KO) return "검색어";
                else if (lang == Lang.EN) return "Word";
                else return "";
            }
        }
        #endregion
        #region Close
        public static string Close
        {
            get
            {
                if (lang == Lang.KO) return "닫기";
                else if (lang == Lang.EN) return "Close";
                else return "";
            }
        }
        #endregion
        #region Setting
        public const string SettingK = "설정";
        public const string SettingE = "Setting";
        public static string Setting
        {
            get
            {
                if (lang == Lang.KO) return SettingK;
                else if (lang == Lang.EN) return SettingE;
                else return "";
            }
        }
        #endregion
        #region SettingList
        public const string SettingListK = "설정 목록";
        public const string SettingListE = "Setting List";
        public static string SettingList
        {
            get
            {
                if (lang == Lang.KO) return SettingListK;
                else if (lang == Lang.EN) return SettingListE;
                else return "";
            }
        }
        #endregion
        #region ProjectFolder
        public const string ProjectFolderK = "프로젝트 폴더";
        public const string ProjectFolderE = "Project Folder";
        public static string ProjectFolder
        {
            get
            {
                if (lang == Lang.KO) return ProjectFolderK;
                else if (lang == Lang.EN) return ProjectFolderE;
                else return "";
            }
        }
        #endregion
        #region Language
        public const string LanguageK = "언어";
        public const string LanguageE = "Language";
        public static string Language
        {
            get
            {
                if (lang == Lang.KO) return LanguageK;
                else if (lang == Lang.EN) return LanguageE;
                else return "";
            }
        }
        #endregion
        #region SymbolInput
        public static string SymbolInput
        {
            get
            {
                if (lang == Lang.KO) return "심볼 입력";
                else if (lang == Lang.EN) return "Symbol Input";
                else return "";
            }
        }
        #endregion
        #region AreaCount
        public static string AreaCount
        {
            get
            {
                if (lang == Lang.KO) return "영역 크기";
                else if (lang == Lang.EN) return "Area Count";
                else return "";
            }
        }
        #endregion
        #region SymbolList
        public static string SymbolList
        {
            get
            {
                if (lang == Lang.KO) return "심볼 목록";
                else if (lang == Lang.EN) return "Symbol List";
                else return "";
            }
        }
        #endregion
        #region Input
        public static string Input
        {
            get
            {
                if (lang == Lang.KO) return "입력";
                else if (lang == Lang.EN) return "Input";
                else return "";
            }
        }
        #endregion
        #region SymbolInputFormat
        public static string SymbolInputFormat
        {
            get
            {
                if (lang == Lang.KO) return "※입력 형식 : '[주소]    [명칭]'\r\n※입력 예시 : 'D0    Test'";
                else if (lang == Lang.EN) return "※Input format : '[address]    [name]'\r\n※Input example : 'D0    Test'";
                else return "";
            }
        }
        #endregion
        #region Edit
        public static string Edit
        {
            get
            {
                if (lang == Lang.KO) return "편집";
                else if (lang == Lang.EN) return "Edit";
                else return "";
            }
        }
        #endregion

        #region SyntaxDisplay
        public const string SyntaxDisplayK = "구문 표시";
        public const string SyntaxDisplayE = "Syntax Display";
        public static string SyntaxDisplay
        {
            get
            {
                if (lang == Lang.KO) return SyntaxDisplayK;
                else if (lang == Lang.EN) return SyntaxDisplayE;
                else return "";
            }
        }
        #endregion
        #region SyntaxAll
        public const string SyntaxAllK = "전체";
        public const string SyntaxAllE = "All";
        public static string SyntaxAll
        {
            get
            {
                if (lang == Lang.KO) return SyntaxAllK;
                else if (lang == Lang.EN) return SyntaxAllE;
                else return "";
            }
        }
        #endregion
        #region SyntaxShortened
        public const string SyntaxShortenedK = "축약";
        public const string SyntaxShortenedE = "Shortened";
        public static string SyntaxShortened
        {
            get
            {
                if (lang == Lang.KO) return SyntaxShortenedK;
                else if (lang == Lang.EN) return SyntaxShortenedE;
                else return "";
            }
        }
        #endregion

        #region Ok
        public const string OkK = "확인";
        public const string OkE = "Ok";
        public static string Ok
        {
            get
            {
                if (lang == Lang.KO) return OkK;
                else if (lang == Lang.EN) return OkE;
                else return "";
            }
        }
        #endregion
        #region Cancel
        public const string CancelK = "취소";
        public const string CancelE = "Cancel";
        public static string Cancel
        {
            get
            {
                if (lang == Lang.KO) return CancelK;
                else if (lang == Lang.EN) return CancelE;
                else return "";
            }
        }
        #endregion
        #region Yes
        public const string YesK = "예";
        public const string YesE = "Yes";
        public static string Yes
        {
            get
            {
                if (lang == Lang.KO) return YesK;
                else if (lang == Lang.EN) return YesE;
                else return "";
            }
        }
        #endregion
        #region No
        public const string NoK = "아니요";
        public const string NoE = "No";
        public static string No
        {
            get
            {
                if (lang == Lang.KO) return NoK;
                else if (lang == Lang.EN) return NoE;
                else return "";
            }
        }
        #endregion

        #region ConnectErrorAddress
        public static string ConnectErrorAddress
        {
            get
            {
                if (lang == Lang.KO) return "유효한 주소가 아닙니다.";
                else if (lang == Lang.EN) return "The address is not valid.";
                else return "";
            }
        }
        #endregion
        #region ConnectErrorEmpty
        public static string ConnectErrorEmpty
        {
            get
            {
                if (lang == Lang.KO) return "주소를 입력하거나 조회 항목을 선택하세요.";
                else if (lang == Lang.EN) return "Please enter an address or select a query item.";
                else return "";
            }
        }
        #endregion

        #region CommErrorPort
        public static string CommErrorPort
        {
            get
            {
                if (lang == Lang.KO) return "· 통신 포트를 입력하세요.";
                else if (lang == Lang.EN) return "· Please enter the port.";
                else return "";
            }
        }
        #endregion
        #region CommErrorBaudrate
        public static string CommErrorBaudrate
        {
            get
            {
                if (lang == Lang.KO) return "· 통신 속도를 입력하세요.";
                else if (lang == Lang.EN) return"· Please enter the baudrate.";
                else return "";
            }
        }
        #endregion
        #region CommErrorInterval
        public static string CommErrorInterval
        {
            get
            {
                if (lang == Lang.KO) return "· 인터벌은 0 이상의 값을 입력하세요.";
                else if (lang == Lang.EN) return "· Please enter a value greater than or equal to 0 for the interval.";
                else return "";
            }
        }
        #endregion
        #region CommErrorTimeout
        public static string CommErrorTimeout
        {
            get
            {
                if (lang == Lang.KO) return "· 타임아웃은 0 이상의 값을 입력하세요.";
                else if (lang == Lang.EN) return "· Please enter a value greater than or equal to 0 for the timeout.";
                else return "";
            }
        }
        #endregion
        #region CommErrorSlave
        public static string CommErrorSlave
        {
            get
            {
                if (lang == Lang.KO) return "· 국번은 0~255 사이 숫자로 입력하여야 합니다.";
                else if (lang == Lang.EN) return "· The slave number should be entered as a number between 0 and 255.";
                else return "";
            }
        }
        #endregion
        #region CommErrorAreaP
        public static string CommErrorAreaP
        {
            get
            {
                if (lang == Lang.KO) return "P 영역 시작주소를 입력하세요.";
                else if (lang == Lang.EN) return "Please enter the starting address of the P Area.";
                else return "";
            }
        }
        #endregion
        #region CommErrorAreaM
        public static string CommErrorAreaM
        {
            get
            {
                if (lang == Lang.KO) return "M 영역 시작주소를 입력하세요.";
                else if (lang == Lang.EN) return "Please enter the starting address of the M Area.";
                else return "";
            }
        }
        #endregion
        #region CommErrorAreaT
        public static string CommErrorAreaT
        {
            get
            {
                if (lang == Lang.KO) return "T 영역 시작주소를 입력하세요.";
                else if (lang == Lang.EN) return "Please enter the starting address of the T Area.";
                else return "";
            }
        }
        #endregion
        #region CommErrorAreaC
        public static string CommErrorAreaC
        {
            get
            {
                if (lang == Lang.KO) return "C 영역 시작주소를 입력하세요.";
                else if (lang == Lang.EN) return "Please enter the starting address of the C Area.";
                else return "";
            }
        }
        #endregion
        #region CommErrorAreaD
        public static string CommErrorAreaD
        {
            get
            {
                if (lang == Lang.KO) return "D 영역 시작주소를 입력하세요.";
                else if (lang == Lang.EN) return "Please enter the starting address of the D Area.";
                else return "";
            }
        }
        #endregion
        #region CommErrorAreaWP
        public static string CommErrorAreaWP
        {
            get
            {
                if (lang == Lang.KO) return "WP 영역 시작주소를 입력하세요.";
                else if (lang == Lang.EN) return "Please enter the starting address of the WP Area.";
                else return "";
            }
        }
        #endregion
        #region CommErrorAreaWM
        public static string CommErrorAreaWM
        {
            get
            {
                if (lang == Lang.KO) return "WM 영역 시작주소를 입력하세요.";
                else if (lang == Lang.EN) return "Please enter the starting address of the WM Area.";
                else return "";
            }
        }
        #endregion
        #region CommErrorRemoteIP
        public static string CommErrorRemoteIP
        {
            get
            {
                if (lang == Lang.KO) return "· 원격 주소를 IPv4 형식으로 입력하여야 합니다.";
                else if (lang == Lang.EN) return "· Please enter the remote address in IPv4 format.";
                else return "";
            }
        }
        #endregion
        #region CommErrorSub
        public static string CommErrorSub
        {
            get
            {
                if (lang == Lang.KO) return "· 구독 항목에 빈 토픽이 존재합니다.";
                else if (lang == Lang.EN) return "· There is an empty topic in the subscription items.";
                else return "";
            }
        }
        #endregion
        #region CommErrorPub
        public static string CommErrorPub
        {
            get
            {
                if (lang == Lang.KO) return "· 발행 항목에 빈 토픽이 존재합니다.";
                else if (lang == Lang.EN) return "· There is an empty topic in the publishing items.";
                else return "";
            }
        }
        #endregion

        #region SymbolErrorEmptyP
        public static string SymbolErrorEmptyP
        {
            get
            {
                if (lang == Lang.KO) return "P 영역 크기가 비어있습니다.";
                else if (lang == Lang.EN) return "The size of the P area is empty.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorRangeP
        public static string SymbolErrorRangeP
        {
            get
            {
                if (lang == Lang.KO) return "P 영역 범위는 0 ~ 32768 입니다.";
                else if (lang == Lang.EN) return "The range of the P area is 0 to 32768.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorEmptyM
        public static string SymbolErrorEmptyM
        {
            get
            {
                if (lang == Lang.KO) return "M 영역 크기가 비어있습니다.";
                else if (lang == Lang.EN) return "The size of the M area is empty.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorRangeM
        public static string SymbolErrorRangeM
        {
            get
            {
                if (lang == Lang.KO) return "P 영역 범위는 0 ~ 32768 입니다.";
                else if (lang == Lang.EN) return "The range of the P area is 0 to 32768.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorEmptyT
        public static string SymbolErrorEmptyT
        {
            get
            {
                if (lang == Lang.KO) return "T 영역 크기가 비어있습니다.";
                else if (lang == Lang.EN) return "The size of the T area is empty.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorRangeT
        public static string SymbolErrorRangeT
        {
            get
            {
                if (lang == Lang.KO) return "T 영역 범위는 0 ~ 32768 입니다.";
                else if (lang == Lang.EN) return "The range of the T area is 0 to 32768.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorEmptyC
        public static string SymbolErrorEmptyC
        {
            get
            {
                if (lang == Lang.KO) return "C 영역 크기가 비어있습니다.";
                else if (lang == Lang.EN) return "The size of the C area is empty.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorRangeC
        public static string SymbolErrorRangeC
        {
            get
            {
                if (lang == Lang.KO) return "C 영역 범위는 0 ~ 32768 입니다.";
                else if (lang == Lang.EN) return "The range of the C area is 0 to 32768.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorEmptyD
        public static string SymbolErrorEmptyD
        {
            get
            {
                if (lang == Lang.KO) return "D 영역 크기가 비어있습니다.";
                else if (lang == Lang.EN) return "The size of the D area is empty.";
                else return "";
            }
        }
        #endregion
        #region SymbolErrorRangeD
        public static string SymbolErrorRangeD
        {
            get
            {
                if (lang == Lang.KO) return "D 영역 범위는 0 ~ 32768 입니다.";
                else if (lang == Lang.EN) return "The range of the D area is 0 to 32768.";
                else return "";
            }
        }
        #endregion

        #region LadderErrorIncomplete
        public static string LadderErrorIncomplete
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorIncompleteK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorIncompleteE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorSyntax
        public static string LadderErrorSyntax
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorSyntaxK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorSyntaxE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorAbnormal
        public static string LadderErrorAbnormal
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorAbnormalK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorAbnormalE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorParenthesis
        public static string LadderErrorParenthesis
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorParenthesisK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorParenthesisE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorFunction
        public static string LadderErrorFunction
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorFunctionK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorFunctionE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorEmptyItem
        public static string LadderErrorEmptyItem
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorEmptyItemK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorEmptyItemE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorWrongAddress
        public static string LadderErrorWrongAddress
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorWrongAddressK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorWrongAddressE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorWrongFormula
        public static string LadderErrorWrongFormula
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorWrongFormulaK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorWrongFormulaE;
                else return "";
            }
        }
        #endregion
        #region LadderErrorUnknown
        public static string LadderErrorUnknown
        {
            get
            {
                if (lang == Lang.KO) return LadderTool.LadderErrorUnknownK;
                else if (lang == Lang.EN) return LadderTool.LadderErrorUnknownE;
                else return "";
            }
        }
        #endregion

        #region Error
        public static string Error(string error)
        {
            if (lang == Lang.EN)
            {
                if (error == LadderTool.LadderErrorIncompleteK) return LadderTool.LadderErrorIncompleteE;
                else if (error == LadderTool.LadderErrorSyntaxK) return LadderTool.LadderErrorSyntaxE;
                else if (error == LadderTool.LadderErrorAbnormalK) return LadderTool.LadderErrorAbnormalE;
                else if (error == LadderTool.LadderErrorParenthesisK) return LadderTool.LadderErrorParenthesisE;
                else if (error == LadderTool.LadderErrorFunctionK) return LadderTool.LadderErrorFunctionE;
                else if (error == LadderTool.LadderErrorEmptyItemK) return LadderTool.LadderErrorEmptyItemE;
                else if (error == LadderTool.LadderErrorWrongAddressK) return LadderTool.LadderErrorWrongAddressE;
                else if (error == LadderTool.LadderErrorWrongFormulaK) return LadderTool.LadderErrorWrongFormulaE;
                else if (error == LadderTool.LadderErrorUnknownK) return LadderTool.LadderErrorUnknownE;
                else return error;
            }
            else return error;
        }
        #endregion
        #region Summary
        public static string Summary(string summary)
        {
            if (lang == Lang.EN)
            {
                return summary.Replace(SlaveK, SlaveE);
            }
            else return summary;
        }
        #endregion
    }
}
