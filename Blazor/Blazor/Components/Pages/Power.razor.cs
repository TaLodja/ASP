namespace Blazor.Components.Pages
{
	public partial class Power
	{
		double a = 1;
		double n = 0;
		double result = 0;
		double A
		{
			get => a;
			set => a = value == 0 ? 1 : value;
		}
		void Calculate()
		{
			result = 0;
			result = Math.Pow(a, n);
		}
	}
}
