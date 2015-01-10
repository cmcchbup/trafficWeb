using System;
using System.Collections.Generic;
using System.Text;

namespace NET.CLY.Model
{	
	[Serializable()]
	public class Login
	{	
			public int Id
			{
				get;
				set;
			}
			public string UserName
			{
				get;
				set;
			}
			public string Password
			{
				get;
				set;
			}
			public string UserType
			{
				get;
				set;
			}
	}
}
