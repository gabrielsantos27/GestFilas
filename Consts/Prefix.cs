namespace ProjetoBacharelatoFilas.Consts
{
    public static class Prefix
    {
        public const string TB = "TB_";
    }
    public static class Extension
    {
        public static string ManipularHora(this DateTime data)
        =>$"{data.Hour}h:{data.Minute}min - {data.ToShortDateString()}";
    }
}
