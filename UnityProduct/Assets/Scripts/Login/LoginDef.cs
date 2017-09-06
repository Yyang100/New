
public enum LoginViewEvent
{
	LoginEvent,
}

public enum LoginCommandEvent
{
	LoginReqCommand,
	LoginRspCommand,
}

public struct LoginInfo
{
	public string acc;
	public string pw;
	public LoginInfo(string a,string p)
	{
		acc = a;
		pw = p;
	}
}

public struct LoginRsp
{
	public string res;
	public string nickname;
	public string sign;
	public LoginRsp(string res ,string nickname, string sign)
	{
		this.res = res;
		this.nickname = nickname;
		this.sign = sign;
	}
}