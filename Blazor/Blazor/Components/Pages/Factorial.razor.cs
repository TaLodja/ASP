using System.Numerics;

namespace Blazor.Components.Pages
{
	public partial class Factorial		//partial - класс размещен в нескольких файлах
	{
		int n = 0;  //RAII - Resource Aquisition is Initialization
					//		(Выделение ресурсов - это Инициализация)
		BigInteger f = 1;
		int N
		{
			get => n;
			set => n = value < 0 ? 0 : value;
		}
		void Calculate()
		{
			f = 1;
			for (int i = 1; i <= n; i++)
			{
				f *= i;
			}
		}
	}
}
