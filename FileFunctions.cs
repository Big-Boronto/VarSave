public class FileFunctions
{
	public static void FlagUpdate(string NewValue, int Line)
	{
		string FilePath = Global.Folder + "\\GameData\\Flags.txt";
		string[] FlagData = File.ReadAllLines(FilePath);
		FlagData[Line - 1] = NewValue;
		File.WriteAllLines(FilePath, FlagData);
	}

	public static int FlagRead(int Line)
	{
		Retry:
		string FilePath = Global.Folder + "\\GameData\\Flags.txt";
		var fRAM = File.ReadLines(FilePath).Skip(Line - 1).Take(1).First() + "";
		if (fRAM == "") { FlagReset(Line); goto Retry; }
		int data = Convert.ToInt32(fRAM);
		return data;
	}
	public static double FlagReadDouble(int Line)
	{
	Retry:
		string FilePath = Global.Folder + "\\GameData\\Flags.txt";
		var fRAM = File.ReadLines(FilePath).Skip(Line - 1).Take(1).First() + "";
		if (fRAM == "") { FlagReset(Line); goto Retry; }
		double data = Convert.ToDouble(fRAM);
		return data;
	}
	public static string FlagReadString(int Line)
	{
		Retry:
		string FilePath = Global.Folder + "\\GameData\\Flags.txt";
		string data = File.ReadLines(FilePath).Skip(Line - 1).Take(1).First() + "";
		if (data == "") { FlagReset(Line); goto Retry; }
		return data;
	}

	public static void FlagReset(int Line)
	{
		string  FilePath = Global.Folder + "\\GameData\\FlagDefaults.txt";
		string  data = File.ReadLines(FilePath).Skip(Line - 1).Take(1).First() + "";
		FlagUpdate(data, Line);
	}
}