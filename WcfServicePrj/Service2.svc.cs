using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServicePrj {
	// 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service2"。
	// 注意: 若要啟動 WCF 測試用戶端以便測試此服務，請在 [方案總管] 中選取 Service2.svc 或 Service2.svc.cs，然後開始偵錯。
	// 對應IService2.cs
	// 使用 工具\WcfTestClient 進行測試 參考:https://dotblogs.com.tw/hatelove/archive/2011/12/08/how-to-invoke-wcf-service-to-verify-input-output.aspx
	public class Service2 : IService2 {
		public string DoWork() {
			return "Hello! The World!";
		}
	}
}
