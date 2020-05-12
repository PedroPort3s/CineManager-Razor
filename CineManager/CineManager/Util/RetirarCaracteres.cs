namespace CineManager.Util
{
    public class RetirarCaracteres
    {

        public static string RetirarMascara(string pTexto)
        {
            pTexto = pTexto.Replace(".", "");
            pTexto = pTexto.Replace("-", "");
            pTexto = pTexto.Replace("(", "");
            pTexto = pTexto.Replace(")", "");
            return pTexto;
        }
    }
}
