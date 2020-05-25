using System.Text;

namespace CineManager.Util
{
    public static class FuncaoSweetAlert
    {
        public static string RetornarMsgAlertaComJS(string pMsg)
        {
            StringBuilder js = new StringBuilder();
            js.Append(@"<script type=""text/javascript"">");
            js.Append(@"$(document).ready(function(){");
            js.Append(@"Swal.Fire(""Atenção!"", """);
            js.Append(pMsg);
            js.Append(@" "", ""warning"");");
            js.Append(@"});");
            js.Append(@"</script>");

            return js.ToString();
        }

        public static string RetornarMsgSucessoComJS(string pMsg)
        {
            StringBuilder js = new StringBuilder();
            js.Append(@"<script type=""text/javascript"">");
            js.Append(@"$(document).ready(function(){");
            js.Append(@"swal("""",""");
            js.Append(pMsg);
            js.Append(@" "", ""success"");");
            js.Append(@"});");
            js.Append(@"</script>");

            return js.ToString();
        }

        public static string RetornarMsgErroComJS(string pMsg)
        {
            StringBuilder js = new StringBuilder();
            js.Append(@"<script type=""text/javascript"">");
            js.Append(@"$(document).ready(function(){");
            js.Append(@"swal(""Atenção!"", """);
            js.Append(pMsg);
            js.Append(@" "", ""error"");");
            js.Append(@"});");
            js.Append(@"</script>");

            return js.ToString();
        }
    }
}