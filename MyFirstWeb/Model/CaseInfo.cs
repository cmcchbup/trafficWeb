using System;
using System.Collections.Generic;
using System.Text;

namespace NET.CLY.Model
{	
	[Serializable()]
	public class CaseInfo
	{	
			public string CaseId
			{
				get;
				set;
			}
			public string CaseLevel
			{
				get;
				set;
			}
			public string CaseSource
			{
				get;
				set;
			}
			public string CaseDescribe
			{
				get;
				set;
			}
	}
}
