using System.Numerics;

namespace Blazor.Components.Pages
{
	public partial class Fibonacci
	{
		int n = 0;
		BigInteger[] fib = { };
		int N
		{
			get => n;
			set => n = value < 0 ? 0 : value;
		}
		void OutputFibonacci()
		{
			fib = new BigInteger[n];
			for (int i = 0; i < n; i++)
			{
				fib[i] = i == 0 ? 1 : i == 1 ? 1 : fib[i - 1] + fib[i - 2];
			}
		}
	}
}
