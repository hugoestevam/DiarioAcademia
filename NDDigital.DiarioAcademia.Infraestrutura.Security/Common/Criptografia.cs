using Chilkat;
using System;
using System.Security;
using System.Text;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Common
{
    public class Criptografia
    {
        private static readonly string ChaveSenha = ".F==Q9E2*NRF,OP24QP<E2QH-QUEI8+E=2<N-N0R@UR76B?43ER9-M0=UHCL63AV3TT1-*CL-0O6.2OF2:*TB.:,S7;0V5>@84OF86>EK=5B1JU-U>DQED<-9B117;L6BETA>369KT/41,RJ:IHDCN3@931<BVQD@.SAFVEII6E:2*LDI9+L=8VMUH+Q728P2;=ME+63O8H;@.8JP-;N+D1MTE8BD5V*T,I8P0V/DNK;FD6>7/<2VCL?Q:A04F0;G4T>,K:SJKEH0IM1PIHC0I=8,3I2OG9A64..3EC1@I<@,L+61ABGB,,QGHN28*O44B,L2:RMPC0.<@OO-+O91/N-=4PR509.QOM=-Q-DQGJS>2VGS-HO*0C/CBBT.23BI;M9RRKM8?CS?BJLR+TV5?49JF?*P=*4U,CD+?B2S*D:K44L4;DJ*845P=QL=GN?+NDF5G:-:AA5T.2N+U=JD9H2NI>N+B2-?GB/=85,B<-F*<-1AK@HLSID2,FG+B0;";
        private static readonly string ChaveSenhaOLD = ".F=4QP<E2QH-76B?43ER9-M=Q9E2*NRF,O@UR0=UHC1-L63AV3TT*CL-0O6P2QUEI8+E=2<N-N0R.*TB.:,S0V5>@84OF827;OF2:6>EK=5B1JU-U>DQED<-9B117;L6B2*LDIKT/41,RJ:E+63O8H;@.8JP-;N+D1M9+L=8ETA>369IHDCN3@931<BVQD@.SAFVEII6E:VMUH+Q728P2;=MTE8BD5V*T,3I2OG9A64..3EI8P0V/DNKPIHC0I=8,C1@I<@,L?Q:A04F0;G4T;FD6>7/<2VCIM1>,K:SJKEH0L+61ABGB,,QGHN28*O44BPC0.<@OO-+O91/N-=4PR509.QOM=-Q-DQRRKM8?CS?B2NI>N+,L2:RMB2-JLR+GJS>2VGS-HO*0C/CBBT.23BI;M9TV5?49JF5T.2N+U=JDK44?*P=*4U,CD+?B2S*D:G:-:AAL4;DJ*84F*<-1AK@HLSI5P=QL=GN?+NDF59H?GB/=85,B<-D2,FG+B0;";
        private static readonly string ChaveSenhaVerificacao = "ArfgREtfBNNvertrGH56778ghFGd38hnsdeDrefuyKkjgVSssx3SDfbF";

        public static string DescompactaString(string texto)
        {
            Gzip gzip = new Gzip();
            gzip.UnlockComponent("SEllevoZIP_rZJqzM4pky1a");
            return gzip.InflateStringENC(texto, "iso-8859-1", "hex");
        }

        private static string CriptografiaRC4(string texto, string password)
        {
            int index1 = 0;
            int index2 = 0;
            string str = "";
            int[] numArray1 = new int[256];
            int[] numArray2 = new int[256];
            int length = password.Length;
            for (int index3 = 0; index3 <= (int)byte.MaxValue; ++index3)
            {
                numArray2[index3] = Convert.ToInt32(Convert.ToChar(password.Substring(index3 % length, 1)));
                numArray1[index3] = index3;
            }
            int index4 = 0;
            for (int index3 = 0; index3 <= (int)byte.MaxValue; ++index3)
            {
                index4 = (index4 + numArray1[index3] + numArray2[index3]) % 256;
                int num = numArray1[index3];
                numArray1[index3] = numArray1[index4];
                numArray1[index4] = num;
            }
            for (int index3 = 1; index3 <= texto.Length; ++index3)
            {
                index1 = (index1 + 1) % 256;
                index2 = (index2 + numArray1[index1]) % 256;
                int num1 = numArray1[index1];
                numArray1[index1] = numArray1[index2];
                numArray1[index2] = num1;
                int num2 = numArray1[(numArray1[index1] + numArray1[index2]) % 256];
                byte num3 = (byte)(Convert.ToInt32(Convert.ToChar(texto.Substring(index3 - 1, 1))) ^ num2);
                if ((int)num3 == 0)
                    num3 = (byte)num2;
                str += ((char)num3).ToString();
            }
            return str;
        }

        public static string Base64Encode(string valor)
        {
            return Convert.ToBase64String(Encoding.GetEncoding("iso-8859-1").GetBytes(valor));
        }

        public static string Base64Decode(string valor)
        {
            return Encoding.GetEncoding("iso-8859-1").GetString(Convert.FromBase64String(valor));
        }

        public static string Criptografar(string senha)
        {
            return Criptografia.Criptografar(senha, Criptografia.ModoSimples.Padrao, "");
        }

        public static string Criptografar(string senha, Criptografia.ModoSimples tipo)
        {
            return Criptografia.Criptografar(senha, tipo, "");
        }

        public static string Criptografar(string senha, string ChavePersonalizada)
        {
            return Criptografia.Criptografar(senha, Criptografia.ModoSimples.Personalizado, ChavePersonalizada);
        }

        private static string Criptografar(string senha, Criptografia.ModoSimples tipo, string ChavePersonalizada)
        {
            string valor = string.Empty;
            senha = senha.Trim();
            if (!string.IsNullOrEmpty(senha))
            {
                if ("".Equals((object)tipo))
                    tipo = Criptografia.ModoSimples.Padrao;
                valor = Criptografia.CriptografiaRC4(senha, tipo == Criptografia.ModoSimples.Padrao ? Criptografia.ChaveSenha : (tipo == Criptografia.ModoSimples.Antigo ? Criptografia.ChaveSenhaOLD : (tipo == Criptografia.ModoSimples.Verificacao ? Criptografia.ChaveSenhaVerificacao : ChavePersonalizada)));
                if (Criptografia.ModoSimples.Padrao.Equals((object)tipo) || Criptografia.ModoSimples.Verificacao.Equals((object)tipo))
                    valor = Criptografia.Base64Encode(valor);
            }
            return valor;
        }

        public static string Criptografar(string senha, Criptografia.ModoAvancado tipo)
        {
            string str = string.Empty;
            senha = senha.Trim();
            if (!string.IsNullOrEmpty(senha))
            {
                Crypt2 crypt2 = new Crypt2();
                crypt2.UnlockComponent("SEllevoCrypt_XHkm5VchVRk9");
                crypt2.EncodingMode = ("hex");
                crypt2.HashAlgorithm = (tipo.ToString());
                str = crypt2.HashStringENC(senha);
            }
            return str;
        }

        public static string Descriptografar(string senha)
        {
            return Criptografia.Descriptografar(senha, Criptografia.ModoSimples.Padrao);
        }

        public static string Descriptografar(string senha, Criptografia.ModoSimples tipo)
        {
            return Criptografia.Descriptografar(senha, tipo, "");
        }

        public static string Descriptografar(string senha, string ChavePersonalizada)
        {
            return Criptografia.Descriptografar(senha, Criptografia.ModoSimples.Personalizado, ChavePersonalizada);
        }

        private static string Descriptografar(string senha, Criptografia.ModoSimples tipo, string ChavePersonalizada)
        {
            if (!string.IsNullOrEmpty(senha) && !"".Equals(senha.Trim()))
            {
                senha = senha.Trim();
                if ("".Equals((object)tipo))
                    tipo = Criptografia.ModoSimples.Padrao;
                if (Criptografia.ModoSimples.Antigo != tipo)
                    senha = Criptografia.Base64Decode(senha);
                senha = Criptografia.CriptografiaRC4(senha, tipo == Criptografia.ModoSimples.Padrao ? Criptografia.ChaveSenha : (tipo == Criptografia.ModoSimples.Antigo ? Criptografia.ChaveSenhaOLD : (tipo == Criptografia.ModoSimples.Verificacao ? Criptografia.ChaveSenhaVerificacao : ChavePersonalizada)));
            }
            return senha;
        }

        public static SecureString CriaSecureString(string senha)
        {
            SecureString secureString = new SecureString();
            foreach (char c in senha.ToCharArray())
                secureString.AppendChar(c);
            return secureString;
        }

        public enum ModoAutenticacao
        {
            Simples,
            Avancado,
        }

        public enum ModoSimples
        {
            Padrao,
            Antigo,
            Verificacao,
            Personalizado,
        }

        public enum ModoAvancado
        {
            SHA1,
            SHA256,
            SHA384,
            SHA512,
            MD2,
            MD5,
        }
    }
}