namespace Asp.netCore_Palma_RealState.Extention
{
    public static class PriceConverter
    {
        public static string ToToman(this int value) => value.ToString("#,0 تومان");
        public static string ToToman(this double value) => value.ToString("#,0 تومان");
    }
}
